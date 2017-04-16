#r "System.dll"
#r "../../lib/Microsoft.SqlServer.TransactSql.ScriptDom.dll"

// Warning: Bad code

open System
open System.Reflection
open System.Collections.Generic
open Microsoft.SqlServer.TransactSql

type TypeHier =
  { typ: Type
    children: Map<string, TypeHier> }

let typeHasChildren     = Dictionary<Type, bool>(8000)
let propReferencedTypes = HashSet<Type>()
let topLevelTypes       = HashSet<Type>()
let missingCases        = HashSet<Type>()

let doesTypeHaveChildren (typ:Type) = 
  typeHasChildren.ContainsKey(typ) && typeHasChildren.[typ]

let objTp = typeof<System.Object>
let startTp = typeof<ScriptDom.TSqlFragment>

let typesUntilStart (typ: Type) =
  let rec impl (ts: Type list) (typ:Type) =
    if typ = objTp then []
    elif typ = startTp then
      ts
    else
      match typ.BaseType with 
      | null -> 
        printfn "Found Null base for %A" typ 
        [] 
      | x -> impl (typ::ts) x
  impl [] typ 

let rec addRec (acc: TypeHier) (typs: Type list) =
  match typs with
  | [] -> acc
  | tp::typs ->
    let k = tp.Name //tp.FullName
    match Map.tryFind k acc.children with
    | Some(child) ->
      { acc with children = Map.add k (addRec child typs)  acc.children }
    | None ->
      let child = { typ = tp; children = Map.empty }
      let updChild = addRec child typs
      { acc with children = Map.add k updChild acc.children }

let addType (acc: TypeHier) (typ: Type) =
  addRec acc (typesUntilStart typ)

let listTypes() =
  let asm = Assembly.GetAssembly(startTp)
  let hier = { typ = startTp; children = Map.empty }
  Array.fold addType hier (asm.GetTypes())

let typeProps (typ:Type) =
  [| for m in typ.GetProperties() do
      if m.PropertyType.IsGenericType then
        
        let itemType = m.PropertyType.GetGenericArguments().[0].Name
        yield m.Name, (sprintf "%s<%s>" (m.PropertyType.Name) itemType) 
      else
        yield m.Name, m.PropertyType.Name |]

let getProps =
  let startProps = startTp.GetProperties() |> Array.map (fun p -> p.Name) |> Set.ofArray  
  fun (typ:Type) ->
    [|for p in typ.GetProperties() do
        if not <| startProps.Contains(p.Name) && p.GetIndexParameters().Length = 0
          then yield p|]
    |> Array.sortBy (fun p -> p.Name)

let typePropsTrim (typ:Type) =
  let propsTop = typeProps startTp |> Set.ofSeq
  Set.difference (typeProps typ |> Set.ofSeq) propsTop

let rec printTree (tree:TypeHier) (sb:Text.StringBuilder) (depth: int) =
  let start = String(' ', depth * 2)
  sb.Append(start) |> ignore
  sb.Append(tree.typ.Name) |> ignore
  for name, propName in (typePropsTrim (tree.typ)) do
    sb.Append(" ") |> ignore
    sb.Append(name) |> ignore
    sb.Append(':') |> ignore
    sb.Append(propName) |> ignore
    sb.Append(" ") |> ignore
  sb.Append("\n") |> ignore
  for (KeyValue(k,v)) in tree.children do
    printTree v sb (depth + 1)

let getDestTypeName (typ:Type) = 
  if typ.IsEnum then "ScriptDom." + typ.Name
  else
    match typ.Name with 
    | "Boolean" -> "bool"
    | x ->
      if missingCases.Contains(typ) then
        typ.Name //+ "." + typ.Name
      else
        if doesTypeHaveChildren typ then
          typ.Name
        elif propReferencedTypes.Contains(typ) then
          typ.Name
        else
          match typ.Namespace with
          | "Microsoft.SqlServer.TransactSql.Scriptdom" ->
            failwith "Unhandled!"
          | _ -> typ.Name
          //typ.BaseType.Name + "." + typ.Name

let getTypeDep (typ:Type) =
  let ofTyp (typ:Type) =
    match typ.Namespace with
    | "Microsoft.SqlServer.TransactSql.ScriptDom" -> Some(typ)
    | _ -> None 

  if typ.IsGenericType then
    let genTp = typ.GetGenericTypeDefinition()
    match typ.GetGenericArguments() with
    | [|gentypA|] -> ofTyp gentypA
    | x -> failwithf "Unhandled gen arguments ary: %A" x
  else
    ofTyp typ 

let getDestPropName (typ:Type) =
  if typ.IsGenericType then
    let genTp = typ.GetGenericTypeDefinition()
    match typ.GetGenericArguments() with
    | [|gentypA|] ->
      let cleanName = typ.Name.Substring(0, (typ.Name.Length - 2))
      match cleanName with
      | "IList" ->
        sprintf "(%s) list" (getDestTypeName gentypA)
      | "Nullable" ->
        sprintf "(%s) option" (getDestTypeName gentypA)
      | _ -> sprintf "%s<%s>" cleanName (gentypA.Name)
    | x -> failwithf "Unhandled gen arguments ary: %A" x
  elif not <| typ.IsGenericType then
    if typ.IsEnum || typ.IsValueType then getDestTypeName (typ)
    else sprintf "%s option" (getDestTypeName typ)
  else
    failwithf "Can't handle type %A" (typ)

let rec getMapping (typ:Type) =
  match typ.Namespace with
  | "Microsoft.SqlServer.TransactSql.ScriptDom" ->
    if typ.IsEnum then "(* dont do nthing *)"
    else
      let baseName, tname =
        if missingCases.Contains(typ) then
          typ.Name, typ.Name
        else typ.BaseType.Name, typ.Name
      if doesTypeHaveChildren typ then
        sprintf "|> Seq.map (%s.FromTs) " (typ.Name)
      else
        match getProps typ with
        | [||] ->
          sprintf "|> Seq.map (%s.%s) " baseName tname
        | props ->
          let pms = 
            props
            |> Array.map getPropertyAccess
            |> String.concat ", "
          sprintf "|> Seq.map (fun src -> %s.%s(%s)) " baseName tname pms
  | _ -> sprintf "(* Is mapping needed? %s *)" typ.Namespace

and getPropertyAccess (prop:PropertyInfo) =
  if prop.PropertyType.IsGenericType then
    let genTp = prop.PropertyType.GetGenericTypeDefinition()
    match prop.PropertyType.GetGenericArguments() with
    | [|gentypA|] ->
      let cleanName = prop.PropertyType.Name.Substring(0, (prop.PropertyType.Name.Length - 2))
      match cleanName with
      | "IList" ->
        sprintf "(src.%s %s|> List.ofSeq)" prop.Name (getMapping gentypA)
      | "Nullable" ->
        sprintf "(Option.ofNullable (src.%s))" prop.Name
      | _ -> sprintf "%s<%s>" cleanName (gentypA.Name)
    | x -> failwithf "Unhandled gen arguments ary: %A" x
  else
    let typ = prop.PropertyType
    let baseName, tname =
      if missingCases.Contains(typ) then
        typ.Name, typ.Name
      else typ.BaseType.Name, typ.Name
    match prop.PropertyType.Namespace with
    | "Microsoft.SqlServer.TransactSql.ScriptDom" when not prop.PropertyType.IsEnum && not prop.PropertyType.IsValueType ->
      if doesTypeHaveChildren (prop.PropertyType) then
        sprintf "(src.%s |> Option.ofObj |> Option.map (%s.FromTs))" (prop.Name) tname
      else
        sprintf "(src.%s |> Option.ofObj |> Option.map (%s.FromTs))" (prop.Name) baseName
    | _ ->
      if prop.PropertyType.IsValueType then
        sprintf "(src.%s)" (prop.Name)
      else
         sprintf "(Option.ofObj (src.%s))" (prop.Name)

let printDUs (tree:TypeHier) (sb:Text.StringBuilder) =
  let cont (s:string) = sb.Append(s) |> ignore
  let w fmtstr = Printf.kprintf cont fmtstr
  
  let q = Queue()
  let written = HashSet()
  let mutable duNum = 0

  q.Enqueue(tree)

  while q.Count > 0 do
    let tree = q.Dequeue()
    
    if duNum = 0 then w "type " else w "and "
    
    w "[<RequireQualifiedAccess>] %s = \n" (tree.typ.Name)

    let ctyps = 
      [| for (KeyValue(k,v)) in tree.children do yield v|]
      |> Array.sortBy (fun t -> t.typ.Name)

    let renderDUcase (typ:Type) (asName: string option) =
      let tname = if asName.IsSome then asName.Value else typ.Name
      match getProps typ with
      | [||] ->
        w "  | %s " tname
      | props ->
        w "  | %s of " tname

        for i in [0..props.Length - 1] do
          let prop = props.[i]
          w "%s:%s" (prop.Name) (getDestPropName prop.PropertyType)
          if i <> props.Length - 1 then w " * "

    if ctyps.Length > 0 then    
      if not <| tree.typ.IsAbstract then
        renderDUcase (tree.typ) (Some("Base"))
        w "\n"
        
      for ctyp in ctyps do
        if ctyp.children.Count > 0 then
          //w "// %s has %d children, rendering: \n" (ctyp.typ.Name) (ctyp.children.Count)
          //w "(* %A *)\n" ctyp
          w "  | %s of %s" (ctyp.typ.Name) (ctyp.typ.Name)
        else
          // w "// No children, rendering props\n"
          renderDUcase ctyp.typ None
      
        w "\n"
      let renderProps (thier:TypeHier) (asBase:bool) =
        if not asBase && thier.children.Count > 0 then
            w "((%s.FromTs(src)))" thier.typ.Name
            //w "((%s.%s.FromTs(src))))) (* %s *)\n" thier.typ.BaseType.Name cctyp.typ.Name __LINE__
          else
            match getProps thier.typ with
            | [||] -> w ""
            | props ->
              w "("
              for i in [0..props.Length - 1] do
                let prop = props.[i]
                w "%s" (getPropertyAccess prop)
                if i <> props.Length - 1 then w ", "
              w ")" 
      w "  static member FromTs(src:ScriptDom.%s) : %s =\n" (tree.typ.Name) (tree.typ.Name)
      w "    match src with\n"
      for ctyp in ctyps do
        w "    | :? ScriptDom.%s as src ->\n" ctyp.typ.Name
        if ctyp.children.Count > 0 then
          w "      match src with\n"
          let cctyps =
            [| for (KeyValue(k,v)) in ctyp.children do yield v|]
            |> Array.sortBy (fun t -> t.typ.Name)
          
          for cctyp in cctyps do
            w "      | :? ScriptDom.%s as src->\n" cctyp.typ.Name
            w "        %s.%s((%s.%s" tree.typ.Name ctyp.typ.Name ctyp.typ.Name cctyp.typ.Name
            renderProps cctyp false
            w "))\n"

          if not <| ctyp.typ.IsAbstract then
            w "      | _ -> (* :? ScriptDom.%s as src *)\n" ctyp.typ.Name
            w "        %s.%s((%s.Base" tree.typ.Name ctyp.typ.Name ctyp.typ.Name 
            renderProps ctyp true
            w "))\n"
        else
          w "      %s.%s" (tree.typ.Name) (ctyp.typ.Name)
          match getProps (ctyp.typ) with
          | [||] -> w "\n"
          | cprops ->
            w "("
            for i in [0..cprops.Length - 1] do
              let cprop = cprops.[i]
              w "%s" (getPropertyAccess cprop)
              if i <> cprops.Length - 1 then w ", "
            w ")\n"
      if not <| tree.typ.IsAbstract then
        w "    | _ -> (* :? ScriptDom.%s as src *)\n" tree.typ.Name
        w "      %s.Base(" tree.typ.Name
        renderProps tree true
        w ")\n"
    else
      ()
//      let upcastStr = ""
//      renderProps tree.typ
//      w "\n  static member FromTS(src:ScriptDom.%s) : %s =\n" (tree.typ.Name) (tree.typ.Name)
//
//      match getProps tree.typ with
//      | [||] ->
//        w "    %s.%s %s\n"  (tree.typ.Name) (tree.typ.Name) upcastStr
//      | props ->
//        w "    %s.%s(" (tree.typ.Name) (tree.typ.Name)
//
//        for i in [0..props.Length - 1] do
//          let prop = props.[i]
//          w "%s" (getPropertyAccess prop)
//          if i <> props.Length - 1 then w ", "
//        w ")%s\n" upcastStr

    written.Add(tree) |> ignore

    duNum <- duNum + 1
    for (KeyValue(_, subtree)) in tree.children do
      if not <| written.Contains(subtree) && doesTypeHaveChildren (subtree.typ) then 
        q.Enqueue(subtree)
  w "// Rendering missing cases\n"
  for typ in missingCases do
    //if doesTypeHaveChildren typ then failwith "logic error"
    let recordTypesStr = 
      [| for prop in getProps typ do
          yield sprintf "%s:%s" (prop.Name) (getDestPropName prop.PropertyType) |]
      |> String.concat " * "
      |> fun s -> if s <> "" then "of " + s else s
    w "and [<RequireQualifiedAccess>] %s =\n  | %s %s \n" typ.Name typ.Name recordTypesStr
    let upcastStr = ""
    //renderProps tree.typ
    w "  static member FromTs(src:ScriptDom.%s) : %s =\n" (typ.Name) (typ.Name)

    match getProps typ with
    | [||] ->
      w "    %s.%s %s\n"  (typ.Name) (typ.Name) upcastStr
    | props ->
      w "    %s.%s(" (typ.Name) (typ.Name)

      for i in [0..props.Length - 1] do
        let prop = props.[i]
        w "%s" (getPropertyAccess prop)
        if i <> props.Length - 1 then w ", "
      w ")%s\n" upcastStr
  ()

let processTree (tree:TypeHier) =
  let rec impl (tree:TypeHier) (depth: int) =
    let typHasChildren = tree.children.Count > 0
    
    if typHasChildren || false (* depth <= 1 *) then topLevelTypes.Add(tree.typ) |> ignore
    //if depth % 2 = 0 then topLevelTypes.Add(tree.typ) |> ignore
    if tree.typ <> startTp then
      for prop in getProps (tree.typ) do
        match getTypeDep (prop.PropertyType) with
        | Some(typ) -> 
          propReferencedTypes.Add(typ) |> ignore 
        | None -> ()

    typeHasChildren.[tree.typ] <- typHasChildren
    for (KeyValue(_, c)) in tree.children do impl c (depth + 1)
  impl tree 0

  for typ in propReferencedTypes do
    if not <| topLevelTypes.Contains(typ) then
      missingCases.Add(typ) |> ignore

let buildLib() = 
  let tree = listTypes()
  processTree tree
  let sb = Text.StringBuilder()
  let _ = sb.AppendLine "module FsSqlDom\n"
  let _ = sb.AppendLine "open System"
  let _ = sb.AppendLine "open Microsoft.SqlServer.TransactSql\n"

  printDUs tree sb
  let outPath = IO.Path.Combine(__SOURCE_DIRECTORY__, "../../src/FsSqlDom/FsSqlDom.fs")
  IO.File.WriteAllText(outPath, sb.ToString())

  let treeSb = Text.StringBuilder()
  printTree tree treeSb 0
  //IO.File.WriteAllText(@"C:\Users\isak\Desktop\tree.txt", treeSb.ToString())

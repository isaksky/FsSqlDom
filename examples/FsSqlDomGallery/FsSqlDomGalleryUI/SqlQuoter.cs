using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FsSqlDomGalleryUI {
    public class SqlQuoter {
        static HashSet<string> SkipPropNames = new HashSet<string> {
            "FirstTokenIndex",
            "LastTokenIndex",
            "ScriptTokenStream"
        };

        static HashSet<string> SkipEnumValues = new HashSet<string> {
            "QuoteType.NotQuoted",
            "UniqueRowFilter.NotSpecified",
            "ColumnType.Regular"
        };

        public string Render(TSqlFragment frag) {
            var node = GetCodeNode(frag);
            return RenderNode(node, 0, RenderContext.None);
        }

        CodeNode GetCodeNode(object o) {
            if (o is null) {
                return null;
            }
            var t = o.GetType();
            if (typeof(TSqlFragment).IsAssignableFrom(t)) {
                return GetCodeNode((TSqlFragment)o);
            } else if (TryGetCSharpLiteral(o, out var literal)) {
                return new LiteralNode(null) {
                    Value = literal
                };
            } else if (o is IEnumerable<object> xs) {
                var node = new CollectionNode(null) { };
                foreach (var x in xs) {
                    var c = GetCodeNode(x);
                    node.Values.Add(c);
                }
                if (node.Values.Count == 0) {
                    return null;
                }
                return node;
            } else {
                return null;
            }
        }

        CodeNode GetCodeNode(TSqlFragment frag) {
            if (frag is null) {
                return null;
            }
            var t = frag.GetType();
            var node = new ClassSyntaxNode(frag, t.Name);
            foreach (var p in t.GetProperties()) {
                if (SkipProp(p)) {
                    continue;
                }
                var v = p.GetValue(frag);
                if (v is null) {
                    continue;
                } else if (GetCodeNode(v) is CodeNode n) {
                    node.KeyValuePairs.Add((p.Name, n));
                }
            }
            return node;
        }

        bool SkipProp(PropertyInfo p) {
            if (!p.CanRead
                || (!p.CanWrite && !p.PropertyType.GetInterfaces().Any(it => it.IsGenericType && it.Name == "ICollection`1"))
                || p.GetIndexParameters().Any()) {
                return true;
            }
            if (SkipPropNames.Contains(p.Name)) {
                return true;
            }
            return false;
        }

        [Flags]
        enum RenderContext {
            None = 0,
            SkipOpeningBrace = 1,
            SkipIndent = 2,
            AddTrailingComma = 4
        }

        string RenderNode(CodeNode node, int indent, RenderContext ctx) {
            var rawSpace = new string(' ', indent);
            var sfx = ctx.HasFlag(RenderContext.AddTrailingComma) ? "," : "";
            var space = ctx.HasFlag(RenderContext.SkipIndent) ? "" : rawSpace;
            if (node is LiteralNode ln) {
                return space + ln.Value + sfx;
            } else if (node is ClassSyntaxNode cs) {
                if (cs.KeyValuePairs.Count == 0 && !ctx.HasFlag(RenderContext.SkipOpeningBrace)) {
                    return $"new {cs.ClassName}()";
                }
                var lines = new List<string>();
                if (!ctx.HasFlag(RenderContext.SkipOpeningBrace)) {
                    lines.Add($"{space}new {cs.ClassName} {{");
                }
                var cindent = indent + 4;
                var childCtx = RenderContext.SkipOpeningBrace | RenderContext.AddTrailingComma;
                foreach (var c in cs.KeyValuePairs) {
                    if (c.val is LiteralNode) {
                        lines.Add($"{new string(' ', cindent)}{c.key} = {RenderNode(c.val, cindent + 4, childCtx | RenderContext.SkipIndent)}");
                    } else if (c.val is CollectionNode) {
                        var sb = new StringBuilder();
                        sb.Append($"{new string(' ', cindent)}{c.key} = {{\n");
                        sb.Append(RenderNode(c.val, cindent, childCtx));
                        lines.Add(sb.ToString());
                    } else if (c.val is ClassSyntaxNode childCs) {
                        lines.Add($"{new string(' ', cindent)}{c.key} = new {childCs.ClassName} {{");
                        lines.Add(RenderNode(c.val, cindent, childCtx));
                    } else {
                        throw new NotImplementedException();
                    }
                }
                lines.Add($"{rawSpace}}}{sfx}");
                //lines.Add(rawSpace);
                return string.Join("\n", lines);
            } else if (node is CollectionNode xs) {
                var lines = new List<string>();
                if (!ctx.HasFlag(RenderContext.SkipOpeningBrace)) {
                    lines.Add($"{space}{{");
                }
                var items = new List<string>();
                foreach (var c in xs.Values) {
                    if (c is LiteralNode) {
                        items.Add($"{RenderNode(c, indent + 4, RenderContext.AddTrailingComma)}");
                    } else {
                        items.Add(RenderNode(c, indent + 4, RenderContext.AddTrailingComma));
                    }
                }
                lines.Add(string.Join($"\n", items));
                lines.Add($"}}{sfx}");
                return string.Join($"\n{space}", lines);
            } else {
                throw new NotImplementedException();
            }
        }

        public bool TryGetCSharpLiteral(object x, out string literal) {
            if (x is string s) {
                literal = CSharpStringLiteral(s);
                return true;
            } else if (x is bool b && b) {
                literal = "true"; // False is default and obvious
                return true;
            } else if (x is int i) {
                literal = i.ToString(CultureInfo.InvariantCulture);
                return true;
            } else if (x is long l) {
                literal = l.ToString(CultureInfo.InvariantCulture);
                return true;
            } else {
                var t = x.GetType();
                if (t.IsEnum) {
                    literal = t.Name + "." + x.ToString();
                    if (SkipEnumValues.Contains(literal)) {
                        literal = null;
                        return false;
                    }
                    return true;
                }
            }
            literal = null;
            return false;
        }

        public string CSharpStringLiteral(string s) {
            var sb = new StringBuilder();
            sb.Append("\"");
            foreach (var c in s) {
                if (c == '"') {
                    sb.Append('\\');
                }
                sb.Append(c);
            }
            sb.Append("\"");
            return sb.ToString();
        }
    }

    internal abstract class CodeNode {
        public TSqlFragment Fragment { get; set; }
        public CodeNode(TSqlFragment fragment) {
            //this.Fragment = fragment;
        }
    }

    internal class LiteralNode : CodeNode {
        public string Value { get; set; }
        public LiteralNode(TSqlFragment fragment) : base(fragment) {

        }
    }

    internal class ClassSyntaxNode : CodeNode {
        public string ClassName { get; set; }
        public List<(string key, CodeNode val)> KeyValuePairs { get; } = new List<(string key, CodeNode)>();

        public ClassSyntaxNode(TSqlFragment fragment, string className) : base(fragment) {
            this.ClassName = className;
        }
    }

    internal class CollectionNode : CodeNode {
        public List<CodeNode> Values { get; } = new List<CodeNode>();

        public CollectionNode(TSqlFragment fragment) : base(fragment) { }
    }
}

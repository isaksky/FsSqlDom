module FsSqlDom

open System
open Microsoft.SqlServer.TransactSql

type [<RequireQualifiedAccess>] TSqlFragment = 
  | AdHocDataSource of InitString:StringLiteral option * ProviderName:StringLiteral option
  | AddFileSpec of File:ScalarExpression option * FileName:Literal option
  | AlterAvailabilityGroupAction of AlterAvailabilityGroupAction
  | AlterAvailabilityGroupFailoverOption of OptionKind:ScriptDom.FailoverActionOptionKind * Value:Literal option
  | AlterDatabaseTermination of ImmediateRollback:bool * NoWait:bool * RollbackAfter:Literal option
  | AlterFullTextIndexAction of AlterFullTextIndexAction
  | AlterRoleAction of AlterRoleAction
  | AlterServerConfigurationBufferPoolExtensionOption of AlterServerConfigurationBufferPoolExtensionOption
  | AlterServerConfigurationDiagnosticsLogOption of AlterServerConfigurationDiagnosticsLogOption
  | AlterServerConfigurationFailoverClusterPropertyOption of OptionKind:ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind * OptionValue:OptionValue option
  | AlterServerConfigurationHadrClusterOption of IsLocal:bool * OptionKind:ScriptDom.AlterServerConfigurationHadrClusterOptionKind * OptionValue:OptionValue option
  | AlterServerConfigurationSoftNumaOption of OptionKind:ScriptDom.AlterServerConfigurationSoftNumaOptionKind * OptionValue:OptionValue option
  | AlterTableDropTableElement of DropClusteredConstraintOptions:(DropClusteredConstraintOption) list * IsIfExists:bool * Name:Identifier option * TableElementType:ScriptDom.TableElementType
  | ApplicationRoleOption of OptionKind:ScriptDom.ApplicationRoleOptionKind * Value:IdentifierOrValueExpression option
  | AssemblyName of ClassName:Identifier option * Name:Identifier option
  | AssemblyOption of AssemblyOption
  | AtomicBlockOption of AtomicBlockOption
  | AuditOption of AuditOption
  | AuditSpecificationDetail of AuditSpecificationDetail
  | AuditSpecificationPart of Details:AuditSpecificationDetail option * IsDrop:bool
  | AuditTarget of TargetKind:ScriptDom.AuditTargetKind * TargetOptions:(AuditTargetOption) list
  | AuditTargetOption of AuditTargetOption
  | AvailabilityGroupOption of AvailabilityGroupOption
  | AvailabilityReplica of Options:(AvailabilityReplicaOption) list * ServerName:StringLiteral option
  | AvailabilityReplicaOption of AvailabilityReplicaOption
  | BackupOption of BackupOption
  | BackupRestoreFileInfo of ItemKind:ScriptDom.BackupRestoreItemKind * Items:(ValueExpression) list
  | BooleanExpression of BooleanExpression
  | BoundingBoxParameter of Parameter:ScriptDom.BoundingBoxParameterType * Value:ScalarExpression option
  | BrokerPriorityParameter of IsDefaultOrAny:ScriptDom.BrokerPriorityParameterSpecialType * ParameterType:ScriptDom.BrokerPriorityParameterType * ParameterValue:IdentifierOrValueExpression option
  | BulkInsertOption of BulkInsertOption
  | CallTarget of CallTarget
  | CertificateOption of Kind:ScriptDom.CertificateOptionKinds * Value:Literal option
  | ChangeTrackingOptionDetail of ChangeTrackingOptionDetail
  | ColumnDefinitionBase of ColumnDefinitionBase
  | ColumnEncryptionDefinition of Parameters:(ColumnEncryptionDefinitionParameter) list
  | ColumnEncryptionDefinitionParameter of ColumnEncryptionDefinitionParameter
  | ColumnEncryptionKeyValue of Parameters:(ColumnEncryptionKeyValueParameter) list
  | ColumnEncryptionKeyValueParameter of ColumnEncryptionKeyValueParameter
  | ColumnMasterKeyParameter of ColumnMasterKeyParameter
  | ColumnStorageOptions of IsFileStream:bool * SparseOption:ScriptDom.SparseColumnOption
  | ColumnWithSortOrder of Column:ColumnReferenceExpression option * SortOrder:ScriptDom.SortOrder
  | CommonTableExpression of Columns:(Identifier) list * ExpressionName:Identifier option * QueryExpression:QueryExpression option
  | CompressionPartitionRange of From:ScalarExpression option * To:ScalarExpression option
  | ComputeClause of ByExpressions:(ScalarExpression) list * ComputeFunctions:(ComputeFunction) list
  | ComputeFunction of ComputeFunctionType:ScriptDom.ComputeFunctionType * Expression:ScalarExpression option
  | ConstraintDefinition of ConstraintDefinition
  | ContractMessage of Name:Identifier option * SentBy:ScriptDom.MessageSender
  | CreateLoginSource of CreateLoginSource
  | CryptoMechanism of CryptoMechanismType:ScriptDom.CryptoMechanismType * Identifier:Identifier option * PasswordOrSignature:Literal option
  | CursorDefinition of Options:(CursorOption) list * Select:SelectStatement option
  | CursorId of IsGlobal:bool * Name:IdentifierOrValueExpression option
  | CursorOption of OptionKind:ScriptDom.CursorOptionKind
  | DataModificationSpecification of DataModificationSpecification
  | DataTypeReference of DataTypeReference
  | DatabaseAuditAction of ActionKind:ScriptDom.DatabaseAuditActionKind
  | DatabaseConfigurationClearOption of OptionKind:ScriptDom.DatabaseConfigClearOptionKind
  | DatabaseConfigurationSetOption of DatabaseConfigurationSetOption
  | DatabaseOption of DatabaseOption
  | DbccNamedLiteral of Name:String option * Value:ScalarExpression option
  | DbccOption of OptionKind:ScriptDom.DbccOptionKind
  | DeclareTableVariableBody of AsDefined:bool * Definition:TableDefinition option * VariableName:Identifier option
  | DeclareVariableElement of DeclareVariableElement
  | DeviceInfo of DeviceType:ScriptDom.DeviceType * LogicalDevice:IdentifierOrValueExpression option * PhysicalDevice:ValueExpression option
  | DialogOption of DialogOption
  | DiskStatementOption of OptionKind:ScriptDom.DiskStatementOptionKind * Value:IdentifierOrValueExpression option
  | DropClusteredConstraintOption of DropClusteredConstraintOption
  | DropIndexClauseBase of DropIndexClauseBase
  | EncryptionSource of EncryptionSource
  | EndpointAffinity of Kind:ScriptDom.AffinityKind * Value:Literal option
  | EndpointProtocolOption of EndpointProtocolOption
  | EventDeclaration of EventDeclarationActionParameters:(EventSessionObjectName) list * EventDeclarationPredicateParameter:BooleanExpression option * EventDeclarationSetParameters:(EventDeclarationSetParameter) list * ObjectName:EventSessionObjectName option
  | EventDeclarationSetParameter of EventField:Identifier option * EventValue:ScalarExpression option
  | EventNotificationObjectScope of QueueName:SchemaObjectName option * Target:ScriptDom.EventNotificationTarget
  | EventSessionObjectName of MultiPartIdentifier:MultiPartIdentifier option
  | EventTypeGroupContainer of EventTypeGroupContainer
  | ExecutableEntity of ExecutableEntity
  | ExecuteAsClause of ExecuteAsOption:ScriptDom.ExecuteAsOption * Literal:Literal option
  | ExecuteContext of Kind:ScriptDom.ExecuteAsOption * Principal:ScalarExpression option
  | ExecuteOption of ExecuteOption
  | ExecuteParameter of IsOutput:bool * ParameterValue:ScalarExpression option * Variable:VariableReference option
  | ExecuteSpecification of ExecutableEntity:ExecutableEntity option * ExecuteContext:ExecuteContext option * LinkedServer:Identifier option * Variable:VariableReference option
  | ExpressionWithSortOrder of Expression:ScalarExpression option * SortOrder:ScriptDom.SortOrder
  | ExternalDataSourceOption of ExternalDataSourceOption
  | ExternalFileFormatOption of ExternalFileFormatOption
  | ExternalResourcePoolAffinitySpecification of AffinityType:ScriptDom.ExternalResourcePoolAffinityType * IsAuto:bool * ParameterValue:Literal option * PoolAffinityRanges:(LiteralRange) list
  | ExternalResourcePoolParameter of AffinitySpecification:ExternalResourcePoolAffinitySpecification option * ParameterType:ScriptDom.ExternalResourcePoolParameterType * ParameterValue:Literal option
  | ExternalTableColumnDefinition of ColumnDefinition:ColumnDefinitionBase option * NullableConstraint:NullableConstraintDefinition option
  | ExternalTableDistributionPolicy of ExternalTableDistributionPolicy
  | ExternalTableOption of ExternalTableOption
  | FederationScheme of ColumnName:Identifier option * DistributionName:Identifier option
  | FetchType of Orientation:ScriptDom.FetchOrientation * RowOffset:ScalarExpression option
  | FileDeclaration of IsPrimary:bool * Options:(FileDeclarationOption) list
  | FileDeclarationOption of FileDeclarationOption
  | FileGroupDefinition of ContainsFileStream:bool * ContainsMemoryOptimizedData:bool * FileDeclarations:(FileDeclaration) list * IsDefault:bool * Name:Identifier option
  | FileGroupOrPartitionScheme of Name:IdentifierOrValueExpression option * PartitionSchemeColumns:(Identifier) list
  | ForClause of ForClause
  | FromClause of TableReferences:(TableReference) list
  | FullTextCatalogAndFileGroup of CatalogName:Identifier option * FileGroupIsFirst:bool * FileGroupName:Identifier option
  | FullTextCatalogOption of FullTextCatalogOption
  | FullTextIndexColumn of LanguageTerm:IdentifierOrValueExpression option * Name:Identifier option * StatisticalSemantics:bool * TypeColumn:Identifier option
  | FullTextIndexOption of FullTextIndexOption
  | FullTextStopListAction of IsAdd:bool * IsAll:bool * LanguageTerm:IdentifierOrValueExpression option * StopWord:Literal option
  | FunctionOption of FunctionOption
  | FunctionReturnType of FunctionReturnType
  | GridParameter of Parameter:ScriptDom.GridParameterType * Value:ScriptDom.ImportanceParameterType
  | GroupByClause of All:bool * GroupByOption:ScriptDom.GroupByOption * GroupingSpecifications:(GroupingSpecification) list
  | GroupingSpecification of GroupingSpecification
  | HavingClause of SearchCondition:BooleanExpression option
  | IPv4 of OctetFour:Literal option * OctetOne:Literal option * OctetThree:Literal option * OctetTwo:Literal option
  | Identifier of Identifier
  | IdentifierOrValueExpression of Identifier:Identifier option * Value:String option * ValueExpression:ValueExpression option
  | IdentityOptions of IdentityIncrement:ScalarExpression option * IdentitySeed:ScalarExpression option * IsIdentityNotForReplication:bool
  | IndexOption of IndexOption
  | IndexType of IndexTypeKind:(ScriptDom.IndexTypeKind) option
  | InsertBulkColumnDefinition of Column:ColumnDefinitionBase option * NullNotNull:ScriptDom.NullNotNull
  | InsertSource of InsertSource
  | KeyOption of KeyOption
  | LiteralRange of LiteralRange
  | LowPriorityLockWaitOption of LowPriorityLockWaitOption
  | MergeAction of MergeAction
  | MergeActionClause of Action:MergeAction option * Condition:ScriptDom.MergeCondition * SearchCondition:BooleanExpression option
  | MethodSpecifier of AssemblyName:Identifier option * ClassName:Identifier option * MethodName:Identifier option
  | MirrorToClause of Devices:(DeviceInfo) list
  | MultiPartIdentifier of MultiPartIdentifier
  | OffsetClause of FetchExpression:ScalarExpression option * OffsetExpression:ScalarExpression option
  | OnlineIndexLowPriorityLockWaitOption of Options:(LowPriorityLockWaitOption) list
  | OptimizerHint of OptimizerHint
  | OptionValue of OptionValue
  | OrderByClause of OrderByElements:(ExpressionWithSortOrder) list
  | OutputClause of SelectColumns:(SelectElement) list
  | OutputIntoClause of IntoTable:TableReference option * IntoTableColumns:(ColumnReferenceExpression) list * SelectColumns:(SelectElement) list
  | OverClause of OrderByClause:OrderByClause option * Partitions:(ScalarExpression) list * WindowFrameClause:WindowFrameClause option
  | PartitionParameterType of Collation:Identifier option * DataType:DataTypeReference option
  | PartitionSpecifier of All:bool * Number:ScalarExpression option
  | PayloadOption of PayloadOption
  | Permission of Columns:(Identifier) list * Identifiers:(Identifier) list
  | PrincipalOption of PrincipalOption
  | Privilege80 of Columns:(Identifier) list * PrivilegeType80:ScriptDom.PrivilegeType80
  | ProcedureOption of ProcedureOption
  | ProcedureReference of Name:SchemaObjectName option * Number:Literal option
  | ProcedureReferenceName of ProcedureReference:ProcedureReference option * ProcedureVariable:VariableReference option
  | QueryExpression of QueryExpression
  | QueryStoreOption of QueryStoreOption
  | QueueOption of QueueOption
  | RemoteDataArchiveDatabaseSetting of RemoteDataArchiveDatabaseSetting
  | RemoteServiceBindingOption of RemoteServiceBindingOption
  | ResourcePoolAffinitySpecification of AffinityType:ScriptDom.ResourcePoolAffinityType * IsAuto:bool * ParameterValue:Literal option * PoolAffinityRanges:(LiteralRange) list
  | ResourcePoolParameter of AffinitySpecification:ResourcePoolAffinitySpecification option * ParameterType:ScriptDom.ResourcePoolParameterType * ParameterValue:Literal option
  | RestoreOption of RestoreOption
  | ResultColumnDefinition of ColumnDefinition:ColumnDefinitionBase option * Nullable:NullableConstraintDefinition option
  | ResultSetDefinition of ResultSetDefinition
  | RouteOption of Literal:Literal option * OptionKind:ScriptDom.RouteOptionKind
  | RowValue of ColumnValues:(ScalarExpression) list
  | ScalarExpression of ScalarExpression
  | SchemaDeclarationItem of SchemaDeclarationItem
  | SchemaObjectNameOrValueExpression of SchemaObjectName:SchemaObjectName option * ValueExpression:ValueExpression option
  | SearchPropertyListAction of SearchPropertyListAction
  | SecurityElement80 of SecurityElement80
  | SecurityPolicyOption of OptionKind:ScriptDom.SecurityPolicyOptionKind * OptionState:ScriptDom.OptionState
  | SecurityPredicateAction of ActionType:ScriptDom.SecurityPredicateActionType * FunctionCall:FunctionCall option * SecurityPredicateOperation:ScriptDom.SecurityPredicateOperation * SecurityPredicateType:ScriptDom.SecurityPredicateType * TargetObjectName:SchemaObjectName option
  | SecurityPrincipal of Identifier:Identifier option * PrincipalType:ScriptDom.PrincipalType
  | SecurityTargetObject of Columns:(Identifier) list * ObjectKind:ScriptDom.SecurityObjectKind * ObjectName:SecurityTargetObjectName option
  | SecurityTargetObjectName of MultiPartIdentifier:MultiPartIdentifier option
  | SecurityUserClause80 of UserType80:ScriptDom.UserType80 * Users:(Identifier) list
  | SelectElement of SelectElement
  | SelectiveXmlIndexPromotedPath of IsSingleton:bool * MaxLength:IntegerLiteral option * Name:Identifier option * Path:Literal option * SQLDataType:DataTypeReference option * XQueryDataType:Literal option
  | SequenceOption of SequenceOption
  | ServiceContract of Action:ScriptDom.AlterAction * Name:Identifier option
  | SessionOption of SessionOption
  | SetClause of SetClause
  | SetCommand of SetCommand
  | SpatialIndexOption of SpatialIndexOption
  | StatementList of StatementList
  | StatisticsOption of StatisticsOption
  | StatisticsPartitionRange of From:IntegerLiteral option * To:IntegerLiteral option
  | SystemTimePeriodDefinition of EndTimeColumn:Identifier option * StartTimeColumn:Identifier option
  | TSqlBatch of Statements:(TSqlStatement) list
  | TSqlFragmentSnippet of Script:String option
  | TSqlScript of Batches:(TSqlBatch) list
  | TSqlStatement of TSqlStatement
  | TableDefinition of ColumnDefinitions:(ColumnDefinition) list * Indexes:(IndexDefinition) list * SystemTimePeriod:SystemTimePeriodDefinition option * TableConstraints:(ConstraintDefinition) list
  | TableHint of TableHint
  | TableOption of TableOption
  | TableReference of TableReference
  | TableSampleClause of RepeatSeed:ScalarExpression option * SampleNumber:ScalarExpression option * System:bool * TableSampleClauseOption:ScriptDom.TableSampleClauseOption
  | TableSwitchOption of TableSwitchOption
  | TargetDeclaration of ObjectName:EventSessionObjectName option * TargetDeclarationParameters:(EventDeclarationSetParameter) list
  | TemporalClause of EndTime:ScalarExpression option * StartTime:ScalarExpression option * TemporalClauseType:ScriptDom.TemporalClauseType
  | TopRowFilter of Expression:ScalarExpression option * Percent:bool * WithTies:bool
  | TriggerAction of EventTypeGroup:EventTypeGroupContainer option * TriggerActionType:ScriptDom.TriggerActionType
  | TriggerObject of Name:SchemaObjectName option * TriggerScope:ScriptDom.TriggerScope
  | TriggerOption of TriggerOption
  | UserLoginOption of Identifier:Identifier option * UserLoginOptionType:ScriptDom.UserLoginOptionType
  | VariableValuePair of IsForUnknown:bool * Value:ScalarExpression option * Variable:VariableReference option
  | ViewOption of OptionKind:ScriptDom.ViewOptionKind
  | WhenClause of WhenClause
  | WhereClause of Cursor:CursorId option * SearchCondition:BooleanExpression option
  | WindowDelimiter of OffsetValue:ScalarExpression option * WindowDelimiterType:ScriptDom.WindowDelimiterType
  | WindowFrameClause of Bottom:WindowDelimiter option * Top:WindowDelimiter option * WindowFrameType:ScriptDom.WindowFrameType
  | WithCtesAndXmlNamespaces of ChangeTrackingContext:ValueExpression option * CommonTableExpressions:(CommonTableExpression) list * XmlNamespaces:XmlNamespaces option
  | WithinGroupClause of OrderByClause:OrderByClause option
  | WorkloadGroupParameter of WorkloadGroupParameter
  | XmlNamespaces of XmlNamespacesElements:(XmlNamespacesElement) list
  | XmlNamespacesElement of XmlNamespacesElement
  static member FromTs(src:ScriptDom.TSqlFragment) : TSqlFragment =
    match src with
    | :? ScriptDom.AdHocDataSource as src ->
      TSqlFragment.AdHocDataSource((src.InitString |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.AddFileSpec as src ->
      TSqlFragment.AddFileSpec((src.File |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.AlterAvailabilityGroupAction as src ->
      match src with
      | :? ScriptDom.AlterAvailabilityGroupFailoverAction as src-> (* 274 *)
        TSqlFragment.AlterAvailabilityGroupAction((AlterAvailabilityGroupAction.AlterAvailabilityGroupFailoverAction((src.ActionType) (* 196 *), (src.Options |> Seq.map (fun src -> AlterAvailabilityGroupFailoverOption.AlterAvailabilityGroupFailoverOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.AlterAvailabilityGroupAction as src *)
        TSqlFragment.AlterAvailabilityGroupAction((AlterAvailabilityGroupAction.Base((src.ActionType) (* 196 *))))
    | :? ScriptDom.AlterAvailabilityGroupFailoverOption as src ->
      TSqlFragment.AlterAvailabilityGroupFailoverOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.AlterDatabaseTermination as src ->
      TSqlFragment.AlterDatabaseTermination((src.ImmediateRollback) (* 196 *), (src.NoWait) (* 196 *), (src.RollbackAfter |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.AlterFullTextIndexAction as src ->
      match src with
      | :? ScriptDom.AddAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.AddAlterFullTextIndexAction((src.Columns |> Seq.map (fun src -> FullTextIndexColumn.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.WithNoPopulation) (* 196 *))))
      | :? ScriptDom.AlterColumnAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.AlterColumnAlterFullTextIndexAction((src.Column |> Option.ofObj |> Option.map (FullTextIndexColumn.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))))
      | :? ScriptDom.DropAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.DropAlterFullTextIndexAction((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.WithNoPopulation) (* 196 *))))
      | :? ScriptDom.SetSearchPropertyListAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.SetSearchPropertyListAlterFullTextIndexAction((src.SearchPropertyListOption |> Option.ofObj |> Option.map (SearchPropertyListFullTextIndexOption.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))))
      | :? ScriptDom.SetStopListAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.SetStopListAlterFullTextIndexAction((src.StopListOption |> Option.ofObj |> Option.map (StopListFullTextIndexOption.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))))
      | :? ScriptDom.SimpleAlterFullTextIndexAction as src-> (* 274 *)
        TSqlFragment.AlterFullTextIndexAction((AlterFullTextIndexAction.SimpleAlterFullTextIndexAction((src.ActionKind) (* 196 *))))
    | :? ScriptDom.AlterRoleAction as src ->
      match src with
      | :? ScriptDom.AddMemberAlterRoleAction as src-> (* 274 *)
        TSqlFragment.AlterRoleAction((AlterRoleAction.AddMemberAlterRoleAction((src.Member |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropMemberAlterRoleAction as src-> (* 274 *)
        TSqlFragment.AlterRoleAction((AlterRoleAction.DropMemberAlterRoleAction((src.Member |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.RenameAlterRoleAction as src-> (* 274 *)
        TSqlFragment.AlterRoleAction((AlterRoleAction.RenameAlterRoleAction((src.NewName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.AlterServerConfigurationBufferPoolExtensionOption as src ->
      match src with
      | :? ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption as src-> (* 274 *)
        TSqlFragment.AlterServerConfigurationBufferPoolExtensionOption((AlterServerConfigurationBufferPoolExtensionOption.AlterServerConfigurationBufferPoolExtensionContainerOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.Suboptions |> Seq.map (AlterServerConfigurationBufferPoolExtensionOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption as src-> (* 274 *)
        TSqlFragment.AlterServerConfigurationBufferPoolExtensionOption((AlterServerConfigurationBufferPoolExtensionOption.AlterServerConfigurationBufferPoolExtensionSizeOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.SizeUnit) (* 196 *))))
      | _ -> (* :? ScriptDom.AlterServerConfigurationBufferPoolExtensionOption as src *)
        TSqlFragment.AlterServerConfigurationBufferPoolExtensionOption((AlterServerConfigurationBufferPoolExtensionOption.Base((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))))
    | :? ScriptDom.AlterServerConfigurationDiagnosticsLogOption as src ->
      match src with
      | :? ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption as src-> (* 274 *)
        TSqlFragment.AlterServerConfigurationDiagnosticsLogOption((AlterServerConfigurationDiagnosticsLogOption.AlterServerConfigurationDiagnosticsLogMaxSizeOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.SizeUnit) (* 196 *))))
      | _ -> (* :? ScriptDom.AlterServerConfigurationDiagnosticsLogOption as src *)
        TSqlFragment.AlterServerConfigurationDiagnosticsLogOption((AlterServerConfigurationDiagnosticsLogOption.Base((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))))
    | :? ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption as src ->
      TSqlFragment.AlterServerConfigurationFailoverClusterPropertyOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
    | :? ScriptDom.AlterServerConfigurationHadrClusterOption as src ->
      TSqlFragment.AlterServerConfigurationHadrClusterOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
    | :? ScriptDom.AlterServerConfigurationSoftNumaOption as src ->
      TSqlFragment.AlterServerConfigurationSoftNumaOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableDropTableElement as src ->
      TSqlFragment.AlterTableDropTableElement((src.DropClusteredConstraintOptions |> Seq.map (DropClusteredConstraintOption.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableElementType) (* 196 *))
    | :? ScriptDom.ApplicationRoleOption as src ->
      TSqlFragment.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.AssemblyName as src ->
      TSqlFragment.AssemblyName((src.ClassName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AssemblyOption as src ->
      match src with
      | :? ScriptDom.OnOffAssemblyOption as src-> (* 274 *)
        TSqlFragment.AssemblyOption((AssemblyOption.OnOffAssemblyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.PermissionSetAssemblyOption as src-> (* 274 *)
        TSqlFragment.AssemblyOption((AssemblyOption.PermissionSetAssemblyOption((src.OptionKind) (* 196 *), (src.PermissionSetOption) (* 196 *))))
      | _ -> (* :? ScriptDom.AssemblyOption as src *)
        TSqlFragment.AssemblyOption((AssemblyOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.AtomicBlockOption as src ->
      match src with
      | :? ScriptDom.IdentifierAtomicBlockOption as src-> (* 274 *)
        TSqlFragment.AtomicBlockOption((AtomicBlockOption.IdentifierAtomicBlockOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.LiteralAtomicBlockOption as src-> (* 274 *)
        TSqlFragment.AtomicBlockOption((AtomicBlockOption.LiteralAtomicBlockOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OnOffAtomicBlockOption as src-> (* 274 *)
        TSqlFragment.AtomicBlockOption((AtomicBlockOption.OnOffAtomicBlockOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
    | :? ScriptDom.AuditOption as src ->
      match src with
      | :? ScriptDom.AuditGuidAuditOption as src-> (* 274 *)
        TSqlFragment.AuditOption((AuditOption.AuditGuidAuditOption((src.Guid |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.OnFailureAuditOption as src-> (* 274 *)
        TSqlFragment.AuditOption((AuditOption.OnFailureAuditOption((src.OnFailureAction) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.QueueDelayAuditOption as src-> (* 274 *)
        TSqlFragment.AuditOption((AuditOption.QueueDelayAuditOption((src.Delay |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.StateAuditOption as src-> (* 274 *)
        TSqlFragment.AuditOption((AuditOption.StateAuditOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
    | :? ScriptDom.AuditSpecificationDetail as src ->
      match src with
      | :? ScriptDom.AuditActionGroupReference as src-> (* 274 *)
        TSqlFragment.AuditSpecificationDetail((AuditSpecificationDetail.AuditActionGroupReference((src.Group) (* 196 *))))
      | :? ScriptDom.AuditActionSpecification as src-> (* 274 *)
        TSqlFragment.AuditSpecificationDetail((AuditSpecificationDetail.AuditActionSpecification((src.Actions |> Seq.map (fun src -> DatabaseAuditAction.DatabaseAuditAction((src.ActionKind) (* 196 *))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.TargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))))
    | :? ScriptDom.AuditSpecificationPart as src ->
      TSqlFragment.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))
    | :? ScriptDom.AuditTarget as src ->
      TSqlFragment.AuditTarget((src.TargetKind) (* 196 *), (src.TargetOptions |> Seq.map (AuditTargetOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.AuditTargetOption as src ->
      match src with
      | :? ScriptDom.LiteralAuditTargetOption as src-> (* 274 *)
        TSqlFragment.AuditTargetOption((AuditTargetOption.LiteralAuditTargetOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.MaxRolloverFilesAuditTargetOption as src-> (* 274 *)
        TSqlFragment.AuditTargetOption((AuditTargetOption.MaxRolloverFilesAuditTargetOption((src.IsUnlimited) (* 196 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.MaxSizeAuditTargetOption as src-> (* 274 *)
        TSqlFragment.AuditTargetOption((AuditTargetOption.MaxSizeAuditTargetOption((src.IsUnlimited) (* 196 *), (src.OptionKind) (* 196 *), (src.Size |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))))
      | :? ScriptDom.OnOffAuditTargetOption as src-> (* 274 *)
        TSqlFragment.AuditTargetOption((AuditTargetOption.OnOffAuditTargetOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
    | :? ScriptDom.AvailabilityGroupOption as src ->
      match src with
      | :? ScriptDom.LiteralAvailabilityGroupOption as src-> (* 274 *)
        TSqlFragment.AvailabilityGroupOption((AvailabilityGroupOption.LiteralAvailabilityGroupOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.AvailabilityReplica as src ->
      TSqlFragment.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.AvailabilityReplicaOption as src ->
      match src with
      | :? ScriptDom.AvailabilityModeReplicaOption as src-> (* 274 *)
        TSqlFragment.AvailabilityReplicaOption((AvailabilityReplicaOption.AvailabilityModeReplicaOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.FailoverModeReplicaOption as src-> (* 274 *)
        TSqlFragment.AvailabilityReplicaOption((AvailabilityReplicaOption.FailoverModeReplicaOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.LiteralReplicaOption as src-> (* 274 *)
        TSqlFragment.AvailabilityReplicaOption((AvailabilityReplicaOption.LiteralReplicaOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.PrimaryRoleReplicaOption as src-> (* 274 *)
        TSqlFragment.AvailabilityReplicaOption((AvailabilityReplicaOption.PrimaryRoleReplicaOption((src.AllowConnections) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.SecondaryRoleReplicaOption as src-> (* 274 *)
        TSqlFragment.AvailabilityReplicaOption((AvailabilityReplicaOption.SecondaryRoleReplicaOption((src.AllowConnections) (* 196 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.BackupOption as src ->
      match src with
      | :? ScriptDom.BackupEncryptionOption as src-> (* 274 *)
        TSqlFragment.BackupOption((BackupOption.BackupEncryptionOption((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.BackupOption as src *)
        TSqlFragment.BackupOption((BackupOption.Base((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.BackupRestoreFileInfo as src ->
      TSqlFragment.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.BooleanExpression as src ->
      match src with
      | :? ScriptDom.BooleanBinaryExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanBinaryExpression((src.BinaryExpressionType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BooleanComparisonExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanComparisonExpression((src.ComparisonType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BooleanExpressionSnippet as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanExpressionSnippet((Option.ofObj (src.Script)) (* 198 *))))
      | :? ScriptDom.BooleanIsNullExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanIsNullExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsNot) (* 196 *))))
      | :? ScriptDom.BooleanNotExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanNotExpression((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BooleanParenthesisExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanParenthesisExpression((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BooleanTernaryExpression as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.BooleanTernaryExpression((src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TernaryExpressionType) (* 196 *), (src.ThirdExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.EventDeclarationCompareFunctionParameter as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.EventDeclarationCompareFunctionParameter((src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.SourceDeclaration |> Option.ofObj |> Option.map (SourceDeclaration.FromTs)) (* 193 *))))
      | :? ScriptDom.ExistsPredicate as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.ExistsPredicate((src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *))))
      | :? ScriptDom.FullTextPredicate as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.FullTextPredicate((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FullTextFunctionType) (* 196 *), (src.LanguageTerm |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.InPredicate as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.InPredicate((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.NotDefined) (* 196 *), (src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *), (src.Values |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.LikePredicate as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.LikePredicate((src.EscapeExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.NotDefined) (* 196 *), (src.OdbcEscape) (* 196 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SubqueryComparisonPredicate as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.SubqueryComparisonPredicate((src.ComparisonType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *), (src.SubqueryComparisonPredicateType) (* 196 *))))
      | :? ScriptDom.TSEqualCall as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.TSEqualCall((src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.UpdateCall as src-> (* 274 *)
        TSqlFragment.BooleanExpression((BooleanExpression.UpdateCall((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.BoundingBoxParameter as src ->
      TSqlFragment.BoundingBoxParameter((src.Parameter) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BrokerPriorityParameter as src ->
      TSqlFragment.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.BulkInsertOption as src ->
      match src with
      | :? ScriptDom.LiteralBulkInsertOption as src-> (* 274 *)
        TSqlFragment.BulkInsertOption((BulkInsertOption.LiteralBulkInsertOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OrderBulkInsertOption as src-> (* 274 *)
        TSqlFragment.BulkInsertOption((BulkInsertOption.OrderBulkInsertOption((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.IsUnique) (* 196 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.BulkInsertOption as src *)
        TSqlFragment.BulkInsertOption((BulkInsertOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.CallTarget as src ->
      match src with
      | :? ScriptDom.ExpressionCallTarget as src-> (* 274 *)
        TSqlFragment.CallTarget((CallTarget.ExpressionCallTarget((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.MultiPartIdentifierCallTarget as src-> (* 274 *)
        TSqlFragment.CallTarget((CallTarget.MultiPartIdentifierCallTarget((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))))
      | :? ScriptDom.UserDefinedTypeCallTarget as src-> (* 274 *)
        TSqlFragment.CallTarget((CallTarget.UserDefinedTypeCallTarget((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.CertificateOption as src ->
      TSqlFragment.CertificateOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ChangeTrackingOptionDetail as src ->
      match src with
      | :? ScriptDom.AutoCleanupChangeTrackingOptionDetail as src-> (* 274 *)
        TSqlFragment.ChangeTrackingOptionDetail((ChangeTrackingOptionDetail.AutoCleanupChangeTrackingOptionDetail((src.IsOn) (* 196 *))))
      | :? ScriptDom.ChangeRetentionChangeTrackingOptionDetail as src-> (* 274 *)
        TSqlFragment.ChangeTrackingOptionDetail((ChangeTrackingOptionDetail.ChangeRetentionChangeTrackingOptionDetail((src.RetentionPeriod |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))))
    | :? ScriptDom.ColumnDefinitionBase as src ->
      match src with
      | :? ScriptDom.ColumnDefinition as src-> (* 274 *)
        TSqlFragment.ColumnDefinitionBase((ColumnDefinitionBase.ColumnDefinition((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ComputedColumnExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Constraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DefaultConstraint |> Option.ofObj |> Option.map (DefaultConstraintDefinition.FromTs)) (* 193 *), (src.Encryption |> Option.ofObj |> Option.map (ColumnEncryptionDefinition.FromTs)) (* 193 *), (Option.ofNullable (src.GeneratedAlways)), (src.IdentityOptions |> Option.ofObj |> Option.map (IdentityOptions.FromTs)) (* 193 *), (src.Index |> Option.ofObj |> Option.map (IndexDefinition.FromTs)) (* 193 *), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.IsPersisted) (* 196 *), (src.IsRowGuidCol) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))))
      | _ -> (* :? ScriptDom.ColumnDefinitionBase as src *)
        TSqlFragment.ColumnDefinitionBase((ColumnDefinitionBase.Base((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))))
    | :? ScriptDom.ColumnEncryptionDefinition as src ->
      TSqlFragment.ColumnEncryptionDefinition((src.Parameters |> Seq.map (ColumnEncryptionDefinitionParameter.FromTs) |> List.ofSeq))
    | :? ScriptDom.ColumnEncryptionDefinitionParameter as src ->
      match src with
      | :? ScriptDom.ColumnEncryptionAlgorithmParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionDefinitionParameter((ColumnEncryptionDefinitionParameter.ColumnEncryptionAlgorithmParameter((src.EncryptionAlgorithm |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))))
      | :? ScriptDom.ColumnEncryptionKeyNameParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionDefinitionParameter((ColumnEncryptionDefinitionParameter.ColumnEncryptionKeyNameParameter((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterKind) (* 196 *))))
      | :? ScriptDom.ColumnEncryptionTypeParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionDefinitionParameter((ColumnEncryptionDefinitionParameter.ColumnEncryptionTypeParameter((src.EncryptionType) (* 196 *), (src.ParameterKind) (* 196 *))))
    | :? ScriptDom.ColumnEncryptionKeyValue as src ->
      TSqlFragment.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))
    | :? ScriptDom.ColumnEncryptionKeyValueParameter as src ->
      match src with
      | :? ScriptDom.ColumnEncryptionAlgorithmNameParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionKeyValueParameter((ColumnEncryptionKeyValueParameter.ColumnEncryptionAlgorithmNameParameter((src.Algorithm |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))))
      | :? ScriptDom.ColumnMasterKeyNameParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionKeyValueParameter((ColumnEncryptionKeyValueParameter.ColumnMasterKeyNameParameter((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterKind) (* 196 *))))
      | :? ScriptDom.EncryptedValueParameter as src-> (* 274 *)
        TSqlFragment.ColumnEncryptionKeyValueParameter((ColumnEncryptionKeyValueParameter.EncryptedValueParameter((src.ParameterKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (BinaryLiteral.FromTs)) (* 193 *))))
    | :? ScriptDom.ColumnMasterKeyParameter as src ->
      match src with
      | :? ScriptDom.ColumnMasterKeyPathParameter as src-> (* 274 *)
        TSqlFragment.ColumnMasterKeyParameter((ColumnMasterKeyParameter.ColumnMasterKeyPathParameter((src.ParameterKind) (* 196 *), (src.Path |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.ColumnMasterKeyStoreProviderNameParameter as src-> (* 274 *)
        TSqlFragment.ColumnMasterKeyParameter((ColumnMasterKeyParameter.ColumnMasterKeyStoreProviderNameParameter((src.Name |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))))
    | :? ScriptDom.ColumnStorageOptions as src ->
      TSqlFragment.ColumnStorageOptions((src.IsFileStream) (* 196 *), (src.SparseOption) (* 196 *))
    | :? ScriptDom.ColumnWithSortOrder as src ->
      TSqlFragment.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))
    | :? ScriptDom.CommonTableExpression as src ->
      TSqlFragment.CommonTableExpression((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExpressionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.CompressionPartitionRange as src ->
      TSqlFragment.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ComputeClause as src ->
      TSqlFragment.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.ComputeFunction as src ->
      TSqlFragment.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ConstraintDefinition as src ->
      match src with
      | :? ScriptDom.CheckConstraintDefinition as src-> (* 274 *)
        TSqlFragment.ConstraintDefinition((ConstraintDefinition.CheckConstraintDefinition((src.CheckCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *))))
      | :? ScriptDom.DefaultConstraintDefinition as src-> (* 274 *)
        TSqlFragment.ConstraintDefinition((ConstraintDefinition.DefaultConstraintDefinition((src.Column |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WithValues) (* 196 *))))
      | :? ScriptDom.ForeignKeyConstraintDefinition as src-> (* 274 *)
        TSqlFragment.ConstraintDefinition((ConstraintDefinition.ForeignKeyConstraintDefinition((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DeleteAction) (* 196 *), (src.NotForReplication) (* 196 *), (src.ReferenceTableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ReferencedTableColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.UpdateAction) (* 196 *))))
      | :? ScriptDom.NullableConstraintDefinition as src-> (* 274 *)
        TSqlFragment.ConstraintDefinition((ConstraintDefinition.NullableConstraintDefinition((src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Nullable) (* 196 *))))
      | :? ScriptDom.UniqueConstraintDefinition as src-> (* 274 *)
        TSqlFragment.ConstraintDefinition((ConstraintDefinition.UniqueConstraintDefinition((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.IsPrimaryKey) (* 196 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *))))
    | :? ScriptDom.ContractMessage as src ->
      TSqlFragment.ContractMessage((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SentBy) (* 196 *))
    | :? ScriptDom.CreateLoginSource as src ->
      match src with
      | :? ScriptDom.AsymmetricKeyCreateLoginSource as src-> (* 274 *)
        TSqlFragment.CreateLoginSource((CreateLoginSource.AsymmetricKeyCreateLoginSource((src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Key |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CertificateCreateLoginSource as src-> (* 274 *)
        TSqlFragment.CreateLoginSource((CreateLoginSource.CertificateCreateLoginSource((src.Certificate |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.PasswordCreateLoginSource as src-> (* 274 *)
        TSqlFragment.CreateLoginSource((CreateLoginSource.PasswordCreateLoginSource((src.Hashed) (* 196 *), (src.MustChange) (* 196 *), (src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.WindowsCreateLoginSource as src-> (* 274 *)
        TSqlFragment.CreateLoginSource((CreateLoginSource.WindowsCreateLoginSource((src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.CryptoMechanism as src ->
      TSqlFragment.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CursorDefinition as src ->
      TSqlFragment.CursorDefinition((src.Options |> Seq.map (fun src -> CursorOption.CursorOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.Select |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *))
    | :? ScriptDom.CursorId as src ->
      TSqlFragment.CursorId((src.IsGlobal) (* 196 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.CursorOption as src ->
      TSqlFragment.CursorOption((src.OptionKind) (* 196 *))
    | :? ScriptDom.DataModificationSpecification as src ->
      match src with
      | :? ScriptDom.InsertSpecification as src-> (* 274 *)
        TSqlFragment.DataModificationSpecification((DataModificationSpecification.InsertSpecification((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.InsertOption) (* 196 *), (src.InsertSource |> Option.ofObj |> Option.map (InsertSource.FromTs)) (* 191 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))))
      | :? ScriptDom.MergeSpecification as src-> (* 274 *)
        TSqlFragment.DataModificationSpecification((DataModificationSpecification.MergeSpecification((src.ActionClauses |> Seq.map (fun src -> MergeActionClause.MergeActionClause((src.Action |> Option.ofObj |> Option.map (MergeAction.FromTs)) (* 191 *), (src.Condition) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.TableAlias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))))
      | :? ScriptDom.UpdateDeleteSpecificationBase as src-> (* 274 *)
        TSqlFragment.DataModificationSpecification((DataModificationSpecification.UpdateDeleteSpecificationBase((UpdateDeleteSpecificationBase.FromTs(src))) (* 251 *)))
    | :? ScriptDom.DataTypeReference as src ->
      match src with
      | :? ScriptDom.ParameterizedDataTypeReference as src-> (* 274 *)
        TSqlFragment.DataTypeReference((DataTypeReference.ParameterizedDataTypeReference((ParameterizedDataTypeReference.FromTs(src))) (* 251 *)))
      | :? ScriptDom.XmlDataTypeReference as src-> (* 274 *)
        TSqlFragment.DataTypeReference((DataTypeReference.XmlDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.XmlDataTypeOption) (* 196 *), (src.XmlSchemaCollection |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.DatabaseAuditAction as src ->
      TSqlFragment.DatabaseAuditAction((src.ActionKind) (* 196 *))
    | :? ScriptDom.DatabaseConfigurationClearOption as src ->
      TSqlFragment.DatabaseConfigurationClearOption((src.OptionKind) (* 196 *))
    | :? ScriptDom.DatabaseConfigurationSetOption as src ->
      match src with
      | :? ScriptDom.MaxDopConfigurationOption as src-> (* 274 *)
        TSqlFragment.DatabaseConfigurationSetOption((DatabaseConfigurationSetOption.MaxDopConfigurationOption((src.OptionKind) (* 196 *), (src.Primary) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OnOffPrimaryConfigurationOption as src-> (* 274 *)
        TSqlFragment.DatabaseConfigurationSetOption((DatabaseConfigurationSetOption.OnOffPrimaryConfigurationOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | _ -> (* :? ScriptDom.DatabaseConfigurationSetOption as src *)
        TSqlFragment.DatabaseConfigurationSetOption((DatabaseConfigurationSetOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.DatabaseOption as src ->
      match src with
      | :? ScriptDom.ChangeTrackingDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.ChangeTrackingDatabaseOption((src.Details |> Seq.map (ChangeTrackingOptionDetail.FromTs) |> List.ofSeq), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.ContainmentDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.ContainmentDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.CursorDefaultDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.CursorDefaultDatabaseOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.DelayedDurabilityDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.DelayedDurabilityDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.FileStreamDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.FileStreamDatabaseOption((src.DirectoryName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (Option.ofNullable (src.NonTransactedAccess)), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.HadrDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.HadrDatabaseOption((HadrDatabaseOption.FromTs(src))) (* 251 *)))
      | :? ScriptDom.IdentifierDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.IdentifierDatabaseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.LiteralDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.LiteralDatabaseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.MaxSizeDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.MaxSizeDatabaseOption((src.MaxSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *))))
      | :? ScriptDom.OnOffDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.OnOffDatabaseOption((OnOffDatabaseOption.FromTs(src))) (* 251 *)))
      | :? ScriptDom.PageVerifyDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.PageVerifyDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.ParameterizationDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.ParameterizationDatabaseOption((src.IsSimple) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.PartnerDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.PartnerDatabaseOption((src.OptionKind) (* 196 *), (src.PartnerOption) (* 196 *), (src.PartnerServer |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.QueryStoreDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.QueryStoreDatabaseOption((src.Clear) (* 196 *), (src.ClearAll) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *), (src.Options |> Seq.map (QueryStoreOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.RecoveryDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.RecoveryDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.RemoteDataArchiveDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.RemoteDataArchiveDatabaseOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *), (src.Settings |> Seq.map (RemoteDataArchiveDatabaseSetting.FromTs) |> List.ofSeq))))
      | :? ScriptDom.TargetRecoveryTimeDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.TargetRecoveryTimeDatabaseOption((src.OptionKind) (* 196 *), (src.RecoveryTime |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))))
      | :? ScriptDom.WitnessDatabaseOption as src-> (* 274 *)
        TSqlFragment.DatabaseOption((DatabaseOption.WitnessDatabaseOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.WitnessServer |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.DatabaseOption as src *)
        TSqlFragment.DatabaseOption((DatabaseOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.DbccNamedLiteral as src ->
      TSqlFragment.DbccNamedLiteral((Option.ofObj (src.Name)) (* 198 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.DbccOption as src ->
      TSqlFragment.DbccOption((src.OptionKind) (* 196 *))
    | :? ScriptDom.DeclareTableVariableBody as src ->
      TSqlFragment.DeclareTableVariableBody((src.AsDefined) (* 196 *), (src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DeclareVariableElement as src ->
      match src with
      | :? ScriptDom.ProcedureParameter as src-> (* 274 *)
        TSqlFragment.DeclareVariableElement((DeclareVariableElement.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.DeclareVariableElement as src *)
        TSqlFragment.DeclareVariableElement((DeclareVariableElement.Base((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.DeviceInfo as src ->
      TSqlFragment.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.DialogOption as src ->
      match src with
      | :? ScriptDom.OnOffDialogOption as src-> (* 274 *)
        TSqlFragment.DialogOption((DialogOption.OnOffDialogOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.ScalarExpressionDialogOption as src-> (* 274 *)
        TSqlFragment.DialogOption((DialogOption.ScalarExpressionDialogOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.DiskStatementOption as src ->
      TSqlFragment.DiskStatementOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.DropClusteredConstraintOption as src ->
      match src with
      | :? ScriptDom.DropClusteredConstraintMoveOption as src-> (* 274 *)
        TSqlFragment.DropClusteredConstraintOption((DropClusteredConstraintOption.DropClusteredConstraintMoveOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *))))
      | :? ScriptDom.DropClusteredConstraintStateOption as src-> (* 274 *)
        TSqlFragment.DropClusteredConstraintOption((DropClusteredConstraintOption.DropClusteredConstraintStateOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.DropClusteredConstraintValueOption as src-> (* 274 *)
        TSqlFragment.DropClusteredConstraintOption((DropClusteredConstraintOption.DropClusteredConstraintValueOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.DropIndexClauseBase as src ->
      match src with
      | :? ScriptDom.BackwardsCompatibleDropIndexClause as src-> (* 274 *)
        TSqlFragment.DropIndexClauseBase((DropIndexClauseBase.BackwardsCompatibleDropIndexClause((src.Index |> Option.ofObj |> Option.map (ChildObjectName.FromTs)) (* 193 *))))
      | :? ScriptDom.DropIndexClause as src-> (* 274 *)
        TSqlFragment.DropIndexClauseBase((DropIndexClauseBase.DropIndexClause((src.Index |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (IndexOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.EncryptionSource as src ->
      match src with
      | :? ScriptDom.AssemblyEncryptionSource as src-> (* 274 *)
        TSqlFragment.EncryptionSource((EncryptionSource.AssemblyEncryptionSource((src.Assembly |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.FileEncryptionSource as src-> (* 274 *)
        TSqlFragment.EncryptionSource((EncryptionSource.FileEncryptionSource((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsExecutable) (* 196 *))))
      | :? ScriptDom.ProviderEncryptionSource as src-> (* 274 *)
        TSqlFragment.EncryptionSource((EncryptionSource.ProviderEncryptionSource((src.KeyOptions |> Seq.map (KeyOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.EndpointAffinity as src ->
      TSqlFragment.EndpointAffinity((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.EndpointProtocolOption as src ->
      match src with
      | :? ScriptDom.AuthenticationEndpointProtocolOption as src-> (* 274 *)
        TSqlFragment.EndpointProtocolOption((EndpointProtocolOption.AuthenticationEndpointProtocolOption((src.AuthenticationTypes) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.CompressionEndpointProtocolOption as src-> (* 274 *)
        TSqlFragment.EndpointProtocolOption((EndpointProtocolOption.CompressionEndpointProtocolOption((src.IsEnabled) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.ListenerIPEndpointProtocolOption as src-> (* 274 *)
        TSqlFragment.EndpointProtocolOption((EndpointProtocolOption.ListenerIPEndpointProtocolOption((src.IPv4PartOne |> Option.ofObj |> Option.map (IPv4.FromTs)) (* 193 *), (src.IPv4PartTwo |> Option.ofObj |> Option.map (IPv4.FromTs)) (* 193 *), (src.IPv6 |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsAll) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.LiteralEndpointProtocolOption as src-> (* 274 *)
        TSqlFragment.EndpointProtocolOption((EndpointProtocolOption.LiteralEndpointProtocolOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.PortsEndpointProtocolOption as src-> (* 274 *)
        TSqlFragment.EndpointProtocolOption((EndpointProtocolOption.PortsEndpointProtocolOption((src.Kind) (* 196 *), (src.PortTypes) (* 196 *))))
    | :? ScriptDom.EventDeclaration as src ->
      TSqlFragment.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))
    | :? ScriptDom.EventDeclarationSetParameter as src ->
      TSqlFragment.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.EventNotificationObjectScope as src ->
      TSqlFragment.EventNotificationObjectScope((src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Target) (* 196 *))
    | :? ScriptDom.EventSessionObjectName as src ->
      TSqlFragment.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
    | :? ScriptDom.EventTypeGroupContainer as src ->
      match src with
      | :? ScriptDom.EventGroupContainer as src-> (* 274 *)
        TSqlFragment.EventTypeGroupContainer((EventTypeGroupContainer.EventGroupContainer((src.EventGroup) (* 196 *))))
      | :? ScriptDom.EventTypeContainer as src-> (* 274 *)
        TSqlFragment.EventTypeGroupContainer((EventTypeGroupContainer.EventTypeContainer((src.EventType) (* 196 *))))
    | :? ScriptDom.ExecutableEntity as src ->
      match src with
      | :? ScriptDom.ExecutableProcedureReference as src-> (* 274 *)
        TSqlFragment.ExecutableEntity((ExecutableEntity.ExecutableProcedureReference((src.AdHocDataSource |> Option.ofObj |> Option.map (AdHocDataSource.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ExecuteParameter.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReferenceName.FromTs)) (* 193 *))))
      | :? ScriptDom.ExecutableStringList as src-> (* 274 *)
        TSqlFragment.ExecutableEntity((ExecutableEntity.ExecutableStringList((src.Parameters |> Seq.map (fun src -> ExecuteParameter.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq), (src.Strings |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))))
    | :? ScriptDom.ExecuteAsClause as src ->
      TSqlFragment.ExecuteAsClause((src.ExecuteAsOption) (* 196 *), (src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ExecuteContext as src ->
      TSqlFragment.ExecuteContext((src.Kind) (* 196 *), (src.Principal |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ExecuteOption as src ->
      match src with
      | :? ScriptDom.ResultSetsExecuteOption as src-> (* 274 *)
        TSqlFragment.ExecuteOption((ExecuteOption.ResultSetsExecuteOption((src.Definitions |> Seq.map (ResultSetDefinition.FromTs) |> List.ofSeq), (src.OptionKind) (* 196 *), (src.ResultSetsOptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.ExecuteOption as src *)
        TSqlFragment.ExecuteOption((ExecuteOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.ExecuteParameter as src ->
      TSqlFragment.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.ExecuteSpecification as src ->
      TSqlFragment.ExecuteSpecification((src.ExecutableEntity |> Option.ofObj |> Option.map (ExecutableEntity.FromTs)) (* 191 *), (src.ExecuteContext |> Option.ofObj |> Option.map (ExecuteContext.FromTs)) (* 193 *), (src.LinkedServer |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.ExpressionWithSortOrder as src ->
      TSqlFragment.ExpressionWithSortOrder((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SortOrder) (* 196 *))
    | :? ScriptDom.ExternalDataSourceOption as src ->
      match src with
      | :? ScriptDom.ExternalDataSourceLiteralOrIdentifierOption as src-> (* 274 *)
        TSqlFragment.ExternalDataSourceOption((ExternalDataSourceOption.ExternalDataSourceLiteralOrIdentifierOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
    | :? ScriptDom.ExternalFileFormatOption as src ->
      match src with
      | :? ScriptDom.ExternalFileFormatContainerOption as src-> (* 274 *)
        TSqlFragment.ExternalFileFormatOption((ExternalFileFormatOption.ExternalFileFormatContainerOption((src.OptionKind) (* 196 *), (src.Suboptions |> Seq.map (ExternalFileFormatOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ExternalFileFormatLiteralOption as src-> (* 274 *)
        TSqlFragment.ExternalFileFormatOption((ExternalFileFormatOption.ExternalFileFormatLiteralOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.ExternalFileFormatUseDefaultTypeOption as src-> (* 274 *)
        TSqlFragment.ExternalFileFormatOption((ExternalFileFormatOption.ExternalFileFormatUseDefaultTypeOption((src.ExternalFileFormatUseDefaultType) (* 196 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.ExternalResourcePoolAffinitySpecification as src ->
      TSqlFragment.ExternalResourcePoolAffinitySpecification((src.AffinityType) (* 196 *), (src.IsAuto) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.PoolAffinityRanges |> Seq.map (LiteralRange.FromTs) |> List.ofSeq))
    | :? ScriptDom.ExternalResourcePoolParameter as src ->
      TSqlFragment.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ExternalTableColumnDefinition as src ->
      TSqlFragment.ExternalTableColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))
    | :? ScriptDom.ExternalTableDistributionPolicy as src ->
      match src with
      | :? ScriptDom.ExternalTableReplicatedDistributionPolicy as src-> (* 274 *)
        TSqlFragment.ExternalTableDistributionPolicy((ExternalTableDistributionPolicy.ExternalTableReplicatedDistributionPolicy))
      | :? ScriptDom.ExternalTableRoundRobinDistributionPolicy as src-> (* 274 *)
        TSqlFragment.ExternalTableDistributionPolicy((ExternalTableDistributionPolicy.ExternalTableRoundRobinDistributionPolicy))
      | :? ScriptDom.ExternalTableShardedDistributionPolicy as src-> (* 274 *)
        TSqlFragment.ExternalTableDistributionPolicy((ExternalTableDistributionPolicy.ExternalTableShardedDistributionPolicy((src.ShardingColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ExternalTableOption as src ->
      match src with
      | :? ScriptDom.ExternalTableDistributionOption as src-> (* 274 *)
        TSqlFragment.ExternalTableOption((ExternalTableOption.ExternalTableDistributionOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ExternalTableDistributionPolicy.FromTs)) (* 191 *))))
      | :? ScriptDom.ExternalTableLiteralOrIdentifierOption as src-> (* 274 *)
        TSqlFragment.ExternalTableOption((ExternalTableOption.ExternalTableLiteralOrIdentifierOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.ExternalTableRejectTypeOption as src-> (* 274 *)
        TSqlFragment.ExternalTableOption((ExternalTableOption.ExternalTableRejectTypeOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
    | :? ScriptDom.FederationScheme as src ->
      TSqlFragment.FederationScheme((src.ColumnName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FetchType as src ->
      TSqlFragment.FetchType((src.Orientation) (* 196 *), (src.RowOffset |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.FileDeclaration as src ->
      TSqlFragment.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.FileDeclarationOption as src ->
      match src with
      | :? ScriptDom.FileGrowthFileDeclarationOption as src-> (* 274 *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.FileGrowthFileDeclarationOption((src.GrowthIncrement |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *))))
      | :? ScriptDom.FileNameFileDeclarationOption as src-> (* 274 *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.FileNameFileDeclarationOption((src.OSFileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.MaxSizeFileDeclarationOption as src-> (* 274 *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.MaxSizeFileDeclarationOption((src.MaxSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *), (src.Unlimited) (* 196 *))))
      | :? ScriptDom.NameFileDeclarationOption as src-> (* 274 *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.NameFileDeclarationOption((src.IsNewName) (* 196 *), (src.LogicalFileName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.SizeFileDeclarationOption as src-> (* 274 *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.SizeFileDeclarationOption((src.OptionKind) (* 196 *), (src.Size |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Units) (* 196 *))))
      | _ -> (* :? ScriptDom.FileDeclarationOption as src *)
        TSqlFragment.FileDeclarationOption((FileDeclarationOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.FileGroupDefinition as src ->
      TSqlFragment.FileGroupDefinition((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FileGroupOrPartitionScheme as src ->
      TSqlFragment.FileGroupOrPartitionScheme((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PartitionSchemeColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq))
    | :? ScriptDom.ForClause as src ->
      match src with
      | :? ScriptDom.BrowseForClause as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.BrowseForClause))
      | :? ScriptDom.JsonForClause as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.JsonForClause((src.Options |> Seq.map (fun src -> JsonForClauseOption.JsonForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.JsonForClauseOption as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.JsonForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.ReadOnlyForClause as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.ReadOnlyForClause))
      | :? ScriptDom.UpdateForClause as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.UpdateForClause((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.XmlForClause as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.XmlForClause((src.Options |> Seq.map (fun src -> XmlForClauseOption.XmlForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.XmlForClauseOption as src-> (* 274 *)
        TSqlFragment.ForClause((ForClause.XmlForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.FromClause as src ->
      TSqlFragment.FromClause((src.TableReferences |> Seq.map (TableReference.FromTs) |> List.ofSeq))
    | :? ScriptDom.FullTextCatalogAndFileGroup as src ->
      TSqlFragment.FullTextCatalogAndFileGroup((src.CatalogName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroupIsFirst) (* 196 *), (src.FileGroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FullTextCatalogOption as src ->
      match src with
      | :? ScriptDom.OnOffFullTextCatalogOption as src-> (* 274 *)
        TSqlFragment.FullTextCatalogOption((FullTextCatalogOption.OnOffFullTextCatalogOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
    | :? ScriptDom.FullTextIndexColumn as src ->
      TSqlFragment.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FullTextIndexOption as src ->
      match src with
      | :? ScriptDom.ChangeTrackingFullTextIndexOption as src-> (* 274 *)
        TSqlFragment.FullTextIndexOption((FullTextIndexOption.ChangeTrackingFullTextIndexOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.SearchPropertyListFullTextIndexOption as src-> (* 274 *)
        TSqlFragment.FullTextIndexOption((FullTextIndexOption.SearchPropertyListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.PropertyListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.StopListFullTextIndexOption as src-> (* 274 *)
        TSqlFragment.FullTextIndexOption((FullTextIndexOption.StopListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.StopListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.FullTextStopListAction as src ->
      TSqlFragment.FullTextStopListAction((src.IsAdd) (* 196 *), (src.IsAll) (* 196 *), (src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.StopWord |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.FunctionOption as src ->
      match src with
      | :? ScriptDom.ExecuteAsFunctionOption as src-> (* 274 *)
        TSqlFragment.FunctionOption((FunctionOption.ExecuteAsFunctionOption((src.ExecuteAs |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.FunctionOption as src *)
        TSqlFragment.FunctionOption((FunctionOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.FunctionReturnType as src ->
      match src with
      | :? ScriptDom.ScalarFunctionReturnType as src-> (* 274 *)
        TSqlFragment.FunctionReturnType((FunctionReturnType.ScalarFunctionReturnType((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))))
      | :? ScriptDom.SelectFunctionReturnType as src-> (* 274 *)
        TSqlFragment.FunctionReturnType((FunctionReturnType.SelectFunctionReturnType((src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *))))
      | :? ScriptDom.TableValuedFunctionReturnType as src-> (* 274 *)
        TSqlFragment.FunctionReturnType((FunctionReturnType.TableValuedFunctionReturnType((src.DeclareTableVariableBody |> Option.ofObj |> Option.map (DeclareTableVariableBody.FromTs)) (* 193 *))))
    | :? ScriptDom.GridParameter as src ->
      TSqlFragment.GridParameter((src.Parameter) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.GroupByClause as src ->
      TSqlFragment.GroupByClause((src.All) (* 196 *), (src.GroupByOption) (* 196 *), (src.GroupingSpecifications |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
    | :? ScriptDom.GroupingSpecification as src ->
      match src with
      | :? ScriptDom.CompositeGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.CompositeGroupingSpecification((src.Items |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CubeGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.CubeGroupingSpecification((src.Arguments |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ExpressionGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.ExpressionGroupingSpecification((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.GrandTotalGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.GrandTotalGroupingSpecification))
      | :? ScriptDom.GroupingSetsGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.GroupingSetsGroupingSpecification((src.Sets |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))))
      | :? ScriptDom.RollupGroupingSpecification as src-> (* 274 *)
        TSqlFragment.GroupingSpecification((GroupingSpecification.RollupGroupingSpecification((src.Arguments |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))))
    | :? ScriptDom.HavingClause as src ->
      TSqlFragment.HavingClause((src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.IPv4 as src ->
      TSqlFragment.IPv4((src.OctetFour |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetOne |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetThree |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetTwo |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.Identifier as src ->
      match src with
      | :? ScriptDom.IdentifierSnippet as src-> (* 274 *)
        TSqlFragment.Identifier((Identifier.IdentifierSnippet((src.QuoteType) (* 196 *), (Option.ofObj (src.Script)) (* 198 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.SqlCommandIdentifier as src-> (* 274 *)
        TSqlFragment.Identifier((Identifier.SqlCommandIdentifier((src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | _ -> (* :? ScriptDom.Identifier as src *)
        TSqlFragment.Identifier((Identifier.Base((src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
    | :? ScriptDom.IdentifierOrValueExpression as src ->
      TSqlFragment.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.IdentityOptions as src ->
      TSqlFragment.IdentityOptions((src.IdentityIncrement |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IdentitySeed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsIdentityNotForReplication) (* 196 *))
    | :? ScriptDom.IndexOption as src ->
      match src with
      | :? ScriptDom.CompressionDelayIndexOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.CompressionDelayIndexOption((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.TimeUnit) (* 196 *))))
      | :? ScriptDom.DataCompressionOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.DataCompressionOption((src.CompressionLevel) (* 196 *), (src.OptionKind) (* 196 *), (src.PartitionRanges |> Seq.map (fun src -> CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.FileStreamOnDropIndexOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.FileStreamOnDropIndexOption((src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.IndexExpressionOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.IndexExpressionOption((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.IndexStateOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.IndexStateOption((IndexStateOption.FromTs(src))) (* 251 *)))
      | :? ScriptDom.MoveToDropIndexOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.MoveToDropIndexOption((src.MoveTo |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.OrderIndexOption as src-> (* 274 *)
        TSqlFragment.IndexOption((IndexOption.OrderIndexOption((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.IndexType as src ->
      TSqlFragment.IndexType((Option.ofNullable (src.IndexTypeKind)))
    | :? ScriptDom.InsertBulkColumnDefinition as src ->
      TSqlFragment.InsertBulkColumnDefinition((src.Column |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullNotNull) (* 196 *))
    | :? ScriptDom.InsertSource as src ->
      match src with
      | :? ScriptDom.ExecuteInsertSource as src-> (* 274 *)
        TSqlFragment.InsertSource((InsertSource.ExecuteInsertSource((src.Execute |> Option.ofObj |> Option.map (ExecuteSpecification.FromTs)) (* 193 *))))
      | :? ScriptDom.SelectInsertSource as src-> (* 274 *)
        TSqlFragment.InsertSource((InsertSource.SelectInsertSource((src.Select |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ValuesInsertSource as src-> (* 274 *)
        TSqlFragment.InsertSource((InsertSource.ValuesInsertSource((src.IsDefaultValues) (* 196 *), (src.RowValues |> Seq.map (fun src -> RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))) |> List.ofSeq))))
    | :? ScriptDom.KeyOption as src ->
      match src with
      | :? ScriptDom.AlgorithmKeyOption as src-> (* 274 *)
        TSqlFragment.KeyOption((KeyOption.AlgorithmKeyOption((src.Algorithm) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.CreationDispositionKeyOption as src-> (* 274 *)
        TSqlFragment.KeyOption((KeyOption.CreationDispositionKeyOption((src.IsCreateNew) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.IdentityValueKeyOption as src-> (* 274 *)
        TSqlFragment.KeyOption((KeyOption.IdentityValueKeyOption((src.IdentityPhrase |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.KeySourceKeyOption as src-> (* 274 *)
        TSqlFragment.KeyOption((KeyOption.KeySourceKeyOption((src.OptionKind) (* 196 *), (src.PassPhrase |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.ProviderKeyNameKeyOption as src-> (* 274 *)
        TSqlFragment.KeyOption((KeyOption.ProviderKeyNameKeyOption((src.KeyName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.LiteralRange as src ->
      match src with
      | :? ScriptDom.ProcessAffinityRange as src-> (* 274 *)
        TSqlFragment.LiteralRange((LiteralRange.ProcessAffinityRange((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.LiteralRange as src *)
        TSqlFragment.LiteralRange((LiteralRange.Base((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.LowPriorityLockWaitOption as src ->
      match src with
      | :? ScriptDom.LowPriorityLockWaitAbortAfterWaitOption as src-> (* 274 *)
        TSqlFragment.LowPriorityLockWaitOption((LowPriorityLockWaitOption.LowPriorityLockWaitAbortAfterWaitOption((src.AbortAfterWait) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.LowPriorityLockWaitMaxDurationOption as src-> (* 274 *)
        TSqlFragment.LowPriorityLockWaitOption((LowPriorityLockWaitOption.LowPriorityLockWaitMaxDurationOption((src.MaxDuration |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (Option.ofNullable (src.Unit)))))
    | :? ScriptDom.MergeAction as src ->
      match src with
      | :? ScriptDom.DeleteMergeAction as src-> (* 274 *)
        TSqlFragment.MergeAction((MergeAction.DeleteMergeAction))
      | :? ScriptDom.InsertMergeAction as src-> (* 274 *)
        TSqlFragment.MergeAction((MergeAction.InsertMergeAction((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.Source |> Option.ofObj |> Option.map (ValuesInsertSource.FromTs)) (* 193 *))))
      | :? ScriptDom.UpdateMergeAction as src-> (* 274 *)
        TSqlFragment.MergeAction((MergeAction.UpdateMergeAction((src.SetClauses |> Seq.map (SetClause.FromTs) |> List.ofSeq))))
    | :? ScriptDom.MergeActionClause as src ->
      TSqlFragment.MergeActionClause((src.Action |> Option.ofObj |> Option.map (MergeAction.FromTs)) (* 191 *), (src.Condition) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.MethodSpecifier as src ->
      TSqlFragment.MethodSpecifier((src.AssemblyName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ClassName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.MethodName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.MirrorToClause as src ->
      TSqlFragment.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.MultiPartIdentifier as src ->
      match src with
      | :? ScriptDom.SchemaObjectName as src-> (* 274 *)
        TSqlFragment.MultiPartIdentifier((MultiPartIdentifier.SchemaObjectName((SchemaObjectName.FromTs(src))) (* 251 *)))
      | _ -> (* :? ScriptDom.MultiPartIdentifier as src *)
        TSqlFragment.MultiPartIdentifier((MultiPartIdentifier.Base((src.Count) (* 196 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))))
    | :? ScriptDom.OffsetClause as src ->
      TSqlFragment.OffsetClause((src.FetchExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OffsetExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.OnlineIndexLowPriorityLockWaitOption as src ->
      TSqlFragment.OnlineIndexLowPriorityLockWaitOption((src.Options |> Seq.map (LowPriorityLockWaitOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.OptimizerHint as src ->
      match src with
      | :? ScriptDom.LiteralOptimizerHint as src-> (* 274 *)
        TSqlFragment.OptimizerHint((OptimizerHint.LiteralOptimizerHint((src.HintKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OptimizeForOptimizerHint as src-> (* 274 *)
        TSqlFragment.OptimizerHint((OptimizerHint.OptimizeForOptimizerHint((src.HintKind) (* 196 *), (src.IsForUnknown) (* 196 *), (src.Pairs |> Seq.map (fun src -> VariableValuePair.VariableValuePair((src.IsForUnknown) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq))))
      | :? ScriptDom.TableHintsOptimizerHint as src-> (* 274 *)
        TSqlFragment.OptimizerHint((OptimizerHint.TableHintsOptimizerHint((src.HintKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TableHints |> Seq.map (TableHint.FromTs) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.OptimizerHint as src *)
        TSqlFragment.OptimizerHint((OptimizerHint.Base((src.HintKind) (* 196 *))))
    | :? ScriptDom.OptionValue as src ->
      match src with
      | :? ScriptDom.LiteralOptionValue as src-> (* 274 *)
        TSqlFragment.OptionValue((OptionValue.LiteralOptionValue((src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OnOffOptionValue as src-> (* 274 *)
        TSqlFragment.OptionValue((OptionValue.OnOffOptionValue((src.OptionState) (* 196 *))))
    | :? ScriptDom.OrderByClause as src ->
      TSqlFragment.OrderByClause((src.OrderByElements |> Seq.map (fun src -> ExpressionWithSortOrder.ExpressionWithSortOrder((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SortOrder) (* 196 *))) |> List.ofSeq))
    | :? ScriptDom.OutputClause as src ->
      TSqlFragment.OutputClause((src.SelectColumns |> Seq.map (SelectElement.FromTs) |> List.ofSeq))
    | :? ScriptDom.OutputIntoClause as src ->
      TSqlFragment.OutputIntoClause((src.IntoTable |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.IntoTableColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.SelectColumns |> Seq.map (SelectElement.FromTs) |> List.ofSeq))
    | :? ScriptDom.OverClause as src ->
      TSqlFragment.OverClause((src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.Partitions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.WindowFrameClause |> Option.ofObj |> Option.map (WindowFrameClause.FromTs)) (* 193 *))
    | :? ScriptDom.PartitionParameterType as src ->
      TSqlFragment.PartitionParameterType((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))
    | :? ScriptDom.PartitionSpecifier as src ->
      TSqlFragment.PartitionSpecifier((src.All) (* 196 *), (src.Number |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.PayloadOption as src ->
      match src with
      | :? ScriptDom.AuthenticationPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.AuthenticationPayloadOption((src.Certificate |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Protocol) (* 196 *), (src.TryCertificateFirst) (* 196 *))))
      | :? ScriptDom.CharacterSetPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.CharacterSetPayloadOption((src.IsSql) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.EnabledDisabledPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.EnabledDisabledPayloadOption((src.IsEnabled) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.EncryptionPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.EncryptionPayloadOption((src.AlgorithmPartOne) (* 196 *), (src.AlgorithmPartTwo) (* 196 *), (src.EncryptionSupport) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.LiteralPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.LiteralPayloadOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.LoginTypePayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.LoginTypePayloadOption((src.IsWindows) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.RolePayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.RolePayloadOption((src.Kind) (* 196 *), (src.Role) (* 196 *))))
      | :? ScriptDom.SchemaPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.SchemaPayloadOption((src.IsStandard) (* 196 *), (src.Kind) (* 196 *))))
      | :? ScriptDom.SessionTimeoutPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.SessionTimeoutPayloadOption((src.IsNever) (* 196 *), (src.Kind) (* 196 *), (src.Timeout |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.SoapMethod as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.SoapMethod((src.Action) (* 196 *), (src.Alias |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Format) (* 196 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Namespace |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Schema) (* 196 *))))
      | :? ScriptDom.WsdlPayloadOption as src-> (* 274 *)
        TSqlFragment.PayloadOption((PayloadOption.WsdlPayloadOption((src.IsNone) (* 196 *), (src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.Permission as src ->
      TSqlFragment.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))
    | :? ScriptDom.PrincipalOption as src ->
      match src with
      | :? ScriptDom.IdentifierPrincipalOption as src-> (* 274 *)
        TSqlFragment.PrincipalOption((PrincipalOption.IdentifierPrincipalOption((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.LiteralPrincipalOption as src-> (* 274 *)
        TSqlFragment.PrincipalOption((PrincipalOption.LiteralPrincipalOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OnOffPrincipalOption as src-> (* 274 *)
        TSqlFragment.PrincipalOption((PrincipalOption.OnOffPrincipalOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.PasswordAlterPrincipalOption as src-> (* 274 *)
        TSqlFragment.PrincipalOption((PrincipalOption.PasswordAlterPrincipalOption((src.Hashed) (* 196 *), (src.MustChange) (* 196 *), (src.OldPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unlock) (* 196 *))))
      | _ -> (* :? ScriptDom.PrincipalOption as src *)
        TSqlFragment.PrincipalOption((PrincipalOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.Privilege80 as src ->
      TSqlFragment.Privilege80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrivilegeType80) (* 196 *))
    | :? ScriptDom.ProcedureOption as src ->
      match src with
      | :? ScriptDom.ExecuteAsProcedureOption as src-> (* 274 *)
        TSqlFragment.ProcedureOption((ProcedureOption.ExecuteAsProcedureOption((src.ExecuteAs |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.ProcedureOption as src *)
        TSqlFragment.ProcedureOption((ProcedureOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.ProcedureReference as src ->
      TSqlFragment.ProcedureReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Number |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ProcedureReferenceName as src ->
      TSqlFragment.ProcedureReferenceName((src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.ProcedureVariable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.QueryExpression as src ->
      match src with
      | :? ScriptDom.BinaryQueryExpression as src-> (* 274 *)
        TSqlFragment.QueryExpression((QueryExpression.BinaryQueryExpression((src.All) (* 196 *), (src.BinaryQueryExpressionType) (* 196 *), (src.FirstQueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.SecondQueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.QueryParenthesisExpression as src-> (* 274 *)
        TSqlFragment.QueryExpression((QueryExpression.QueryParenthesisExpression((src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.QuerySpecification as src-> (* 274 *)
        TSqlFragment.QueryExpression((QueryExpression.QuerySpecification((src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.GroupByClause |> Option.ofObj |> Option.map (GroupByClause.FromTs)) (* 193 *), (src.HavingClause |> Option.ofObj |> Option.map (HavingClause.FromTs)) (* 193 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.SelectElements |> Seq.map (SelectElement.FromTs) |> List.ofSeq), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.UniqueRowFilter) (* 196 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))))
    | :? ScriptDom.QueryStoreOption as src ->
      match src with
      | :? ScriptDom.QueryStoreCapturePolicyOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreCapturePolicyOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.QueryStoreDataFlushIntervalOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreDataFlushIntervalOption((src.FlushInterval |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.QueryStoreDesiredStateOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreDesiredStateOption((src.OperationModeSpecified) (* 196 *), (src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.QueryStoreIntervalLengthOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreIntervalLengthOption((src.OptionKind) (* 196 *), (src.StatsIntervalLength |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.QueryStoreMaxPlansPerQueryOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreMaxPlansPerQueryOption((src.MaxPlansPerQuery |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.QueryStoreMaxStorageSizeOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreMaxStorageSizeOption((src.MaxQdsSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.QueryStoreSizeCleanupPolicyOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreSizeCleanupPolicyOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.QueryStoreTimeCleanupPolicyOption as src-> (* 274 *)
        TSqlFragment.QueryStoreOption((QueryStoreOption.QueryStoreTimeCleanupPolicyOption((src.OptionKind) (* 196 *), (src.StaleQueryThreshold |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.QueueOption as src ->
      match src with
      | :? ScriptDom.QueueExecuteAsOption as src-> (* 274 *)
        TSqlFragment.QueueOption((QueueOption.QueueExecuteAsOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *))))
      | :? ScriptDom.QueueProcedureOption as src-> (* 274 *)
        TSqlFragment.QueueOption((QueueOption.QueueProcedureOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.QueueStateOption as src-> (* 274 *)
        TSqlFragment.QueueOption((QueueOption.QueueStateOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.QueueValueOption as src-> (* 274 *)
        TSqlFragment.QueueOption((QueueOption.QueueValueOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.QueueOption as src *)
        TSqlFragment.QueueOption((QueueOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.RemoteDataArchiveDatabaseSetting as src ->
      match src with
      | :? ScriptDom.RemoteDataArchiveDbCredentialSetting as src-> (* 274 *)
        TSqlFragment.RemoteDataArchiveDatabaseSetting((RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbCredentialSetting((src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SettingKind) (* 196 *))))
      | :? ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting as src-> (* 274 *)
        TSqlFragment.RemoteDataArchiveDatabaseSetting((RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbFederatedServiceAccountSetting((src.IsOn) (* 196 *), (src.SettingKind) (* 196 *))))
      | :? ScriptDom.RemoteDataArchiveDbServerSetting as src-> (* 274 *)
        TSqlFragment.RemoteDataArchiveDatabaseSetting((RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbServerSetting((src.Server |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SettingKind) (* 196 *))))
    | :? ScriptDom.RemoteServiceBindingOption as src ->
      match src with
      | :? ScriptDom.OnOffRemoteServiceBindingOption as src-> (* 274 *)
        TSqlFragment.RemoteServiceBindingOption((RemoteServiceBindingOption.OnOffRemoteServiceBindingOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.UserRemoteServiceBindingOption as src-> (* 274 *)
        TSqlFragment.RemoteServiceBindingOption((RemoteServiceBindingOption.UserRemoteServiceBindingOption((src.OptionKind) (* 196 *), (src.User |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ResourcePoolAffinitySpecification as src ->
      TSqlFragment.ResourcePoolAffinitySpecification((src.AffinityType) (* 196 *), (src.IsAuto) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.PoolAffinityRanges |> Seq.map (LiteralRange.FromTs) |> List.ofSeq))
    | :? ScriptDom.ResourcePoolParameter as src ->
      TSqlFragment.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.RestoreOption as src ->
      match src with
      | :? ScriptDom.FileStreamRestoreOption as src-> (* 274 *)
        TSqlFragment.RestoreOption((RestoreOption.FileStreamRestoreOption((src.FileStreamOption |> Option.ofObj |> Option.map (FileStreamDatabaseOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.MoveRestoreOption as src-> (* 274 *)
        TSqlFragment.RestoreOption((RestoreOption.MoveRestoreOption((src.LogicalFileName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OSFileName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.ScalarExpressionRestoreOption as src-> (* 274 *)
        TSqlFragment.RestoreOption((RestoreOption.ScalarExpressionRestoreOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.StopRestoreOption as src-> (* 274 *)
        TSqlFragment.RestoreOption((RestoreOption.StopRestoreOption((src.After |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.IsStopAt) (* 196 *), (src.Mark |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.RestoreOption as src *)
        TSqlFragment.RestoreOption((RestoreOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.ResultColumnDefinition as src ->
      TSqlFragment.ResultColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))
    | :? ScriptDom.ResultSetDefinition as src ->
      match src with
      | :? ScriptDom.InlineResultSetDefinition as src-> (* 274 *)
        TSqlFragment.ResultSetDefinition((ResultSetDefinition.InlineResultSetDefinition((src.ResultColumnDefinitions |> Seq.map (fun src -> ResultColumnDefinition.ResultColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))) |> List.ofSeq), (src.ResultSetType) (* 196 *))))
      | :? ScriptDom.SchemaObjectResultSetDefinition as src-> (* 274 *)
        TSqlFragment.ResultSetDefinition((ResultSetDefinition.SchemaObjectResultSetDefinition((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ResultSetType) (* 196 *))))
      | _ -> (* :? ScriptDom.ResultSetDefinition as src *)
        TSqlFragment.ResultSetDefinition((ResultSetDefinition.Base((src.ResultSetType) (* 196 *))))
    | :? ScriptDom.RouteOption as src ->
      TSqlFragment.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.RowValue as src ->
      TSqlFragment.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.ScalarExpression as src ->
      match src with
      | :? ScriptDom.BinaryExpression as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.BinaryExpression((src.BinaryExpressionType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ExtractFromExpression as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.ExtractFromExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ExtractedElement |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.IdentityFunctionCall as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.IdentityFunctionCall((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Increment |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Seed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.OdbcConvertSpecification as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.OdbcConvertSpecification((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.PrimaryExpression as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.PrimaryExpression((PrimaryExpression.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ScalarExpressionSnippet as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.ScalarExpressionSnippet((Option.ofObj (src.Script)) (* 198 *))))
      | :? ScriptDom.SourceDeclaration as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.SourceDeclaration((src.Value |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))))
      | :? ScriptDom.UnaryExpression as src-> (* 274 *)
        TSqlFragment.ScalarExpression((ScalarExpression.UnaryExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.UnaryExpressionType) (* 196 *))))
    | :? ScriptDom.SchemaDeclarationItem as src ->
      match src with
      | :? ScriptDom.SchemaDeclarationItemOpenjson as src-> (* 274 *)
        TSqlFragment.SchemaDeclarationItem((SchemaDeclarationItem.SchemaDeclarationItemOpenjson((src.AsJson) (* 196 *), (src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.SchemaDeclarationItem as src *)
        TSqlFragment.SchemaDeclarationItem((SchemaDeclarationItem.Base((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.SchemaObjectNameOrValueExpression as src ->
      TSqlFragment.SchemaObjectNameOrValueExpression((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SearchPropertyListAction as src ->
      match src with
      | :? ScriptDom.AddSearchPropertyListAction as src-> (* 274 *)
        TSqlFragment.SearchPropertyListAction((SearchPropertyListAction.AddSearchPropertyListAction((src.Description |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Guid |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Id |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.DropSearchPropertyListAction as src-> (* 274 *)
        TSqlFragment.SearchPropertyListAction((SearchPropertyListAction.DropSearchPropertyListAction((src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
    | :? ScriptDom.SecurityElement80 as src ->
      match src with
      | :? ScriptDom.CommandSecurityElement80 as src-> (* 274 *)
        TSqlFragment.SecurityElement80((SecurityElement80.CommandSecurityElement80((src.All) (* 196 *), (src.CommandOptions) (* 196 *))))
      | :? ScriptDom.PrivilegeSecurityElement80 as src-> (* 274 *)
        TSqlFragment.SecurityElement80((SecurityElement80.PrivilegeSecurityElement80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Privileges |> Seq.map (fun src -> Privilege80.Privilege80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrivilegeType80) (* 196 *))) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.SecurityPolicyOption as src ->
      TSqlFragment.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.SecurityPredicateAction as src ->
      TSqlFragment.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.SecurityPrincipal as src ->
      TSqlFragment.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))
    | :? ScriptDom.SecurityTargetObject as src ->
      TSqlFragment.SecurityTargetObject((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ObjectKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SecurityTargetObjectName.FromTs)) (* 193 *))
    | :? ScriptDom.SecurityTargetObjectName as src ->
      TSqlFragment.SecurityTargetObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
    | :? ScriptDom.SecurityUserClause80 as src ->
      TSqlFragment.SecurityUserClause80((src.UserType80) (* 196 *), (src.Users |> Seq.map (Identifier.FromTs) |> List.ofSeq))
    | :? ScriptDom.SelectElement as src ->
      match src with
      | :? ScriptDom.SelectScalarExpression as src-> (* 274 *)
        TSqlFragment.SelectElement((SelectElement.SelectScalarExpression((src.ColumnName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SelectSetVariable as src-> (* 274 *)
        TSqlFragment.SelectElement((SelectElement.SelectSetVariable((src.AssignmentKind) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
      | :? ScriptDom.SelectStarExpression as src-> (* 274 *)
        TSqlFragment.SelectElement((SelectElement.SelectStarExpression((src.Qualifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))))
    | :? ScriptDom.SelectiveXmlIndexPromotedPath as src ->
      TSqlFragment.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.SequenceOption as src ->
      match src with
      | :? ScriptDom.DataTypeSequenceOption as src-> (* 274 *)
        TSqlFragment.SequenceOption((SequenceOption.DataTypeSequenceOption((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.NoValue) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.ScalarExpressionSequenceOption as src-> (* 274 *)
        TSqlFragment.SequenceOption((SequenceOption.ScalarExpressionSequenceOption((src.NoValue) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.SequenceOption as src *)
        TSqlFragment.SequenceOption((SequenceOption.Base((src.NoValue) (* 196 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.ServiceContract as src ->
      TSqlFragment.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.SessionOption as src ->
      match src with
      | :? ScriptDom.EventRetentionSessionOption as src-> (* 274 *)
        TSqlFragment.SessionOption((SessionOption.EventRetentionSessionOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.LiteralSessionOption as src-> (* 274 *)
        TSqlFragment.SessionOption((SessionOption.LiteralSessionOption((src.OptionKind) (* 196 *), (src.Unit) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.MaxDispatchLatencySessionOption as src-> (* 274 *)
        TSqlFragment.SessionOption((SessionOption.MaxDispatchLatencySessionOption((src.IsInfinite) (* 196 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.MemoryPartitionSessionOption as src-> (* 274 *)
        TSqlFragment.SessionOption((SessionOption.MemoryPartitionSessionOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.OnOffSessionOption as src-> (* 274 *)
        TSqlFragment.SessionOption((SessionOption.OnOffSessionOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
    | :? ScriptDom.SetClause as src ->
      match src with
      | :? ScriptDom.AssignmentSetClause as src-> (* 274 *)
        TSqlFragment.SetClause((SetClause.AssignmentSetClause((src.AssignmentKind) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.NewValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
      | :? ScriptDom.FunctionCallSetClause as src-> (* 274 *)
        TSqlFragment.SetClause((SetClause.FunctionCallSetClause((src.MutatorFunction |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *))))
    | :? ScriptDom.SetCommand as src ->
      match src with
      | :? ScriptDom.GeneralSetCommand as src-> (* 274 *)
        TSqlFragment.SetCommand((SetCommand.GeneralSetCommand((src.CommandType) (* 196 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SetFipsFlaggerCommand as src-> (* 274 *)
        TSqlFragment.SetCommand((SetCommand.SetFipsFlaggerCommand((src.ComplianceLevel) (* 196 *))))
    | :? ScriptDom.SpatialIndexOption as src ->
      match src with
      | :? ScriptDom.BoundingBoxSpatialIndexOption as src-> (* 274 *)
        TSqlFragment.SpatialIndexOption((SpatialIndexOption.BoundingBoxSpatialIndexOption((src.BoundingBoxParameters |> Seq.map (fun src -> BoundingBoxParameter.BoundingBoxParameter((src.Parameter) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.CellsPerObjectSpatialIndexOption as src-> (* 274 *)
        TSqlFragment.SpatialIndexOption((SpatialIndexOption.CellsPerObjectSpatialIndexOption((src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.GridsSpatialIndexOption as src-> (* 274 *)
        TSqlFragment.SpatialIndexOption((SpatialIndexOption.GridsSpatialIndexOption((src.GridParameters |> Seq.map (fun src -> GridParameter.GridParameter((src.Parameter) (* 196 *), (src.Value) (* 196 *))) |> List.ofSeq))))
      | :? ScriptDom.SpatialIndexRegularOption as src-> (* 274 *)
        TSqlFragment.SpatialIndexOption((SpatialIndexOption.SpatialIndexRegularOption((src.Option |> Option.ofObj |> Option.map (IndexOption.FromTs)) (* 191 *))))
    | :? ScriptDom.StatementList as src ->
      match src with
      | :? ScriptDom.StatementListSnippet as src-> (* 274 *)
        TSqlFragment.StatementList((StatementList.StatementListSnippet((Option.ofObj (src.Script)) (* 198 *), (src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.StatementList as src *)
        TSqlFragment.StatementList((StatementList.Base((src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))))
    | :? ScriptDom.StatisticsOption as src ->
      match src with
      | :? ScriptDom.LiteralStatisticsOption as src-> (* 274 *)
        TSqlFragment.StatisticsOption((StatisticsOption.LiteralStatisticsOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.OnOffStatisticsOption as src-> (* 274 *)
        TSqlFragment.StatisticsOption((StatisticsOption.OnOffStatisticsOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.ResampleStatisticsOption as src-> (* 274 *)
        TSqlFragment.StatisticsOption((StatisticsOption.ResampleStatisticsOption((src.OptionKind) (* 196 *), (src.Partitions |> Seq.map (fun src -> StatisticsPartitionRange.StatisticsPartitionRange((src.From |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.To |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.StatisticsOption as src *)
        TSqlFragment.StatisticsOption((StatisticsOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.StatisticsPartitionRange as src ->
      TSqlFragment.StatisticsPartitionRange((src.From |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.To |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.SystemTimePeriodDefinition as src ->
      TSqlFragment.SystemTimePeriodDefinition((src.EndTimeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StartTimeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.TSqlBatch as src ->
      TSqlFragment.TSqlBatch((src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))
    | :? ScriptDom.TSqlFragmentSnippet as src ->
      TSqlFragment.TSqlFragmentSnippet((Option.ofObj (src.Script)) (* 198 *))
    | :? ScriptDom.TSqlScript as src ->
      TSqlFragment.TSqlScript((src.Batches |> Seq.map (fun src -> TSqlBatch.TSqlBatch((src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))) |> List.ofSeq))
    | :? ScriptDom.TSqlStatement as src ->
      match src with
      | :? ScriptDom.AlterAsymmetricKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterAsymmetricKeyStatement((src.AttestedBy |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterAuthorizationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterAuthorizationStatement((src.PrincipalName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *), (src.ToSchemaOwner) (* 196 *))))
      | :? ScriptDom.AlterCreateEndpointStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterCreateEndpointStatementBase((AlterCreateEndpointStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterCreateServiceStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterCreateServiceStatementBase((AlterCreateServiceStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterCryptographicProviderStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterCryptographicProviderStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Option) (* 196 *))))
      | :? ScriptDom.AlterDatabaseScopedConfigurationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterDatabaseScopedConfigurationStatement((AlterDatabaseScopedConfigurationStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterDatabaseStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterFederationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterFederationStatement((src.Boundary |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterFullTextIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterFullTextIndexStatement((src.Action |> Option.ofObj |> Option.map (AlterFullTextIndexAction.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterFullTextStopListStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterFullTextStopListStatement((src.Action |> Option.ofObj |> Option.map (FullTextStopListAction.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterLoginStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterLoginStatement((AlterLoginStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterPartitionFunctionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterPartitionFunctionStatement((src.Boundary |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsSplit) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterPartitionSchemeStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterPartitionSchemeStatement((src.FileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterResourceGovernorStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterResourceGovernorStatement((src.ClassifierFunction |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Command) (* 196 *))))
      | :? ScriptDom.AlterSchemaStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterSchemaStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ObjectKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterSearchPropertyListStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterSearchPropertyListStatement((src.Action |> Option.ofObj |> Option.map (SearchPropertyListAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationSetBufferPoolExtensionStatement((src.Options |> Seq.map (AlterServerConfigurationBufferPoolExtensionOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationSetDiagnosticsLogStatement((src.Options |> Seq.map (AlterServerConfigurationDiagnosticsLogOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationSetFailoverClusterPropertyStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationFailoverClusterPropertyOption.AlterServerConfigurationFailoverClusterPropertyOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationSetHadrClusterStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationSetHadrClusterStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationHadrClusterOption.AlterServerConfigurationHadrClusterOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationSetSoftNumaStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationSetSoftNumaStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationSoftNumaOption.AlterServerConfigurationSoftNumaOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.AlterServerConfigurationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServerConfigurationStatement((src.ProcessAffinity) (* 196 *), (src.ProcessAffinityRanges |> Seq.map (fun src -> ProcessAffinityRange.ProcessAffinityRange((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.AlterServiceMasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterServiceMasterKeyStatement((src.Account |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterTableStatement((AlterTableStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AlterXmlSchemaCollectionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AlterXmlSchemaCollectionStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.ApplicationRoleStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ApplicationRoleStatement((ApplicationRoleStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AssemblyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AssemblyStatement((AssemblyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AuditSpecificationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AuditSpecificationStatement((AuditSpecificationStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.AvailabilityGroupStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.AvailabilityGroupStatement((AvailabilityGroupStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.BackupRestoreMasterKeyStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BackupRestoreMasterKeyStatementBase((BackupRestoreMasterKeyStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.BackupStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BackupStatement((BackupStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.BeginConversationTimerStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BeginConversationTimerStatement((src.Handle |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BeginDialogStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BeginDialogStatement((src.ContractName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Handle |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.InitiatorServiceName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.InstanceSpec |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.IsConversation) (* 196 *), (src.Options |> Seq.map (DialogOption.FromTs) |> List.ofSeq), (src.TargetServiceName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.BeginEndBlockStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BeginEndBlockStatement((BeginEndBlockStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.BreakStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BreakStatement))
      | :? ScriptDom.BrokerPriorityStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BrokerPriorityStatement((BrokerPriorityStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.BulkInsertBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.BulkInsertBase((BulkInsertBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CertificateStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CertificateStatementBase((CertificateStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CheckpointStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CheckpointStatement((src.Duration |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.CloseMasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CloseMasterKeyStatement))
      | :? ScriptDom.CloseSymmetricKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CloseSymmetricKeyStatement((src.All) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.ColumnEncryptionKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ColumnEncryptionKeyStatement((ColumnEncryptionKeyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ContinueStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ContinueStatement))
      | :? ScriptDom.CreateAggregateStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateAggregateStatement((src.AssemblyName |> Option.ofObj |> Option.map (AssemblyName.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateAsymmetricKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateAsymmetricKeyStatement((src.EncryptionAlgorithm) (* 196 *), (src.KeySource |> Option.ofObj |> Option.map (EncryptionSource.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateColumnMasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateColumnMasterKeyStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ColumnMasterKeyParameter.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateColumnStoreIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateColumnStoreIndexStatement((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateContractStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateContractStatement((src.Messages |> Seq.map (fun src -> ContractMessage.ContractMessage((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SentBy) (* 196 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateCryptographicProviderStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateCryptographicProviderStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateDatabaseStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateDatabaseStatement((src.AttachMode) (* 196 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Containment |> Option.ofObj |> Option.map (ContainmentDatabaseOption.FromTs)) (* 193 *), (src.CopyOf |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseSnapshot |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroups |> Seq.map (fun src -> FileGroupDefinition.FileGroupDefinition((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.LogOn |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (DatabaseOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateDefaultStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateDefaultStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateEventNotificationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateEventNotificationStatement((src.BrokerInstanceSpecifier |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.BrokerService |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EventTypeGroups |> Seq.map (EventTypeGroupContainer.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Scope |> Option.ofObj |> Option.map (EventNotificationObjectScope.FromTs)) (* 193 *), (src.WithFanIn) (* 196 *))))
      | :? ScriptDom.CreateFederationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateFederationStatement((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateFullTextIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateFullTextIndexStatement((src.CatalogAndFileGroup |> Option.ofObj |> Option.map (FullTextCatalogAndFileGroup.FromTs)) (* 193 *), (src.FullTextIndexColumns |> Seq.map (fun src -> FullTextIndexColumn.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.KeyIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextIndexOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateFullTextStopListStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateFullTextStopListStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsSystemStopList) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SourceStopListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateLoginStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateLoginStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Source |> Option.ofObj |> Option.map (CreateLoginSource.FromTs)) (* 191 *))))
      | :? ScriptDom.CreatePartitionFunctionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreatePartitionFunctionStatement((src.BoundaryValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterType |> Option.ofObj |> Option.map (PartitionParameterType.FromTs)) (* 193 *), (src.Range) (* 196 *))))
      | :? ScriptDom.CreatePartitionSchemeStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreatePartitionSchemeStatement((src.FileGroups |> Seq.map (fun src -> IdentifierOrValueExpression.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.IsAll) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PartitionFunction |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateRuleStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateRuleStatement((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateSchemaStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateSchemaStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateSearchPropertyListStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateSearchPropertyListStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SourceSearchPropertyList |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateSpatialIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateSpatialIndexStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OnFileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.SpatialColumnName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SpatialIndexOptions |> Seq.map (SpatialIndexOption.FromTs) |> List.ofSeq), (src.SpatialIndexingScheme) (* 196 *))))
      | :? ScriptDom.CreateStatisticsStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateStatisticsStatement((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StatisticsOptions |> Seq.map (StatisticsOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateSynonymStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateSynonymStatement((src.ForName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateTableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateTableStatement((src.AsFileTable) (* 196 *), (src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.FederationScheme |> Option.ofObj |> Option.map (FederationScheme.FromTs)) (* 193 *), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TextImageOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.CreateTypeStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateTypeStatement((CreateTypeStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CreateXmlSchemaCollectionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CreateXmlSchemaCollectionStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CredentialStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CredentialStatement((CredentialStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CursorStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.CursorStatement((CursorStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.DatabaseEncryptionKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DatabaseEncryptionKeyStatement((DatabaseEncryptionKeyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.DbccStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DbccStatement((src.Command) (* 196 *), (Option.ofObj (src.DllName)) (* 198 *), (src.Literals |> Seq.map (fun src -> DbccNamedLiteral.DbccNamedLiteral((Option.ofObj (src.Name)) (* 198 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Options |> Seq.map (fun src -> DbccOption.DbccOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.OptionsUseJoin) (* 196 *), (src.ParenthesisRequired) (* 196 *))))
      | :? ScriptDom.DeclareCursorStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DeclareCursorStatement((src.CursorDefinition |> Option.ofObj |> Option.map (CursorDefinition.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DeclareTableVariableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DeclareTableVariableStatement((src.Body |> Option.ofObj |> Option.map (DeclareTableVariableBody.FromTs)) (* 193 *))))
      | :? ScriptDom.DeclareVariableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DeclareVariableStatement((src.Declarations |> Seq.map (DeclareVariableElement.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DiskStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DiskStatement((src.DiskStatementType) (* 196 *), (src.Options |> Seq.map (fun src -> DiskStatementOption.DiskStatementOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq))))
      | :? ScriptDom.DropChildObjectsStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropChildObjectsStatement((DropChildObjectsStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.DropDatabaseEncryptionKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropDatabaseEncryptionKeyStatement))
      | :? ScriptDom.DropDatabaseStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropDatabaseStatement((src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *))))
      | :? ScriptDom.DropEventNotificationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropEventNotificationStatement((src.Notifications |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Scope |> Option.ofObj |> Option.map (EventNotificationObjectScope.FromTs)) (* 193 *))))
      | :? ScriptDom.DropFullTextIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropFullTextIndexStatement((src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.DropIndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropIndexStatement((src.DropIndexClauses |> Seq.map (DropIndexClauseBase.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *))))
      | :? ScriptDom.DropMasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropMasterKeyStatement))
      | :? ScriptDom.DropObjectsStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropObjectsStatement((DropObjectsStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.DropQueueStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.DropSchemaStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropSchemaStatement((src.DropBehavior) (* 196 *), (src.IsIfExists) (* 196 *), (src.Schema |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.DropTypeStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropTypeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.DropUnownedObjectStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.DropXmlSchemaCollectionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.DropXmlSchemaCollectionStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.EnableDisableTriggerStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.EnableDisableTriggerStatement((src.All) (* 196 *), (src.TriggerEnforcement) (* 196 *), (src.TriggerNames |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *))))
      | :? ScriptDom.EndConversationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.EndConversationStatement((src.Conversation |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ErrorCode |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.ErrorDescription |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.WithCleanup) (* 196 *))))
      | :? ScriptDom.EventSessionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.EventSessionStatement((EventSessionStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ExecuteAsStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExecuteAsStatement((src.Cookie |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.ExecuteContext |> Option.ofObj |> Option.map (ExecuteContext.FromTs)) (* 193 *), (src.WithNoRevert) (* 196 *))))
      | :? ScriptDom.ExecuteStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExecuteStatement((src.ExecuteSpecification |> Option.ofObj |> Option.map (ExecuteSpecification.FromTs)) (* 193 *), (src.Options |> Seq.map (ExecuteOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ExternalDataSourceStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExternalDataSourceStatement((ExternalDataSourceStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ExternalFileFormatStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExternalFileFormatStatement((ExternalFileFormatStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ExternalResourcePoolStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExternalResourcePoolStatement((ExternalResourcePoolStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ExternalTableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ExternalTableStatement((ExternalTableStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.FullTextCatalogStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.FullTextCatalogStatement((FullTextCatalogStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.GoToStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.GoToStatement((src.LabelName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.IfStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.IfStatement((src.ElseStatement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *), (src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ThenStatement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *))))
      | :? ScriptDom.IndexDefinition as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.IndexDefinition((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Unique) (* 196 *))))
      | :? ScriptDom.IndexStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.IndexStatement((IndexStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.KillQueryNotificationSubscriptionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.KillQueryNotificationSubscriptionStatement((src.All) (* 196 *), (src.SubscriptionId |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.KillStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.KillStatement((src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WithStatusOnly) (* 196 *))))
      | :? ScriptDom.KillStatsJobStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.KillStatsJobStatement((src.JobId |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.LabelStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.LabelStatement((Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.LineNoStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.LineNoStatement((src.LineNo |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.MasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.MasterKeyStatement((MasterKeyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.MessageTypeStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.MessageTypeStatementBase((MessageTypeStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.MoveConversationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.MoveConversationStatement((src.Conversation |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Group |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.OpenMasterKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.OpenMasterKeyStatement((src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.OpenSymmetricKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.OpenSymmetricKeyStatement((src.DecryptionMechanism |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.PrintStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.PrintStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ProcedureStatementBodyBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ProcedureStatementBodyBase((ProcedureStatementBodyBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.QueueStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.QueueStatement((QueueStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.RaiseErrorLegacyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RaiseErrorLegacyStatement((src.FirstParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.RaiseErrorStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RaiseErrorStatement((src.FirstParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionalParameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.RaiseErrorOptions) (* 196 *), (src.SecondParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ThirdParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ReadTextStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ReadTextStatement((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.HoldLock) (* 196 *), (src.Offset |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Size |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextPointer |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ReconfigureStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ReconfigureStatement((src.WithOverride) (* 196 *))))
      | :? ScriptDom.RemoteServiceBindingStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RemoteServiceBindingStatementBase((RemoteServiceBindingStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ResourcePoolStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ResourcePoolStatement((ResourcePoolStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.RestoreStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RestoreStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Files |> Seq.map (fun src -> BackupRestoreFileInfo.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Kind) (* 196 *), (src.Options |> Seq.map (RestoreOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ReturnStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ReturnStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.RevertStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RevertStatement((src.Cookie |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.RoleStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RoleStatement((RoleStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.RouteStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.RouteStatement((RouteStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SecurityPolicyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SecurityPolicyStatement((SecurityPolicyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SecurityStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SecurityStatement((SecurityStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SecurityStatementBody80 as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SecurityStatementBody80((SecurityStatementBody80.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SendStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SendStatement((src.ConversationHandles |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.MessageBody |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.MessageTypeName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.SequenceStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SequenceStatement((SequenceStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ServerAuditStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ServerAuditStatement((ServerAuditStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SetCommandStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetCommandStatement((src.Commands |> Seq.map (SetCommand.FromTs) |> List.ofSeq))))
      | :? ScriptDom.SetErrorLevelStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetErrorLevelStatement((src.Level |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SetOnOffStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetOnOffStatement((SetOnOffStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SetRowCountStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetRowCountStatement((src.NumberRows |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SetTextSizeStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetTextSizeStatement((src.TextSize |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SetTransactionIsolationLevelStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetTransactionIsolationLevelStatement((src.Level) (* 196 *))))
      | :? ScriptDom.SetUserStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetUserStatement((src.UserName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.WithNoReset) (* 196 *))))
      | :? ScriptDom.SetVariableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SetVariableStatement((src.AssignmentKind) (* 196 *), (src.CursorDefinition |> Option.ofObj |> Option.map (CursorDefinition.FromTs)) (* 193 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FunctionCallExists) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.SeparatorType) (* 196 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
      | :? ScriptDom.ShutdownStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ShutdownStatement((src.WithNoWait) (* 196 *))))
      | :? ScriptDom.SignatureStatementBase as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SignatureStatementBase((SignatureStatementBase.FromTs(src))) (* 251 *)))
      | :? ScriptDom.StatementWithCtesAndXmlNamespaces as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.StatementWithCtesAndXmlNamespaces((StatementWithCtesAndXmlNamespaces.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SymmetricKeyStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.SymmetricKeyStatement((SymmetricKeyStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.TSqlStatementSnippet as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TSqlStatementSnippet((Option.ofObj (src.Script)) (* 198 *))))
      | :? ScriptDom.TextModificationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TextModificationStatement((TextModificationStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ThrowStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ThrowStatement((src.ErrorNumber |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Message |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.State |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.TransactionStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TransactionStatement((TransactionStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.TriggerStatementBody as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TriggerStatementBody((TriggerStatementBody.FromTs(src))) (* 251 *)))
      | :? ScriptDom.TruncateTableStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TruncateTableStatement((src.PartitionRanges |> Seq.map (fun src -> CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.TryCatchStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.TryCatchStatement((src.CatchStatements |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TryStatements |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
      | :? ScriptDom.UpdateStatisticsStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.UpdateStatisticsStatement((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StatisticsOptions |> Seq.map (StatisticsOption.FromTs) |> List.ofSeq), (src.SubElements |> Seq.map (Identifier.FromTs) |> List.ofSeq))))
      | :? ScriptDom.UseFederationStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.UseFederationStatement((src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FederationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Filtering) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.UseStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.UseStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.UserStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.UserStatement((UserStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ViewStatementBody as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.ViewStatementBody((ViewStatementBody.FromTs(src))) (* 251 *)))
      | :? ScriptDom.WaitForStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.WaitForStatement((src.Parameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Statement |> Option.ofObj |> Option.map (WaitForSupportedStatement.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WaitForOption) (* 196 *))))
      | :? ScriptDom.WaitForSupportedStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.WaitForSupportedStatement((WaitForSupportedStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.WhileStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.WhileStatement((src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Statement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *))))
      | :? ScriptDom.WorkloadGroupStatement as src-> (* 274 *)
        TSqlFragment.TSqlStatement((TSqlStatement.WorkloadGroupStatement((WorkloadGroupStatement.FromTs(src))) (* 251 *)))
    | :? ScriptDom.TableDefinition as src ->
      TSqlFragment.TableDefinition((src.ColumnDefinitions |> Seq.map (fun src -> ColumnDefinition.ColumnDefinition((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ComputedColumnExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Constraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DefaultConstraint |> Option.ofObj |> Option.map (DefaultConstraintDefinition.FromTs)) (* 193 *), (src.Encryption |> Option.ofObj |> Option.map (ColumnEncryptionDefinition.FromTs)) (* 193 *), (Option.ofNullable (src.GeneratedAlways)), (src.IdentityOptions |> Option.ofObj |> Option.map (IdentityOptions.FromTs)) (* 193 *), (src.Index |> Option.ofObj |> Option.map (IndexDefinition.FromTs)) (* 193 *), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.IsPersisted) (* 196 *), (src.IsRowGuidCol) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))) |> List.ofSeq), (src.Indexes |> Seq.map (fun src -> IndexDefinition.IndexDefinition((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Unique) (* 196 *))) |> List.ofSeq), (src.SystemTimePeriod |> Option.ofObj |> Option.map (SystemTimePeriodDefinition.FromTs)) (* 193 *), (src.TableConstraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq))
    | :? ScriptDom.TableHint as src ->
      match src with
      | :? ScriptDom.ForceSeekTableHint as src-> (* 274 *)
        TSqlFragment.TableHint((TableHint.ForceSeekTableHint((src.ColumnValues |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.HintKind) (* 196 *), (src.IndexValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.IndexTableHint as src-> (* 274 *)
        TSqlFragment.TableHint((TableHint.IndexTableHint((src.HintKind) (* 196 *), (src.IndexValues |> Seq.map (fun src -> IdentifierOrValueExpression.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.LiteralTableHint as src-> (* 274 *)
        TSqlFragment.TableHint((TableHint.LiteralTableHint((src.HintKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.TableHint as src *)
        TSqlFragment.TableHint((TableHint.Base((src.HintKind) (* 196 *))))
    | :? ScriptDom.TableOption as src ->
      match src with
      | :? ScriptDom.DurabilityTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.DurabilityTableOption((src.DurabilityTableOptionKind) (* 196 *), (src.OptionKind) (* 196 *))))
      | :? ScriptDom.FileStreamOnTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.FileStreamOnTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.FileTableCollateFileNameTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.FileTableCollateFileNameTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.FileTableConstraintNameTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.FileTableConstraintNameTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.FileTableDirectoryTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.FileTableDirectoryTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.LockEscalationTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.LockEscalationTableOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))))
      | :? ScriptDom.MemoryOptimizedTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.MemoryOptimizedTableOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.RemoteDataArchiveAlterTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.RemoteDataArchiveAlterTableOption((src.FilterPredicate |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.IsFilterPredicateSpecified) (* 196 *), (src.IsMigrationStateSpecified) (* 196 *), (src.MigrationState) (* 196 *), (src.OptionKind) (* 196 *), (src.RdaTableOption) (* 196 *))))
      | :? ScriptDom.RemoteDataArchiveTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.RemoteDataArchiveTableOption((src.MigrationState) (* 196 *), (src.OptionKind) (* 196 *), (src.RdaTableOption) (* 196 *))))
      | :? ScriptDom.SystemVersioningTableOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.SystemVersioningTableOption((src.ConsistencyCheckEnabled) (* 196 *), (src.HistoryTable |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | :? ScriptDom.TableDataCompressionOption as src-> (* 274 *)
        TSqlFragment.TableOption((TableOption.TableDataCompressionOption((src.DataCompressionOption |> Option.ofObj |> Option.map (DataCompressionOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.TableReference as src ->
      match src with
      | :? ScriptDom.JoinParenthesisTableReference as src-> (* 274 *)
        TSqlFragment.TableReference((TableReference.JoinParenthesisTableReference((src.Join |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))))
      | :? ScriptDom.JoinTableReference as src-> (* 274 *)
        TSqlFragment.TableReference((TableReference.JoinTableReference((JoinTableReference.FromTs(src))) (* 251 *)))
      | :? ScriptDom.OdbcQualifiedJoinTableReference as src-> (* 274 *)
        TSqlFragment.TableReference((TableReference.OdbcQualifiedJoinTableReference((src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))))
      | :? ScriptDom.TableReferenceWithAlias as src-> (* 274 *)
        TSqlFragment.TableReference((TableReference.TableReferenceWithAlias((TableReferenceWithAlias.FromTs(src))) (* 251 *)))
    | :? ScriptDom.TableSampleClause as src ->
      TSqlFragment.TableSampleClause((src.RepeatSeed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SampleNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.System) (* 196 *), (src.TableSampleClauseOption) (* 196 *))
    | :? ScriptDom.TableSwitchOption as src ->
      match src with
      | :? ScriptDom.LowPriorityLockWaitTableSwitchOption as src-> (* 274 *)
        TSqlFragment.TableSwitchOption((TableSwitchOption.LowPriorityLockWaitTableSwitchOption((src.OptionKind) (* 196 *), (src.Options |> Seq.map (LowPriorityLockWaitOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.TargetDeclaration as src ->
      TSqlFragment.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.TemporalClause as src ->
      TSqlFragment.TemporalClause((src.EndTime |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.StartTime |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TemporalClauseType) (* 196 *))
    | :? ScriptDom.TopRowFilter as src ->
      TSqlFragment.TopRowFilter((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Percent) (* 196 *), (src.WithTies) (* 196 *))
    | :? ScriptDom.TriggerAction as src ->
      TSqlFragment.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))
    | :? ScriptDom.TriggerObject as src ->
      TSqlFragment.TriggerObject((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TriggerScope) (* 196 *))
    | :? ScriptDom.TriggerOption as src ->
      match src with
      | :? ScriptDom.ExecuteAsTriggerOption as src-> (* 274 *)
        TSqlFragment.TriggerOption((TriggerOption.ExecuteAsTriggerOption((src.ExecuteAsClause |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.TriggerOption as src *)
        TSqlFragment.TriggerOption((TriggerOption.Base((src.OptionKind) (* 196 *))))
    | :? ScriptDom.UserLoginOption as src ->
      TSqlFragment.UserLoginOption((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserLoginOptionType) (* 196 *))
    | :? ScriptDom.VariableValuePair as src ->
      TSqlFragment.VariableValuePair((src.IsForUnknown) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.ViewOption as src ->
      TSqlFragment.ViewOption((src.OptionKind) (* 196 *))
    | :? ScriptDom.WhenClause as src ->
      match src with
      | :? ScriptDom.SearchedWhenClause as src-> (* 274 *)
        TSqlFragment.WhenClause((WhenClause.SearchedWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SimpleWhenClause as src-> (* 274 *)
        TSqlFragment.WhenClause((WhenClause.SimpleWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.WhereClause as src ->
      TSqlFragment.WhereClause((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.WindowDelimiter as src ->
      TSqlFragment.WindowDelimiter((src.OffsetValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WindowDelimiterType) (* 196 *))
    | :? ScriptDom.WindowFrameClause as src ->
      TSqlFragment.WindowFrameClause((src.Bottom |> Option.ofObj |> Option.map (WindowDelimiter.FromTs)) (* 193 *), (src.Top |> Option.ofObj |> Option.map (WindowDelimiter.FromTs)) (* 193 *), (src.WindowFrameType) (* 196 *))
    | :? ScriptDom.WithCtesAndXmlNamespaces as src ->
      TSqlFragment.WithCtesAndXmlNamespaces((src.ChangeTrackingContext |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.CommonTableExpressions |> Seq.map (fun src -> CommonTableExpression.CommonTableExpression((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExpressionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.WithinGroupClause as src ->
      TSqlFragment.WithinGroupClause((src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *))
    | :? ScriptDom.WorkloadGroupParameter as src ->
      match src with
      | :? ScriptDom.WorkloadGroupImportanceParameter as src-> (* 274 *)
        TSqlFragment.WorkloadGroupParameter((WorkloadGroupParameter.WorkloadGroupImportanceParameter((src.ParameterType) (* 196 *), (src.ParameterValue) (* 196 *))))
      | :? ScriptDom.WorkloadGroupResourceParameter as src-> (* 274 *)
        TSqlFragment.WorkloadGroupParameter((WorkloadGroupParameter.WorkloadGroupResourceParameter((src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.XmlNamespaces as src ->
      TSqlFragment.XmlNamespaces((src.XmlNamespacesElements |> Seq.map (XmlNamespacesElement.FromTs) |> List.ofSeq))
    | :? ScriptDom.XmlNamespacesElement as src ->
      match src with
      | :? ScriptDom.XmlNamespacesAliasElement as src-> (* 274 *)
        TSqlFragment.XmlNamespacesElement((XmlNamespacesElement.XmlNamespacesAliasElement((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.String |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.XmlNamespacesDefaultElement as src-> (* 274 *)
        TSqlFragment.XmlNamespacesElement((XmlNamespacesElement.XmlNamespacesDefaultElement((src.String |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
and [<RequireQualifiedAccess>] AlterAvailabilityGroupAction = 
  | Base of ActionType:ScriptDom.AlterAvailabilityGroupActionType
  | AlterAvailabilityGroupFailoverAction of ActionType:ScriptDom.AlterAvailabilityGroupActionType * Options:(AlterAvailabilityGroupFailoverOption) list
  static member FromTs(src:ScriptDom.AlterAvailabilityGroupAction) : AlterAvailabilityGroupAction =
    match src with
    | :? ScriptDom.AlterAvailabilityGroupFailoverAction as src ->
      AlterAvailabilityGroupAction.AlterAvailabilityGroupFailoverAction((src.ActionType) (* 196 *), (src.Options |> Seq.map (fun src -> AlterAvailabilityGroupFailoverOption.AlterAvailabilityGroupFailoverOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | _ -> (* :? ScriptDom.AlterAvailabilityGroupAction as src *)
      AlterAvailabilityGroupAction.Base((* 297 *)((src.ActionType) (* 196 *)))
and [<RequireQualifiedAccess>] AlterFullTextIndexAction = 
  | AddAlterFullTextIndexAction of Columns:(FullTextIndexColumn) list * WithNoPopulation:bool
  | AlterColumnAlterFullTextIndexAction of Column:FullTextIndexColumn option * WithNoPopulation:bool
  | DropAlterFullTextIndexAction of Columns:(Identifier) list * WithNoPopulation:bool
  | SetSearchPropertyListAlterFullTextIndexAction of SearchPropertyListOption:SearchPropertyListFullTextIndexOption option * WithNoPopulation:bool
  | SetStopListAlterFullTextIndexAction of StopListOption:StopListFullTextIndexOption option * WithNoPopulation:bool
  | SimpleAlterFullTextIndexAction of ActionKind:ScriptDom.SimpleAlterFullTextIndexActionKind
  static member FromTs(src:ScriptDom.AlterFullTextIndexAction) : AlterFullTextIndexAction =
    match src with
    | :? ScriptDom.AddAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.AddAlterFullTextIndexAction((src.Columns |> Seq.map (fun src -> FullTextIndexColumn.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.WithNoPopulation) (* 196 *))
    | :? ScriptDom.AlterColumnAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.AlterColumnAlterFullTextIndexAction((src.Column |> Option.ofObj |> Option.map (FullTextIndexColumn.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))
    | :? ScriptDom.DropAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.DropAlterFullTextIndexAction((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.WithNoPopulation) (* 196 *))
    | :? ScriptDom.SetSearchPropertyListAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.SetSearchPropertyListAlterFullTextIndexAction((src.SearchPropertyListOption |> Option.ofObj |> Option.map (SearchPropertyListFullTextIndexOption.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))
    | :? ScriptDom.SetStopListAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.SetStopListAlterFullTextIndexAction((src.StopListOption |> Option.ofObj |> Option.map (StopListFullTextIndexOption.FromTs)) (* 193 *), (src.WithNoPopulation) (* 196 *))
    | :? ScriptDom.SimpleAlterFullTextIndexAction as src ->
      AlterFullTextIndexAction.SimpleAlterFullTextIndexAction((src.ActionKind) (* 196 *))
and [<RequireQualifiedAccess>] AlterRoleAction = 
  | AddMemberAlterRoleAction of Member:Identifier option
  | DropMemberAlterRoleAction of Member:Identifier option
  | RenameAlterRoleAction of NewName:Identifier option
  static member FromTs(src:ScriptDom.AlterRoleAction) : AlterRoleAction =
    match src with
    | :? ScriptDom.AddMemberAlterRoleAction as src ->
      AlterRoleAction.AddMemberAlterRoleAction((src.Member |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropMemberAlterRoleAction as src ->
      AlterRoleAction.DropMemberAlterRoleAction((src.Member |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.RenameAlterRoleAction as src ->
      AlterRoleAction.RenameAlterRoleAction((src.NewName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterServerConfigurationBufferPoolExtensionOption = 
  | Base of OptionKind:ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind * OptionValue:OptionValue option
  | AlterServerConfigurationBufferPoolExtensionContainerOption of OptionKind:ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind * OptionValue:OptionValue option * Suboptions:(AlterServerConfigurationBufferPoolExtensionOption) list
  | AlterServerConfigurationBufferPoolExtensionSizeOption of OptionKind:ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind * OptionValue:OptionValue option * SizeUnit:ScriptDom.MemoryUnit
  static member FromTs(src:ScriptDom.AlterServerConfigurationBufferPoolExtensionOption) : AlterServerConfigurationBufferPoolExtensionOption =
    match src with
    | :? ScriptDom.AlterServerConfigurationBufferPoolExtensionContainerOption as src ->
      AlterServerConfigurationBufferPoolExtensionOption.AlterServerConfigurationBufferPoolExtensionContainerOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.Suboptions |> Seq.map (AlterServerConfigurationBufferPoolExtensionOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationBufferPoolExtensionSizeOption as src ->
      AlterServerConfigurationBufferPoolExtensionOption.AlterServerConfigurationBufferPoolExtensionSizeOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.SizeUnit) (* 196 *))
    | _ -> (* :? ScriptDom.AlterServerConfigurationBufferPoolExtensionOption as src *)
      AlterServerConfigurationBufferPoolExtensionOption.Base((* 297 *)((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] AlterServerConfigurationDiagnosticsLogOption = 
  | Base of OptionKind:ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind * OptionValue:OptionValue option
  | AlterServerConfigurationDiagnosticsLogMaxSizeOption of OptionKind:ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind * OptionValue:OptionValue option * SizeUnit:ScriptDom.MemoryUnit
  static member FromTs(src:ScriptDom.AlterServerConfigurationDiagnosticsLogOption) : AlterServerConfigurationDiagnosticsLogOption =
    match src with
    | :? ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption as src ->
      AlterServerConfigurationDiagnosticsLogOption.AlterServerConfigurationDiagnosticsLogMaxSizeOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *), (src.SizeUnit) (* 196 *))
    | _ -> (* :? ScriptDom.AlterServerConfigurationDiagnosticsLogOption as src *)
      AlterServerConfigurationDiagnosticsLogOption.Base((* 297 *)((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] AssemblyOption = 
  | Base of OptionKind:ScriptDom.AssemblyOptionKind
  | OnOffAssemblyOption of OptionKind:ScriptDom.AssemblyOptionKind * OptionState:ScriptDom.OptionState
  | PermissionSetAssemblyOption of OptionKind:ScriptDom.AssemblyOptionKind * PermissionSetOption:ScriptDom.PermissionSetOption
  static member FromTs(src:ScriptDom.AssemblyOption) : AssemblyOption =
    match src with
    | :? ScriptDom.OnOffAssemblyOption as src ->
      AssemblyOption.OnOffAssemblyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.PermissionSetAssemblyOption as src ->
      AssemblyOption.PermissionSetAssemblyOption((src.OptionKind) (* 196 *), (src.PermissionSetOption) (* 196 *))
    | _ -> (* :? ScriptDom.AssemblyOption as src *)
      AssemblyOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] AtomicBlockOption = 
  | IdentifierAtomicBlockOption of OptionKind:ScriptDom.AtomicBlockOptionKind * Value:Identifier option
  | LiteralAtomicBlockOption of OptionKind:ScriptDom.AtomicBlockOptionKind * Value:Literal option
  | OnOffAtomicBlockOption of OptionKind:ScriptDom.AtomicBlockOptionKind * OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.AtomicBlockOption) : AtomicBlockOption =
    match src with
    | :? ScriptDom.IdentifierAtomicBlockOption as src ->
      AtomicBlockOption.IdentifierAtomicBlockOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.LiteralAtomicBlockOption as src ->
      AtomicBlockOption.LiteralAtomicBlockOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OnOffAtomicBlockOption as src ->
      AtomicBlockOption.OnOffAtomicBlockOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
and [<RequireQualifiedAccess>] AuditOption = 
  | AuditGuidAuditOption of Guid:Literal option * OptionKind:ScriptDom.AuditOptionKind
  | OnFailureAuditOption of OnFailureAction:ScriptDom.AuditFailureActionType * OptionKind:ScriptDom.AuditOptionKind
  | QueueDelayAuditOption of Delay:Literal option * OptionKind:ScriptDom.AuditOptionKind
  | StateAuditOption of OptionKind:ScriptDom.AuditOptionKind * Value:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.AuditOption) : AuditOption =
    match src with
    | :? ScriptDom.AuditGuidAuditOption as src ->
      AuditOption.AuditGuidAuditOption((src.Guid |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.OnFailureAuditOption as src ->
      AuditOption.OnFailureAuditOption((src.OnFailureAction) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.QueueDelayAuditOption as src ->
      AuditOption.QueueDelayAuditOption((src.Delay |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.StateAuditOption as src ->
      AuditOption.StateAuditOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
and [<RequireQualifiedAccess>] AuditSpecificationDetail = 
  | AuditActionGroupReference of Group:ScriptDom.AuditActionGroup
  | AuditActionSpecification of Actions:(DatabaseAuditAction) list * Principals:(SecurityPrincipal) list * TargetObject:SecurityTargetObject option
  static member FromTs(src:ScriptDom.AuditSpecificationDetail) : AuditSpecificationDetail =
    match src with
    | :? ScriptDom.AuditActionGroupReference as src ->
      AuditSpecificationDetail.AuditActionGroupReference((src.Group) (* 196 *))
    | :? ScriptDom.AuditActionSpecification as src ->
      AuditSpecificationDetail.AuditActionSpecification((src.Actions |> Seq.map (fun src -> DatabaseAuditAction.DatabaseAuditAction((src.ActionKind) (* 196 *))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.TargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AuditTargetOption = 
  | LiteralAuditTargetOption of OptionKind:ScriptDom.AuditTargetOptionKind * Value:Literal option
  | MaxRolloverFilesAuditTargetOption of IsUnlimited:bool * OptionKind:ScriptDom.AuditTargetOptionKind * Value:Literal option
  | MaxSizeAuditTargetOption of IsUnlimited:bool * OptionKind:ScriptDom.AuditTargetOptionKind * Size:Literal option * Unit:ScriptDom.MemoryUnit
  | OnOffAuditTargetOption of OptionKind:ScriptDom.AuditTargetOptionKind * Value:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.AuditTargetOption) : AuditTargetOption =
    match src with
    | :? ScriptDom.LiteralAuditTargetOption as src ->
      AuditTargetOption.LiteralAuditTargetOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.MaxRolloverFilesAuditTargetOption as src ->
      AuditTargetOption.MaxRolloverFilesAuditTargetOption((src.IsUnlimited) (* 196 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.MaxSizeAuditTargetOption as src ->
      AuditTargetOption.MaxSizeAuditTargetOption((src.IsUnlimited) (* 196 *), (src.OptionKind) (* 196 *), (src.Size |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))
    | :? ScriptDom.OnOffAuditTargetOption as src ->
      AuditTargetOption.OnOffAuditTargetOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
and [<RequireQualifiedAccess>] AvailabilityGroupOption = 
  | LiteralAvailabilityGroupOption of OptionKind:ScriptDom.AvailabilityGroupOptionKind * Value:Literal option
  static member FromTs(src:ScriptDom.AvailabilityGroupOption) : AvailabilityGroupOption =
    match src with
    | :? ScriptDom.LiteralAvailabilityGroupOption as src ->
      AvailabilityGroupOption.LiteralAvailabilityGroupOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AvailabilityReplicaOption = 
  | AvailabilityModeReplicaOption of OptionKind:ScriptDom.AvailabilityReplicaOptionKind * Value:ScriptDom.AvailabilityModeOptionKind
  | FailoverModeReplicaOption of OptionKind:ScriptDom.AvailabilityReplicaOptionKind * Value:ScriptDom.FailoverModeOptionKind
  | LiteralReplicaOption of OptionKind:ScriptDom.AvailabilityReplicaOptionKind * Value:Literal option
  | PrimaryRoleReplicaOption of AllowConnections:ScriptDom.AllowConnectionsOptionKind * OptionKind:ScriptDom.AvailabilityReplicaOptionKind
  | SecondaryRoleReplicaOption of AllowConnections:ScriptDom.AllowConnectionsOptionKind * OptionKind:ScriptDom.AvailabilityReplicaOptionKind
  static member FromTs(src:ScriptDom.AvailabilityReplicaOption) : AvailabilityReplicaOption =
    match src with
    | :? ScriptDom.AvailabilityModeReplicaOption as src ->
      AvailabilityReplicaOption.AvailabilityModeReplicaOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.FailoverModeReplicaOption as src ->
      AvailabilityReplicaOption.FailoverModeReplicaOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.LiteralReplicaOption as src ->
      AvailabilityReplicaOption.LiteralReplicaOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.PrimaryRoleReplicaOption as src ->
      AvailabilityReplicaOption.PrimaryRoleReplicaOption((src.AllowConnections) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.SecondaryRoleReplicaOption as src ->
      AvailabilityReplicaOption.SecondaryRoleReplicaOption((src.AllowConnections) (* 196 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] BackupOption = 
  | Base of OptionKind:ScriptDom.BackupOptionKind * Value:ScalarExpression option
  | BackupEncryptionOption of Algorithm:ScriptDom.EncryptionAlgorithm * Encryptor:CryptoMechanism option * OptionKind:ScriptDom.BackupOptionKind * Value:ScalarExpression option
  static member FromTs(src:ScriptDom.BackupOption) : BackupOption =
    match src with
    | :? ScriptDom.BackupEncryptionOption as src ->
      BackupOption.BackupEncryptionOption((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.BackupOption as src *)
      BackupOption.Base((* 297 *)((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] BooleanExpression = 
  | BooleanBinaryExpression of BinaryExpressionType:ScriptDom.BooleanBinaryExpressionType * FirstExpression:BooleanExpression option * SecondExpression:BooleanExpression option
  | BooleanComparisonExpression of ComparisonType:ScriptDom.BooleanComparisonType * FirstExpression:ScalarExpression option * SecondExpression:ScalarExpression option
  | BooleanExpressionSnippet of Script:String option
  | BooleanIsNullExpression of Expression:ScalarExpression option * IsNot:bool
  | BooleanNotExpression of Expression:BooleanExpression option
  | BooleanParenthesisExpression of Expression:BooleanExpression option
  | BooleanTernaryExpression of FirstExpression:ScalarExpression option * SecondExpression:ScalarExpression option * TernaryExpressionType:ScriptDom.BooleanTernaryExpressionType * ThirdExpression:ScalarExpression option
  | EventDeclarationCompareFunctionParameter of EventValue:ScalarExpression option * Name:EventSessionObjectName option * SourceDeclaration:SourceDeclaration option
  | ExistsPredicate of Subquery:ScalarSubquery option
  | FullTextPredicate of Columns:(ColumnReferenceExpression) list * FullTextFunctionType:ScriptDom.FullTextFunctionType * LanguageTerm:ValueExpression option * PropertyName:StringLiteral option * Value:ValueExpression option
  | InPredicate of Expression:ScalarExpression option * NotDefined:bool * Subquery:ScalarSubquery option * Values:(ScalarExpression) list
  | LikePredicate of EscapeExpression:ScalarExpression option * FirstExpression:ScalarExpression option * NotDefined:bool * OdbcEscape:bool * SecondExpression:ScalarExpression option
  | SubqueryComparisonPredicate of ComparisonType:ScriptDom.BooleanComparisonType * Expression:ScalarExpression option * Subquery:ScalarSubquery option * SubqueryComparisonPredicateType:ScriptDom.SubqueryComparisonPredicateType
  | TSEqualCall of FirstExpression:ScalarExpression option * SecondExpression:ScalarExpression option
  | UpdateCall of Identifier:Identifier option
  static member FromTs(src:ScriptDom.BooleanExpression) : BooleanExpression =
    match src with
    | :? ScriptDom.BooleanBinaryExpression as src ->
      BooleanExpression.BooleanBinaryExpression((src.BinaryExpressionType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BooleanComparisonExpression as src ->
      BooleanExpression.BooleanComparisonExpression((src.ComparisonType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BooleanExpressionSnippet as src ->
      BooleanExpression.BooleanExpressionSnippet((Option.ofObj (src.Script)) (* 198 *))
    | :? ScriptDom.BooleanIsNullExpression as src ->
      BooleanExpression.BooleanIsNullExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsNot) (* 196 *))
    | :? ScriptDom.BooleanNotExpression as src ->
      BooleanExpression.BooleanNotExpression((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BooleanParenthesisExpression as src ->
      BooleanExpression.BooleanParenthesisExpression((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BooleanTernaryExpression as src ->
      BooleanExpression.BooleanTernaryExpression((src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TernaryExpressionType) (* 196 *), (src.ThirdExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.EventDeclarationCompareFunctionParameter as src ->
      BooleanExpression.EventDeclarationCompareFunctionParameter((src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.SourceDeclaration |> Option.ofObj |> Option.map (SourceDeclaration.FromTs)) (* 193 *))
    | :? ScriptDom.ExistsPredicate as src ->
      BooleanExpression.ExistsPredicate((src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *))
    | :? ScriptDom.FullTextPredicate as src ->
      BooleanExpression.FullTextPredicate((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FullTextFunctionType) (* 196 *), (src.LanguageTerm |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.InPredicate as src ->
      BooleanExpression.InPredicate((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.NotDefined) (* 196 *), (src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *), (src.Values |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.LikePredicate as src ->
      BooleanExpression.LikePredicate((src.EscapeExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.NotDefined) (* 196 *), (src.OdbcEscape) (* 196 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SubqueryComparisonPredicate as src ->
      BooleanExpression.SubqueryComparisonPredicate((src.ComparisonType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Subquery |> Option.ofObj |> Option.map (ScalarSubquery.FromTs)) (* 193 *), (src.SubqueryComparisonPredicateType) (* 196 *))
    | :? ScriptDom.TSEqualCall as src ->
      BooleanExpression.TSEqualCall((src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.UpdateCall as src ->
      BooleanExpression.UpdateCall((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] BulkInsertOption = 
  | Base of OptionKind:ScriptDom.BulkInsertOptionKind
  | LiteralBulkInsertOption of OptionKind:ScriptDom.BulkInsertOptionKind * Value:Literal option
  | OrderBulkInsertOption of Columns:(ColumnWithSortOrder) list * IsUnique:bool * OptionKind:ScriptDom.BulkInsertOptionKind
  static member FromTs(src:ScriptDom.BulkInsertOption) : BulkInsertOption =
    match src with
    | :? ScriptDom.LiteralBulkInsertOption as src ->
      BulkInsertOption.LiteralBulkInsertOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OrderBulkInsertOption as src ->
      BulkInsertOption.OrderBulkInsertOption((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.IsUnique) (* 196 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.BulkInsertOption as src *)
      BulkInsertOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] CallTarget = 
  | ExpressionCallTarget of Expression:ScalarExpression option
  | MultiPartIdentifierCallTarget of MultiPartIdentifier:MultiPartIdentifier option
  | UserDefinedTypeCallTarget of SchemaObjectName:SchemaObjectName option
  static member FromTs(src:ScriptDom.CallTarget) : CallTarget =
    match src with
    | :? ScriptDom.ExpressionCallTarget as src ->
      CallTarget.ExpressionCallTarget((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.MultiPartIdentifierCallTarget as src ->
      CallTarget.MultiPartIdentifierCallTarget((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
    | :? ScriptDom.UserDefinedTypeCallTarget as src ->
      CallTarget.UserDefinedTypeCallTarget((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ChangeTrackingOptionDetail = 
  | AutoCleanupChangeTrackingOptionDetail of IsOn:bool
  | ChangeRetentionChangeTrackingOptionDetail of RetentionPeriod:Literal option * Unit:ScriptDom.TimeUnit
  static member FromTs(src:ScriptDom.ChangeTrackingOptionDetail) : ChangeTrackingOptionDetail =
    match src with
    | :? ScriptDom.AutoCleanupChangeTrackingOptionDetail as src ->
      ChangeTrackingOptionDetail.AutoCleanupChangeTrackingOptionDetail((src.IsOn) (* 196 *))
    | :? ScriptDom.ChangeRetentionChangeTrackingOptionDetail as src ->
      ChangeTrackingOptionDetail.ChangeRetentionChangeTrackingOptionDetail((src.RetentionPeriod |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))
and [<RequireQualifiedAccess>] ColumnDefinitionBase = 
  | Base of Collation:Identifier option * ColumnIdentifier:Identifier option * DataType:DataTypeReference option
  | ColumnDefinition of Collation:Identifier option * ColumnIdentifier:Identifier option * ComputedColumnExpression:ScalarExpression option * Constraints:(ConstraintDefinition) list * DataType:DataTypeReference option * DefaultConstraint:DefaultConstraintDefinition option * Encryption:ColumnEncryptionDefinition option * GeneratedAlways:(ScriptDom.GeneratedAlwaysType) option * IdentityOptions:IdentityOptions option * Index:IndexDefinition option * IsHidden:bool * IsMasked:bool * IsPersisted:bool * IsRowGuidCol:bool * MaskingFunction:StringLiteral option * StorageOptions:ColumnStorageOptions option
  static member FromTs(src:ScriptDom.ColumnDefinitionBase) : ColumnDefinitionBase =
    match src with
    | :? ScriptDom.ColumnDefinition as src ->
      ColumnDefinitionBase.ColumnDefinition((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ComputedColumnExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Constraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DefaultConstraint |> Option.ofObj |> Option.map (DefaultConstraintDefinition.FromTs)) (* 193 *), (src.Encryption |> Option.ofObj |> Option.map (ColumnEncryptionDefinition.FromTs)) (* 193 *), (Option.ofNullable (src.GeneratedAlways)), (src.IdentityOptions |> Option.ofObj |> Option.map (IdentityOptions.FromTs)) (* 193 *), (src.Index |> Option.ofObj |> Option.map (IndexDefinition.FromTs)) (* 193 *), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.IsPersisted) (* 196 *), (src.IsRowGuidCol) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))
    | _ -> (* :? ScriptDom.ColumnDefinitionBase as src *)
      ColumnDefinitionBase.Base((* 297 *)((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] ColumnEncryptionDefinitionParameter = 
  | ColumnEncryptionAlgorithmParameter of EncryptionAlgorithm:StringLiteral option * ParameterKind:ScriptDom.ColumnEncryptionDefinitionParameterKind
  | ColumnEncryptionKeyNameParameter of Name:Identifier option * ParameterKind:ScriptDom.ColumnEncryptionDefinitionParameterKind
  | ColumnEncryptionTypeParameter of EncryptionType:ScriptDom.ColumnEncryptionType * ParameterKind:ScriptDom.ColumnEncryptionDefinitionParameterKind
  static member FromTs(src:ScriptDom.ColumnEncryptionDefinitionParameter) : ColumnEncryptionDefinitionParameter =
    match src with
    | :? ScriptDom.ColumnEncryptionAlgorithmParameter as src ->
      ColumnEncryptionDefinitionParameter.ColumnEncryptionAlgorithmParameter((src.EncryptionAlgorithm |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))
    | :? ScriptDom.ColumnEncryptionKeyNameParameter as src ->
      ColumnEncryptionDefinitionParameter.ColumnEncryptionKeyNameParameter((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterKind) (* 196 *))
    | :? ScriptDom.ColumnEncryptionTypeParameter as src ->
      ColumnEncryptionDefinitionParameter.ColumnEncryptionTypeParameter((src.EncryptionType) (* 196 *), (src.ParameterKind) (* 196 *))
and [<RequireQualifiedAccess>] ColumnEncryptionKeyValueParameter = 
  | ColumnEncryptionAlgorithmNameParameter of Algorithm:StringLiteral option * ParameterKind:ScriptDom.ColumnEncryptionKeyValueParameterKind
  | ColumnMasterKeyNameParameter of Name:Identifier option * ParameterKind:ScriptDom.ColumnEncryptionKeyValueParameterKind
  | EncryptedValueParameter of ParameterKind:ScriptDom.ColumnEncryptionKeyValueParameterKind * Value:BinaryLiteral option
  static member FromTs(src:ScriptDom.ColumnEncryptionKeyValueParameter) : ColumnEncryptionKeyValueParameter =
    match src with
    | :? ScriptDom.ColumnEncryptionAlgorithmNameParameter as src ->
      ColumnEncryptionKeyValueParameter.ColumnEncryptionAlgorithmNameParameter((src.Algorithm |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))
    | :? ScriptDom.ColumnMasterKeyNameParameter as src ->
      ColumnEncryptionKeyValueParameter.ColumnMasterKeyNameParameter((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterKind) (* 196 *))
    | :? ScriptDom.EncryptedValueParameter as src ->
      ColumnEncryptionKeyValueParameter.EncryptedValueParameter((src.ParameterKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (BinaryLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ColumnMasterKeyParameter = 
  | ColumnMasterKeyPathParameter of ParameterKind:ScriptDom.ColumnMasterKeyParameterKind * Path:StringLiteral option
  | ColumnMasterKeyStoreProviderNameParameter of Name:StringLiteral option * ParameterKind:ScriptDom.ColumnMasterKeyParameterKind
  static member FromTs(src:ScriptDom.ColumnMasterKeyParameter) : ColumnMasterKeyParameter =
    match src with
    | :? ScriptDom.ColumnMasterKeyPathParameter as src ->
      ColumnMasterKeyParameter.ColumnMasterKeyPathParameter((src.ParameterKind) (* 196 *), (src.Path |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.ColumnMasterKeyStoreProviderNameParameter as src ->
      ColumnMasterKeyParameter.ColumnMasterKeyStoreProviderNameParameter((src.Name |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ParameterKind) (* 196 *))
and [<RequireQualifiedAccess>] ConstraintDefinition = 
  | CheckConstraintDefinition of CheckCondition:BooleanExpression option * ConstraintIdentifier:Identifier option * NotForReplication:bool
  | DefaultConstraintDefinition of Column:Identifier option * ConstraintIdentifier:Identifier option * Expression:ScalarExpression option * WithValues:bool
  | ForeignKeyConstraintDefinition of Columns:(Identifier) list * ConstraintIdentifier:Identifier option * DeleteAction:ScriptDom.DeleteUpdateAction * NotForReplication:bool * ReferenceTableName:SchemaObjectName option * ReferencedTableColumns:(Identifier) list * UpdateAction:ScriptDom.DeleteUpdateAction
  | NullableConstraintDefinition of ConstraintIdentifier:Identifier option * Nullable:bool
  | UniqueConstraintDefinition of Clustered:(bool) option * Columns:(ColumnWithSortOrder) list * ConstraintIdentifier:Identifier option * FileStreamOn:IdentifierOrValueExpression option * IndexOptions:(IndexOption) list * IndexType:IndexType option * IsPrimaryKey:bool * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option
  static member FromTs(src:ScriptDom.ConstraintDefinition) : ConstraintDefinition =
    match src with
    | :? ScriptDom.CheckConstraintDefinition as src ->
      ConstraintDefinition.CheckConstraintDefinition((src.CheckCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *))
    | :? ScriptDom.DefaultConstraintDefinition as src ->
      ConstraintDefinition.DefaultConstraintDefinition((src.Column |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WithValues) (* 196 *))
    | :? ScriptDom.ForeignKeyConstraintDefinition as src ->
      ConstraintDefinition.ForeignKeyConstraintDefinition((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DeleteAction) (* 196 *), (src.NotForReplication) (* 196 *), (src.ReferenceTableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ReferencedTableColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.UpdateAction) (* 196 *))
    | :? ScriptDom.NullableConstraintDefinition as src ->
      ConstraintDefinition.NullableConstraintDefinition((src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Nullable) (* 196 *))
    | :? ScriptDom.UniqueConstraintDefinition as src ->
      ConstraintDefinition.UniqueConstraintDefinition((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.IsPrimaryKey) (* 196 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] CreateLoginSource = 
  | AsymmetricKeyCreateLoginSource of Credential:Identifier option * Key:Identifier option
  | CertificateCreateLoginSource of Certificate:Identifier option * Credential:Identifier option
  | PasswordCreateLoginSource of Hashed:bool * MustChange:bool * Options:(PrincipalOption) list * Password:Literal option
  | WindowsCreateLoginSource of Options:(PrincipalOption) list
  static member FromTs(src:ScriptDom.CreateLoginSource) : CreateLoginSource =
    match src with
    | :? ScriptDom.AsymmetricKeyCreateLoginSource as src ->
      CreateLoginSource.AsymmetricKeyCreateLoginSource((src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Key |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CertificateCreateLoginSource as src ->
      CreateLoginSource.CertificateCreateLoginSource((src.Certificate |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.PasswordCreateLoginSource as src ->
      CreateLoginSource.PasswordCreateLoginSource((src.Hashed) (* 196 *), (src.MustChange) (* 196 *), (src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.WindowsCreateLoginSource as src ->
      CreateLoginSource.WindowsCreateLoginSource((src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] DataModificationSpecification = 
  | InsertSpecification of Columns:(ColumnReferenceExpression) list * InsertOption:ScriptDom.InsertOption * InsertSource:InsertSource option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * Target:TableReference option * TopRowFilter:TopRowFilter option
  | MergeSpecification of ActionClauses:(MergeActionClause) list * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * SearchCondition:BooleanExpression option * TableAlias:Identifier option * TableReference:TableReference option * Target:TableReference option * TopRowFilter:TopRowFilter option
  | UpdateDeleteSpecificationBase of UpdateDeleteSpecificationBase
  static member FromTs(src:ScriptDom.DataModificationSpecification) : DataModificationSpecification =
    match src with
    | :? ScriptDom.InsertSpecification as src ->
      DataModificationSpecification.InsertSpecification((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.InsertOption) (* 196 *), (src.InsertSource |> Option.ofObj |> Option.map (InsertSource.FromTs)) (* 191 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))
    | :? ScriptDom.MergeSpecification as src ->
      DataModificationSpecification.MergeSpecification((src.ActionClauses |> Seq.map (fun src -> MergeActionClause.MergeActionClause((src.Action |> Option.ofObj |> Option.map (MergeAction.FromTs)) (* 191 *), (src.Condition) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.TableAlias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))
    | :? ScriptDom.UpdateDeleteSpecificationBase as src ->
      match src with
      | :? ScriptDom.DeleteSpecification as src-> (* 274 *)
        DataModificationSpecification.UpdateDeleteSpecificationBase((UpdateDeleteSpecificationBase.DeleteSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))))
      | :? ScriptDom.UpdateSpecification as src-> (* 274 *)
        DataModificationSpecification.UpdateDeleteSpecificationBase((UpdateDeleteSpecificationBase.UpdateSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SetClauses |> Seq.map (SetClause.FromTs) |> List.ofSeq), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))))
and [<RequireQualifiedAccess>] DataTypeReference = 
  | ParameterizedDataTypeReference of ParameterizedDataTypeReference
  | XmlDataTypeReference of Name:SchemaObjectName option * XmlDataTypeOption:ScriptDom.XmlDataTypeOption * XmlSchemaCollection:SchemaObjectName option
  static member FromTs(src:ScriptDom.DataTypeReference) : DataTypeReference =
    match src with
    | :? ScriptDom.ParameterizedDataTypeReference as src ->
      match src with
      | :? ScriptDom.SqlDataTypeReference as src-> (* 274 *)
        DataTypeReference.ParameterizedDataTypeReference((ParameterizedDataTypeReference.SqlDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (Literal.FromTs) |> List.ofSeq), (src.SqlDataTypeOption) (* 196 *))))
      | :? ScriptDom.UserDataTypeReference as src-> (* 274 *)
        DataTypeReference.ParameterizedDataTypeReference((ParameterizedDataTypeReference.UserDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (Literal.FromTs) |> List.ofSeq))))
    | :? ScriptDom.XmlDataTypeReference as src ->
      DataTypeReference.XmlDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.XmlDataTypeOption) (* 196 *), (src.XmlSchemaCollection |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DatabaseConfigurationSetOption = 
  | Base of OptionKind:ScriptDom.DatabaseConfigSetOptionKind
  | MaxDopConfigurationOption of OptionKind:ScriptDom.DatabaseConfigSetOptionKind * Primary:bool * Value:Literal option
  | OnOffPrimaryConfigurationOption of OptionKind:ScriptDom.DatabaseConfigSetOptionKind * OptionState:ScriptDom.DatabaseConfigurationOptionState
  static member FromTs(src:ScriptDom.DatabaseConfigurationSetOption) : DatabaseConfigurationSetOption =
    match src with
    | :? ScriptDom.MaxDopConfigurationOption as src ->
      DatabaseConfigurationSetOption.MaxDopConfigurationOption((src.OptionKind) (* 196 *), (src.Primary) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OnOffPrimaryConfigurationOption as src ->
      DatabaseConfigurationSetOption.OnOffPrimaryConfigurationOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | _ -> (* :? ScriptDom.DatabaseConfigurationSetOption as src *)
      DatabaseConfigurationSetOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] DatabaseOption = 
  | Base of OptionKind:ScriptDom.DatabaseOptionKind
  | ChangeTrackingDatabaseOption of Details:(ChangeTrackingOptionDetail) list * OptionKind:ScriptDom.DatabaseOptionKind * OptionState:ScriptDom.OptionState
  | ContainmentDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:ScriptDom.ContainmentOptionKind
  | CursorDefaultDatabaseOption of IsLocal:bool * OptionKind:ScriptDom.DatabaseOptionKind
  | DelayedDurabilityDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:ScriptDom.DelayedDurabilityOptionKind
  | FileStreamDatabaseOption of DirectoryName:Literal option * NonTransactedAccess:(ScriptDom.NonTransactedFileStreamAccess) option * OptionKind:ScriptDom.DatabaseOptionKind
  | HadrDatabaseOption of HadrDatabaseOption
  | IdentifierDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:Identifier option
  | LiteralDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:Literal option
  | MaxSizeDatabaseOption of MaxSize:Literal option * OptionKind:ScriptDom.DatabaseOptionKind * Units:ScriptDom.MemoryUnit
  | OnOffDatabaseOption of OnOffDatabaseOption
  | PageVerifyDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:ScriptDom.PageVerifyDatabaseOptionKind
  | ParameterizationDatabaseOption of IsSimple:bool * OptionKind:ScriptDom.DatabaseOptionKind
  | PartnerDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * PartnerOption:ScriptDom.PartnerDatabaseOptionKind * PartnerServer:Literal option * Timeout:Literal option
  | QueryStoreDatabaseOption of Clear:bool * ClearAll:bool * OptionKind:ScriptDom.DatabaseOptionKind * OptionState:ScriptDom.OptionState * Options:(QueryStoreOption) list
  | RecoveryDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:ScriptDom.RecoveryDatabaseOptionKind
  | RemoteDataArchiveDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * OptionState:ScriptDom.OptionState * Settings:(RemoteDataArchiveDatabaseSetting) list
  | TargetRecoveryTimeDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * RecoveryTime:Literal option * Unit:ScriptDom.TimeUnit
  | WitnessDatabaseOption of IsOff:bool * OptionKind:ScriptDom.DatabaseOptionKind * WitnessServer:Literal option
  static member FromTs(src:ScriptDom.DatabaseOption) : DatabaseOption =
    match src with
    | :? ScriptDom.ChangeTrackingDatabaseOption as src ->
      DatabaseOption.ChangeTrackingDatabaseOption((src.Details |> Seq.map (ChangeTrackingOptionDetail.FromTs) |> List.ofSeq), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.ContainmentDatabaseOption as src ->
      DatabaseOption.ContainmentDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.CursorDefaultDatabaseOption as src ->
      DatabaseOption.CursorDefaultDatabaseOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.DelayedDurabilityDatabaseOption as src ->
      DatabaseOption.DelayedDurabilityDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.FileStreamDatabaseOption as src ->
      DatabaseOption.FileStreamDatabaseOption((src.DirectoryName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (Option.ofNullable (src.NonTransactedAccess)), (src.OptionKind) (* 196 *))
    | :? ScriptDom.HadrDatabaseOption as src ->
      match src with
      | :? ScriptDom.HadrAvailabilityGroupDatabaseOption as src-> (* 274 *)
        DatabaseOption.HadrDatabaseOption((HadrDatabaseOption.HadrAvailabilityGroupDatabaseOption((src.GroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.HadrOption) (* 196 *), (src.OptionKind) (* 196 *))))
      | _ -> (* :? ScriptDom.HadrDatabaseOption as src *)
        DatabaseOption.HadrDatabaseOption((HadrDatabaseOption.Base((src.HadrOption) (* 196 *), (src.OptionKind) (* 196 *))))
    | :? ScriptDom.IdentifierDatabaseOption as src ->
      DatabaseOption.IdentifierDatabaseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.LiteralDatabaseOption as src ->
      DatabaseOption.LiteralDatabaseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.MaxSizeDatabaseOption as src ->
      DatabaseOption.MaxSizeDatabaseOption((src.MaxSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *))
    | :? ScriptDom.OnOffDatabaseOption as src ->
      match src with
      | :? ScriptDom.AutoCreateStatisticsDatabaseOption as src-> (* 274 *)
        DatabaseOption.OnOffDatabaseOption((OnOffDatabaseOption.AutoCreateStatisticsDatabaseOption((src.HasIncremental) (* 196 *), (src.IncrementalState) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | _ -> (* :? ScriptDom.OnOffDatabaseOption as src *)
        DatabaseOption.OnOffDatabaseOption((OnOffDatabaseOption.Base((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
    | :? ScriptDom.PageVerifyDatabaseOption as src ->
      DatabaseOption.PageVerifyDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.ParameterizationDatabaseOption as src ->
      DatabaseOption.ParameterizationDatabaseOption((src.IsSimple) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.PartnerDatabaseOption as src ->
      DatabaseOption.PartnerDatabaseOption((src.OptionKind) (* 196 *), (src.PartnerOption) (* 196 *), (src.PartnerServer |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.QueryStoreDatabaseOption as src ->
      DatabaseOption.QueryStoreDatabaseOption((src.Clear) (* 196 *), (src.ClearAll) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *), (src.Options |> Seq.map (QueryStoreOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.RecoveryDatabaseOption as src ->
      DatabaseOption.RecoveryDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.RemoteDataArchiveDatabaseOption as src ->
      DatabaseOption.RemoteDataArchiveDatabaseOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *), (src.Settings |> Seq.map (RemoteDataArchiveDatabaseSetting.FromTs) |> List.ofSeq))
    | :? ScriptDom.TargetRecoveryTimeDatabaseOption as src ->
      DatabaseOption.TargetRecoveryTimeDatabaseOption((src.OptionKind) (* 196 *), (src.RecoveryTime |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unit) (* 196 *))
    | :? ScriptDom.WitnessDatabaseOption as src ->
      DatabaseOption.WitnessDatabaseOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.WitnessServer |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.DatabaseOption as src *)
      DatabaseOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] DeclareVariableElement = 
  | Base of DataType:DataTypeReference option * Nullable:NullableConstraintDefinition option * Value:ScalarExpression option * VariableName:Identifier option
  | ProcedureParameter of DataType:DataTypeReference option * IsVarying:bool * Modifier:ScriptDom.ParameterModifier * Nullable:NullableConstraintDefinition option * Value:ScalarExpression option * VariableName:Identifier option
  static member FromTs(src:ScriptDom.DeclareVariableElement) : DeclareVariableElement =
    match src with
    | :? ScriptDom.ProcedureParameter as src ->
      DeclareVariableElement.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.DeclareVariableElement as src *)
      DeclareVariableElement.Base((* 297 *)((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] DialogOption = 
  | OnOffDialogOption of OptionKind:ScriptDom.DialogOptionKind * OptionState:ScriptDom.OptionState
  | ScalarExpressionDialogOption of OptionKind:ScriptDom.DialogOptionKind * Value:ScalarExpression option
  static member FromTs(src:ScriptDom.DialogOption) : DialogOption =
    match src with
    | :? ScriptDom.OnOffDialogOption as src ->
      DialogOption.OnOffDialogOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.ScalarExpressionDialogOption as src ->
      DialogOption.ScalarExpressionDialogOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DropClusteredConstraintOption = 
  | DropClusteredConstraintMoveOption of OptionKind:ScriptDom.DropClusteredConstraintOptionKind * OptionValue:FileGroupOrPartitionScheme option
  | DropClusteredConstraintStateOption of OptionKind:ScriptDom.DropClusteredConstraintOptionKind * OptionState:ScriptDom.OptionState
  | DropClusteredConstraintValueOption of OptionKind:ScriptDom.DropClusteredConstraintOptionKind * OptionValue:Literal option
  static member FromTs(src:ScriptDom.DropClusteredConstraintOption) : DropClusteredConstraintOption =
    match src with
    | :? ScriptDom.DropClusteredConstraintMoveOption as src ->
      DropClusteredConstraintOption.DropClusteredConstraintMoveOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *))
    | :? ScriptDom.DropClusteredConstraintStateOption as src ->
      DropClusteredConstraintOption.DropClusteredConstraintStateOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.DropClusteredConstraintValueOption as src ->
      DropClusteredConstraintOption.DropClusteredConstraintValueOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DropIndexClauseBase = 
  | BackwardsCompatibleDropIndexClause of Index:ChildObjectName option
  | DropIndexClause of Index:Identifier option * Object:SchemaObjectName option * Options:(IndexOption) list
  static member FromTs(src:ScriptDom.DropIndexClauseBase) : DropIndexClauseBase =
    match src with
    | :? ScriptDom.BackwardsCompatibleDropIndexClause as src ->
      DropIndexClauseBase.BackwardsCompatibleDropIndexClause((src.Index |> Option.ofObj |> Option.map (ChildObjectName.FromTs)) (* 193 *))
    | :? ScriptDom.DropIndexClause as src ->
      DropIndexClauseBase.DropIndexClause((src.Index |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (IndexOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] EncryptionSource = 
  | AssemblyEncryptionSource of Assembly:Identifier option
  | FileEncryptionSource of File:Literal option * IsExecutable:bool
  | ProviderEncryptionSource of KeyOptions:(KeyOption) list * Name:Identifier option
  static member FromTs(src:ScriptDom.EncryptionSource) : EncryptionSource =
    match src with
    | :? ScriptDom.AssemblyEncryptionSource as src ->
      EncryptionSource.AssemblyEncryptionSource((src.Assembly |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FileEncryptionSource as src ->
      EncryptionSource.FileEncryptionSource((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsExecutable) (* 196 *))
    | :? ScriptDom.ProviderEncryptionSource as src ->
      EncryptionSource.ProviderEncryptionSource((src.KeyOptions |> Seq.map (KeyOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EndpointProtocolOption = 
  | AuthenticationEndpointProtocolOption of AuthenticationTypes:ScriptDom.AuthenticationTypes * Kind:ScriptDom.EndpointProtocolOptions
  | CompressionEndpointProtocolOption of IsEnabled:bool * Kind:ScriptDom.EndpointProtocolOptions
  | ListenerIPEndpointProtocolOption of IPv4PartOne:IPv4 option * IPv4PartTwo:IPv4 option * IPv6:Literal option * IsAll:bool * Kind:ScriptDom.EndpointProtocolOptions
  | LiteralEndpointProtocolOption of Kind:ScriptDom.EndpointProtocolOptions * Value:Literal option
  | PortsEndpointProtocolOption of Kind:ScriptDom.EndpointProtocolOptions * PortTypes:ScriptDom.PortTypes
  static member FromTs(src:ScriptDom.EndpointProtocolOption) : EndpointProtocolOption =
    match src with
    | :? ScriptDom.AuthenticationEndpointProtocolOption as src ->
      EndpointProtocolOption.AuthenticationEndpointProtocolOption((src.AuthenticationTypes) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.CompressionEndpointProtocolOption as src ->
      EndpointProtocolOption.CompressionEndpointProtocolOption((src.IsEnabled) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.ListenerIPEndpointProtocolOption as src ->
      EndpointProtocolOption.ListenerIPEndpointProtocolOption((src.IPv4PartOne |> Option.ofObj |> Option.map (IPv4.FromTs)) (* 193 *), (src.IPv4PartTwo |> Option.ofObj |> Option.map (IPv4.FromTs)) (* 193 *), (src.IPv6 |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsAll) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.LiteralEndpointProtocolOption as src ->
      EndpointProtocolOption.LiteralEndpointProtocolOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.PortsEndpointProtocolOption as src ->
      EndpointProtocolOption.PortsEndpointProtocolOption((src.Kind) (* 196 *), (src.PortTypes) (* 196 *))
and [<RequireQualifiedAccess>] EventTypeGroupContainer = 
  | EventGroupContainer of EventGroup:ScriptDom.EventNotificationEventGroup
  | EventTypeContainer of EventType:ScriptDom.EventNotificationEventType
  static member FromTs(src:ScriptDom.EventTypeGroupContainer) : EventTypeGroupContainer =
    match src with
    | :? ScriptDom.EventGroupContainer as src ->
      EventTypeGroupContainer.EventGroupContainer((src.EventGroup) (* 196 *))
    | :? ScriptDom.EventTypeContainer as src ->
      EventTypeGroupContainer.EventTypeContainer((src.EventType) (* 196 *))
and [<RequireQualifiedAccess>] ExecutableEntity = 
  | ExecutableProcedureReference of AdHocDataSource:AdHocDataSource option * Parameters:(ExecuteParameter) list * ProcedureReference:ProcedureReferenceName option
  | ExecutableStringList of Parameters:(ExecuteParameter) list * Strings:(ValueExpression) list
  static member FromTs(src:ScriptDom.ExecutableEntity) : ExecutableEntity =
    match src with
    | :? ScriptDom.ExecutableProcedureReference as src ->
      ExecutableEntity.ExecutableProcedureReference((src.AdHocDataSource |> Option.ofObj |> Option.map (AdHocDataSource.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ExecuteParameter.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReferenceName.FromTs)) (* 193 *))
    | :? ScriptDom.ExecutableStringList as src ->
      ExecutableEntity.ExecutableStringList((src.Parameters |> Seq.map (fun src -> ExecuteParameter.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq), (src.Strings |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ExecuteOption = 
  | Base of OptionKind:ScriptDom.ExecuteOptionKind
  | ResultSetsExecuteOption of Definitions:(ResultSetDefinition) list * OptionKind:ScriptDom.ExecuteOptionKind * ResultSetsOptionKind:ScriptDom.ResultSetsOptionKind
  static member FromTs(src:ScriptDom.ExecuteOption) : ExecuteOption =
    match src with
    | :? ScriptDom.ResultSetsExecuteOption as src ->
      ExecuteOption.ResultSetsExecuteOption((src.Definitions |> Seq.map (ResultSetDefinition.FromTs) |> List.ofSeq), (src.OptionKind) (* 196 *), (src.ResultSetsOptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.ExecuteOption as src *)
      ExecuteOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] ExternalDataSourceOption = 
  | ExternalDataSourceLiteralOrIdentifierOption of OptionKind:ScriptDom.ExternalDataSourceOptionKind * Value:IdentifierOrValueExpression option
  static member FromTs(src:ScriptDom.ExternalDataSourceOption) : ExternalDataSourceOption =
    match src with
    | :? ScriptDom.ExternalDataSourceLiteralOrIdentifierOption as src ->
      ExternalDataSourceOption.ExternalDataSourceLiteralOrIdentifierOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ExternalFileFormatOption = 
  | ExternalFileFormatContainerOption of OptionKind:ScriptDom.ExternalFileFormatOptionKind * Suboptions:(ExternalFileFormatOption) list
  | ExternalFileFormatLiteralOption of OptionKind:ScriptDom.ExternalFileFormatOptionKind * Value:Literal option
  | ExternalFileFormatUseDefaultTypeOption of ExternalFileFormatUseDefaultType:ScriptDom.ExternalFileFormatUseDefaultType * OptionKind:ScriptDom.ExternalFileFormatOptionKind
  static member FromTs(src:ScriptDom.ExternalFileFormatOption) : ExternalFileFormatOption =
    match src with
    | :? ScriptDom.ExternalFileFormatContainerOption as src ->
      ExternalFileFormatOption.ExternalFileFormatContainerOption((src.OptionKind) (* 196 *), (src.Suboptions |> Seq.map (ExternalFileFormatOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.ExternalFileFormatLiteralOption as src ->
      ExternalFileFormatOption.ExternalFileFormatLiteralOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ExternalFileFormatUseDefaultTypeOption as src ->
      ExternalFileFormatOption.ExternalFileFormatUseDefaultTypeOption((src.ExternalFileFormatUseDefaultType) (* 196 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] ExternalTableDistributionPolicy = 
  | ExternalTableReplicatedDistributionPolicy 
  | ExternalTableRoundRobinDistributionPolicy 
  | ExternalTableShardedDistributionPolicy of ShardingColumn:Identifier option
  static member FromTs(src:ScriptDom.ExternalTableDistributionPolicy) : ExternalTableDistributionPolicy =
    match src with
    | :? ScriptDom.ExternalTableReplicatedDistributionPolicy as src ->
      ExternalTableDistributionPolicy.ExternalTableReplicatedDistributionPolicy
    | :? ScriptDom.ExternalTableRoundRobinDistributionPolicy as src ->
      ExternalTableDistributionPolicy.ExternalTableRoundRobinDistributionPolicy
    | :? ScriptDom.ExternalTableShardedDistributionPolicy as src ->
      ExternalTableDistributionPolicy.ExternalTableShardedDistributionPolicy((src.ShardingColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ExternalTableOption = 
  | ExternalTableDistributionOption of OptionKind:ScriptDom.ExternalTableOptionKind * Value:ExternalTableDistributionPolicy option
  | ExternalTableLiteralOrIdentifierOption of OptionKind:ScriptDom.ExternalTableOptionKind * Value:IdentifierOrValueExpression option
  | ExternalTableRejectTypeOption of OptionKind:ScriptDom.ExternalTableOptionKind * Value:ScriptDom.ExternalTableRejectType
  static member FromTs(src:ScriptDom.ExternalTableOption) : ExternalTableOption =
    match src with
    | :? ScriptDom.ExternalTableDistributionOption as src ->
      ExternalTableOption.ExternalTableDistributionOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ExternalTableDistributionPolicy.FromTs)) (* 191 *))
    | :? ScriptDom.ExternalTableLiteralOrIdentifierOption as src ->
      ExternalTableOption.ExternalTableLiteralOrIdentifierOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.ExternalTableRejectTypeOption as src ->
      ExternalTableOption.ExternalTableRejectTypeOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
and [<RequireQualifiedAccess>] FileDeclarationOption = 
  | Base of OptionKind:ScriptDom.FileDeclarationOptionKind
  | FileGrowthFileDeclarationOption of GrowthIncrement:Literal option * OptionKind:ScriptDom.FileDeclarationOptionKind * Units:ScriptDom.MemoryUnit
  | FileNameFileDeclarationOption of OSFileName:Literal option * OptionKind:ScriptDom.FileDeclarationOptionKind
  | MaxSizeFileDeclarationOption of MaxSize:Literal option * OptionKind:ScriptDom.FileDeclarationOptionKind * Units:ScriptDom.MemoryUnit * Unlimited:bool
  | NameFileDeclarationOption of IsNewName:bool * LogicalFileName:IdentifierOrValueExpression option * OptionKind:ScriptDom.FileDeclarationOptionKind
  | SizeFileDeclarationOption of OptionKind:ScriptDom.FileDeclarationOptionKind * Size:Literal option * Units:ScriptDom.MemoryUnit
  static member FromTs(src:ScriptDom.FileDeclarationOption) : FileDeclarationOption =
    match src with
    | :? ScriptDom.FileGrowthFileDeclarationOption as src ->
      FileDeclarationOption.FileGrowthFileDeclarationOption((src.GrowthIncrement |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *))
    | :? ScriptDom.FileNameFileDeclarationOption as src ->
      FileDeclarationOption.FileNameFileDeclarationOption((src.OSFileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.MaxSizeFileDeclarationOption as src ->
      FileDeclarationOption.MaxSizeFileDeclarationOption((src.MaxSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Units) (* 196 *), (src.Unlimited) (* 196 *))
    | :? ScriptDom.NameFileDeclarationOption as src ->
      FileDeclarationOption.NameFileDeclarationOption((src.IsNewName) (* 196 *), (src.LogicalFileName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.SizeFileDeclarationOption as src ->
      FileDeclarationOption.SizeFileDeclarationOption((src.OptionKind) (* 196 *), (src.Size |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Units) (* 196 *))
    | _ -> (* :? ScriptDom.FileDeclarationOption as src *)
      FileDeclarationOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] ForClause = 
  | BrowseForClause 
  | JsonForClause of Options:(JsonForClauseOption) list
  | JsonForClauseOption of OptionKind:ScriptDom.JsonForClauseOptions * Value:Literal option
  | ReadOnlyForClause 
  | UpdateForClause of Columns:(ColumnReferenceExpression) list
  | XmlForClause of Options:(XmlForClauseOption) list
  | XmlForClauseOption of OptionKind:ScriptDom.XmlForClauseOptions * Value:Literal option
  static member FromTs(src:ScriptDom.ForClause) : ForClause =
    match src with
    | :? ScriptDom.BrowseForClause as src ->
      ForClause.BrowseForClause
    | :? ScriptDom.JsonForClause as src ->
      ForClause.JsonForClause((src.Options |> Seq.map (fun src -> JsonForClauseOption.JsonForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.JsonForClauseOption as src ->
      ForClause.JsonForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ReadOnlyForClause as src ->
      ForClause.ReadOnlyForClause
    | :? ScriptDom.UpdateForClause as src ->
      ForClause.UpdateForClause((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.XmlForClause as src ->
      ForClause.XmlForClause((src.Options |> Seq.map (fun src -> XmlForClauseOption.XmlForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.XmlForClauseOption as src ->
      ForClause.XmlForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FullTextCatalogOption = 
  | OnOffFullTextCatalogOption of OptionKind:ScriptDom.FullTextCatalogOptionKind * OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.FullTextCatalogOption) : FullTextCatalogOption =
    match src with
    | :? ScriptDom.OnOffFullTextCatalogOption as src ->
      FullTextCatalogOption.OnOffFullTextCatalogOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
and [<RequireQualifiedAccess>] FullTextIndexOption = 
  | ChangeTrackingFullTextIndexOption of OptionKind:ScriptDom.FullTextIndexOptionKind * Value:ScriptDom.ChangeTrackingOption
  | SearchPropertyListFullTextIndexOption of IsOff:bool * OptionKind:ScriptDom.FullTextIndexOptionKind * PropertyListName:Identifier option
  | StopListFullTextIndexOption of IsOff:bool * OptionKind:ScriptDom.FullTextIndexOptionKind * StopListName:Identifier option
  static member FromTs(src:ScriptDom.FullTextIndexOption) : FullTextIndexOption =
    match src with
    | :? ScriptDom.ChangeTrackingFullTextIndexOption as src ->
      FullTextIndexOption.ChangeTrackingFullTextIndexOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.SearchPropertyListFullTextIndexOption as src ->
      FullTextIndexOption.SearchPropertyListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.PropertyListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.StopListFullTextIndexOption as src ->
      FullTextIndexOption.StopListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.StopListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FunctionOption = 
  | Base of OptionKind:ScriptDom.FunctionOptionKind
  | ExecuteAsFunctionOption of ExecuteAs:ExecuteAsClause option * OptionKind:ScriptDom.FunctionOptionKind
  static member FromTs(src:ScriptDom.FunctionOption) : FunctionOption =
    match src with
    | :? ScriptDom.ExecuteAsFunctionOption as src ->
      FunctionOption.ExecuteAsFunctionOption((src.ExecuteAs |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.FunctionOption as src *)
      FunctionOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] FunctionReturnType = 
  | ScalarFunctionReturnType of DataType:DataTypeReference option
  | SelectFunctionReturnType of SelectStatement:SelectStatement option
  | TableValuedFunctionReturnType of DeclareTableVariableBody:DeclareTableVariableBody option
  static member FromTs(src:ScriptDom.FunctionReturnType) : FunctionReturnType =
    match src with
    | :? ScriptDom.ScalarFunctionReturnType as src ->
      FunctionReturnType.ScalarFunctionReturnType((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))
    | :? ScriptDom.SelectFunctionReturnType as src ->
      FunctionReturnType.SelectFunctionReturnType((src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *))
    | :? ScriptDom.TableValuedFunctionReturnType as src ->
      FunctionReturnType.TableValuedFunctionReturnType((src.DeclareTableVariableBody |> Option.ofObj |> Option.map (DeclareTableVariableBody.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] GroupingSpecification = 
  | CompositeGroupingSpecification of Items:(GroupingSpecification) list
  | CubeGroupingSpecification of Arguments:(GroupingSpecification) list
  | ExpressionGroupingSpecification of Expression:ScalarExpression option
  | GrandTotalGroupingSpecification 
  | GroupingSetsGroupingSpecification of Sets:(GroupingSpecification) list
  | RollupGroupingSpecification of Arguments:(GroupingSpecification) list
  static member FromTs(src:ScriptDom.GroupingSpecification) : GroupingSpecification =
    match src with
    | :? ScriptDom.CompositeGroupingSpecification as src ->
      GroupingSpecification.CompositeGroupingSpecification((src.Items |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
    | :? ScriptDom.CubeGroupingSpecification as src ->
      GroupingSpecification.CubeGroupingSpecification((src.Arguments |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
    | :? ScriptDom.ExpressionGroupingSpecification as src ->
      GroupingSpecification.ExpressionGroupingSpecification((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.GrandTotalGroupingSpecification as src ->
      GroupingSpecification.GrandTotalGroupingSpecification
    | :? ScriptDom.GroupingSetsGroupingSpecification as src ->
      GroupingSpecification.GroupingSetsGroupingSpecification((src.Sets |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
    | :? ScriptDom.RollupGroupingSpecification as src ->
      GroupingSpecification.RollupGroupingSpecification((src.Arguments |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] Identifier = 
  | Base of QuoteType:ScriptDom.QuoteType * Value:String option
  | IdentifierSnippet of QuoteType:ScriptDom.QuoteType * Script:String option * Value:String option
  | SqlCommandIdentifier of QuoteType:ScriptDom.QuoteType * Value:String option
  static member FromTs(src:ScriptDom.Identifier) : Identifier =
    match src with
    | :? ScriptDom.IdentifierSnippet as src ->
      Identifier.IdentifierSnippet((src.QuoteType) (* 196 *), (Option.ofObj (src.Script)) (* 198 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.SqlCommandIdentifier as src ->
      Identifier.SqlCommandIdentifier((src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | _ -> (* :? ScriptDom.Identifier as src *)
      Identifier.Base((* 297 *)((src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *)))
and [<RequireQualifiedAccess>] IndexOption = 
  | CompressionDelayIndexOption of Expression:ScalarExpression option * OptionKind:ScriptDom.IndexOptionKind * TimeUnit:ScriptDom.CompressionDelayTimeUnit
  | DataCompressionOption of CompressionLevel:ScriptDom.DataCompressionLevel * OptionKind:ScriptDom.IndexOptionKind * PartitionRanges:(CompressionPartitionRange) list
  | FileStreamOnDropIndexOption of FileStreamOn:IdentifierOrValueExpression option * OptionKind:ScriptDom.IndexOptionKind
  | IndexExpressionOption of Expression:ScalarExpression option * OptionKind:ScriptDom.IndexOptionKind
  | IndexStateOption of IndexStateOption
  | MoveToDropIndexOption of MoveTo:FileGroupOrPartitionScheme option * OptionKind:ScriptDom.IndexOptionKind
  | OrderIndexOption of Columns:(ColumnReferenceExpression) list * OptionKind:ScriptDom.IndexOptionKind
  static member FromTs(src:ScriptDom.IndexOption) : IndexOption =
    match src with
    | :? ScriptDom.CompressionDelayIndexOption as src ->
      IndexOption.CompressionDelayIndexOption((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.TimeUnit) (* 196 *))
    | :? ScriptDom.DataCompressionOption as src ->
      IndexOption.DataCompressionOption((src.CompressionLevel) (* 196 *), (src.OptionKind) (* 196 *), (src.PartitionRanges |> Seq.map (fun src -> CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.FileStreamOnDropIndexOption as src ->
      IndexOption.FileStreamOnDropIndexOption((src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.IndexExpressionOption as src ->
      IndexOption.IndexExpressionOption((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.IndexStateOption as src ->
      match src with
      | :? ScriptDom.OnlineIndexOption as src-> (* 274 *)
        IndexOption.IndexStateOption((IndexStateOption.OnlineIndexOption((src.LowPriorityLockWaitOption |> Option.ofObj |> Option.map (OnlineIndexLowPriorityLockWaitOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
      | _ -> (* :? ScriptDom.IndexStateOption as src *)
        IndexOption.IndexStateOption((IndexStateOption.Base((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))))
    | :? ScriptDom.MoveToDropIndexOption as src ->
      IndexOption.MoveToDropIndexOption((src.MoveTo |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.OrderIndexOption as src ->
      IndexOption.OrderIndexOption((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] InsertSource = 
  | ExecuteInsertSource of Execute:ExecuteSpecification option
  | SelectInsertSource of Select:QueryExpression option
  | ValuesInsertSource of IsDefaultValues:bool * RowValues:(RowValue) list
  static member FromTs(src:ScriptDom.InsertSource) : InsertSource =
    match src with
    | :? ScriptDom.ExecuteInsertSource as src ->
      InsertSource.ExecuteInsertSource((src.Execute |> Option.ofObj |> Option.map (ExecuteSpecification.FromTs)) (* 193 *))
    | :? ScriptDom.SelectInsertSource as src ->
      InsertSource.SelectInsertSource((src.Select |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ValuesInsertSource as src ->
      InsertSource.ValuesInsertSource((src.IsDefaultValues) (* 196 *), (src.RowValues |> Seq.map (fun src -> RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))) |> List.ofSeq))
and [<RequireQualifiedAccess>] KeyOption = 
  | AlgorithmKeyOption of Algorithm:ScriptDom.EncryptionAlgorithm * OptionKind:ScriptDom.KeyOptionKind
  | CreationDispositionKeyOption of IsCreateNew:bool * OptionKind:ScriptDom.KeyOptionKind
  | IdentityValueKeyOption of IdentityPhrase:Literal option * OptionKind:ScriptDom.KeyOptionKind
  | KeySourceKeyOption of OptionKind:ScriptDom.KeyOptionKind * PassPhrase:Literal option
  | ProviderKeyNameKeyOption of KeyName:Literal option * OptionKind:ScriptDom.KeyOptionKind
  static member FromTs(src:ScriptDom.KeyOption) : KeyOption =
    match src with
    | :? ScriptDom.AlgorithmKeyOption as src ->
      KeyOption.AlgorithmKeyOption((src.Algorithm) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.CreationDispositionKeyOption as src ->
      KeyOption.CreationDispositionKeyOption((src.IsCreateNew) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.IdentityValueKeyOption as src ->
      KeyOption.IdentityValueKeyOption((src.IdentityPhrase |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.KeySourceKeyOption as src ->
      KeyOption.KeySourceKeyOption((src.OptionKind) (* 196 *), (src.PassPhrase |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.ProviderKeyNameKeyOption as src ->
      KeyOption.ProviderKeyNameKeyOption((src.KeyName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] LiteralRange = 
  | Base of From:Literal option * To:Literal option
  | ProcessAffinityRange of From:Literal option * To:Literal option
  static member FromTs(src:ScriptDom.LiteralRange) : LiteralRange =
    match src with
    | :? ScriptDom.ProcessAffinityRange as src ->
      LiteralRange.ProcessAffinityRange((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.LiteralRange as src *)
      LiteralRange.Base((* 297 *)((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] LowPriorityLockWaitOption = 
  | LowPriorityLockWaitAbortAfterWaitOption of AbortAfterWait:ScriptDom.AbortAfterWaitType * OptionKind:ScriptDom.LowPriorityLockWaitOptionKind
  | LowPriorityLockWaitMaxDurationOption of MaxDuration:Literal option * OptionKind:ScriptDom.LowPriorityLockWaitOptionKind * Unit:(ScriptDom.TimeUnit) option
  static member FromTs(src:ScriptDom.LowPriorityLockWaitOption) : LowPriorityLockWaitOption =
    match src with
    | :? ScriptDom.LowPriorityLockWaitAbortAfterWaitOption as src ->
      LowPriorityLockWaitOption.LowPriorityLockWaitAbortAfterWaitOption((src.AbortAfterWait) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.LowPriorityLockWaitMaxDurationOption as src ->
      LowPriorityLockWaitOption.LowPriorityLockWaitMaxDurationOption((src.MaxDuration |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (Option.ofNullable (src.Unit)))
and [<RequireQualifiedAccess>] MergeAction = 
  | DeleteMergeAction 
  | InsertMergeAction of Columns:(ColumnReferenceExpression) list * Source:ValuesInsertSource option
  | UpdateMergeAction of SetClauses:(SetClause) list
  static member FromTs(src:ScriptDom.MergeAction) : MergeAction =
    match src with
    | :? ScriptDom.DeleteMergeAction as src ->
      MergeAction.DeleteMergeAction
    | :? ScriptDom.InsertMergeAction as src ->
      MergeAction.InsertMergeAction((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.Source |> Option.ofObj |> Option.map (ValuesInsertSource.FromTs)) (* 193 *))
    | :? ScriptDom.UpdateMergeAction as src ->
      MergeAction.UpdateMergeAction((src.SetClauses |> Seq.map (SetClause.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] MultiPartIdentifier = 
  | Base of Count:Int32 * Identifiers:(Identifier) list
  | SchemaObjectName of SchemaObjectName
  static member FromTs(src:ScriptDom.MultiPartIdentifier) : MultiPartIdentifier =
    match src with
    | :? ScriptDom.SchemaObjectName as src ->
      match src with
      | :? ScriptDom.ChildObjectName as src-> (* 274 *)
        MultiPartIdentifier.SchemaObjectName((SchemaObjectName.ChildObjectName((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ChildIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.SchemaObjectNameSnippet as src-> (* 274 *)
        MultiPartIdentifier.SchemaObjectName((SchemaObjectName.SchemaObjectNameSnippet((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Script)) (* 198 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.SchemaObjectName as src *)
        MultiPartIdentifier.SchemaObjectName((SchemaObjectName.Base((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | _ -> (* :? ScriptDom.MultiPartIdentifier as src *)
      MultiPartIdentifier.Base((* 297 *)((src.Count) (* 196 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq)))
and [<RequireQualifiedAccess>] OptimizerHint = 
  | Base of HintKind:ScriptDom.OptimizerHintKind
  | LiteralOptimizerHint of HintKind:ScriptDom.OptimizerHintKind * Value:Literal option
  | OptimizeForOptimizerHint of HintKind:ScriptDom.OptimizerHintKind * IsForUnknown:bool * Pairs:(VariableValuePair) list
  | TableHintsOptimizerHint of HintKind:ScriptDom.OptimizerHintKind * ObjectName:SchemaObjectName option * TableHints:(TableHint) list
  static member FromTs(src:ScriptDom.OptimizerHint) : OptimizerHint =
    match src with
    | :? ScriptDom.LiteralOptimizerHint as src ->
      OptimizerHint.LiteralOptimizerHint((src.HintKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OptimizeForOptimizerHint as src ->
      OptimizerHint.OptimizeForOptimizerHint((src.HintKind) (* 196 *), (src.IsForUnknown) (* 196 *), (src.Pairs |> Seq.map (fun src -> VariableValuePair.VariableValuePair((src.IsForUnknown) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))) |> List.ofSeq))
    | :? ScriptDom.TableHintsOptimizerHint as src ->
      OptimizerHint.TableHintsOptimizerHint((src.HintKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TableHints |> Seq.map (TableHint.FromTs) |> List.ofSeq))
    | _ -> (* :? ScriptDom.OptimizerHint as src *)
      OptimizerHint.Base((* 297 *)((src.HintKind) (* 196 *)))
and [<RequireQualifiedAccess>] OptionValue = 
  | LiteralOptionValue of Value:Literal option
  | OnOffOptionValue of OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.OptionValue) : OptionValue =
    match src with
    | :? ScriptDom.LiteralOptionValue as src ->
      OptionValue.LiteralOptionValue((src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OnOffOptionValue as src ->
      OptionValue.OnOffOptionValue((src.OptionState) (* 196 *))
and [<RequireQualifiedAccess>] PayloadOption = 
  | AuthenticationPayloadOption of Certificate:Identifier option * Kind:ScriptDom.PayloadOptionKinds * Protocol:ScriptDom.AuthenticationProtocol * TryCertificateFirst:bool
  | CharacterSetPayloadOption of IsSql:bool * Kind:ScriptDom.PayloadOptionKinds
  | EnabledDisabledPayloadOption of IsEnabled:bool * Kind:ScriptDom.PayloadOptionKinds
  | EncryptionPayloadOption of AlgorithmPartOne:ScriptDom.EncryptionAlgorithmPreference * AlgorithmPartTwo:ScriptDom.EncryptionAlgorithmPreference * EncryptionSupport:ScriptDom.EndpointEncryptionSupport * Kind:ScriptDom.PayloadOptionKinds
  | LiteralPayloadOption of Kind:ScriptDom.PayloadOptionKinds * Value:Literal option
  | LoginTypePayloadOption of IsWindows:bool * Kind:ScriptDom.PayloadOptionKinds
  | RolePayloadOption of Kind:ScriptDom.PayloadOptionKinds * Role:ScriptDom.DatabaseMirroringEndpointRole
  | SchemaPayloadOption of IsStandard:bool * Kind:ScriptDom.PayloadOptionKinds
  | SessionTimeoutPayloadOption of IsNever:bool * Kind:ScriptDom.PayloadOptionKinds * Timeout:Literal option
  | SoapMethod of Action:ScriptDom.SoapMethodAction * Alias:Literal option * Format:ScriptDom.SoapMethodFormat * Kind:ScriptDom.PayloadOptionKinds * Name:Literal option * Namespace:Literal option * Schema:ScriptDom.SoapMethodSchemas
  | WsdlPayloadOption of IsNone:bool * Kind:ScriptDom.PayloadOptionKinds * Value:Literal option
  static member FromTs(src:ScriptDom.PayloadOption) : PayloadOption =
    match src with
    | :? ScriptDom.AuthenticationPayloadOption as src ->
      PayloadOption.AuthenticationPayloadOption((src.Certificate |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Protocol) (* 196 *), (src.TryCertificateFirst) (* 196 *))
    | :? ScriptDom.CharacterSetPayloadOption as src ->
      PayloadOption.CharacterSetPayloadOption((src.IsSql) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.EnabledDisabledPayloadOption as src ->
      PayloadOption.EnabledDisabledPayloadOption((src.IsEnabled) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.EncryptionPayloadOption as src ->
      PayloadOption.EncryptionPayloadOption((src.AlgorithmPartOne) (* 196 *), (src.AlgorithmPartTwo) (* 196 *), (src.EncryptionSupport) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.LiteralPayloadOption as src ->
      PayloadOption.LiteralPayloadOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.LoginTypePayloadOption as src ->
      PayloadOption.LoginTypePayloadOption((src.IsWindows) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.RolePayloadOption as src ->
      PayloadOption.RolePayloadOption((src.Kind) (* 196 *), (src.Role) (* 196 *))
    | :? ScriptDom.SchemaPayloadOption as src ->
      PayloadOption.SchemaPayloadOption((src.IsStandard) (* 196 *), (src.Kind) (* 196 *))
    | :? ScriptDom.SessionTimeoutPayloadOption as src ->
      PayloadOption.SessionTimeoutPayloadOption((src.IsNever) (* 196 *), (src.Kind) (* 196 *), (src.Timeout |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.SoapMethod as src ->
      PayloadOption.SoapMethod((src.Action) (* 196 *), (src.Alias |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Format) (* 196 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Namespace |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Schema) (* 196 *))
    | :? ScriptDom.WsdlPayloadOption as src ->
      PayloadOption.WsdlPayloadOption((src.IsNone) (* 196 *), (src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] PrincipalOption = 
  | Base of OptionKind:ScriptDom.PrincipalOptionKind
  | IdentifierPrincipalOption of Identifier:Identifier option * OptionKind:ScriptDom.PrincipalOptionKind
  | LiteralPrincipalOption of OptionKind:ScriptDom.PrincipalOptionKind * Value:Literal option
  | OnOffPrincipalOption of OptionKind:ScriptDom.PrincipalOptionKind * OptionState:ScriptDom.OptionState
  | PasswordAlterPrincipalOption of Hashed:bool * MustChange:bool * OldPassword:Literal option * OptionKind:ScriptDom.PrincipalOptionKind * Password:Literal option * Unlock:bool
  static member FromTs(src:ScriptDom.PrincipalOption) : PrincipalOption =
    match src with
    | :? ScriptDom.IdentifierPrincipalOption as src ->
      PrincipalOption.IdentifierPrincipalOption((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.LiteralPrincipalOption as src ->
      PrincipalOption.LiteralPrincipalOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OnOffPrincipalOption as src ->
      PrincipalOption.OnOffPrincipalOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.PasswordAlterPrincipalOption as src ->
      PrincipalOption.PasswordAlterPrincipalOption((src.Hashed) (* 196 *), (src.MustChange) (* 196 *), (src.OldPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Unlock) (* 196 *))
    | _ -> (* :? ScriptDom.PrincipalOption as src *)
      PrincipalOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] ProcedureOption = 
  | Base of OptionKind:ScriptDom.ProcedureOptionKind
  | ExecuteAsProcedureOption of ExecuteAs:ExecuteAsClause option * OptionKind:ScriptDom.ProcedureOptionKind
  static member FromTs(src:ScriptDom.ProcedureOption) : ProcedureOption =
    match src with
    | :? ScriptDom.ExecuteAsProcedureOption as src ->
      ProcedureOption.ExecuteAsProcedureOption((src.ExecuteAs |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.ProcedureOption as src *)
      ProcedureOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] QueryExpression = 
  | BinaryQueryExpression of All:bool * BinaryQueryExpressionType:ScriptDom.BinaryQueryExpressionType * FirstQueryExpression:QueryExpression option * ForClause:ForClause option * OffsetClause:OffsetClause option * OrderByClause:OrderByClause option * SecondQueryExpression:QueryExpression option
  | QueryParenthesisExpression of ForClause:ForClause option * OffsetClause:OffsetClause option * OrderByClause:OrderByClause option * QueryExpression:QueryExpression option
  | QuerySpecification of ForClause:ForClause option * FromClause:FromClause option * GroupByClause:GroupByClause option * HavingClause:HavingClause option * OffsetClause:OffsetClause option * OrderByClause:OrderByClause option * SelectElements:(SelectElement) list * TopRowFilter:TopRowFilter option * UniqueRowFilter:ScriptDom.UniqueRowFilter * WhereClause:WhereClause option
  static member FromTs(src:ScriptDom.QueryExpression) : QueryExpression =
    match src with
    | :? ScriptDom.BinaryQueryExpression as src ->
      QueryExpression.BinaryQueryExpression((src.All) (* 196 *), (src.BinaryQueryExpressionType) (* 196 *), (src.FirstQueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.SecondQueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.QueryParenthesisExpression as src ->
      QueryExpression.QueryParenthesisExpression((src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.QuerySpecification as src ->
      QueryExpression.QuerySpecification((src.ForClause |> Option.ofObj |> Option.map (ForClause.FromTs)) (* 191 *), (src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.GroupByClause |> Option.ofObj |> Option.map (GroupByClause.FromTs)) (* 193 *), (src.HavingClause |> Option.ofObj |> Option.map (HavingClause.FromTs)) (* 193 *), (src.OffsetClause |> Option.ofObj |> Option.map (OffsetClause.FromTs)) (* 193 *), (src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.SelectElements |> Seq.map (SelectElement.FromTs) |> List.ofSeq), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.UniqueRowFilter) (* 196 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] QueryStoreOption = 
  | QueryStoreCapturePolicyOption of OptionKind:ScriptDom.QueryStoreOptionKind * Value:ScriptDom.QueryStoreCapturePolicyOptionKind
  | QueryStoreDataFlushIntervalOption of FlushInterval:Literal option * OptionKind:ScriptDom.QueryStoreOptionKind
  | QueryStoreDesiredStateOption of OperationModeSpecified:bool * OptionKind:ScriptDom.QueryStoreOptionKind * Value:ScriptDom.QueryStoreDesiredStateOptionKind
  | QueryStoreIntervalLengthOption of OptionKind:ScriptDom.QueryStoreOptionKind * StatsIntervalLength:Literal option
  | QueryStoreMaxPlansPerQueryOption of MaxPlansPerQuery:Literal option * OptionKind:ScriptDom.QueryStoreOptionKind
  | QueryStoreMaxStorageSizeOption of MaxQdsSize:Literal option * OptionKind:ScriptDom.QueryStoreOptionKind
  | QueryStoreSizeCleanupPolicyOption of OptionKind:ScriptDom.QueryStoreOptionKind * Value:ScriptDom.QueryStoreSizeCleanupPolicyOptionKind
  | QueryStoreTimeCleanupPolicyOption of OptionKind:ScriptDom.QueryStoreOptionKind * StaleQueryThreshold:Literal option
  static member FromTs(src:ScriptDom.QueryStoreOption) : QueryStoreOption =
    match src with
    | :? ScriptDom.QueryStoreCapturePolicyOption as src ->
      QueryStoreOption.QueryStoreCapturePolicyOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.QueryStoreDataFlushIntervalOption as src ->
      QueryStoreOption.QueryStoreDataFlushIntervalOption((src.FlushInterval |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.QueryStoreDesiredStateOption as src ->
      QueryStoreOption.QueryStoreDesiredStateOption((src.OperationModeSpecified) (* 196 *), (src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.QueryStoreIntervalLengthOption as src ->
      QueryStoreOption.QueryStoreIntervalLengthOption((src.OptionKind) (* 196 *), (src.StatsIntervalLength |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.QueryStoreMaxPlansPerQueryOption as src ->
      QueryStoreOption.QueryStoreMaxPlansPerQueryOption((src.MaxPlansPerQuery |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.QueryStoreMaxStorageSizeOption as src ->
      QueryStoreOption.QueryStoreMaxStorageSizeOption((src.MaxQdsSize |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.QueryStoreSizeCleanupPolicyOption as src ->
      QueryStoreOption.QueryStoreSizeCleanupPolicyOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.QueryStoreTimeCleanupPolicyOption as src ->
      QueryStoreOption.QueryStoreTimeCleanupPolicyOption((src.OptionKind) (* 196 *), (src.StaleQueryThreshold |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] QueueOption = 
  | Base of OptionKind:ScriptDom.QueueOptionKind
  | QueueExecuteAsOption of OptionKind:ScriptDom.QueueOptionKind * OptionValue:ExecuteAsClause option
  | QueueProcedureOption of OptionKind:ScriptDom.QueueOptionKind * OptionValue:SchemaObjectName option
  | QueueStateOption of OptionKind:ScriptDom.QueueOptionKind * OptionState:ScriptDom.OptionState
  | QueueValueOption of OptionKind:ScriptDom.QueueOptionKind * OptionValue:ValueExpression option
  static member FromTs(src:ScriptDom.QueueOption) : QueueOption =
    match src with
    | :? ScriptDom.QueueExecuteAsOption as src ->
      QueueOption.QueueExecuteAsOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *))
    | :? ScriptDom.QueueProcedureOption as src ->
      QueueOption.QueueProcedureOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.QueueStateOption as src ->
      QueueOption.QueueStateOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.QueueValueOption as src ->
      QueueOption.QueueValueOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.QueueOption as src *)
      QueueOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] RemoteDataArchiveDatabaseSetting = 
  | RemoteDataArchiveDbCredentialSetting of Credential:Identifier option * SettingKind:ScriptDom.RemoteDataArchiveDatabaseSettingKind
  | RemoteDataArchiveDbFederatedServiceAccountSetting of IsOn:bool * SettingKind:ScriptDom.RemoteDataArchiveDatabaseSettingKind
  | RemoteDataArchiveDbServerSetting of Server:StringLiteral option * SettingKind:ScriptDom.RemoteDataArchiveDatabaseSettingKind
  static member FromTs(src:ScriptDom.RemoteDataArchiveDatabaseSetting) : RemoteDataArchiveDatabaseSetting =
    match src with
    | :? ScriptDom.RemoteDataArchiveDbCredentialSetting as src ->
      RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbCredentialSetting((src.Credential |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SettingKind) (* 196 *))
    | :? ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting as src ->
      RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbFederatedServiceAccountSetting((src.IsOn) (* 196 *), (src.SettingKind) (* 196 *))
    | :? ScriptDom.RemoteDataArchiveDbServerSetting as src ->
      RemoteDataArchiveDatabaseSetting.RemoteDataArchiveDbServerSetting((src.Server |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SettingKind) (* 196 *))
and [<RequireQualifiedAccess>] RemoteServiceBindingOption = 
  | OnOffRemoteServiceBindingOption of OptionKind:ScriptDom.RemoteServiceBindingOptionKind * OptionState:ScriptDom.OptionState
  | UserRemoteServiceBindingOption of OptionKind:ScriptDom.RemoteServiceBindingOptionKind * User:Identifier option
  static member FromTs(src:ScriptDom.RemoteServiceBindingOption) : RemoteServiceBindingOption =
    match src with
    | :? ScriptDom.OnOffRemoteServiceBindingOption as src ->
      RemoteServiceBindingOption.OnOffRemoteServiceBindingOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.UserRemoteServiceBindingOption as src ->
      RemoteServiceBindingOption.UserRemoteServiceBindingOption((src.OptionKind) (* 196 *), (src.User |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] RestoreOption = 
  | Base of OptionKind:ScriptDom.RestoreOptionKind
  | FileStreamRestoreOption of FileStreamOption:FileStreamDatabaseOption option * OptionKind:ScriptDom.RestoreOptionKind
  | MoveRestoreOption of LogicalFileName:ValueExpression option * OSFileName:ValueExpression option * OptionKind:ScriptDom.RestoreOptionKind
  | ScalarExpressionRestoreOption of OptionKind:ScriptDom.RestoreOptionKind * Value:ScalarExpression option
  | StopRestoreOption of After:ValueExpression option * IsStopAt:bool * Mark:ValueExpression option * OptionKind:ScriptDom.RestoreOptionKind
  static member FromTs(src:ScriptDom.RestoreOption) : RestoreOption =
    match src with
    | :? ScriptDom.FileStreamRestoreOption as src ->
      RestoreOption.FileStreamRestoreOption((src.FileStreamOption |> Option.ofObj |> Option.map (FileStreamDatabaseOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.MoveRestoreOption as src ->
      RestoreOption.MoveRestoreOption((src.LogicalFileName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OSFileName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.ScalarExpressionRestoreOption as src ->
      RestoreOption.ScalarExpressionRestoreOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.StopRestoreOption as src ->
      RestoreOption.StopRestoreOption((src.After |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.IsStopAt) (* 196 *), (src.Mark |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.RestoreOption as src *)
      RestoreOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] ResultSetDefinition = 
  | Base of ResultSetType:ScriptDom.ResultSetType
  | InlineResultSetDefinition of ResultColumnDefinitions:(ResultColumnDefinition) list * ResultSetType:ScriptDom.ResultSetType
  | SchemaObjectResultSetDefinition of Name:SchemaObjectName option * ResultSetType:ScriptDom.ResultSetType
  static member FromTs(src:ScriptDom.ResultSetDefinition) : ResultSetDefinition =
    match src with
    | :? ScriptDom.InlineResultSetDefinition as src ->
      ResultSetDefinition.InlineResultSetDefinition((src.ResultColumnDefinitions |> Seq.map (fun src -> ResultColumnDefinition.ResultColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))) |> List.ofSeq), (src.ResultSetType) (* 196 *))
    | :? ScriptDom.SchemaObjectResultSetDefinition as src ->
      ResultSetDefinition.SchemaObjectResultSetDefinition((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ResultSetType) (* 196 *))
    | _ -> (* :? ScriptDom.ResultSetDefinition as src *)
      ResultSetDefinition.Base((* 297 *)((src.ResultSetType) (* 196 *)))
and [<RequireQualifiedAccess>] ScalarExpression = 
  | BinaryExpression of BinaryExpressionType:ScriptDom.BinaryExpressionType * FirstExpression:ScalarExpression option * SecondExpression:ScalarExpression option
  | ExtractFromExpression of Expression:ScalarExpression option * ExtractedElement:Identifier option
  | IdentityFunctionCall of DataType:DataTypeReference option * Increment:ScalarExpression option * Seed:ScalarExpression option
  | OdbcConvertSpecification of Identifier:Identifier option
  | PrimaryExpression of PrimaryExpression
  | ScalarExpressionSnippet of Script:String option
  | SourceDeclaration of Value:EventSessionObjectName option
  | UnaryExpression of Expression:ScalarExpression option * UnaryExpressionType:ScriptDom.UnaryExpressionType
  static member FromTs(src:ScriptDom.ScalarExpression) : ScalarExpression =
    match src with
    | :? ScriptDom.BinaryExpression as src ->
      ScalarExpression.BinaryExpression((src.BinaryExpressionType) (* 196 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ExtractFromExpression as src ->
      ScalarExpression.ExtractFromExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ExtractedElement |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.IdentityFunctionCall as src ->
      ScalarExpression.IdentityFunctionCall((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Increment |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Seed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.OdbcConvertSpecification as src ->
      ScalarExpression.OdbcConvertSpecification((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.PrimaryExpression as src ->
      match src with
      | :? ScriptDom.AtTimeZoneCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.AtTimeZoneCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DateValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TimeZone |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.CaseExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.CaseExpression((CaseExpression.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CastCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.CastCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.CoalesceExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.CoalesceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ColumnReferenceExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))))
      | :? ScriptDom.ConvertCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ConvertCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Style |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.FunctionCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.FunctionCall((src.CallTarget |> Option.ofObj |> Option.map (CallTarget.FromTs)) (* 191 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FunctionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OverClause |> Option.ofObj |> Option.map (OverClause.FromTs)) (* 193 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.UniqueRowFilter) (* 196 *), (src.WithinGroupClause |> Option.ofObj |> Option.map (WithinGroupClause.FromTs)) (* 193 *))))
      | :? ScriptDom.IIfCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.IIfCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.LeftFunctionCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.LeftFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.NextValueForExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.NextValueForExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OverClause |> Option.ofObj |> Option.map (OverClause.FromTs)) (* 193 *), (src.SequenceName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.NullIfExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.NullIfExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.OdbcFunctionCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.OdbcFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ParametersUsed) (* 196 *))))
      | :? ScriptDom.ParameterlessCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ParameterlessCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterlessCallType) (* 196 *))))
      | :? ScriptDom.ParenthesisExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ParenthesisExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.ParseCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ParseCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Culture |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.StringValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.PartitionFunctionCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.PartitionFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FunctionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.RightFunctionCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.RightFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ScalarSubquery as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ScalarSubquery((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.TryCastCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.TryCastCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.TryConvertCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.TryConvertCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Style |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.TryParseCall as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.TryParseCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Culture |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.StringValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.UserDefinedTypePropertyAccess as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.UserDefinedTypePropertyAccess((src.CallTarget |> Option.ofObj |> Option.map (CallTarget.FromTs)) (* 191 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.ValueExpression as src-> (* 274 *)
        ScalarExpression.PrimaryExpression((PrimaryExpression.ValueExpression((ValueExpression.FromTs(src))) (* 251 *)))
    | :? ScriptDom.ScalarExpressionSnippet as src ->
      ScalarExpression.ScalarExpressionSnippet((Option.ofObj (src.Script)) (* 198 *))
    | :? ScriptDom.SourceDeclaration as src ->
      ScalarExpression.SourceDeclaration((src.Value |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))
    | :? ScriptDom.UnaryExpression as src ->
      ScalarExpression.UnaryExpression((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.UnaryExpressionType) (* 196 *))
and [<RequireQualifiedAccess>] SchemaDeclarationItem = 
  | Base of ColumnDefinition:ColumnDefinitionBase option * Mapping:ValueExpression option
  | SchemaDeclarationItemOpenjson of AsJson:bool * ColumnDefinition:ColumnDefinitionBase option * Mapping:ValueExpression option
  static member FromTs(src:ScriptDom.SchemaDeclarationItem) : SchemaDeclarationItem =
    match src with
    | :? ScriptDom.SchemaDeclarationItemOpenjson as src ->
      SchemaDeclarationItem.SchemaDeclarationItemOpenjson((src.AsJson) (* 196 *), (src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.SchemaDeclarationItem as src *)
      SchemaDeclarationItem.Base((* 297 *)((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] SearchPropertyListAction = 
  | AddSearchPropertyListAction of Description:StringLiteral option * Guid:StringLiteral option * Id:IntegerLiteral option * PropertyName:StringLiteral option
  | DropSearchPropertyListAction of PropertyName:StringLiteral option
  static member FromTs(src:ScriptDom.SearchPropertyListAction) : SearchPropertyListAction =
    match src with
    | :? ScriptDom.AddSearchPropertyListAction as src ->
      SearchPropertyListAction.AddSearchPropertyListAction((src.Description |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Guid |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Id |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.DropSearchPropertyListAction as src ->
      SearchPropertyListAction.DropSearchPropertyListAction((src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SecurityElement80 = 
  | CommandSecurityElement80 of All:bool * CommandOptions:ScriptDom.CommandOptions
  | PrivilegeSecurityElement80 of Columns:(Identifier) list * Privileges:(Privilege80) list * SchemaObjectName:SchemaObjectName option
  static member FromTs(src:ScriptDom.SecurityElement80) : SecurityElement80 =
    match src with
    | :? ScriptDom.CommandSecurityElement80 as src ->
      SecurityElement80.CommandSecurityElement80((src.All) (* 196 *), (src.CommandOptions) (* 196 *))
    | :? ScriptDom.PrivilegeSecurityElement80 as src ->
      SecurityElement80.PrivilegeSecurityElement80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Privileges |> Seq.map (fun src -> Privilege80.Privilege80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrivilegeType80) (* 196 *))) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SelectElement = 
  | SelectScalarExpression of ColumnName:IdentifierOrValueExpression option * Expression:ScalarExpression option
  | SelectSetVariable of AssignmentKind:ScriptDom.AssignmentKind * Expression:ScalarExpression option * Variable:VariableReference option
  | SelectStarExpression of Qualifier:MultiPartIdentifier option
  static member FromTs(src:ScriptDom.SelectElement) : SelectElement =
    match src with
    | :? ScriptDom.SelectScalarExpression as src ->
      SelectElement.SelectScalarExpression((src.ColumnName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SelectSetVariable as src ->
      SelectElement.SelectSetVariable((src.AssignmentKind) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.SelectStarExpression as src ->
      SelectElement.SelectStarExpression((src.Qualifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SequenceOption = 
  | Base of NoValue:bool * OptionKind:ScriptDom.SequenceOptionKind
  | DataTypeSequenceOption of DataType:DataTypeReference option * NoValue:bool * OptionKind:ScriptDom.SequenceOptionKind
  | ScalarExpressionSequenceOption of NoValue:bool * OptionKind:ScriptDom.SequenceOptionKind * OptionValue:ScalarExpression option
  static member FromTs(src:ScriptDom.SequenceOption) : SequenceOption =
    match src with
    | :? ScriptDom.DataTypeSequenceOption as src ->
      SequenceOption.DataTypeSequenceOption((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.NoValue) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.ScalarExpressionSequenceOption as src ->
      SequenceOption.ScalarExpressionSequenceOption((src.NoValue) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.SequenceOption as src *)
      SequenceOption.Base((* 297 *)((src.NoValue) (* 196 *), (src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] SessionOption = 
  | EventRetentionSessionOption of OptionKind:ScriptDom.SessionOptionKind * Value:ScriptDom.EventSessionEventRetentionModeType
  | LiteralSessionOption of OptionKind:ScriptDom.SessionOptionKind * Unit:ScriptDom.MemoryUnit * Value:Literal option
  | MaxDispatchLatencySessionOption of IsInfinite:bool * OptionKind:ScriptDom.SessionOptionKind * Value:Literal option
  | MemoryPartitionSessionOption of OptionKind:ScriptDom.SessionOptionKind * Value:ScriptDom.EventSessionMemoryPartitionModeType
  | OnOffSessionOption of OptionKind:ScriptDom.SessionOptionKind * OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.SessionOption) : SessionOption =
    match src with
    | :? ScriptDom.EventRetentionSessionOption as src ->
      SessionOption.EventRetentionSessionOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.LiteralSessionOption as src ->
      SessionOption.LiteralSessionOption((src.OptionKind) (* 196 *), (src.Unit) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.MaxDispatchLatencySessionOption as src ->
      SessionOption.MaxDispatchLatencySessionOption((src.IsInfinite) (* 196 *), (src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.MemoryPartitionSessionOption as src ->
      SessionOption.MemoryPartitionSessionOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.OnOffSessionOption as src ->
      SessionOption.OnOffSessionOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
and [<RequireQualifiedAccess>] SetClause = 
  | AssignmentSetClause of AssignmentKind:ScriptDom.AssignmentKind * Column:ColumnReferenceExpression option * NewValue:ScalarExpression option * Variable:VariableReference option
  | FunctionCallSetClause of MutatorFunction:FunctionCall option
  static member FromTs(src:ScriptDom.SetClause) : SetClause =
    match src with
    | :? ScriptDom.AssignmentSetClause as src ->
      SetClause.AssignmentSetClause((src.AssignmentKind) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.NewValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.FunctionCallSetClause as src ->
      SetClause.FunctionCallSetClause((src.MutatorFunction |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SetCommand = 
  | GeneralSetCommand of CommandType:ScriptDom.GeneralSetCommandType * Parameter:ScalarExpression option
  | SetFipsFlaggerCommand of ComplianceLevel:ScriptDom.FipsComplianceLevel
  static member FromTs(src:ScriptDom.SetCommand) : SetCommand =
    match src with
    | :? ScriptDom.GeneralSetCommand as src ->
      SetCommand.GeneralSetCommand((src.CommandType) (* 196 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SetFipsFlaggerCommand as src ->
      SetCommand.SetFipsFlaggerCommand((src.ComplianceLevel) (* 196 *))
and [<RequireQualifiedAccess>] SpatialIndexOption = 
  | BoundingBoxSpatialIndexOption of BoundingBoxParameters:(BoundingBoxParameter) list
  | CellsPerObjectSpatialIndexOption of Value:Literal option
  | GridsSpatialIndexOption of GridParameters:(GridParameter) list
  | SpatialIndexRegularOption of Option:IndexOption option
  static member FromTs(src:ScriptDom.SpatialIndexOption) : SpatialIndexOption =
    match src with
    | :? ScriptDom.BoundingBoxSpatialIndexOption as src ->
      SpatialIndexOption.BoundingBoxSpatialIndexOption((src.BoundingBoxParameters |> Seq.map (fun src -> BoundingBoxParameter.BoundingBoxParameter((src.Parameter) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.CellsPerObjectSpatialIndexOption as src ->
      SpatialIndexOption.CellsPerObjectSpatialIndexOption((src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.GridsSpatialIndexOption as src ->
      SpatialIndexOption.GridsSpatialIndexOption((src.GridParameters |> Seq.map (fun src -> GridParameter.GridParameter((src.Parameter) (* 196 *), (src.Value) (* 196 *))) |> List.ofSeq))
    | :? ScriptDom.SpatialIndexRegularOption as src ->
      SpatialIndexOption.SpatialIndexRegularOption((src.Option |> Option.ofObj |> Option.map (IndexOption.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] StatementList = 
  | Base of Statements:(TSqlStatement) list
  | StatementListSnippet of Script:String option * Statements:(TSqlStatement) list
  static member FromTs(src:ScriptDom.StatementList) : StatementList =
    match src with
    | :? ScriptDom.StatementListSnippet as src ->
      StatementList.StatementListSnippet((Option.ofObj (src.Script)) (* 198 *), (src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))
    | _ -> (* :? ScriptDom.StatementList as src *)
      StatementList.Base((* 297 *)((src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq)))
and [<RequireQualifiedAccess>] StatisticsOption = 
  | Base of OptionKind:ScriptDom.StatisticsOptionKind
  | LiteralStatisticsOption of Literal:Literal option * OptionKind:ScriptDom.StatisticsOptionKind
  | OnOffStatisticsOption of OptionKind:ScriptDom.StatisticsOptionKind * OptionState:ScriptDom.OptionState
  | ResampleStatisticsOption of OptionKind:ScriptDom.StatisticsOptionKind * Partitions:(StatisticsPartitionRange) list
  static member FromTs(src:ScriptDom.StatisticsOption) : StatisticsOption =
    match src with
    | :? ScriptDom.LiteralStatisticsOption as src ->
      StatisticsOption.LiteralStatisticsOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.OnOffStatisticsOption as src ->
      StatisticsOption.OnOffStatisticsOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.ResampleStatisticsOption as src ->
      StatisticsOption.ResampleStatisticsOption((src.OptionKind) (* 196 *), (src.Partitions |> Seq.map (fun src -> StatisticsPartitionRange.StatisticsPartitionRange((src.From |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.To |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))) |> List.ofSeq))
    | _ -> (* :? ScriptDom.StatisticsOption as src *)
      StatisticsOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] TSqlStatement = 
  | AlterAsymmetricKeyStatement of AttestedBy:Literal option * DecryptionPassword:Literal option * EncryptionPassword:Literal option * Kind:ScriptDom.AlterCertificateStatementKind * Name:Identifier option
  | AlterAuthorizationStatement of PrincipalName:Identifier option * SecurityTargetObject:SecurityTargetObject option * ToSchemaOwner:bool
  | AlterCreateEndpointStatementBase of AlterCreateEndpointStatementBase
  | AlterCreateServiceStatementBase of AlterCreateServiceStatementBase
  | AlterCryptographicProviderStatement of File:Literal option * Name:Identifier option * Option:ScriptDom.EnableDisableOptionType
  | AlterDatabaseScopedConfigurationStatement of AlterDatabaseScopedConfigurationStatement
  | AlterDatabaseStatement of AlterDatabaseStatement
  | AlterFederationStatement of Boundary:ScalarExpression option * DistributionName:Identifier option * Kind:ScriptDom.AlterFederationKind * Name:Identifier option
  | AlterFullTextIndexStatement of Action:AlterFullTextIndexAction option * OnName:SchemaObjectName option
  | AlterFullTextStopListStatement of Action:FullTextStopListAction option * Name:Identifier option
  | AlterLoginStatement of AlterLoginStatement
  | AlterPartitionFunctionStatement of Boundary:ScalarExpression option * IsSplit:bool * Name:Identifier option
  | AlterPartitionSchemeStatement of FileGroup:IdentifierOrValueExpression option * Name:Identifier option
  | AlterResourceGovernorStatement of ClassifierFunction:SchemaObjectName option * Command:ScriptDom.AlterResourceGovernorCommandType
  | AlterSchemaStatement of Name:Identifier option * ObjectKind:ScriptDom.SecurityObjectKind * ObjectName:SchemaObjectName option
  | AlterSearchPropertyListStatement of Action:SearchPropertyListAction option * Name:Identifier option
  | AlterServerConfigurationSetBufferPoolExtensionStatement of Options:(AlterServerConfigurationBufferPoolExtensionOption) list
  | AlterServerConfigurationSetDiagnosticsLogStatement of Options:(AlterServerConfigurationDiagnosticsLogOption) list
  | AlterServerConfigurationSetFailoverClusterPropertyStatement of Options:(AlterServerConfigurationFailoverClusterPropertyOption) list
  | AlterServerConfigurationSetHadrClusterStatement of Options:(AlterServerConfigurationHadrClusterOption) list
  | AlterServerConfigurationSetSoftNumaStatement of Options:(AlterServerConfigurationSoftNumaOption) list
  | AlterServerConfigurationStatement of ProcessAffinity:ScriptDom.ProcessAffinityType * ProcessAffinityRanges:(ProcessAffinityRange) list
  | AlterServiceMasterKeyStatement of Account:Literal option * Kind:ScriptDom.AlterServiceMasterKeyOption * Password:Literal option
  | AlterTableStatement of AlterTableStatement
  | AlterXmlSchemaCollectionStatement of Expression:ScalarExpression option * Name:SchemaObjectName option
  | ApplicationRoleStatement of ApplicationRoleStatement
  | AssemblyStatement of AssemblyStatement
  | AuditSpecificationStatement of AuditSpecificationStatement
  | AvailabilityGroupStatement of AvailabilityGroupStatement
  | BackupRestoreMasterKeyStatementBase of BackupRestoreMasterKeyStatementBase
  | BackupStatement of BackupStatement
  | BeginConversationTimerStatement of Handle:ScalarExpression option * Timeout:ScalarExpression option
  | BeginDialogStatement of ContractName:IdentifierOrValueExpression option * Handle:VariableReference option * InitiatorServiceName:IdentifierOrValueExpression option * InstanceSpec:ValueExpression option * IsConversation:bool * Options:(DialogOption) list * TargetServiceName:ValueExpression option
  | BeginEndBlockStatement of BeginEndBlockStatement
  | BreakStatement 
  | BrokerPriorityStatement of BrokerPriorityStatement
  | BulkInsertBase of BulkInsertBase
  | CertificateStatementBase of CertificateStatementBase
  | CheckpointStatement of Duration:Literal option
  | CloseMasterKeyStatement 
  | CloseSymmetricKeyStatement of All:bool * Name:Identifier option
  | ColumnEncryptionKeyStatement of ColumnEncryptionKeyStatement
  | ContinueStatement 
  | CreateAggregateStatement of AssemblyName:AssemblyName option * Name:SchemaObjectName option * Parameters:(ProcedureParameter) list * ReturnType:DataTypeReference option
  | CreateAsymmetricKeyStatement of EncryptionAlgorithm:ScriptDom.EncryptionAlgorithm * KeySource:EncryptionSource option * Name:Identifier option * Owner:Identifier option * Password:Literal option
  | CreateColumnMasterKeyStatement of Name:Identifier option * Parameters:(ColumnMasterKeyParameter) list
  | CreateColumnStoreIndexStatement of Clustered:(bool) option * Columns:(ColumnReferenceExpression) list * FilterPredicate:BooleanExpression option * IndexOptions:(IndexOption) list * Name:Identifier option * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option * OnName:SchemaObjectName option
  | CreateContractStatement of Messages:(ContractMessage) list * Name:Identifier option * Owner:Identifier option
  | CreateCryptographicProviderStatement of File:Literal option * Name:Identifier option
  | CreateDatabaseStatement of AttachMode:ScriptDom.AttachMode * Collation:Identifier option * Containment:ContainmentDatabaseOption option * CopyOf:MultiPartIdentifier option * DatabaseName:Identifier option * DatabaseSnapshot:Identifier option * FileGroups:(FileGroupDefinition) list * LogOn:(FileDeclaration) list * Options:(DatabaseOption) list
  | CreateDefaultStatement of Expression:ScalarExpression option * Name:SchemaObjectName option
  | CreateEventNotificationStatement of BrokerInstanceSpecifier:Literal option * BrokerService:Literal option * EventTypeGroups:(EventTypeGroupContainer) list * Name:Identifier option * Scope:EventNotificationObjectScope option * WithFanIn:bool
  | CreateFederationStatement of DataType:DataTypeReference option * DistributionName:Identifier option * Name:Identifier option
  | CreateFullTextIndexStatement of CatalogAndFileGroup:FullTextCatalogAndFileGroup option * FullTextIndexColumns:(FullTextIndexColumn) list * KeyIndexName:Identifier option * OnName:SchemaObjectName option * Options:(FullTextIndexOption) list
  | CreateFullTextStopListStatement of DatabaseName:Identifier option * IsSystemStopList:bool * Name:Identifier option * Owner:Identifier option * SourceStopListName:Identifier option
  | CreateLoginStatement of Name:Identifier option * Source:CreateLoginSource option
  | CreatePartitionFunctionStatement of BoundaryValues:(ScalarExpression) list * Name:Identifier option * ParameterType:PartitionParameterType option * Range:ScriptDom.PartitionFunctionRange
  | CreatePartitionSchemeStatement of FileGroups:(IdentifierOrValueExpression) list * IsAll:bool * Name:Identifier option * PartitionFunction:Identifier option
  | CreateRuleStatement of Expression:BooleanExpression option * Name:SchemaObjectName option
  | CreateSchemaStatement of Name:Identifier option * Owner:Identifier option * StatementList:StatementList option
  | CreateSearchPropertyListStatement of Name:Identifier option * Owner:Identifier option * SourceSearchPropertyList:MultiPartIdentifier option
  | CreateSpatialIndexStatement of Name:Identifier option * Object:SchemaObjectName option * OnFileGroup:IdentifierOrValueExpression option * SpatialColumnName:Identifier option * SpatialIndexOptions:(SpatialIndexOption) list * SpatialIndexingScheme:ScriptDom.SpatialIndexingSchemeType
  | CreateStatisticsStatement of Columns:(ColumnReferenceExpression) list * FilterPredicate:BooleanExpression option * Name:Identifier option * OnName:SchemaObjectName option * StatisticsOptions:(StatisticsOption) list
  | CreateSynonymStatement of ForName:SchemaObjectName option * Name:SchemaObjectName option
  | CreateTableStatement of AsFileTable:bool * Definition:TableDefinition option * FederationScheme:FederationScheme option * FileStreamOn:IdentifierOrValueExpression option * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option * Options:(TableOption) list * SchemaObjectName:SchemaObjectName option * TextImageOn:IdentifierOrValueExpression option
  | CreateTypeStatement of CreateTypeStatement
  | CreateXmlSchemaCollectionStatement of Expression:ScalarExpression option * Name:SchemaObjectName option
  | CredentialStatement of CredentialStatement
  | CursorStatement of CursorStatement
  | DatabaseEncryptionKeyStatement of DatabaseEncryptionKeyStatement
  | DbccStatement of Command:ScriptDom.DbccCommand * DllName:String option * Literals:(DbccNamedLiteral) list * Options:(DbccOption) list * OptionsUseJoin:bool * ParenthesisRequired:bool
  | DeclareCursorStatement of CursorDefinition:CursorDefinition option * Name:Identifier option
  | DeclareTableVariableStatement of Body:DeclareTableVariableBody option
  | DeclareVariableStatement of Declarations:(DeclareVariableElement) list
  | DiskStatement of DiskStatementType:ScriptDom.DiskStatementType * Options:(DiskStatementOption) list
  | DropChildObjectsStatement of DropChildObjectsStatement
  | DropDatabaseEncryptionKeyStatement 
  | DropDatabaseStatement of Databases:(Identifier) list * IsIfExists:bool
  | DropEventNotificationStatement of Notifications:(Identifier) list * Scope:EventNotificationObjectScope option
  | DropFullTextIndexStatement of TableName:SchemaObjectName option
  | DropIndexStatement of DropIndexClauses:(DropIndexClauseBase) list * IsIfExists:bool
  | DropMasterKeyStatement 
  | DropObjectsStatement of DropObjectsStatement
  | DropQueueStatement of Name:SchemaObjectName option
  | DropSchemaStatement of DropBehavior:ScriptDom.DropSchemaBehavior * IsIfExists:bool * Schema:SchemaObjectName option
  | DropTypeStatement of IsIfExists:bool * Name:SchemaObjectName option
  | DropUnownedObjectStatement of DropUnownedObjectStatement
  | DropXmlSchemaCollectionStatement of Name:SchemaObjectName option
  | EnableDisableTriggerStatement of All:bool * TriggerEnforcement:ScriptDom.TriggerEnforcement * TriggerNames:(SchemaObjectName) list * TriggerObject:TriggerObject option
  | EndConversationStatement of Conversation:ScalarExpression option * ErrorCode:ValueExpression option * ErrorDescription:ValueExpression option * WithCleanup:bool
  | EventSessionStatement of EventSessionStatement
  | ExecuteAsStatement of Cookie:VariableReference option * ExecuteContext:ExecuteContext option * WithNoRevert:bool
  | ExecuteStatement of ExecuteSpecification:ExecuteSpecification option * Options:(ExecuteOption) list
  | ExternalDataSourceStatement of ExternalDataSourceStatement
  | ExternalFileFormatStatement of ExternalFileFormatStatement
  | ExternalResourcePoolStatement of ExternalResourcePoolStatement
  | ExternalTableStatement of ExternalTableStatement
  | FullTextCatalogStatement of FullTextCatalogStatement
  | GoToStatement of LabelName:Identifier option
  | IfStatement of ElseStatement:TSqlStatement option * Predicate:BooleanExpression option * ThenStatement:TSqlStatement option
  | IndexDefinition of Columns:(ColumnWithSortOrder) list * FileStreamOn:IdentifierOrValueExpression option * FilterPredicate:BooleanExpression option * IndexOptions:(IndexOption) list * IndexType:IndexType option * Name:Identifier option * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option * Unique:bool
  | IndexStatement of IndexStatement
  | KillQueryNotificationSubscriptionStatement of All:bool * SubscriptionId:Literal option
  | KillStatement of Parameter:ScalarExpression option * WithStatusOnly:bool
  | KillStatsJobStatement of JobId:ScalarExpression option
  | LabelStatement of Value:String option
  | LineNoStatement of LineNo:IntegerLiteral option
  | MasterKeyStatement of MasterKeyStatement
  | MessageTypeStatementBase of MessageTypeStatementBase
  | MoveConversationStatement of Conversation:ScalarExpression option * Group:ScalarExpression option
  | OpenMasterKeyStatement of Password:Literal option
  | OpenSymmetricKeyStatement of DecryptionMechanism:CryptoMechanism option * Name:Identifier option
  | PrintStatement of Expression:ScalarExpression option
  | ProcedureStatementBodyBase of ProcedureStatementBodyBase
  | QueueStatement of QueueStatement
  | RaiseErrorLegacyStatement of FirstParameter:ScalarExpression option * SecondParameter:ValueExpression option
  | RaiseErrorStatement of FirstParameter:ScalarExpression option * OptionalParameters:(ScalarExpression) list * RaiseErrorOptions:ScriptDom.RaiseErrorOptions * SecondParameter:ScalarExpression option * ThirdParameter:ScalarExpression option
  | ReadTextStatement of Column:ColumnReferenceExpression option * HoldLock:bool * Offset:ValueExpression option * Size:ValueExpression option * TextPointer:ValueExpression option
  | ReconfigureStatement of WithOverride:bool
  | RemoteServiceBindingStatementBase of RemoteServiceBindingStatementBase
  | ResourcePoolStatement of ResourcePoolStatement
  | RestoreStatement of DatabaseName:IdentifierOrValueExpression option * Devices:(DeviceInfo) list * Files:(BackupRestoreFileInfo) list * Kind:ScriptDom.RestoreStatementKind * Options:(RestoreOption) list
  | ReturnStatement of Expression:ScalarExpression option
  | RevertStatement of Cookie:ScalarExpression option
  | RoleStatement of RoleStatement
  | RouteStatement of RouteStatement
  | SecurityPolicyStatement of SecurityPolicyStatement
  | SecurityStatement of SecurityStatement
  | SecurityStatementBody80 of SecurityStatementBody80
  | SendStatement of ConversationHandles:(ScalarExpression) list * MessageBody:ScalarExpression option * MessageTypeName:IdentifierOrValueExpression option
  | SequenceStatement of SequenceStatement
  | ServerAuditStatement of ServerAuditStatement
  | SetCommandStatement of Commands:(SetCommand) list
  | SetErrorLevelStatement of Level:ScalarExpression option
  | SetOnOffStatement of SetOnOffStatement
  | SetRowCountStatement of NumberRows:ValueExpression option
  | SetTextSizeStatement of TextSize:ScalarExpression option
  | SetTransactionIsolationLevelStatement of Level:ScriptDom.IsolationLevel
  | SetUserStatement of UserName:ValueExpression option * WithNoReset:bool
  | SetVariableStatement of AssignmentKind:ScriptDom.AssignmentKind * CursorDefinition:CursorDefinition option * Expression:ScalarExpression option * FunctionCallExists:bool * Identifier:Identifier option * Parameters:(ScalarExpression) list * SeparatorType:ScriptDom.SeparatorType * Variable:VariableReference option
  | ShutdownStatement of WithNoWait:bool
  | SignatureStatementBase of SignatureStatementBase
  | StatementWithCtesAndXmlNamespaces of StatementWithCtesAndXmlNamespaces
  | SymmetricKeyStatement of SymmetricKeyStatement
  | TSqlStatementSnippet of Script:String option
  | TextModificationStatement of TextModificationStatement
  | ThrowStatement of ErrorNumber:ValueExpression option * Message:ValueExpression option * State:ValueExpression option
  | TransactionStatement of TransactionStatement
  | TriggerStatementBody of TriggerStatementBody
  | TruncateTableStatement of PartitionRanges:(CompressionPartitionRange) list * TableName:SchemaObjectName option
  | TryCatchStatement of CatchStatements:StatementList option * TryStatements:StatementList option
  | UpdateStatisticsStatement of SchemaObjectName:SchemaObjectName option * StatisticsOptions:(StatisticsOption) list * SubElements:(Identifier) list
  | UseFederationStatement of DistributionName:Identifier option * FederationName:Identifier option * Filtering:bool * Value:ScalarExpression option
  | UseStatement of DatabaseName:Identifier option
  | UserStatement of UserStatement
  | ViewStatementBody of ViewStatementBody
  | WaitForStatement of Parameter:ValueExpression option * Statement:WaitForSupportedStatement option * Timeout:ScalarExpression option * WaitForOption:ScriptDom.WaitForOption
  | WaitForSupportedStatement of WaitForSupportedStatement
  | WhileStatement of Predicate:BooleanExpression option * Statement:TSqlStatement option
  | WorkloadGroupStatement of WorkloadGroupStatement
  static member FromTs(src:ScriptDom.TSqlStatement) : TSqlStatement =
    match src with
    | :? ScriptDom.AlterAsymmetricKeyStatement as src ->
      TSqlStatement.AlterAsymmetricKeyStatement((src.AttestedBy |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterAuthorizationStatement as src ->
      TSqlStatement.AlterAuthorizationStatement((src.PrincipalName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *), (src.ToSchemaOwner) (* 196 *))
    | :? ScriptDom.AlterCreateEndpointStatementBase as src ->
      match src with
      | :? ScriptDom.AlterEndpointStatement as src-> (* 274 *)
        TSqlStatement.AlterCreateEndpointStatementBase((AlterCreateEndpointStatementBase.AlterEndpointStatement((src.Affinity |> Option.ofObj |> Option.map (EndpointAffinity.FromTs)) (* 193 *), (src.EndpointType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PayloadOptions |> Seq.map (PayloadOption.FromTs) |> List.ofSeq), (src.Protocol) (* 196 *), (src.ProtocolOptions |> Seq.map (EndpointProtocolOption.FromTs) |> List.ofSeq), (src.State) (* 196 *))))
      | :? ScriptDom.CreateEndpointStatement as src-> (* 274 *)
        TSqlStatement.AlterCreateEndpointStatementBase((AlterCreateEndpointStatementBase.CreateEndpointStatement((src.Affinity |> Option.ofObj |> Option.map (EndpointAffinity.FromTs)) (* 193 *), (src.EndpointType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PayloadOptions |> Seq.map (PayloadOption.FromTs) |> List.ofSeq), (src.Protocol) (* 196 *), (src.ProtocolOptions |> Seq.map (EndpointProtocolOption.FromTs) |> List.ofSeq), (src.State) (* 196 *))))
    | :? ScriptDom.AlterCreateServiceStatementBase as src ->
      match src with
      | :? ScriptDom.AlterServiceStatement as src-> (* 274 *)
        TSqlStatement.AlterCreateServiceStatementBase((AlterCreateServiceStatementBase.AlterServiceStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ServiceContracts |> Seq.map (fun src -> ServiceContract.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.CreateServiceStatement as src-> (* 274 *)
        TSqlStatement.AlterCreateServiceStatementBase((AlterCreateServiceStatementBase.CreateServiceStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ServiceContracts |> Seq.map (fun src -> ServiceContract.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))))
    | :? ScriptDom.AlterCryptographicProviderStatement as src ->
      TSqlStatement.AlterCryptographicProviderStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Option) (* 196 *))
    | :? ScriptDom.AlterDatabaseScopedConfigurationStatement as src ->
      match src with
      | :? ScriptDom.AlterDatabaseScopedConfigurationClearStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseScopedConfigurationStatement((AlterDatabaseScopedConfigurationStatement.AlterDatabaseScopedConfigurationClearStatement((src.Option |> Option.ofObj |> Option.map (DatabaseConfigurationClearOption.FromTs)) (* 193 *), (src.Secondary) (* 196 *))))
      | :? ScriptDom.AlterDatabaseScopedConfigurationSetStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseScopedConfigurationStatement((AlterDatabaseScopedConfigurationStatement.AlterDatabaseScopedConfigurationSetStatement((src.Option |> Option.ofObj |> Option.map (DatabaseConfigurationSetOption.FromTs)) (* 191 *), (src.Secondary) (* 196 *))))
    | :? ScriptDom.AlterDatabaseStatement as src ->
      match src with
      | :? ScriptDom.AlterDatabaseAddFileGroupStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseAddFileGroupStatement((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseAddFileStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseAddFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLog) (* 196 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseCollateStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseCollateStatement((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseModifyFileGroupStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseModifyFileGroupStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.MakeDefault) (* 196 *), (src.NewFileGroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Termination |> Option.ofObj |> Option.map (AlterDatabaseTermination.FromTs)) (* 193 *), (src.UpdatabilityOption) (* 196 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseModifyFileStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseModifyFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclaration |> Option.ofObj |> Option.map (FileDeclaration.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseModifyNameStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseModifyNameStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.NewDatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseRebuildLogStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseRebuildLogStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclaration |> Option.ofObj |> Option.map (FileDeclaration.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseRemoveFileGroupStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseRemoveFileGroupStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseRemoveFileStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseRemoveFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))))
      | :? ScriptDom.AlterDatabaseSetStatement as src-> (* 274 *)
        TSqlStatement.AlterDatabaseStatement((AlterDatabaseStatement.AlterDatabaseSetStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (DatabaseOption.FromTs) |> List.ofSeq), (src.Termination |> Option.ofObj |> Option.map (AlterDatabaseTermination.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))))
    | :? ScriptDom.AlterFederationStatement as src ->
      TSqlStatement.AlterFederationStatement((src.Boundary |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterFullTextIndexStatement as src ->
      TSqlStatement.AlterFullTextIndexStatement((src.Action |> Option.ofObj |> Option.map (AlterFullTextIndexAction.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterFullTextStopListStatement as src ->
      TSqlStatement.AlterFullTextStopListStatement((src.Action |> Option.ofObj |> Option.map (FullTextStopListAction.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterLoginStatement as src ->
      match src with
      | :? ScriptDom.AlterLoginAddDropCredentialStatement as src-> (* 274 *)
        TSqlStatement.AlterLoginStatement((AlterLoginStatement.AlterLoginAddDropCredentialStatement((src.CredentialName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsAdd) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterLoginEnableDisableStatement as src-> (* 274 *)
        TSqlStatement.AlterLoginStatement((AlterLoginStatement.AlterLoginEnableDisableStatement((src.IsEnable) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterLoginOptionsStatement as src-> (* 274 *)
        TSqlStatement.AlterLoginStatement((AlterLoginStatement.AlterLoginOptionsStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.AlterPartitionFunctionStatement as src ->
      TSqlStatement.AlterPartitionFunctionStatement((src.Boundary |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsSplit) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterPartitionSchemeStatement as src ->
      TSqlStatement.AlterPartitionSchemeStatement((src.FileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterResourceGovernorStatement as src ->
      TSqlStatement.AlterResourceGovernorStatement((src.ClassifierFunction |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Command) (* 196 *))
    | :? ScriptDom.AlterSchemaStatement as src ->
      TSqlStatement.AlterSchemaStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ObjectKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterSearchPropertyListStatement as src ->
      TSqlStatement.AlterSearchPropertyListStatement((src.Action |> Option.ofObj |> Option.map (SearchPropertyListAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterServerConfigurationSetBufferPoolExtensionStatement as src ->
      TSqlStatement.AlterServerConfigurationSetBufferPoolExtensionStatement((src.Options |> Seq.map (AlterServerConfigurationBufferPoolExtensionOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationSetDiagnosticsLogStatement as src ->
      TSqlStatement.AlterServerConfigurationSetDiagnosticsLogStatement((src.Options |> Seq.map (AlterServerConfigurationDiagnosticsLogOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationSetFailoverClusterPropertyStatement as src ->
      TSqlStatement.AlterServerConfigurationSetFailoverClusterPropertyStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationFailoverClusterPropertyOption.AlterServerConfigurationFailoverClusterPropertyOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationSetHadrClusterStatement as src ->
      TSqlStatement.AlterServerConfigurationSetHadrClusterStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationHadrClusterOption.AlterServerConfigurationHadrClusterOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationSetSoftNumaStatement as src ->
      TSqlStatement.AlterServerConfigurationSetSoftNumaStatement((src.Options |> Seq.map (fun src -> AlterServerConfigurationSoftNumaOption.AlterServerConfigurationSoftNumaOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.AlterServerConfigurationStatement as src ->
      TSqlStatement.AlterServerConfigurationStatement((src.ProcessAffinity) (* 196 *), (src.ProcessAffinityRanges |> Seq.map (fun src -> ProcessAffinityRange.ProcessAffinityRange((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.AlterServiceMasterKeyStatement as src ->
      TSqlStatement.AlterServiceMasterKeyStatement((src.Account |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableStatement as src ->
      match src with
      | :? ScriptDom.AlterTableAddTableElementStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableAddTableElementStatement((src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.ExistingRowsCheckEnforcement) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableAlterColumnStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableAlterColumnStatement((src.AlterTableAlterColumnOption) (* 196 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (Option.ofNullable (src.GeneratedAlways)), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Options |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))))
      | :? ScriptDom.AlterTableAlterIndexStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableAlterIndexStatement((src.AlterIndexType) (* 196 *), (src.IndexIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableChangeTrackingModificationStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableChangeTrackingModificationStatement((src.IsEnable) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TrackColumnsUpdated) (* 196 *))))
      | :? ScriptDom.AlterTableConstraintModificationStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableConstraintModificationStatement((src.All) (* 196 *), (src.ConstraintEnforcement) (* 196 *), (src.ConstraintNames |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExistingRowsCheckEnforcement) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableDropTableElementStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableDropTableElementStatement((src.AlterTableDropTableElements |> Seq.map (fun src -> AlterTableDropTableElement.AlterTableDropTableElement((src.DropClusteredConstraintOptions |> Seq.map (DropClusteredConstraintOption.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableElementType) (* 196 *))) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableFileTableNamespaceStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableFileTableNamespaceStatement((src.IsEnable) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableRebuildStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableRebuildStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Partition |> Option.ofObj |> Option.map (PartitionSpecifier.FromTs)) (* 193 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableSetStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableSetStatement((src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableSwitchStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableSwitchStatement((src.Options |> Seq.map (TableSwitchOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SourcePartitionNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TargetPartitionNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TargetTable |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterTableTriggerModificationStatement as src-> (* 274 *)
        TSqlStatement.AlterTableStatement((AlterTableStatement.AlterTableTriggerModificationStatement((src.All) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TriggerEnforcement) (* 196 *), (src.TriggerNames |> Seq.map (Identifier.FromTs) |> List.ofSeq))))
    | :? ScriptDom.AlterXmlSchemaCollectionStatement as src ->
      TSqlStatement.AlterXmlSchemaCollectionStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.ApplicationRoleStatement as src ->
      match src with
      | :? ScriptDom.AlterApplicationRoleStatement as src-> (* 274 *)
        TSqlStatement.ApplicationRoleStatement((ApplicationRoleStatement.AlterApplicationRoleStatement((src.ApplicationRoleOptions |> Seq.map (fun src -> ApplicationRoleOption.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateApplicationRoleStatement as src-> (* 274 *)
        TSqlStatement.ApplicationRoleStatement((ApplicationRoleStatement.CreateApplicationRoleStatement((src.ApplicationRoleOptions |> Seq.map (fun src -> ApplicationRoleOption.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.AssemblyStatement as src ->
      match src with
      | :? ScriptDom.AlterAssemblyStatement as src-> (* 274 *)
        TSqlStatement.AssemblyStatement((AssemblyStatement.AlterAssemblyStatement((src.AddFiles |> Seq.map (fun src -> AddFileSpec.AddFileSpec((src.File |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.DropFiles |> Seq.map (Literal.FromTs) |> List.ofSeq), (src.IsDropAll) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AssemblyOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateAssemblyStatement as src-> (* 274 *)
        TSqlStatement.AssemblyStatement((AssemblyStatement.CreateAssemblyStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AssemblyOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
    | :? ScriptDom.AuditSpecificationStatement as src ->
      match src with
      | :? ScriptDom.AlterDatabaseAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.AuditSpecificationStatement((AuditSpecificationStatement.AlterDatabaseAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.AlterServerAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.AuditSpecificationStatement((AuditSpecificationStatement.AlterServerAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateDatabaseAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.AuditSpecificationStatement((AuditSpecificationStatement.CreateDatabaseAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateServerAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.AuditSpecificationStatement((AuditSpecificationStatement.CreateServerAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.AvailabilityGroupStatement as src ->
      match src with
      | :? ScriptDom.AlterAvailabilityGroupStatement as src-> (* 274 *)
        TSqlStatement.AvailabilityGroupStatement((AvailabilityGroupStatement.AlterAvailabilityGroupStatement((src.Action |> Option.ofObj |> Option.map (AlterAvailabilityGroupAction.FromTs)) (* 191 *), (src.AlterAvailabilityGroupStatementType) (* 196 *), (src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AvailabilityGroupOption.FromTs) |> List.ofSeq), (src.Replicas |> Seq.map (fun src -> AvailabilityReplica.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))) |> List.ofSeq))))
      | :? ScriptDom.CreateAvailabilityGroupStatement as src-> (* 274 *)
        TSqlStatement.AvailabilityGroupStatement((AvailabilityGroupStatement.CreateAvailabilityGroupStatement((src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AvailabilityGroupOption.FromTs) |> List.ofSeq), (src.Replicas |> Seq.map (fun src -> AvailabilityReplica.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))) |> List.ofSeq))))
    | :? ScriptDom.BackupRestoreMasterKeyStatementBase as src ->
      match src with
      | :? ScriptDom.BackupMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.BackupRestoreMasterKeyStatementBase((BackupRestoreMasterKeyStatementBase.BackupMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.BackupServiceMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.BackupRestoreMasterKeyStatementBase((BackupRestoreMasterKeyStatementBase.BackupServiceMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.RestoreMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.BackupRestoreMasterKeyStatementBase((BackupRestoreMasterKeyStatementBase.RestoreMasterKeyStatement((src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsForce) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.RestoreServiceMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.BackupRestoreMasterKeyStatementBase((BackupRestoreMasterKeyStatementBase.RestoreServiceMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsForce) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.BackupStatement as src ->
      match src with
      | :? ScriptDom.BackupDatabaseStatement as src-> (* 274 *)
        TSqlStatement.BackupStatement((BackupStatement.BackupDatabaseStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Files |> Seq.map (fun src -> BackupRestoreFileInfo.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.MirrorToClauses |> Seq.map (fun src -> MirrorToClause.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (BackupOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.BackupTransactionLogStatement as src-> (* 274 *)
        TSqlStatement.BackupStatement((BackupStatement.BackupTransactionLogStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.MirrorToClauses |> Seq.map (fun src -> MirrorToClause.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (BackupOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.BeginConversationTimerStatement as src ->
      TSqlStatement.BeginConversationTimerStatement((src.Handle |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BeginDialogStatement as src ->
      TSqlStatement.BeginDialogStatement((src.ContractName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Handle |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.InitiatorServiceName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.InstanceSpec |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.IsConversation) (* 196 *), (src.Options |> Seq.map (DialogOption.FromTs) |> List.ofSeq), (src.TargetServiceName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.BeginEndBlockStatement as src ->
      match src with
      | :? ScriptDom.BeginEndAtomicBlockStatement as src-> (* 274 *)
        TSqlStatement.BeginEndBlockStatement((BeginEndBlockStatement.BeginEndAtomicBlockStatement((src.Options |> Seq.map (AtomicBlockOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.BeginEndBlockStatement as src *)
        TSqlStatement.BeginEndBlockStatement((BeginEndBlockStatement.Base((src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
    | :? ScriptDom.BreakStatement as src ->
      TSqlStatement.BreakStatement
    | :? ScriptDom.BrokerPriorityStatement as src ->
      match src with
      | :? ScriptDom.AlterBrokerPriorityStatement as src-> (* 274 *)
        TSqlStatement.BrokerPriorityStatement((BrokerPriorityStatement.AlterBrokerPriorityStatement((src.BrokerPriorityParameters |> Seq.map (fun src -> BrokerPriorityParameter.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateBrokerPriorityStatement as src-> (* 274 *)
        TSqlStatement.BrokerPriorityStatement((BrokerPriorityStatement.CreateBrokerPriorityStatement((src.BrokerPriorityParameters |> Seq.map (fun src -> BrokerPriorityParameter.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.BulkInsertBase as src ->
      match src with
      | :? ScriptDom.BulkInsertStatement as src-> (* 274 *)
        TSqlStatement.BulkInsertBase((BulkInsertBase.BulkInsertStatement((src.From |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq), (src.To |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.InsertBulkStatement as src-> (* 274 *)
        TSqlStatement.BulkInsertBase((BulkInsertBase.InsertBulkStatement((src.ColumnDefinitions |> Seq.map (fun src -> InsertBulkColumnDefinition.InsertBulkColumnDefinition((src.Column |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullNotNull) (* 196 *))) |> List.ofSeq), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq), (src.To |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.CertificateStatementBase as src ->
      match src with
      | :? ScriptDom.AlterCertificateStatement as src-> (* 274 *)
        TSqlStatement.CertificateStatementBase((CertificateStatementBase.AlterCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.AttestedBy |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.BackupCertificateStatement as src-> (* 274 *)
        TSqlStatement.CertificateStatementBase((CertificateStatementBase.BackupCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateCertificateStatement as src-> (* 274 *)
        TSqlStatement.CertificateStatementBase((CertificateStatementBase.CreateCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.CertificateOptions |> Seq.map (fun src -> CertificateOption.CertificateOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.CertificateSource |> Option.ofObj |> Option.map (EncryptionSource.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.CheckpointStatement as src ->
      TSqlStatement.CheckpointStatement((src.Duration |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CloseMasterKeyStatement as src ->
      TSqlStatement.CloseMasterKeyStatement
    | :? ScriptDom.CloseSymmetricKeyStatement as src ->
      TSqlStatement.CloseSymmetricKeyStatement((src.All) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.ColumnEncryptionKeyStatement as src ->
      match src with
      | :? ScriptDom.AlterColumnEncryptionKeyStatement as src-> (* 274 *)
        TSqlStatement.ColumnEncryptionKeyStatement((ColumnEncryptionKeyStatement.AlterColumnEncryptionKeyStatement((src.AlterType) (* 196 *), (src.ColumnEncryptionKeyValues |> Seq.map (fun src -> ColumnEncryptionKeyValue.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateColumnEncryptionKeyStatement as src-> (* 274 *)
        TSqlStatement.ColumnEncryptionKeyStatement((ColumnEncryptionKeyStatement.CreateColumnEncryptionKeyStatement((src.ColumnEncryptionKeyValues |> Seq.map (fun src -> ColumnEncryptionKeyValue.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ContinueStatement as src ->
      TSqlStatement.ContinueStatement
    | :? ScriptDom.CreateAggregateStatement as src ->
      TSqlStatement.CreateAggregateStatement((src.AssemblyName |> Option.ofObj |> Option.map (AssemblyName.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))
    | :? ScriptDom.CreateAsymmetricKeyStatement as src ->
      TSqlStatement.CreateAsymmetricKeyStatement((src.EncryptionAlgorithm) (* 196 *), (src.KeySource |> Option.ofObj |> Option.map (EncryptionSource.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CreateColumnMasterKeyStatement as src ->
      TSqlStatement.CreateColumnMasterKeyStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ColumnMasterKeyParameter.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateColumnStoreIndexStatement as src ->
      TSqlStatement.CreateColumnStoreIndexStatement((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CreateContractStatement as src ->
      TSqlStatement.CreateContractStatement((src.Messages |> Seq.map (fun src -> ContractMessage.ContractMessage((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SentBy) (* 196 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateCryptographicProviderStatement as src ->
      TSqlStatement.CreateCryptographicProviderStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateDatabaseStatement as src ->
      TSqlStatement.CreateDatabaseStatement((src.AttachMode) (* 196 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Containment |> Option.ofObj |> Option.map (ContainmentDatabaseOption.FromTs)) (* 193 *), (src.CopyOf |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseSnapshot |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroups |> Seq.map (fun src -> FileGroupDefinition.FileGroupDefinition((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.LogOn |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (DatabaseOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateDefaultStatement as src ->
      TSqlStatement.CreateDefaultStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CreateEventNotificationStatement as src ->
      TSqlStatement.CreateEventNotificationStatement((src.BrokerInstanceSpecifier |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.BrokerService |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EventTypeGroups |> Seq.map (EventTypeGroupContainer.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Scope |> Option.ofObj |> Option.map (EventNotificationObjectScope.FromTs)) (* 193 *), (src.WithFanIn) (* 196 *))
    | :? ScriptDom.CreateFederationStatement as src ->
      TSqlStatement.CreateFederationStatement((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateFullTextIndexStatement as src ->
      TSqlStatement.CreateFullTextIndexStatement((src.CatalogAndFileGroup |> Option.ofObj |> Option.map (FullTextCatalogAndFileGroup.FromTs)) (* 193 *), (src.FullTextIndexColumns |> Seq.map (fun src -> FullTextIndexColumn.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.KeyIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextIndexOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateFullTextStopListStatement as src ->
      TSqlStatement.CreateFullTextStopListStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsSystemStopList) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SourceStopListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateLoginStatement as src ->
      TSqlStatement.CreateLoginStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Source |> Option.ofObj |> Option.map (CreateLoginSource.FromTs)) (* 191 *))
    | :? ScriptDom.CreatePartitionFunctionStatement as src ->
      TSqlStatement.CreatePartitionFunctionStatement((src.BoundaryValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterType |> Option.ofObj |> Option.map (PartitionParameterType.FromTs)) (* 193 *), (src.Range) (* 196 *))
    | :? ScriptDom.CreatePartitionSchemeStatement as src ->
      TSqlStatement.CreatePartitionSchemeStatement((src.FileGroups |> Seq.map (fun src -> IdentifierOrValueExpression.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.IsAll) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PartitionFunction |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateRuleStatement as src ->
      TSqlStatement.CreateRuleStatement((src.Expression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CreateSchemaStatement as src ->
      TSqlStatement.CreateSchemaStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
    | :? ScriptDom.CreateSearchPropertyListStatement as src ->
      TSqlStatement.CreateSearchPropertyListStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SourceSearchPropertyList |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateSpatialIndexStatement as src ->
      TSqlStatement.CreateSpatialIndexStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OnFileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.SpatialColumnName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SpatialIndexOptions |> Seq.map (SpatialIndexOption.FromTs) |> List.ofSeq), (src.SpatialIndexingScheme) (* 196 *))
    | :? ScriptDom.CreateStatisticsStatement as src ->
      TSqlStatement.CreateStatisticsStatement((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StatisticsOptions |> Seq.map (StatisticsOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateSynonymStatement as src ->
      TSqlStatement.CreateSynonymStatement((src.ForName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CreateTableStatement as src ->
      TSqlStatement.CreateTableStatement((src.AsFileTable) (* 196 *), (src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.FederationScheme |> Option.ofObj |> Option.map (FederationScheme.FromTs)) (* 193 *), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TextImageOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.CreateTypeStatement as src ->
      match src with
      | :? ScriptDom.CreateTypeTableStatement as src-> (* 274 *)
        TSqlStatement.CreateTypeStatement((CreateTypeStatement.CreateTypeTableStatement((src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateTypeUddtStatement as src-> (* 274 *)
        TSqlStatement.CreateTypeStatement((CreateTypeStatement.CreateTypeUddtStatement((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))))
      | :? ScriptDom.CreateTypeUdtStatement as src-> (* 274 *)
        TSqlStatement.CreateTypeStatement((CreateTypeStatement.CreateTypeUdtStatement((src.AssemblyName |> Option.ofObj |> Option.map (AssemblyName.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.CreateXmlSchemaCollectionStatement as src ->
      TSqlStatement.CreateXmlSchemaCollectionStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CredentialStatement as src ->
      match src with
      | :? ScriptDom.AlterCredentialStatement as src-> (* 274 *)
        TSqlStatement.CredentialStatement((CredentialStatement.AlterCredentialStatement((src.Identity |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsDatabaseScoped) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Secret |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateCredentialStatement as src-> (* 274 *)
        TSqlStatement.CredentialStatement((CredentialStatement.CreateCredentialStatement((src.CryptographicProviderName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identity |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsDatabaseScoped) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Secret |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.CursorStatement as src ->
      match src with
      | :? ScriptDom.CloseCursorStatement as src-> (* 274 *)
        TSqlStatement.CursorStatement((CursorStatement.CloseCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))))
      | :? ScriptDom.DeallocateCursorStatement as src-> (* 274 *)
        TSqlStatement.CursorStatement((CursorStatement.DeallocateCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))))
      | :? ScriptDom.FetchCursorStatement as src-> (* 274 *)
        TSqlStatement.CursorStatement((CursorStatement.FetchCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *), (src.FetchType |> Option.ofObj |> Option.map (FetchType.FromTs)) (* 193 *), (src.IntoVariables |> Seq.map (fun src -> VariableReference.VariableReference((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))) |> List.ofSeq))))
      | :? ScriptDom.OpenCursorStatement as src-> (* 274 *)
        TSqlStatement.CursorStatement((CursorStatement.OpenCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))))
    | :? ScriptDom.DatabaseEncryptionKeyStatement as src ->
      match src with
      | :? ScriptDom.AlterDatabaseEncryptionKeyStatement as src-> (* 274 *)
        TSqlStatement.DatabaseEncryptionKeyStatement((DatabaseEncryptionKeyStatement.AlterDatabaseEncryptionKeyStatement((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.Regenerate) (* 196 *))))
      | :? ScriptDom.CreateDatabaseEncryptionKeyStatement as src-> (* 274 *)
        TSqlStatement.DatabaseEncryptionKeyStatement((DatabaseEncryptionKeyStatement.CreateDatabaseEncryptionKeyStatement((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *))))
    | :? ScriptDom.DbccStatement as src ->
      TSqlStatement.DbccStatement((src.Command) (* 196 *), (Option.ofObj (src.DllName)) (* 198 *), (src.Literals |> Seq.map (fun src -> DbccNamedLiteral.DbccNamedLiteral((Option.ofObj (src.Name)) (* 198 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Options |> Seq.map (fun src -> DbccOption.DbccOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.OptionsUseJoin) (* 196 *), (src.ParenthesisRequired) (* 196 *))
    | :? ScriptDom.DeclareCursorStatement as src ->
      TSqlStatement.DeclareCursorStatement((src.CursorDefinition |> Option.ofObj |> Option.map (CursorDefinition.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DeclareTableVariableStatement as src ->
      TSqlStatement.DeclareTableVariableStatement((src.Body |> Option.ofObj |> Option.map (DeclareTableVariableBody.FromTs)) (* 193 *))
    | :? ScriptDom.DeclareVariableStatement as src ->
      TSqlStatement.DeclareVariableStatement((src.Declarations |> Seq.map (DeclareVariableElement.FromTs) |> List.ofSeq))
    | :? ScriptDom.DiskStatement as src ->
      TSqlStatement.DiskStatement((src.DiskStatementType) (* 196 *), (src.Options |> Seq.map (fun src -> DiskStatementOption.DiskStatementOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq))
    | :? ScriptDom.DropChildObjectsStatement as src ->
      match src with
      | :? ScriptDom.DropStatisticsStatement as src-> (* 274 *)
        TSqlStatement.DropChildObjectsStatement((DropChildObjectsStatement.DropStatisticsStatement((src.Objects |> Seq.map (fun src -> ChildObjectName.ChildObjectName((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ChildIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))))
    | :? ScriptDom.DropDatabaseEncryptionKeyStatement as src ->
      TSqlStatement.DropDatabaseEncryptionKeyStatement
    | :? ScriptDom.DropDatabaseStatement as src ->
      TSqlStatement.DropDatabaseStatement((src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *))
    | :? ScriptDom.DropEventNotificationStatement as src ->
      TSqlStatement.DropEventNotificationStatement((src.Notifications |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Scope |> Option.ofObj |> Option.map (EventNotificationObjectScope.FromTs)) (* 193 *))
    | :? ScriptDom.DropFullTextIndexStatement as src ->
      TSqlStatement.DropFullTextIndexStatement((src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.DropIndexStatement as src ->
      TSqlStatement.DropIndexStatement((src.DropIndexClauses |> Seq.map (DropIndexClauseBase.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *))
    | :? ScriptDom.DropMasterKeyStatement as src ->
      TSqlStatement.DropMasterKeyStatement
    | :? ScriptDom.DropObjectsStatement as src ->
      match src with
      | :? ScriptDom.DropAggregateStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropAggregateStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropAssemblyStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropAssemblyStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.WithNoDependents) (* 196 *))))
      | :? ScriptDom.DropDefaultStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropDefaultStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropExternalTableStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropExternalTableStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropFunctionStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropFunctionStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropProcedureStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropProcedureStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropRuleStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropRuleStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropSecurityPolicyStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropSecurityPolicyStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropSequenceStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropSequenceStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropSynonymStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropSynonymStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropTableStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropTableStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
      | :? ScriptDom.DropTriggerStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropTriggerStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.TriggerScope) (* 196 *))))
      | :? ScriptDom.DropViewStatement as src-> (* 274 *)
        TSqlStatement.DropObjectsStatement((DropObjectsStatement.DropViewStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))))
    | :? ScriptDom.DropQueueStatement as src ->
      TSqlStatement.DropQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.DropSchemaStatement as src ->
      TSqlStatement.DropSchemaStatement((src.DropBehavior) (* 196 *), (src.IsIfExists) (* 196 *), (src.Schema |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.DropTypeStatement as src ->
      TSqlStatement.DropTypeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.DropUnownedObjectStatement as src ->
      match src with
      | :? ScriptDom.DropApplicationRoleStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropApplicationRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropAsymmetricKeyStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropAsymmetricKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RemoveProviderKey) (* 196 *))))
      | :? ScriptDom.DropAvailabilityGroupStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropAvailabilityGroupStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropBrokerPriorityStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropBrokerPriorityStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropCertificateStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropCertificateStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropColumnEncryptionKeyStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropColumnEncryptionKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropColumnMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropColumnMasterKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropContractStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropContractStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropCredentialStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropCredentialStatement((src.IsDatabaseScoped) (* 196 *), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropCryptographicProviderStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropCryptographicProviderStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropDatabaseAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropDatabaseAuditSpecificationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropEndpointStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropEndpointStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropEventSessionStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropEventSessionStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionScope) (* 196 *))))
      | :? ScriptDom.DropExternalDataSourceStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropExternalDataSourceStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropExternalFileFormatStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropExternalFileFormatStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropExternalResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropExternalResourcePoolStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropFederationStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropFederationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropFullTextCatalogStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropFullTextCatalogStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropFullTextStopListStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropFullTextStopListStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropLoginStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropLoginStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropMessageTypeStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropMessageTypeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropPartitionFunctionStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropPartitionFunctionStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropPartitionSchemeStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropPartitionSchemeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropRemoteServiceBindingStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropRemoteServiceBindingStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropResourcePoolStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropRoleStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropRouteStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropRouteStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropSearchPropertyListStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropSearchPropertyListStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropServerAuditSpecificationStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropServerAuditSpecificationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropServerAuditStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropServerAuditStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropServerRoleStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropServerRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropServiceStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropServiceStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropSymmetricKeyStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropSymmetricKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RemoveProviderKey) (* 196 *))))
      | :? ScriptDom.DropUserStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropUserStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.DropWorkloadGroupStatement as src-> (* 274 *)
        TSqlStatement.DropUnownedObjectStatement((DropUnownedObjectStatement.DropWorkloadGroupStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.DropXmlSchemaCollectionStatement as src ->
      TSqlStatement.DropXmlSchemaCollectionStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.EnableDisableTriggerStatement as src ->
      TSqlStatement.EnableDisableTriggerStatement((src.All) (* 196 *), (src.TriggerEnforcement) (* 196 *), (src.TriggerNames |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *))
    | :? ScriptDom.EndConversationStatement as src ->
      TSqlStatement.EndConversationStatement((src.Conversation |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ErrorCode |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.ErrorDescription |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.WithCleanup) (* 196 *))
    | :? ScriptDom.EventSessionStatement as src ->
      match src with
      | :? ScriptDom.AlterEventSessionStatement as src-> (* 274 *)
        TSqlStatement.EventSessionStatement((EventSessionStatement.AlterEventSessionStatement((src.DropEventDeclarations |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.DropTargetDeclarations |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.StatementType) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq))))
      | :? ScriptDom.CreateEventSessionStatement as src-> (* 274 *)
        TSqlStatement.EventSessionStatement((EventSessionStatement.CreateEventSessionStatement((src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.EventSessionStatement as src *)
        TSqlStatement.EventSessionStatement((EventSessionStatement.Base((src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq))))
    | :? ScriptDom.ExecuteAsStatement as src ->
      TSqlStatement.ExecuteAsStatement((src.Cookie |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.ExecuteContext |> Option.ofObj |> Option.map (ExecuteContext.FromTs)) (* 193 *), (src.WithNoRevert) (* 196 *))
    | :? ScriptDom.ExecuteStatement as src ->
      TSqlStatement.ExecuteStatement((src.ExecuteSpecification |> Option.ofObj |> Option.map (ExecuteSpecification.FromTs)) (* 193 *), (src.Options |> Seq.map (ExecuteOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.ExternalDataSourceStatement as src ->
      match src with
      | :? ScriptDom.AlterExternalDataSourceStatement as src-> (* 274 *)
        TSqlStatement.ExternalDataSourceStatement((ExternalDataSourceStatement.AlterExternalDataSourceStatement((src.DataSourceType) (* 196 *), (src.ExternalDataSourceOptions |> Seq.map (ExternalDataSourceOption.FromTs) |> List.ofSeq), (src.Location |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateExternalDataSourceStatement as src-> (* 274 *)
        TSqlStatement.ExternalDataSourceStatement((ExternalDataSourceStatement.CreateExternalDataSourceStatement((src.DataSourceType) (* 196 *), (src.ExternalDataSourceOptions |> Seq.map (ExternalDataSourceOption.FromTs) |> List.ofSeq), (src.Location |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ExternalFileFormatStatement as src ->
      match src with
      | :? ScriptDom.CreateExternalFileFormatStatement as src-> (* 274 *)
        TSqlStatement.ExternalFileFormatStatement((ExternalFileFormatStatement.CreateExternalFileFormatStatement((src.ExternalFileFormatOptions |> Seq.map (ExternalFileFormatOption.FromTs) |> List.ofSeq), (src.FormatType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ExternalResourcePoolStatement as src ->
      match src with
      | :? ScriptDom.AlterExternalResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.ExternalResourcePoolStatement((ExternalResourcePoolStatement.AlterExternalResourcePoolStatement((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateExternalResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.ExternalResourcePoolStatement((ExternalResourcePoolStatement.CreateExternalResourcePoolStatement((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.ExternalResourcePoolStatement as src *)
        TSqlStatement.ExternalResourcePoolStatement((ExternalResourcePoolStatement.Base((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.ExternalTableStatement as src ->
      match src with
      | :? ScriptDom.CreateExternalTableStatement as src-> (* 274 *)
        TSqlStatement.ExternalTableStatement((ExternalTableStatement.CreateExternalTableStatement((src.ColumnDefinitions |> Seq.map (fun src -> ExternalTableColumnDefinition.ExternalTableColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))) |> List.ofSeq), (src.DataSource |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ExternalTableOptions |> Seq.map (ExternalTableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.FullTextCatalogStatement as src ->
      match src with
      | :? ScriptDom.AlterFullTextCatalogStatement as src-> (* 274 *)
        TSqlStatement.FullTextCatalogStatement((FullTextCatalogStatement.AlterFullTextCatalogStatement((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextCatalogOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateFullTextCatalogStatement as src-> (* 274 *)
        TSqlStatement.FullTextCatalogStatement((FullTextCatalogStatement.CreateFullTextCatalogStatement((src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextCatalogOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.GoToStatement as src ->
      TSqlStatement.GoToStatement((src.LabelName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.IfStatement as src ->
      TSqlStatement.IfStatement((src.ElseStatement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *), (src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ThenStatement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *))
    | :? ScriptDom.IndexDefinition as src ->
      TSqlStatement.IndexDefinition((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Unique) (* 196 *))
    | :? ScriptDom.IndexStatement as src ->
      match src with
      | :? ScriptDom.AlterIndexStatement as src-> (* 274 *)
        TSqlStatement.IndexStatement((IndexStatement.AlterIndexStatement((src.All) (* 196 *), (src.AlterIndexType) (* 196 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Partition |> Option.ofObj |> Option.map (PartitionSpecifier.FromTs)) (* 193 *), (src.PromotedPaths |> Seq.map (fun src -> SelectiveXmlIndexPromotedPath.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))))
      | :? ScriptDom.CreateIndexStatement as src-> (* 274 *)
        TSqlStatement.IndexStatement((IndexStatement.CreateIndexStatement((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IncludeColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Translated80SyntaxTo90) (* 196 *), (src.Unique) (* 196 *))))
      | :? ScriptDom.CreateSelectiveXmlIndexStatement as src-> (* 274 *)
        TSqlStatement.IndexStatement((IndexStatement.CreateSelectiveXmlIndexStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IsSecondary) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.PathName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PromotedPaths |> Seq.map (fun src -> SelectiveXmlIndexPromotedPath.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.UsingXmlIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.XmlColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))))
      | :? ScriptDom.CreateXmlIndexStatement as src-> (* 274 *)
        TSqlStatement.IndexStatement((IndexStatement.CreateXmlIndexStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Primary) (* 196 *), (src.SecondaryXmlIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecondaryXmlIndexType) (* 196 *), (src.XmlColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.KillQueryNotificationSubscriptionStatement as src ->
      TSqlStatement.KillQueryNotificationSubscriptionStatement((src.All) (* 196 *), (src.SubscriptionId |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.KillStatement as src ->
      TSqlStatement.KillStatement((src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WithStatusOnly) (* 196 *))
    | :? ScriptDom.KillStatsJobStatement as src ->
      TSqlStatement.KillStatsJobStatement((src.JobId |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.LabelStatement as src ->
      TSqlStatement.LabelStatement((Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.LineNoStatement as src ->
      TSqlStatement.LineNoStatement((src.LineNo |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.MasterKeyStatement as src ->
      match src with
      | :? ScriptDom.AlterMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.MasterKeyStatement((MasterKeyStatement.AlterMasterKeyStatement((src.Option) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateMasterKeyStatement as src-> (* 274 *)
        TSqlStatement.MasterKeyStatement((MasterKeyStatement.CreateMasterKeyStatement((src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.MessageTypeStatementBase as src ->
      match src with
      | :? ScriptDom.AlterMessageTypeStatement as src-> (* 274 *)
        TSqlStatement.MessageTypeStatementBase((MessageTypeStatementBase.AlterMessageTypeStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ValidationMethod) (* 196 *), (src.XmlSchemaCollectionName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateMessageTypeStatement as src-> (* 274 *)
        TSqlStatement.MessageTypeStatementBase((MessageTypeStatementBase.CreateMessageTypeStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ValidationMethod) (* 196 *), (src.XmlSchemaCollectionName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
    | :? ScriptDom.MoveConversationStatement as src ->
      TSqlStatement.MoveConversationStatement((src.Conversation |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Group |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.OpenMasterKeyStatement as src ->
      TSqlStatement.OpenMasterKeyStatement((src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.OpenSymmetricKeyStatement as src ->
      TSqlStatement.OpenSymmetricKeyStatement((src.DecryptionMechanism |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.PrintStatement as src ->
      TSqlStatement.PrintStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ProcedureStatementBodyBase as src ->
      match src with
      | :? ScriptDom.FunctionStatementBody as src-> (* 274 *)
        TSqlStatement.ProcedureStatementBodyBase((ProcedureStatementBodyBase.FunctionStatementBody((FunctionStatementBody.FromTs(src))) (* 251 *)))
      | :? ScriptDom.ProcedureStatementBody as src-> (* 274 *)
        TSqlStatement.ProcedureStatementBodyBase((ProcedureStatementBodyBase.ProcedureStatementBody((ProcedureStatementBody.FromTs(src))) (* 251 *)))
    | :? ScriptDom.QueueStatement as src ->
      match src with
      | :? ScriptDom.AlterQueueStatement as src-> (* 274 *)
        TSqlStatement.QueueStatement((QueueStatement.AlterQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.QueueOptions |> Seq.map (QueueOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateQueueStatement as src-> (* 274 *)
        TSqlStatement.QueueStatement((QueueStatement.CreateQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OnFileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.QueueOptions |> Seq.map (QueueOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.RaiseErrorLegacyStatement as src ->
      TSqlStatement.RaiseErrorLegacyStatement((src.FirstParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.RaiseErrorStatement as src ->
      TSqlStatement.RaiseErrorStatement((src.FirstParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OptionalParameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.RaiseErrorOptions) (* 196 *), (src.SecondParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.ThirdParameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ReadTextStatement as src ->
      TSqlStatement.ReadTextStatement((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.HoldLock) (* 196 *), (src.Offset |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Size |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextPointer |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ReconfigureStatement as src ->
      TSqlStatement.ReconfigureStatement((src.WithOverride) (* 196 *))
    | :? ScriptDom.RemoteServiceBindingStatementBase as src ->
      match src with
      | :? ScriptDom.AlterRemoteServiceBindingStatement as src-> (* 274 *)
        TSqlStatement.RemoteServiceBindingStatementBase((RemoteServiceBindingStatementBase.AlterRemoteServiceBindingStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (RemoteServiceBindingOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateRemoteServiceBindingStatement as src-> (* 274 *)
        TSqlStatement.RemoteServiceBindingStatementBase((RemoteServiceBindingStatementBase.CreateRemoteServiceBindingStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (RemoteServiceBindingOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Service |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))))
    | :? ScriptDom.ResourcePoolStatement as src ->
      match src with
      | :? ScriptDom.AlterResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.ResourcePoolStatement((ResourcePoolStatement.AlterResourcePoolStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.CreateResourcePoolStatement as src-> (* 274 *)
        TSqlStatement.ResourcePoolStatement((ResourcePoolStatement.CreateResourcePoolStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
      | _ -> (* :? ScriptDom.ResourcePoolStatement as src *)
        TSqlStatement.ResourcePoolStatement((ResourcePoolStatement.Base((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))))
    | :? ScriptDom.RestoreStatement as src ->
      TSqlStatement.RestoreStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Files |> Seq.map (fun src -> BackupRestoreFileInfo.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Kind) (* 196 *), (src.Options |> Seq.map (RestoreOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.ReturnStatement as src ->
      TSqlStatement.ReturnStatement((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.RevertStatement as src ->
      TSqlStatement.RevertStatement((src.Cookie |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.RoleStatement as src ->
      match src with
      | :? ScriptDom.AlterRoleStatement as src-> (* 274 *)
        TSqlStatement.RoleStatement((RoleStatement.AlterRoleStatement((AlterRoleStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.CreateRoleStatement as src-> (* 274 *)
        TSqlStatement.RoleStatement((RoleStatement.CreateRoleStatement((CreateRoleStatement.FromTs(src))) (* 251 *)))
    | :? ScriptDom.RouteStatement as src ->
      match src with
      | :? ScriptDom.AlterRouteStatement as src-> (* 274 *)
        TSqlStatement.RouteStatement((RouteStatement.AlterRouteStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RouteOptions |> Seq.map (fun src -> RouteOption.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))) |> List.ofSeq))))
      | :? ScriptDom.CreateRouteStatement as src-> (* 274 *)
        TSqlStatement.RouteStatement((RouteStatement.CreateRouteStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RouteOptions |> Seq.map (fun src -> RouteOption.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))) |> List.ofSeq))))
    | :? ScriptDom.SecurityPolicyStatement as src ->
      match src with
      | :? ScriptDom.AlterSecurityPolicyStatement as src-> (* 274 *)
        TSqlStatement.SecurityPolicyStatement((SecurityPolicyStatement.AlterSecurityPolicyStatement((src.ActionType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *), (src.SecurityPolicyOptions |> Seq.map (fun src -> SecurityPolicyOption.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))) |> List.ofSeq), (src.SecurityPredicateActions |> Seq.map (fun src -> SecurityPredicateAction.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.CreateSecurityPolicyStatement as src-> (* 274 *)
        TSqlStatement.SecurityPolicyStatement((SecurityPolicyStatement.CreateSecurityPolicyStatement((src.ActionType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *), (src.SecurityPolicyOptions |> Seq.map (fun src -> SecurityPolicyOption.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))) |> List.ofSeq), (src.SecurityPredicateActions |> Seq.map (fun src -> SecurityPredicateAction.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))) |> List.ofSeq))))
    | :? ScriptDom.SecurityStatement as src ->
      match src with
      | :? ScriptDom.DenyStatement as src-> (* 274 *)
        TSqlStatement.SecurityStatement((SecurityStatement.DenyStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))))
      | :? ScriptDom.GrantStatement as src-> (* 274 *)
        TSqlStatement.SecurityStatement((SecurityStatement.GrantStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *), (src.WithGrantOption) (* 196 *))))
      | :? ScriptDom.RevokeStatement as src-> (* 274 *)
        TSqlStatement.SecurityStatement((SecurityStatement.RevokeStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.GrantOptionFor) (* 196 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))))
    | :? ScriptDom.SecurityStatementBody80 as src ->
      match src with
      | :? ScriptDom.DenyStatement80 as src-> (* 274 *)
        TSqlStatement.SecurityStatementBody80((SecurityStatementBody80.DenyStatement80((src.CascadeOption) (* 196 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *))))
      | :? ScriptDom.GrantStatement80 as src-> (* 274 *)
        TSqlStatement.SecurityStatementBody80((SecurityStatementBody80.GrantStatement80((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *), (src.WithGrantOption) (* 196 *))))
      | :? ScriptDom.RevokeStatement80 as src-> (* 274 *)
        TSqlStatement.SecurityStatementBody80((SecurityStatementBody80.RevokeStatement80((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.GrantOptionFor) (* 196 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *))))
    | :? ScriptDom.SendStatement as src ->
      TSqlStatement.SendStatement((src.ConversationHandles |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.MessageBody |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.MessageTypeName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.SequenceStatement as src ->
      match src with
      | :? ScriptDom.AlterSequenceStatement as src-> (* 274 *)
        TSqlStatement.SequenceStatement((SequenceStatement.AlterSequenceStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SequenceOptions |> Seq.map (SequenceOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateSequenceStatement as src-> (* 274 *)
        TSqlStatement.SequenceStatement((SequenceStatement.CreateSequenceStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SequenceOptions |> Seq.map (SequenceOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.ServerAuditStatement as src ->
      match src with
      | :? ScriptDom.AlterServerAuditStatement as src-> (* 274 *)
        TSqlStatement.ServerAuditStatement((ServerAuditStatement.AlterServerAuditStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditTarget |> Option.ofObj |> Option.map (AuditTarget.FromTs)) (* 193 *), (src.NewName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AuditOption.FromTs) |> List.ofSeq), (src.PredicateExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.RemoveWhere) (* 196 *))))
      | :? ScriptDom.CreateServerAuditStatement as src-> (* 274 *)
        TSqlStatement.ServerAuditStatement((ServerAuditStatement.CreateServerAuditStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditTarget |> Option.ofObj |> Option.map (AuditTarget.FromTs)) (* 193 *), (src.Options |> Seq.map (AuditOption.FromTs) |> List.ofSeq), (src.PredicateExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.SetCommandStatement as src ->
      TSqlStatement.SetCommandStatement((src.Commands |> Seq.map (SetCommand.FromTs) |> List.ofSeq))
    | :? ScriptDom.SetErrorLevelStatement as src ->
      TSqlStatement.SetErrorLevelStatement((src.Level |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SetOnOffStatement as src ->
      match src with
      | :? ScriptDom.PredicateSetStatement as src-> (* 274 *)
        TSqlStatement.SetOnOffStatement((SetOnOffStatement.PredicateSetStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))))
      | :? ScriptDom.SetIdentityInsertStatement as src-> (* 274 *)
        TSqlStatement.SetOnOffStatement((SetOnOffStatement.SetIdentityInsertStatement((src.IsOn) (* 196 *), (src.Table |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.SetOffsetsStatement as src-> (* 274 *)
        TSqlStatement.SetOnOffStatement((SetOnOffStatement.SetOffsetsStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))))
      | :? ScriptDom.SetStatisticsStatement as src-> (* 274 *)
        TSqlStatement.SetOnOffStatement((SetOnOffStatement.SetStatisticsStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))))
    | :? ScriptDom.SetRowCountStatement as src ->
      TSqlStatement.SetRowCountStatement((src.NumberRows |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SetTextSizeStatement as src ->
      TSqlStatement.SetTextSizeStatement((src.TextSize |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SetTransactionIsolationLevelStatement as src ->
      TSqlStatement.SetTransactionIsolationLevelStatement((src.Level) (* 196 *))
    | :? ScriptDom.SetUserStatement as src ->
      TSqlStatement.SetUserStatement((src.UserName |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.WithNoReset) (* 196 *))
    | :? ScriptDom.SetVariableStatement as src ->
      TSqlStatement.SetVariableStatement((src.AssignmentKind) (* 196 *), (src.CursorDefinition |> Option.ofObj |> Option.map (CursorDefinition.FromTs)) (* 193 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FunctionCallExists) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.SeparatorType) (* 196 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.ShutdownStatement as src ->
      TSqlStatement.ShutdownStatement((src.WithNoWait) (* 196 *))
    | :? ScriptDom.SignatureStatementBase as src ->
      match src with
      | :? ScriptDom.AddSignatureStatement as src-> (* 274 *)
        TSqlStatement.SignatureStatementBase((SignatureStatementBase.AddSignatureStatement((src.Cryptos |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Element |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ElementKind) (* 196 *), (src.IsCounter) (* 196 *))))
      | :? ScriptDom.DropSignatureStatement as src-> (* 274 *)
        TSqlStatement.SignatureStatementBase((SignatureStatementBase.DropSignatureStatement((src.Cryptos |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Element |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ElementKind) (* 196 *), (src.IsCounter) (* 196 *))))
    | :? ScriptDom.StatementWithCtesAndXmlNamespaces as src ->
      match src with
      | :? ScriptDom.DataModificationStatement as src-> (* 274 *)
        TSqlStatement.StatementWithCtesAndXmlNamespaces((StatementWithCtesAndXmlNamespaces.DataModificationStatement((DataModificationStatement.FromTs(src))) (* 251 *)))
      | :? ScriptDom.SelectStatement as src-> (* 274 *)
        TSqlStatement.StatementWithCtesAndXmlNamespaces((StatementWithCtesAndXmlNamespaces.SelectStatement((SelectStatement.FromTs(src))) (* 251 *)))
    | :? ScriptDom.SymmetricKeyStatement as src ->
      match src with
      | :? ScriptDom.AlterSymmetricKeyStatement as src-> (* 274 *)
        TSqlStatement.SymmetricKeyStatement((SymmetricKeyStatement.AlterSymmetricKeyStatement((src.EncryptingMechanisms |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.IsAdd) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateSymmetricKeyStatement as src-> (* 274 *)
        TSqlStatement.SymmetricKeyStatement((SymmetricKeyStatement.CreateSymmetricKeyStatement((src.EncryptingMechanisms |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.KeyOptions |> Seq.map (KeyOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Provider |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.TSqlStatementSnippet as src ->
      TSqlStatement.TSqlStatementSnippet((Option.ofObj (src.Script)) (* 198 *))
    | :? ScriptDom.TextModificationStatement as src ->
      match src with
      | :? ScriptDom.UpdateTextStatement as src-> (* 274 *)
        TSqlStatement.TextModificationStatement((TextModificationStatement.UpdateTextStatement((src.Bulk) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.DeleteLength |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.InsertOffset |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SourceColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SourceParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextId |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Timestamp |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.WithLog) (* 196 *))))
      | :? ScriptDom.WriteTextStatement as src-> (* 274 *)
        TSqlStatement.TextModificationStatement((TextModificationStatement.WriteTextStatement((src.Bulk) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SourceParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextId |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Timestamp |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.WithLog) (* 196 *))))
    | :? ScriptDom.ThrowStatement as src ->
      TSqlStatement.ThrowStatement((src.ErrorNumber |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Message |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.State |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.TransactionStatement as src ->
      match src with
      | :? ScriptDom.BeginTransactionStatement as src-> (* 274 *)
        TSqlStatement.TransactionStatement((TransactionStatement.BeginTransactionStatement((src.Distributed) (* 196 *), (src.MarkDefined) (* 196 *), (src.MarkDescription |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.CommitTransactionStatement as src-> (* 274 *)
        TSqlStatement.TransactionStatement((TransactionStatement.CommitTransactionStatement((src.DelayedDurabilityOption) (* 196 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.RollbackTransactionStatement as src-> (* 274 *)
        TSqlStatement.TransactionStatement((TransactionStatement.RollbackTransactionStatement((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.SaveTransactionStatement as src-> (* 274 *)
        TSqlStatement.TransactionStatement((TransactionStatement.SaveTransactionStatement((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))))
    | :? ScriptDom.TriggerStatementBody as src ->
      match src with
      | :? ScriptDom.AlterTriggerStatement as src-> (* 274 *)
        TSqlStatement.TriggerStatementBody((TriggerStatementBody.AlterTriggerStatement((src.IsNotForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TriggerOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TriggerActions |> Seq.map (fun src -> TriggerAction.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *), (src.TriggerType) (* 196 *), (src.WithAppend) (* 196 *))))
      | :? ScriptDom.CreateTriggerStatement as src-> (* 274 *)
        TSqlStatement.TriggerStatementBody((TriggerStatementBody.CreateTriggerStatement((src.IsNotForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TriggerOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TriggerActions |> Seq.map (fun src -> TriggerAction.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *), (src.TriggerType) (* 196 *), (src.WithAppend) (* 196 *))))
    | :? ScriptDom.TruncateTableStatement as src ->
      TSqlStatement.TruncateTableStatement((src.PartitionRanges |> Seq.map (fun src -> CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.TryCatchStatement as src ->
      TSqlStatement.TryCatchStatement((src.CatchStatements |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TryStatements |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
    | :? ScriptDom.UpdateStatisticsStatement as src ->
      TSqlStatement.UpdateStatisticsStatement((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StatisticsOptions |> Seq.map (StatisticsOption.FromTs) |> List.ofSeq), (src.SubElements |> Seq.map (Identifier.FromTs) |> List.ofSeq))
    | :? ScriptDom.UseFederationStatement as src ->
      TSqlStatement.UseFederationStatement((src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FederationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Filtering) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.UseStatement as src ->
      TSqlStatement.UseStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.UserStatement as src ->
      match src with
      | :? ScriptDom.AlterUserStatement as src-> (* 274 *)
        TSqlStatement.UserStatement((UserStatement.AlterUserStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserOptions |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateUserStatement as src-> (* 274 *)
        TSqlStatement.UserStatement((UserStatement.CreateUserStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserLoginOption |> Option.ofObj |> Option.map (UserLoginOption.FromTs)) (* 193 *), (src.UserOptions |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))))
    | :? ScriptDom.ViewStatementBody as src ->
      match src with
      | :? ScriptDom.AlterViewStatement as src-> (* 274 *)
        TSqlStatement.ViewStatementBody((ViewStatementBody.AlterViewStatement((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *), (src.ViewOptions |> Seq.map (fun src -> ViewOption.ViewOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.WithCheckOption) (* 196 *))))
      | :? ScriptDom.CreateViewStatement as src-> (* 274 *)
        TSqlStatement.ViewStatementBody((ViewStatementBody.CreateViewStatement((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *), (src.ViewOptions |> Seq.map (fun src -> ViewOption.ViewOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.WithCheckOption) (* 196 *))))
    | :? ScriptDom.WaitForStatement as src ->
      TSqlStatement.WaitForStatement((src.Parameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Statement |> Option.ofObj |> Option.map (WaitForSupportedStatement.FromTs)) (* 191 *), (src.Timeout |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WaitForOption) (* 196 *))
    | :? ScriptDom.WaitForSupportedStatement as src ->
      match src with
      | :? ScriptDom.GetConversationGroupStatement as src-> (* 274 *)
        TSqlStatement.WaitForSupportedStatement((WaitForSupportedStatement.GetConversationGroupStatement((src.GroupId |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.Queue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.ReceiveStatement as src-> (* 274 *)
        TSqlStatement.WaitForSupportedStatement((WaitForSupportedStatement.ReceiveStatement((src.Into |> Option.ofObj |> Option.map (VariableTableReference.FromTs)) (* 193 *), (src.IsConversationGroupIdWhere) (* 196 *), (src.Queue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectElements |> Seq.map (SelectElement.FromTs) |> List.ofSeq), (src.Top |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Where |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
    | :? ScriptDom.WhileStatement as src ->
      TSqlStatement.WhileStatement((src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.Statement |> Option.ofObj |> Option.map (TSqlStatement.FromTs)) (* 191 *))
    | :? ScriptDom.WorkloadGroupStatement as src ->
      match src with
      | :? ScriptDom.AlterWorkloadGroupStatement as src-> (* 274 *)
        TSqlStatement.WorkloadGroupStatement((WorkloadGroupStatement.AlterWorkloadGroupStatement((src.ExternalPoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.WorkloadGroupParameters |> Seq.map (WorkloadGroupParameter.FromTs) |> List.ofSeq))))
      | :? ScriptDom.CreateWorkloadGroupStatement as src-> (* 274 *)
        TSqlStatement.WorkloadGroupStatement((WorkloadGroupStatement.CreateWorkloadGroupStatement((src.ExternalPoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.WorkloadGroupParameters |> Seq.map (WorkloadGroupParameter.FromTs) |> List.ofSeq))))
and [<RequireQualifiedAccess>] TableHint = 
  | Base of HintKind:ScriptDom.TableHintKind
  | ForceSeekTableHint of ColumnValues:(ColumnReferenceExpression) list * HintKind:ScriptDom.TableHintKind * IndexValue:IdentifierOrValueExpression option
  | IndexTableHint of HintKind:ScriptDom.TableHintKind * IndexValues:(IdentifierOrValueExpression) list
  | LiteralTableHint of HintKind:ScriptDom.TableHintKind * Value:Literal option
  static member FromTs(src:ScriptDom.TableHint) : TableHint =
    match src with
    | :? ScriptDom.ForceSeekTableHint as src ->
      TableHint.ForceSeekTableHint((src.ColumnValues |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.HintKind) (* 196 *), (src.IndexValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.IndexTableHint as src ->
      TableHint.IndexTableHint((src.HintKind) (* 196 *), (src.IndexValues |> Seq.map (fun src -> IdentifierOrValueExpression.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.LiteralTableHint as src ->
      TableHint.LiteralTableHint((src.HintKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.TableHint as src *)
      TableHint.Base((* 297 *)((src.HintKind) (* 196 *)))
and [<RequireQualifiedAccess>] TableOption = 
  | DurabilityTableOption of DurabilityTableOptionKind:ScriptDom.DurabilityTableOptionKind * OptionKind:ScriptDom.TableOptionKind
  | FileStreamOnTableOption of OptionKind:ScriptDom.TableOptionKind * Value:IdentifierOrValueExpression option
  | FileTableCollateFileNameTableOption of OptionKind:ScriptDom.TableOptionKind * Value:Identifier option
  | FileTableConstraintNameTableOption of OptionKind:ScriptDom.TableOptionKind * Value:Identifier option
  | FileTableDirectoryTableOption of OptionKind:ScriptDom.TableOptionKind * Value:Literal option
  | LockEscalationTableOption of OptionKind:ScriptDom.TableOptionKind * Value:ScriptDom.LockEscalationMethod
  | MemoryOptimizedTableOption of OptionKind:ScriptDom.TableOptionKind * OptionState:ScriptDom.OptionState
  | RemoteDataArchiveAlterTableOption of FilterPredicate:FunctionCall option * IsFilterPredicateSpecified:bool * IsMigrationStateSpecified:bool * MigrationState:ScriptDom.MigrationState * OptionKind:ScriptDom.TableOptionKind * RdaTableOption:ScriptDom.RdaTableOption
  | RemoteDataArchiveTableOption of MigrationState:ScriptDom.MigrationState * OptionKind:ScriptDom.TableOptionKind * RdaTableOption:ScriptDom.RdaTableOption
  | SystemVersioningTableOption of ConsistencyCheckEnabled:ScriptDom.OptionState * HistoryTable:SchemaObjectName option * OptionKind:ScriptDom.TableOptionKind * OptionState:ScriptDom.OptionState
  | TableDataCompressionOption of DataCompressionOption:DataCompressionOption option * OptionKind:ScriptDom.TableOptionKind
  static member FromTs(src:ScriptDom.TableOption) : TableOption =
    match src with
    | :? ScriptDom.DurabilityTableOption as src ->
      TableOption.DurabilityTableOption((src.DurabilityTableOptionKind) (* 196 *), (src.OptionKind) (* 196 *))
    | :? ScriptDom.FileStreamOnTableOption as src ->
      TableOption.FileStreamOnTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.FileTableCollateFileNameTableOption as src ->
      TableOption.FileTableCollateFileNameTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FileTableConstraintNameTableOption as src ->
      TableOption.FileTableConstraintNameTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.FileTableDirectoryTableOption as src ->
      TableOption.FileTableDirectoryTableOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.LockEscalationTableOption as src ->
      TableOption.LockEscalationTableOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
    | :? ScriptDom.MemoryOptimizedTableOption as src ->
      TableOption.MemoryOptimizedTableOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.RemoteDataArchiveAlterTableOption as src ->
      TableOption.RemoteDataArchiveAlterTableOption((src.FilterPredicate |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.IsFilterPredicateSpecified) (* 196 *), (src.IsMigrationStateSpecified) (* 196 *), (src.MigrationState) (* 196 *), (src.OptionKind) (* 196 *), (src.RdaTableOption) (* 196 *))
    | :? ScriptDom.RemoteDataArchiveTableOption as src ->
      TableOption.RemoteDataArchiveTableOption((src.MigrationState) (* 196 *), (src.OptionKind) (* 196 *), (src.RdaTableOption) (* 196 *))
    | :? ScriptDom.SystemVersioningTableOption as src ->
      TableOption.SystemVersioningTableOption((src.ConsistencyCheckEnabled) (* 196 *), (src.HistoryTable |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | :? ScriptDom.TableDataCompressionOption as src ->
      TableOption.TableDataCompressionOption((src.DataCompressionOption |> Option.ofObj |> Option.map (DataCompressionOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] TableReference = 
  | JoinParenthesisTableReference of Join:TableReference option
  | JoinTableReference of JoinTableReference
  | OdbcQualifiedJoinTableReference of TableReference:TableReference option
  | TableReferenceWithAlias of TableReferenceWithAlias
  static member FromTs(src:ScriptDom.TableReference) : TableReference =
    match src with
    | :? ScriptDom.JoinParenthesisTableReference as src ->
      TableReference.JoinParenthesisTableReference((src.Join |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))
    | :? ScriptDom.JoinTableReference as src ->
      match src with
      | :? ScriptDom.QualifiedJoin as src-> (* 274 *)
        TableReference.JoinTableReference((JoinTableReference.QualifiedJoin((src.FirstTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.JoinHint) (* 196 *), (src.QualifiedJoinType) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.SecondTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))))
      | :? ScriptDom.UnqualifiedJoin as src-> (* 274 *)
        TableReference.JoinTableReference((JoinTableReference.UnqualifiedJoin((src.FirstTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.SecondTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.UnqualifiedJoinType) (* 196 *))))
    | :? ScriptDom.OdbcQualifiedJoinTableReference as src ->
      TableReference.OdbcQualifiedJoinTableReference((src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))
    | :? ScriptDom.TableReferenceWithAlias as src ->
      match src with
      | :? ScriptDom.AdHocTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.AdHocTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataSource |> Option.ofObj |> Option.map (AdHocDataSource.FromTs)) (* 193 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectNameOrValueExpression.FromTs)) (* 193 *))))
      | :? ScriptDom.BuiltInFunctionTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.BuiltInFunctionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.FullTextTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.FullTextTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FullTextFunctionType) (* 196 *), (src.Language |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TopN |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.InternalOpenRowset as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.InternalOpenRowset((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.VarArgs |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))))
      | :? ScriptDom.NamedTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.NamedTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SchemaObject |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TableHints |> Seq.map (TableHint.FromTs) |> List.ofSeq), (src.TableSampleClause |> Option.ofObj |> Option.map (TableSampleClause.FromTs)) (* 193 *), (src.TemporalClause |> Option.ofObj |> Option.map (TemporalClause.FromTs)) (* 193 *))))
      | :? ScriptDom.OpenJsonTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.OpenJsonTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RowPattern |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SchemaDeclarationItems |> Seq.map (fun src -> SchemaDeclarationItemOpenjson.SchemaDeclarationItemOpenjson((src.AsJson) (* 196 *), (src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Variable |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.OpenQueryTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.OpenQueryTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LinkedServer |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Query |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.OpenRowsetTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.OpenRowsetTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataSource |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderString |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Query |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.UserId |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))))
      | :? ScriptDom.OpenXmlTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.OpenXmlTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Flags |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.RowPattern |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.SchemaDeclarationItems |> Seq.map (SchemaDeclarationItem.FromTs) |> List.ofSeq), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
      | :? ScriptDom.PivotedTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.PivotedTableReference((src.AggregateFunctionIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *), (src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.InColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PivotColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.ValueColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.SemanticTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.SemanticTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.MatchedColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.MatchedKey |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SemanticFunctionType) (* 196 *), (src.SourceKey |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.TableReferenceWithAliasAndColumns as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.FromTs(src))) (* 251 *)))
      | :? ScriptDom.UnpivotedTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.UnpivotedTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.InColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.PivotColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.ValueColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | :? ScriptDom.VariableTableReference as src-> (* 274 *)
        TableReference.TableReferenceWithAlias((TableReferenceWithAlias.VariableTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
and [<RequireQualifiedAccess>] TableSwitchOption = 
  | LowPriorityLockWaitTableSwitchOption of OptionKind:ScriptDom.TableSwitchOptionKind * Options:(LowPriorityLockWaitOption) list
  static member FromTs(src:ScriptDom.TableSwitchOption) : TableSwitchOption =
    match src with
    | :? ScriptDom.LowPriorityLockWaitTableSwitchOption as src ->
      TableSwitchOption.LowPriorityLockWaitTableSwitchOption((src.OptionKind) (* 196 *), (src.Options |> Seq.map (LowPriorityLockWaitOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] TriggerOption = 
  | Base of OptionKind:ScriptDom.TriggerOptionKind
  | ExecuteAsTriggerOption of ExecuteAsClause:ExecuteAsClause option * OptionKind:ScriptDom.TriggerOptionKind
  static member FromTs(src:ScriptDom.TriggerOption) : TriggerOption =
    match src with
    | :? ScriptDom.ExecuteAsTriggerOption as src ->
      TriggerOption.ExecuteAsTriggerOption((src.ExecuteAsClause |> Option.ofObj |> Option.map (ExecuteAsClause.FromTs)) (* 193 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.TriggerOption as src *)
      TriggerOption.Base((* 297 *)((src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] WhenClause = 
  | SearchedWhenClause of ThenExpression:ScalarExpression option * WhenExpression:BooleanExpression option
  | SimpleWhenClause of ThenExpression:ScalarExpression option * WhenExpression:ScalarExpression option
  static member FromTs(src:ScriptDom.WhenClause) : WhenClause =
    match src with
    | :? ScriptDom.SearchedWhenClause as src ->
      WhenClause.SearchedWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SimpleWhenClause as src ->
      WhenClause.SimpleWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] WorkloadGroupParameter = 
  | WorkloadGroupImportanceParameter of ParameterType:ScriptDom.WorkloadGroupParameterType * ParameterValue:ScriptDom.ImportanceParameterType
  | WorkloadGroupResourceParameter of ParameterType:ScriptDom.WorkloadGroupParameterType * ParameterValue:Literal option
  static member FromTs(src:ScriptDom.WorkloadGroupParameter) : WorkloadGroupParameter =
    match src with
    | :? ScriptDom.WorkloadGroupImportanceParameter as src ->
      WorkloadGroupParameter.WorkloadGroupImportanceParameter((src.ParameterType) (* 196 *), (src.ParameterValue) (* 196 *))
    | :? ScriptDom.WorkloadGroupResourceParameter as src ->
      WorkloadGroupParameter.WorkloadGroupResourceParameter((src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] XmlNamespacesElement = 
  | XmlNamespacesAliasElement of Identifier:Identifier option * String:StringLiteral option
  | XmlNamespacesDefaultElement of String:StringLiteral option
  static member FromTs(src:ScriptDom.XmlNamespacesElement) : XmlNamespacesElement =
    match src with
    | :? ScriptDom.XmlNamespacesAliasElement as src ->
      XmlNamespacesElement.XmlNamespacesAliasElement((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.String |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.XmlNamespacesDefaultElement as src ->
      XmlNamespacesElement.XmlNamespacesDefaultElement((src.String |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] UpdateDeleteSpecificationBase = 
  | DeleteSpecification of FromClause:FromClause option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * Target:TableReference option * TopRowFilter:TopRowFilter option * WhereClause:WhereClause option
  | UpdateSpecification of FromClause:FromClause option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * SetClauses:(SetClause) list * Target:TableReference option * TopRowFilter:TopRowFilter option * WhereClause:WhereClause option
  static member FromTs(src:ScriptDom.UpdateDeleteSpecificationBase) : UpdateDeleteSpecificationBase =
    match src with
    | :? ScriptDom.DeleteSpecification as src ->
      UpdateDeleteSpecificationBase.DeleteSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))
    | :? ScriptDom.UpdateSpecification as src ->
      UpdateDeleteSpecificationBase.UpdateSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SetClauses |> Seq.map (SetClause.FromTs) |> List.ofSeq), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ParameterizedDataTypeReference = 
  | SqlDataTypeReference of Name:SchemaObjectName option * Parameters:(Literal) list * SqlDataTypeOption:ScriptDom.SqlDataTypeOption
  | UserDataTypeReference of Name:SchemaObjectName option * Parameters:(Literal) list
  static member FromTs(src:ScriptDom.ParameterizedDataTypeReference) : ParameterizedDataTypeReference =
    match src with
    | :? ScriptDom.SqlDataTypeReference as src ->
      ParameterizedDataTypeReference.SqlDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (Literal.FromTs) |> List.ofSeq), (src.SqlDataTypeOption) (* 196 *))
    | :? ScriptDom.UserDataTypeReference as src ->
      ParameterizedDataTypeReference.UserDataTypeReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Parameters |> Seq.map (Literal.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] HadrDatabaseOption = 
  | Base of HadrOption:ScriptDom.HadrDatabaseOptionKind * OptionKind:ScriptDom.DatabaseOptionKind
  | HadrAvailabilityGroupDatabaseOption of GroupName:Identifier option * HadrOption:ScriptDom.HadrDatabaseOptionKind * OptionKind:ScriptDom.DatabaseOptionKind
  static member FromTs(src:ScriptDom.HadrDatabaseOption) : HadrDatabaseOption =
    match src with
    | :? ScriptDom.HadrAvailabilityGroupDatabaseOption as src ->
      HadrDatabaseOption.HadrAvailabilityGroupDatabaseOption((src.GroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.HadrOption) (* 196 *), (src.OptionKind) (* 196 *))
    | _ -> (* :? ScriptDom.HadrDatabaseOption as src *)
      HadrDatabaseOption.Base((* 297 *)((src.HadrOption) (* 196 *), (src.OptionKind) (* 196 *)))
and [<RequireQualifiedAccess>] OnOffDatabaseOption = 
  | Base of OptionKind:ScriptDom.DatabaseOptionKind * OptionState:ScriptDom.OptionState
  | AutoCreateStatisticsDatabaseOption of HasIncremental:bool * IncrementalState:ScriptDom.OptionState * OptionKind:ScriptDom.DatabaseOptionKind * OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.OnOffDatabaseOption) : OnOffDatabaseOption =
    match src with
    | :? ScriptDom.AutoCreateStatisticsDatabaseOption as src ->
      OnOffDatabaseOption.AutoCreateStatisticsDatabaseOption((src.HasIncremental) (* 196 *), (src.IncrementalState) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | _ -> (* :? ScriptDom.OnOffDatabaseOption as src *)
      OnOffDatabaseOption.Base((* 297 *)((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *)))
and [<RequireQualifiedAccess>] IndexStateOption = 
  | Base of OptionKind:ScriptDom.IndexOptionKind * OptionState:ScriptDom.OptionState
  | OnlineIndexOption of LowPriorityLockWaitOption:OnlineIndexLowPriorityLockWaitOption option * OptionKind:ScriptDom.IndexOptionKind * OptionState:ScriptDom.OptionState
  static member FromTs(src:ScriptDom.IndexStateOption) : IndexStateOption =
    match src with
    | :? ScriptDom.OnlineIndexOption as src ->
      IndexStateOption.OnlineIndexOption((src.LowPriorityLockWaitOption |> Option.ofObj |> Option.map (OnlineIndexLowPriorityLockWaitOption.FromTs)) (* 193 *), (src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
    | _ -> (* :? ScriptDom.IndexStateOption as src *)
      IndexStateOption.Base((* 297 *)((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *)))
and [<RequireQualifiedAccess>] SchemaObjectName = 
  | Base of BaseIdentifier:Identifier option * Count:Int32 * DatabaseIdentifier:Identifier option * Identifiers:(Identifier) list * SchemaIdentifier:Identifier option * ServerIdentifier:Identifier option
  | ChildObjectName of BaseIdentifier:Identifier option * ChildIdentifier:Identifier option * Count:Int32 * DatabaseIdentifier:Identifier option * Identifiers:(Identifier) list * SchemaIdentifier:Identifier option * ServerIdentifier:Identifier option
  | SchemaObjectNameSnippet of BaseIdentifier:Identifier option * Count:Int32 * DatabaseIdentifier:Identifier option * Identifiers:(Identifier) list * SchemaIdentifier:Identifier option * Script:String option * ServerIdentifier:Identifier option
  static member FromTs(src:ScriptDom.SchemaObjectName) : SchemaObjectName =
    match src with
    | :? ScriptDom.ChildObjectName as src ->
      SchemaObjectName.ChildObjectName((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ChildIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.SchemaObjectNameSnippet as src ->
      SchemaObjectName.SchemaObjectNameSnippet((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Script)) (* 198 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.SchemaObjectName as src *)
      SchemaObjectName.Base((* 297 *)((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] PrimaryExpression = 
  | AtTimeZoneCall of Collation:Identifier option * DateValue:ScalarExpression option * TimeZone:ScalarExpression option
  | CaseExpression of CaseExpression
  | CastCall of Collation:Identifier option * DataType:DataTypeReference option * Parameter:ScalarExpression option
  | CoalesceExpression of Collation:Identifier option * Expressions:(ScalarExpression) list
  | ColumnReferenceExpression of Collation:Identifier option * ColumnType:ScriptDom.ColumnType * MultiPartIdentifier:MultiPartIdentifier option
  | ConvertCall of Collation:Identifier option * DataType:DataTypeReference option * Parameter:ScalarExpression option * Style:ScalarExpression option
  | FunctionCall of CallTarget:CallTarget option * Collation:Identifier option * FunctionName:Identifier option * OverClause:OverClause option * Parameters:(ScalarExpression) list * UniqueRowFilter:ScriptDom.UniqueRowFilter * WithinGroupClause:WithinGroupClause option
  | IIfCall of Collation:Identifier option * ElseExpression:ScalarExpression option * Predicate:BooleanExpression option * ThenExpression:ScalarExpression option
  | LeftFunctionCall of Collation:Identifier option * Parameters:(ScalarExpression) list
  | NextValueForExpression of Collation:Identifier option * OverClause:OverClause option * SequenceName:SchemaObjectName option
  | NullIfExpression of Collation:Identifier option * FirstExpression:ScalarExpression option * SecondExpression:ScalarExpression option
  | OdbcFunctionCall of Collation:Identifier option * Name:Identifier option * Parameters:(ScalarExpression) list * ParametersUsed:bool
  | ParameterlessCall of Collation:Identifier option * ParameterlessCallType:ScriptDom.ParameterlessCallType
  | ParenthesisExpression of Collation:Identifier option * Expression:ScalarExpression option
  | ParseCall of Collation:Identifier option * Culture:ScalarExpression option * DataType:DataTypeReference option * StringValue:ScalarExpression option
  | PartitionFunctionCall of Collation:Identifier option * DatabaseName:Identifier option * FunctionName:Identifier option * Parameters:(ScalarExpression) list
  | RightFunctionCall of Collation:Identifier option * Parameters:(ScalarExpression) list
  | ScalarSubquery of Collation:Identifier option * QueryExpression:QueryExpression option
  | TryCastCall of Collation:Identifier option * DataType:DataTypeReference option * Parameter:ScalarExpression option
  | TryConvertCall of Collation:Identifier option * DataType:DataTypeReference option * Parameter:ScalarExpression option * Style:ScalarExpression option
  | TryParseCall of Collation:Identifier option * Culture:ScalarExpression option * DataType:DataTypeReference option * StringValue:ScalarExpression option
  | UserDefinedTypePropertyAccess of CallTarget:CallTarget option * Collation:Identifier option * PropertyName:Identifier option
  | ValueExpression of ValueExpression
  static member FromTs(src:ScriptDom.PrimaryExpression) : PrimaryExpression =
    match src with
    | :? ScriptDom.AtTimeZoneCall as src ->
      PrimaryExpression.AtTimeZoneCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DateValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TimeZone |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.CaseExpression as src ->
      match src with
      | :? ScriptDom.SearchedCaseExpression as src-> (* 274 *)
        PrimaryExpression.CaseExpression((CaseExpression.SearchedCaseExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenClauses |> Seq.map (fun src -> SearchedWhenClause.SearchedWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))) |> List.ofSeq))))
      | :? ScriptDom.SimpleCaseExpression as src-> (* 274 *)
        PrimaryExpression.CaseExpression((CaseExpression.SimpleCaseExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.InputExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenClauses |> Seq.map (fun src -> SimpleWhenClause.SimpleWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))))
    | :? ScriptDom.CastCall as src ->
      PrimaryExpression.CastCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.CoalesceExpression as src ->
      PrimaryExpression.CoalesceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.ColumnReferenceExpression as src ->
      PrimaryExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
    | :? ScriptDom.ConvertCall as src ->
      PrimaryExpression.ConvertCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Style |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.FunctionCall as src ->
      PrimaryExpression.FunctionCall((src.CallTarget |> Option.ofObj |> Option.map (CallTarget.FromTs)) (* 191 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FunctionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OverClause |> Option.ofObj |> Option.map (OverClause.FromTs)) (* 193 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.UniqueRowFilter) (* 196 *), (src.WithinGroupClause |> Option.ofObj |> Option.map (WithinGroupClause.FromTs)) (* 193 *))
    | :? ScriptDom.IIfCall as src ->
      PrimaryExpression.IIfCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Predicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.LeftFunctionCall as src ->
      PrimaryExpression.LeftFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.NextValueForExpression as src ->
      PrimaryExpression.NextValueForExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OverClause |> Option.ofObj |> Option.map (OverClause.FromTs)) (* 193 *), (src.SequenceName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.NullIfExpression as src ->
      PrimaryExpression.NullIfExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FirstExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SecondExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.OdbcFunctionCall as src ->
      PrimaryExpression.OdbcFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ParametersUsed) (* 196 *))
    | :? ScriptDom.ParameterlessCall as src ->
      PrimaryExpression.ParameterlessCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ParameterlessCallType) (* 196 *))
    | :? ScriptDom.ParenthesisExpression as src ->
      PrimaryExpression.ParenthesisExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.ParseCall as src ->
      PrimaryExpression.ParseCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Culture |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.StringValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.PartitionFunctionCall as src ->
      PrimaryExpression.PartitionFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FunctionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.RightFunctionCall as src ->
      PrimaryExpression.RightFunctionCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.ScalarSubquery as src ->
      PrimaryExpression.ScalarSubquery((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.TryCastCall as src ->
      PrimaryExpression.TryCastCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.TryConvertCall as src ->
      PrimaryExpression.TryConvertCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Parameter |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Style |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.TryParseCall as src ->
      PrimaryExpression.TryParseCall((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Culture |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.StringValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
    | :? ScriptDom.UserDefinedTypePropertyAccess as src ->
      PrimaryExpression.UserDefinedTypePropertyAccess((src.CallTarget |> Option.ofObj |> Option.map (CallTarget.FromTs)) (* 191 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.ValueExpression as src ->
      match src with
      | :? ScriptDom.GlobalVariableExpression as src-> (* 274 *)
        PrimaryExpression.ValueExpression((ValueExpression.GlobalVariableExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))))
      | :? ScriptDom.Literal as src-> (* 274 *)
        PrimaryExpression.ValueExpression((ValueExpression.Literal((Literal.FromTs(src))) (* 251 *)))
      | :? ScriptDom.VariableReference as src-> (* 274 *)
        PrimaryExpression.ValueExpression((ValueExpression.VariableReference((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))))
and [<RequireQualifiedAccess>] AlterCreateEndpointStatementBase = 
  | AlterEndpointStatement of Affinity:EndpointAffinity option * EndpointType:ScriptDom.EndpointType * Name:Identifier option * PayloadOptions:(PayloadOption) list * Protocol:ScriptDom.EndpointProtocol * ProtocolOptions:(EndpointProtocolOption) list * State:ScriptDom.EndpointState
  | CreateEndpointStatement of Affinity:EndpointAffinity option * EndpointType:ScriptDom.EndpointType * Name:Identifier option * Owner:Identifier option * PayloadOptions:(PayloadOption) list * Protocol:ScriptDom.EndpointProtocol * ProtocolOptions:(EndpointProtocolOption) list * State:ScriptDom.EndpointState
  static member FromTs(src:ScriptDom.AlterCreateEndpointStatementBase) : AlterCreateEndpointStatementBase =
    match src with
    | :? ScriptDom.AlterEndpointStatement as src ->
      AlterCreateEndpointStatementBase.AlterEndpointStatement((src.Affinity |> Option.ofObj |> Option.map (EndpointAffinity.FromTs)) (* 193 *), (src.EndpointType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PayloadOptions |> Seq.map (PayloadOption.FromTs) |> List.ofSeq), (src.Protocol) (* 196 *), (src.ProtocolOptions |> Seq.map (EndpointProtocolOption.FromTs) |> List.ofSeq), (src.State) (* 196 *))
    | :? ScriptDom.CreateEndpointStatement as src ->
      AlterCreateEndpointStatementBase.CreateEndpointStatement((src.Affinity |> Option.ofObj |> Option.map (EndpointAffinity.FromTs)) (* 193 *), (src.EndpointType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PayloadOptions |> Seq.map (PayloadOption.FromTs) |> List.ofSeq), (src.Protocol) (* 196 *), (src.ProtocolOptions |> Seq.map (EndpointProtocolOption.FromTs) |> List.ofSeq), (src.State) (* 196 *))
and [<RequireQualifiedAccess>] AlterCreateServiceStatementBase = 
  | AlterServiceStatement of Name:Identifier option * QueueName:SchemaObjectName option * ServiceContracts:(ServiceContract) list
  | CreateServiceStatement of Name:Identifier option * Owner:Identifier option * QueueName:SchemaObjectName option * ServiceContracts:(ServiceContract) list
  static member FromTs(src:ScriptDom.AlterCreateServiceStatementBase) : AlterCreateServiceStatementBase =
    match src with
    | :? ScriptDom.AlterServiceStatement as src ->
      AlterCreateServiceStatementBase.AlterServiceStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ServiceContracts |> Seq.map (fun src -> ServiceContract.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.CreateServiceStatement as src ->
      AlterCreateServiceStatementBase.CreateServiceStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ServiceContracts |> Seq.map (fun src -> ServiceContract.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] AlterDatabaseScopedConfigurationStatement = 
  | AlterDatabaseScopedConfigurationClearStatement of Option:DatabaseConfigurationClearOption option * Secondary:bool
  | AlterDatabaseScopedConfigurationSetStatement of Option:DatabaseConfigurationSetOption option * Secondary:bool
  static member FromTs(src:ScriptDom.AlterDatabaseScopedConfigurationStatement) : AlterDatabaseScopedConfigurationStatement =
    match src with
    | :? ScriptDom.AlterDatabaseScopedConfigurationClearStatement as src ->
      AlterDatabaseScopedConfigurationStatement.AlterDatabaseScopedConfigurationClearStatement((src.Option |> Option.ofObj |> Option.map (DatabaseConfigurationClearOption.FromTs)) (* 193 *), (src.Secondary) (* 196 *))
    | :? ScriptDom.AlterDatabaseScopedConfigurationSetStatement as src ->
      AlterDatabaseScopedConfigurationStatement.AlterDatabaseScopedConfigurationSetStatement((src.Option |> Option.ofObj |> Option.map (DatabaseConfigurationSetOption.FromTs)) (* 191 *), (src.Secondary) (* 196 *))
and [<RequireQualifiedAccess>] AlterDatabaseStatement = 
  | AlterDatabaseAddFileGroupStatement of ContainsFileStream:bool * ContainsMemoryOptimizedData:bool * DatabaseName:Identifier option * FileGroup:Identifier option * UseCurrent:bool
  | AlterDatabaseAddFileStatement of DatabaseName:Identifier option * FileDeclarations:(FileDeclaration) list * FileGroup:Identifier option * IsLog:bool * UseCurrent:bool
  | AlterDatabaseCollateStatement of Collation:Identifier option * DatabaseName:Identifier option * UseCurrent:bool
  | AlterDatabaseModifyFileGroupStatement of DatabaseName:Identifier option * FileGroup:Identifier option * MakeDefault:bool * NewFileGroupName:Identifier option * Termination:AlterDatabaseTermination option * UpdatabilityOption:ScriptDom.ModifyFileGroupOption * UseCurrent:bool
  | AlterDatabaseModifyFileStatement of DatabaseName:Identifier option * FileDeclaration:FileDeclaration option * UseCurrent:bool
  | AlterDatabaseModifyNameStatement of DatabaseName:Identifier option * NewDatabaseName:Identifier option * UseCurrent:bool
  | AlterDatabaseRebuildLogStatement of DatabaseName:Identifier option * FileDeclaration:FileDeclaration option * UseCurrent:bool
  | AlterDatabaseRemoveFileGroupStatement of DatabaseName:Identifier option * FileGroup:Identifier option * UseCurrent:bool
  | AlterDatabaseRemoveFileStatement of DatabaseName:Identifier option * File:Identifier option * UseCurrent:bool
  | AlterDatabaseSetStatement of DatabaseName:Identifier option * Options:(DatabaseOption) list * Termination:AlterDatabaseTermination option * UseCurrent:bool
  static member FromTs(src:ScriptDom.AlterDatabaseStatement) : AlterDatabaseStatement =
    match src with
    | :? ScriptDom.AlterDatabaseAddFileGroupStatement as src ->
      AlterDatabaseStatement.AlterDatabaseAddFileGroupStatement((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseAddFileStatement as src ->
      AlterDatabaseStatement.AlterDatabaseAddFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLog) (* 196 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseCollateStatement as src ->
      AlterDatabaseStatement.AlterDatabaseCollateStatement((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseModifyFileGroupStatement as src ->
      AlterDatabaseStatement.AlterDatabaseModifyFileGroupStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.MakeDefault) (* 196 *), (src.NewFileGroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Termination |> Option.ofObj |> Option.map (AlterDatabaseTermination.FromTs)) (* 193 *), (src.UpdatabilityOption) (* 196 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseModifyFileStatement as src ->
      AlterDatabaseStatement.AlterDatabaseModifyFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclaration |> Option.ofObj |> Option.map (FileDeclaration.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseModifyNameStatement as src ->
      AlterDatabaseStatement.AlterDatabaseModifyNameStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.NewDatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseRebuildLogStatement as src ->
      AlterDatabaseStatement.AlterDatabaseRebuildLogStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileDeclaration |> Option.ofObj |> Option.map (FileDeclaration.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseRemoveFileGroupStatement as src ->
      AlterDatabaseStatement.AlterDatabaseRemoveFileGroupStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseRemoveFileStatement as src ->
      AlterDatabaseStatement.AlterDatabaseRemoveFileStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UseCurrent) (* 196 *))
    | :? ScriptDom.AlterDatabaseSetStatement as src ->
      AlterDatabaseStatement.AlterDatabaseSetStatement((src.DatabaseName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (DatabaseOption.FromTs) |> List.ofSeq), (src.Termination |> Option.ofObj |> Option.map (AlterDatabaseTermination.FromTs)) (* 193 *), (src.UseCurrent) (* 196 *))
and [<RequireQualifiedAccess>] AlterLoginStatement = 
  | AlterLoginAddDropCredentialStatement of CredentialName:Identifier option * IsAdd:bool * Name:Identifier option
  | AlterLoginEnableDisableStatement of IsEnable:bool * Name:Identifier option
  | AlterLoginOptionsStatement of Name:Identifier option * Options:(PrincipalOption) list
  static member FromTs(src:ScriptDom.AlterLoginStatement) : AlterLoginStatement =
    match src with
    | :? ScriptDom.AlterLoginAddDropCredentialStatement as src ->
      AlterLoginStatement.AlterLoginAddDropCredentialStatement((src.CredentialName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsAdd) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterLoginEnableDisableStatement as src ->
      AlterLoginStatement.AlterLoginEnableDisableStatement((src.IsEnable) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterLoginOptionsStatement as src ->
      AlterLoginStatement.AlterLoginOptionsStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] AlterTableStatement = 
  | AlterTableAddTableElementStatement of Definition:TableDefinition option * ExistingRowsCheckEnforcement:ScriptDom.ConstraintEnforcement * SchemaObjectName:SchemaObjectName option
  | AlterTableAlterColumnStatement of AlterTableAlterColumnOption:ScriptDom.AlterTableAlterColumnOption * Collation:Identifier option * ColumnIdentifier:Identifier option * DataType:DataTypeReference option * GeneratedAlways:(ScriptDom.GeneratedAlwaysType) option * IsHidden:bool * IsMasked:bool * MaskingFunction:StringLiteral option * Options:(IndexOption) list * SchemaObjectName:SchemaObjectName option * StorageOptions:ColumnStorageOptions option
  | AlterTableAlterIndexStatement of AlterIndexType:ScriptDom.AlterIndexType * IndexIdentifier:Identifier option * IndexOptions:(IndexOption) list * SchemaObjectName:SchemaObjectName option
  | AlterTableChangeTrackingModificationStatement of IsEnable:bool * SchemaObjectName:SchemaObjectName option * TrackColumnsUpdated:ScriptDom.OptionState
  | AlterTableConstraintModificationStatement of All:bool * ConstraintEnforcement:ScriptDom.ConstraintEnforcement * ConstraintNames:(Identifier) list * ExistingRowsCheckEnforcement:ScriptDom.ConstraintEnforcement * SchemaObjectName:SchemaObjectName option
  | AlterTableDropTableElementStatement of AlterTableDropTableElements:(AlterTableDropTableElement) list * SchemaObjectName:SchemaObjectName option
  | AlterTableFileTableNamespaceStatement of IsEnable:bool * SchemaObjectName:SchemaObjectName option
  | AlterTableRebuildStatement of IndexOptions:(IndexOption) list * Partition:PartitionSpecifier option * SchemaObjectName:SchemaObjectName option
  | AlterTableSetStatement of Options:(TableOption) list * SchemaObjectName:SchemaObjectName option
  | AlterTableSwitchStatement of Options:(TableSwitchOption) list * SchemaObjectName:SchemaObjectName option * SourcePartitionNumber:ScalarExpression option * TargetPartitionNumber:ScalarExpression option * TargetTable:SchemaObjectName option
  | AlterTableTriggerModificationStatement of All:bool * SchemaObjectName:SchemaObjectName option * TriggerEnforcement:ScriptDom.TriggerEnforcement * TriggerNames:(Identifier) list
  static member FromTs(src:ScriptDom.AlterTableStatement) : AlterTableStatement =
    match src with
    | :? ScriptDom.AlterTableAddTableElementStatement as src ->
      AlterTableStatement.AlterTableAddTableElementStatement((src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.ExistingRowsCheckEnforcement) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableAlterColumnStatement as src ->
      AlterTableStatement.AlterTableAlterColumnStatement((src.AlterTableAlterColumnOption) (* 196 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (Option.ofNullable (src.GeneratedAlways)), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Options |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))
    | :? ScriptDom.AlterTableAlterIndexStatement as src ->
      AlterTableStatement.AlterTableAlterIndexStatement((src.AlterIndexType) (* 196 *), (src.IndexIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableChangeTrackingModificationStatement as src ->
      AlterTableStatement.AlterTableChangeTrackingModificationStatement((src.IsEnable) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TrackColumnsUpdated) (* 196 *))
    | :? ScriptDom.AlterTableConstraintModificationStatement as src ->
      AlterTableStatement.AlterTableConstraintModificationStatement((src.All) (* 196 *), (src.ConstraintEnforcement) (* 196 *), (src.ConstraintNames |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExistingRowsCheckEnforcement) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableDropTableElementStatement as src ->
      AlterTableStatement.AlterTableDropTableElementStatement((src.AlterTableDropTableElements |> Seq.map (fun src -> AlterTableDropTableElement.AlterTableDropTableElement((src.DropClusteredConstraintOptions |> Seq.map (DropClusteredConstraintOption.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableElementType) (* 196 *))) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableFileTableNamespaceStatement as src ->
      AlterTableStatement.AlterTableFileTableNamespaceStatement((src.IsEnable) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableRebuildStatement as src ->
      AlterTableStatement.AlterTableRebuildStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Partition |> Option.ofObj |> Option.map (PartitionSpecifier.FromTs)) (* 193 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableSetStatement as src ->
      AlterTableStatement.AlterTableSetStatement((src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableSwitchStatement as src ->
      AlterTableStatement.AlterTableSwitchStatement((src.Options |> Seq.map (TableSwitchOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SourcePartitionNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TargetPartitionNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TargetTable |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.AlterTableTriggerModificationStatement as src ->
      AlterTableStatement.AlterTableTriggerModificationStatement((src.All) (* 196 *), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TriggerEnforcement) (* 196 *), (src.TriggerNames |> Seq.map (Identifier.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ApplicationRoleStatement = 
  | AlterApplicationRoleStatement of ApplicationRoleOptions:(ApplicationRoleOption) list * Name:Identifier option
  | CreateApplicationRoleStatement of ApplicationRoleOptions:(ApplicationRoleOption) list * Name:Identifier option
  static member FromTs(src:ScriptDom.ApplicationRoleStatement) : ApplicationRoleStatement =
    match src with
    | :? ScriptDom.AlterApplicationRoleStatement as src ->
      ApplicationRoleStatement.AlterApplicationRoleStatement((src.ApplicationRoleOptions |> Seq.map (fun src -> ApplicationRoleOption.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateApplicationRoleStatement as src ->
      ApplicationRoleStatement.CreateApplicationRoleStatement((src.ApplicationRoleOptions |> Seq.map (fun src -> ApplicationRoleOption.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AssemblyStatement = 
  | AlterAssemblyStatement of AddFiles:(AddFileSpec) list * DropFiles:(Literal) list * IsDropAll:bool * Name:Identifier option * Options:(AssemblyOption) list * Parameters:(ScalarExpression) list
  | CreateAssemblyStatement of Name:Identifier option * Options:(AssemblyOption) list * Owner:Identifier option * Parameters:(ScalarExpression) list
  static member FromTs(src:ScriptDom.AssemblyStatement) : AssemblyStatement =
    match src with
    | :? ScriptDom.AlterAssemblyStatement as src ->
      AssemblyStatement.AlterAssemblyStatement((src.AddFiles |> Seq.map (fun src -> AddFileSpec.AddFileSpec((src.File |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.DropFiles |> Seq.map (Literal.FromTs) |> List.ofSeq), (src.IsDropAll) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AssemblyOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateAssemblyStatement as src ->
      AssemblyStatement.CreateAssemblyStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AssemblyOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] AuditSpecificationStatement = 
  | AlterDatabaseAuditSpecificationStatement of AuditName:Identifier option * AuditState:ScriptDom.OptionState * Parts:(AuditSpecificationPart) list * SpecificationName:Identifier option
  | AlterServerAuditSpecificationStatement of AuditName:Identifier option * AuditState:ScriptDom.OptionState * Parts:(AuditSpecificationPart) list * SpecificationName:Identifier option
  | CreateDatabaseAuditSpecificationStatement of AuditName:Identifier option * AuditState:ScriptDom.OptionState * Parts:(AuditSpecificationPart) list * SpecificationName:Identifier option
  | CreateServerAuditSpecificationStatement of AuditName:Identifier option * AuditState:ScriptDom.OptionState * Parts:(AuditSpecificationPart) list * SpecificationName:Identifier option
  static member FromTs(src:ScriptDom.AuditSpecificationStatement) : AuditSpecificationStatement =
    match src with
    | :? ScriptDom.AlterDatabaseAuditSpecificationStatement as src ->
      AuditSpecificationStatement.AlterDatabaseAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.AlterServerAuditSpecificationStatement as src ->
      AuditSpecificationStatement.AlterServerAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateDatabaseAuditSpecificationStatement as src ->
      AuditSpecificationStatement.CreateDatabaseAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateServerAuditSpecificationStatement as src ->
      AuditSpecificationStatement.CreateServerAuditSpecificationStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditState) (* 196 *), (src.Parts |> Seq.map (fun src -> AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))) |> List.ofSeq), (src.SpecificationName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AvailabilityGroupStatement = 
  | AlterAvailabilityGroupStatement of Action:AlterAvailabilityGroupAction option * AlterAvailabilityGroupStatementType:ScriptDom.AlterAvailabilityGroupStatementType * Databases:(Identifier) list * Name:Identifier option * Options:(AvailabilityGroupOption) list * Replicas:(AvailabilityReplica) list
  | CreateAvailabilityGroupStatement of Databases:(Identifier) list * Name:Identifier option * Options:(AvailabilityGroupOption) list * Replicas:(AvailabilityReplica) list
  static member FromTs(src:ScriptDom.AvailabilityGroupStatement) : AvailabilityGroupStatement =
    match src with
    | :? ScriptDom.AlterAvailabilityGroupStatement as src ->
      AvailabilityGroupStatement.AlterAvailabilityGroupStatement((src.Action |> Option.ofObj |> Option.map (AlterAvailabilityGroupAction.FromTs)) (* 191 *), (src.AlterAvailabilityGroupStatementType) (* 196 *), (src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AvailabilityGroupOption.FromTs) |> List.ofSeq), (src.Replicas |> Seq.map (fun src -> AvailabilityReplica.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))) |> List.ofSeq))
    | :? ScriptDom.CreateAvailabilityGroupStatement as src ->
      AvailabilityGroupStatement.CreateAvailabilityGroupStatement((src.Databases |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AvailabilityGroupOption.FromTs) |> List.ofSeq), (src.Replicas |> Seq.map (fun src -> AvailabilityReplica.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] BackupRestoreMasterKeyStatementBase = 
  | BackupMasterKeyStatement of File:Literal option * Password:Literal option
  | BackupServiceMasterKeyStatement of File:Literal option * Password:Literal option
  | RestoreMasterKeyStatement of EncryptionPassword:Literal option * File:Literal option * IsForce:bool * Password:Literal option
  | RestoreServiceMasterKeyStatement of File:Literal option * IsForce:bool * Password:Literal option
  static member FromTs(src:ScriptDom.BackupRestoreMasterKeyStatementBase) : BackupRestoreMasterKeyStatementBase =
    match src with
    | :? ScriptDom.BackupMasterKeyStatement as src ->
      BackupRestoreMasterKeyStatementBase.BackupMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.BackupServiceMasterKeyStatement as src ->
      BackupRestoreMasterKeyStatementBase.BackupServiceMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.RestoreMasterKeyStatement as src ->
      BackupRestoreMasterKeyStatementBase.RestoreMasterKeyStatement((src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsForce) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.RestoreServiceMasterKeyStatement as src ->
      BackupRestoreMasterKeyStatementBase.RestoreServiceMasterKeyStatement((src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsForce) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] BackupStatement = 
  | BackupDatabaseStatement of DatabaseName:IdentifierOrValueExpression option * Devices:(DeviceInfo) list * Files:(BackupRestoreFileInfo) list * MirrorToClauses:(MirrorToClause) list * Options:(BackupOption) list
  | BackupTransactionLogStatement of DatabaseName:IdentifierOrValueExpression option * Devices:(DeviceInfo) list * MirrorToClauses:(MirrorToClause) list * Options:(BackupOption) list
  static member FromTs(src:ScriptDom.BackupStatement) : BackupStatement =
    match src with
    | :? ScriptDom.BackupDatabaseStatement as src ->
      BackupStatement.BackupDatabaseStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Files |> Seq.map (fun src -> BackupRestoreFileInfo.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.MirrorToClauses |> Seq.map (fun src -> MirrorToClause.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (BackupOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.BackupTransactionLogStatement as src ->
      BackupStatement.BackupTransactionLogStatement((src.DatabaseName |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.MirrorToClauses |> Seq.map (fun src -> MirrorToClause.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Options |> Seq.map (BackupOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] BeginEndBlockStatement = 
  | Base of StatementList:StatementList option
  | BeginEndAtomicBlockStatement of Options:(AtomicBlockOption) list * StatementList:StatementList option
  static member FromTs(src:ScriptDom.BeginEndBlockStatement) : BeginEndBlockStatement =
    match src with
    | :? ScriptDom.BeginEndAtomicBlockStatement as src ->
      BeginEndBlockStatement.BeginEndAtomicBlockStatement((src.Options |> Seq.map (AtomicBlockOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.BeginEndBlockStatement as src *)
      BeginEndBlockStatement.Base((* 297 *)((src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] BrokerPriorityStatement = 
  | AlterBrokerPriorityStatement of BrokerPriorityParameters:(BrokerPriorityParameter) list * Name:Identifier option
  | CreateBrokerPriorityStatement of BrokerPriorityParameters:(BrokerPriorityParameter) list * Name:Identifier option
  static member FromTs(src:ScriptDom.BrokerPriorityStatement) : BrokerPriorityStatement =
    match src with
    | :? ScriptDom.AlterBrokerPriorityStatement as src ->
      BrokerPriorityStatement.AlterBrokerPriorityStatement((src.BrokerPriorityParameters |> Seq.map (fun src -> BrokerPriorityParameter.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateBrokerPriorityStatement as src ->
      BrokerPriorityStatement.CreateBrokerPriorityStatement((src.BrokerPriorityParameters |> Seq.map (fun src -> BrokerPriorityParameter.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] BulkInsertBase = 
  | BulkInsertStatement of From:IdentifierOrValueExpression option * Options:(BulkInsertOption) list * To:SchemaObjectName option
  | InsertBulkStatement of ColumnDefinitions:(InsertBulkColumnDefinition) list * Options:(BulkInsertOption) list * To:SchemaObjectName option
  static member FromTs(src:ScriptDom.BulkInsertBase) : BulkInsertBase =
    match src with
    | :? ScriptDom.BulkInsertStatement as src ->
      BulkInsertBase.BulkInsertStatement((src.From |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq), (src.To |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.InsertBulkStatement as src ->
      BulkInsertBase.InsertBulkStatement((src.ColumnDefinitions |> Seq.map (fun src -> InsertBulkColumnDefinition.InsertBulkColumnDefinition((src.Column |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullNotNull) (* 196 *))) |> List.ofSeq), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq), (src.To |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] CertificateStatementBase = 
  | AlterCertificateStatement of ActiveForBeginDialog:ScriptDom.OptionState * AttestedBy:Literal option * DecryptionPassword:Literal option * EncryptionPassword:Literal option * Kind:ScriptDom.AlterCertificateStatementKind * Name:Identifier option * PrivateKeyPath:Literal option
  | BackupCertificateStatement of ActiveForBeginDialog:ScriptDom.OptionState * DecryptionPassword:Literal option * EncryptionPassword:Literal option * File:Literal option * Name:Identifier option * PrivateKeyPath:Literal option
  | CreateCertificateStatement of ActiveForBeginDialog:ScriptDom.OptionState * CertificateOptions:(CertificateOption) list * CertificateSource:EncryptionSource option * DecryptionPassword:Literal option * EncryptionPassword:Literal option * Name:Identifier option * Owner:Identifier option * PrivateKeyPath:Literal option
  static member FromTs(src:ScriptDom.CertificateStatementBase) : CertificateStatementBase =
    match src with
    | :? ScriptDom.AlterCertificateStatement as src ->
      CertificateStatementBase.AlterCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.AttestedBy |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Kind) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.BackupCertificateStatement as src ->
      CertificateStatementBase.BackupCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.File |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CreateCertificateStatement as src ->
      CertificateStatementBase.CreateCertificateStatement((src.ActiveForBeginDialog) (* 196 *), (src.CertificateOptions |> Seq.map (fun src -> CertificateOption.CertificateOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.CertificateSource |> Option.ofObj |> Option.map (EncryptionSource.FromTs)) (* 191 *), (src.DecryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.EncryptionPassword |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrivateKeyPath |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ColumnEncryptionKeyStatement = 
  | AlterColumnEncryptionKeyStatement of AlterType:ScriptDom.ColumnEncryptionKeyAlterType * ColumnEncryptionKeyValues:(ColumnEncryptionKeyValue) list * Name:Identifier option
  | CreateColumnEncryptionKeyStatement of ColumnEncryptionKeyValues:(ColumnEncryptionKeyValue) list * Name:Identifier option
  static member FromTs(src:ScriptDom.ColumnEncryptionKeyStatement) : ColumnEncryptionKeyStatement =
    match src with
    | :? ScriptDom.AlterColumnEncryptionKeyStatement as src ->
      ColumnEncryptionKeyStatement.AlterColumnEncryptionKeyStatement((src.AlterType) (* 196 *), (src.ColumnEncryptionKeyValues |> Seq.map (fun src -> ColumnEncryptionKeyValue.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateColumnEncryptionKeyStatement as src ->
      ColumnEncryptionKeyStatement.CreateColumnEncryptionKeyStatement((src.ColumnEncryptionKeyValues |> Seq.map (fun src -> ColumnEncryptionKeyValue.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] CreateTypeStatement = 
  | CreateTypeTableStatement of Definition:TableDefinition option * Name:SchemaObjectName option * Options:(TableOption) list
  | CreateTypeUddtStatement of DataType:DataTypeReference option * Name:SchemaObjectName option * NullableConstraint:NullableConstraintDefinition option
  | CreateTypeUdtStatement of AssemblyName:AssemblyName option * Name:SchemaObjectName option
  static member FromTs(src:ScriptDom.CreateTypeStatement) : CreateTypeStatement =
    match src with
    | :? ScriptDom.CreateTypeTableStatement as src ->
      CreateTypeStatement.CreateTypeTableStatement((src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TableOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateTypeUddtStatement as src ->
      CreateTypeStatement.CreateTypeUddtStatement((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))
    | :? ScriptDom.CreateTypeUdtStatement as src ->
      CreateTypeStatement.CreateTypeUdtStatement((src.AssemblyName |> Option.ofObj |> Option.map (AssemblyName.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] CredentialStatement = 
  | AlterCredentialStatement of Identity:Literal option * IsDatabaseScoped:bool * Name:Identifier option * Secret:Literal option
  | CreateCredentialStatement of CryptographicProviderName:Identifier option * Identity:Literal option * IsDatabaseScoped:bool * Name:Identifier option * Secret:Literal option
  static member FromTs(src:ScriptDom.CredentialStatement) : CredentialStatement =
    match src with
    | :? ScriptDom.AlterCredentialStatement as src ->
      CredentialStatement.AlterCredentialStatement((src.Identity |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsDatabaseScoped) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Secret |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CreateCredentialStatement as src ->
      CredentialStatement.CreateCredentialStatement((src.CryptographicProviderName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identity |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.IsDatabaseScoped) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Secret |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] CursorStatement = 
  | CloseCursorStatement of Cursor:CursorId option
  | DeallocateCursorStatement of Cursor:CursorId option
  | FetchCursorStatement of Cursor:CursorId option * FetchType:FetchType option * IntoVariables:(VariableReference) list
  | OpenCursorStatement of Cursor:CursorId option
  static member FromTs(src:ScriptDom.CursorStatement) : CursorStatement =
    match src with
    | :? ScriptDom.CloseCursorStatement as src ->
      CursorStatement.CloseCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))
    | :? ScriptDom.DeallocateCursorStatement as src ->
      CursorStatement.DeallocateCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))
    | :? ScriptDom.FetchCursorStatement as src ->
      CursorStatement.FetchCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *), (src.FetchType |> Option.ofObj |> Option.map (FetchType.FromTs)) (* 193 *), (src.IntoVariables |> Seq.map (fun src -> VariableReference.VariableReference((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))) |> List.ofSeq))
    | :? ScriptDom.OpenCursorStatement as src ->
      CursorStatement.OpenCursorStatement((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] DatabaseEncryptionKeyStatement = 
  | AlterDatabaseEncryptionKeyStatement of Algorithm:ScriptDom.DatabaseEncryptionKeyAlgorithm * Encryptor:CryptoMechanism option * Regenerate:bool
  | CreateDatabaseEncryptionKeyStatement of Algorithm:ScriptDom.DatabaseEncryptionKeyAlgorithm * Encryptor:CryptoMechanism option
  static member FromTs(src:ScriptDom.DatabaseEncryptionKeyStatement) : DatabaseEncryptionKeyStatement =
    match src with
    | :? ScriptDom.AlterDatabaseEncryptionKeyStatement as src ->
      DatabaseEncryptionKeyStatement.AlterDatabaseEncryptionKeyStatement((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *), (src.Regenerate) (* 196 *))
    | :? ScriptDom.CreateDatabaseEncryptionKeyStatement as src ->
      DatabaseEncryptionKeyStatement.CreateDatabaseEncryptionKeyStatement((src.Algorithm) (* 196 *), (src.Encryptor |> Option.ofObj |> Option.map (CryptoMechanism.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] DropChildObjectsStatement = 
  | DropStatisticsStatement of Objects:(ChildObjectName) list
  static member FromTs(src:ScriptDom.DropChildObjectsStatement) : DropChildObjectsStatement =
    match src with
    | :? ScriptDom.DropStatisticsStatement as src ->
      DropChildObjectsStatement.DropStatisticsStatement((src.Objects |> Seq.map (fun src -> ChildObjectName.ChildObjectName((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ChildIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] DropObjectsStatement = 
  | DropAggregateStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropAssemblyStatement of IsIfExists:bool * Objects:(SchemaObjectName) list * WithNoDependents:bool
  | DropDefaultStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropExternalTableStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropFunctionStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropProcedureStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropRuleStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropSecurityPolicyStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropSequenceStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropSynonymStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropTableStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  | DropTriggerStatement of IsIfExists:bool * Objects:(SchemaObjectName) list * TriggerScope:ScriptDom.TriggerScope
  | DropViewStatement of IsIfExists:bool * Objects:(SchemaObjectName) list
  static member FromTs(src:ScriptDom.DropObjectsStatement) : DropObjectsStatement =
    match src with
    | :? ScriptDom.DropAggregateStatement as src ->
      DropObjectsStatement.DropAggregateStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropAssemblyStatement as src ->
      DropObjectsStatement.DropAssemblyStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.WithNoDependents) (* 196 *))
    | :? ScriptDom.DropDefaultStatement as src ->
      DropObjectsStatement.DropDefaultStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropExternalTableStatement as src ->
      DropObjectsStatement.DropExternalTableStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropFunctionStatement as src ->
      DropObjectsStatement.DropFunctionStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropProcedureStatement as src ->
      DropObjectsStatement.DropProcedureStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropRuleStatement as src ->
      DropObjectsStatement.DropRuleStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropSecurityPolicyStatement as src ->
      DropObjectsStatement.DropSecurityPolicyStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropSequenceStatement as src ->
      DropObjectsStatement.DropSequenceStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropSynonymStatement as src ->
      DropObjectsStatement.DropSynonymStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropTableStatement as src ->
      DropObjectsStatement.DropTableStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
    | :? ScriptDom.DropTriggerStatement as src ->
      DropObjectsStatement.DropTriggerStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq), (src.TriggerScope) (* 196 *))
    | :? ScriptDom.DropViewStatement as src ->
      DropObjectsStatement.DropViewStatement((src.IsIfExists) (* 196 *), (src.Objects |> Seq.map (SchemaObjectName.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] DropUnownedObjectStatement = 
  | DropApplicationRoleStatement of IsIfExists:bool * Name:Identifier option
  | DropAsymmetricKeyStatement of IsIfExists:bool * Name:Identifier option * RemoveProviderKey:bool
  | DropAvailabilityGroupStatement of IsIfExists:bool * Name:Identifier option
  | DropBrokerPriorityStatement of IsIfExists:bool * Name:Identifier option
  | DropCertificateStatement of IsIfExists:bool * Name:Identifier option
  | DropColumnEncryptionKeyStatement of IsIfExists:bool * Name:Identifier option
  | DropColumnMasterKeyStatement of IsIfExists:bool * Name:Identifier option
  | DropContractStatement of IsIfExists:bool * Name:Identifier option
  | DropCredentialStatement of IsDatabaseScoped:bool * IsIfExists:bool * Name:Identifier option
  | DropCryptographicProviderStatement of IsIfExists:bool * Name:Identifier option
  | DropDatabaseAuditSpecificationStatement of IsIfExists:bool * Name:Identifier option
  | DropEndpointStatement of IsIfExists:bool * Name:Identifier option
  | DropEventSessionStatement of IsIfExists:bool * Name:Identifier option * SessionScope:ScriptDom.EventSessionScope
  | DropExternalDataSourceStatement of IsIfExists:bool * Name:Identifier option
  | DropExternalFileFormatStatement of IsIfExists:bool * Name:Identifier option
  | DropExternalResourcePoolStatement of IsIfExists:bool * Name:Identifier option
  | DropFederationStatement of IsIfExists:bool * Name:Identifier option
  | DropFullTextCatalogStatement of IsIfExists:bool * Name:Identifier option
  | DropFullTextStopListStatement of IsIfExists:bool * Name:Identifier option
  | DropLoginStatement of IsIfExists:bool * Name:Identifier option
  | DropMessageTypeStatement of IsIfExists:bool * Name:Identifier option
  | DropPartitionFunctionStatement of IsIfExists:bool * Name:Identifier option
  | DropPartitionSchemeStatement of IsIfExists:bool * Name:Identifier option
  | DropRemoteServiceBindingStatement of IsIfExists:bool * Name:Identifier option
  | DropResourcePoolStatement of IsIfExists:bool * Name:Identifier option
  | DropRoleStatement of IsIfExists:bool * Name:Identifier option
  | DropRouteStatement of IsIfExists:bool * Name:Identifier option
  | DropSearchPropertyListStatement of IsIfExists:bool * Name:Identifier option
  | DropServerAuditSpecificationStatement of IsIfExists:bool * Name:Identifier option
  | DropServerAuditStatement of IsIfExists:bool * Name:Identifier option
  | DropServerRoleStatement of IsIfExists:bool * Name:Identifier option
  | DropServiceStatement of IsIfExists:bool * Name:Identifier option
  | DropSymmetricKeyStatement of IsIfExists:bool * Name:Identifier option * RemoveProviderKey:bool
  | DropUserStatement of IsIfExists:bool * Name:Identifier option
  | DropWorkloadGroupStatement of IsIfExists:bool * Name:Identifier option
  static member FromTs(src:ScriptDom.DropUnownedObjectStatement) : DropUnownedObjectStatement =
    match src with
    | :? ScriptDom.DropApplicationRoleStatement as src ->
      DropUnownedObjectStatement.DropApplicationRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropAsymmetricKeyStatement as src ->
      DropUnownedObjectStatement.DropAsymmetricKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RemoveProviderKey) (* 196 *))
    | :? ScriptDom.DropAvailabilityGroupStatement as src ->
      DropUnownedObjectStatement.DropAvailabilityGroupStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropBrokerPriorityStatement as src ->
      DropUnownedObjectStatement.DropBrokerPriorityStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropCertificateStatement as src ->
      DropUnownedObjectStatement.DropCertificateStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropColumnEncryptionKeyStatement as src ->
      DropUnownedObjectStatement.DropColumnEncryptionKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropColumnMasterKeyStatement as src ->
      DropUnownedObjectStatement.DropColumnMasterKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropContractStatement as src ->
      DropUnownedObjectStatement.DropContractStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropCredentialStatement as src ->
      DropUnownedObjectStatement.DropCredentialStatement((src.IsDatabaseScoped) (* 196 *), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropCryptographicProviderStatement as src ->
      DropUnownedObjectStatement.DropCryptographicProviderStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropDatabaseAuditSpecificationStatement as src ->
      DropUnownedObjectStatement.DropDatabaseAuditSpecificationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropEndpointStatement as src ->
      DropUnownedObjectStatement.DropEndpointStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropEventSessionStatement as src ->
      DropUnownedObjectStatement.DropEventSessionStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionScope) (* 196 *))
    | :? ScriptDom.DropExternalDataSourceStatement as src ->
      DropUnownedObjectStatement.DropExternalDataSourceStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropExternalFileFormatStatement as src ->
      DropUnownedObjectStatement.DropExternalFileFormatStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropExternalResourcePoolStatement as src ->
      DropUnownedObjectStatement.DropExternalResourcePoolStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropFederationStatement as src ->
      DropUnownedObjectStatement.DropFederationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropFullTextCatalogStatement as src ->
      DropUnownedObjectStatement.DropFullTextCatalogStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropFullTextStopListStatement as src ->
      DropUnownedObjectStatement.DropFullTextStopListStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropLoginStatement as src ->
      DropUnownedObjectStatement.DropLoginStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropMessageTypeStatement as src ->
      DropUnownedObjectStatement.DropMessageTypeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropPartitionFunctionStatement as src ->
      DropUnownedObjectStatement.DropPartitionFunctionStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropPartitionSchemeStatement as src ->
      DropUnownedObjectStatement.DropPartitionSchemeStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropRemoteServiceBindingStatement as src ->
      DropUnownedObjectStatement.DropRemoteServiceBindingStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropResourcePoolStatement as src ->
      DropUnownedObjectStatement.DropResourcePoolStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropRoleStatement as src ->
      DropUnownedObjectStatement.DropRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropRouteStatement as src ->
      DropUnownedObjectStatement.DropRouteStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropSearchPropertyListStatement as src ->
      DropUnownedObjectStatement.DropSearchPropertyListStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropServerAuditSpecificationStatement as src ->
      DropUnownedObjectStatement.DropServerAuditSpecificationStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropServerAuditStatement as src ->
      DropUnownedObjectStatement.DropServerAuditStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropServerRoleStatement as src ->
      DropUnownedObjectStatement.DropServerRoleStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropServiceStatement as src ->
      DropUnownedObjectStatement.DropServiceStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropSymmetricKeyStatement as src ->
      DropUnownedObjectStatement.DropSymmetricKeyStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RemoveProviderKey) (* 196 *))
    | :? ScriptDom.DropUserStatement as src ->
      DropUnownedObjectStatement.DropUserStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.DropWorkloadGroupStatement as src ->
      DropUnownedObjectStatement.DropWorkloadGroupStatement((src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EventSessionStatement = 
  | Base of EventDeclarations:(EventDeclaration) list * Name:Identifier option * SessionOptions:(SessionOption) list * SessionScope:ScriptDom.EventSessionScope * TargetDeclarations:(TargetDeclaration) list
  | AlterEventSessionStatement of DropEventDeclarations:(EventSessionObjectName) list * DropTargetDeclarations:(EventSessionObjectName) list * EventDeclarations:(EventDeclaration) list * Name:Identifier option * SessionOptions:(SessionOption) list * SessionScope:ScriptDom.EventSessionScope * StatementType:ScriptDom.AlterEventSessionStatementType * TargetDeclarations:(TargetDeclaration) list
  | CreateEventSessionStatement of EventDeclarations:(EventDeclaration) list * Name:Identifier option * SessionOptions:(SessionOption) list * SessionScope:ScriptDom.EventSessionScope * TargetDeclarations:(TargetDeclaration) list
  static member FromTs(src:ScriptDom.EventSessionStatement) : EventSessionStatement =
    match src with
    | :? ScriptDom.AlterEventSessionStatement as src ->
      EventSessionStatement.AlterEventSessionStatement((src.DropEventDeclarations |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.DropTargetDeclarations |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.StatementType) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq))
    | :? ScriptDom.CreateEventSessionStatement as src ->
      EventSessionStatement.CreateEventSessionStatement((src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq))
    | _ -> (* :? ScriptDom.EventSessionStatement as src *)
      EventSessionStatement.Base((* 297 *)((src.EventDeclarations |> Seq.map (fun src -> EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SessionOptions |> Seq.map (SessionOption.FromTs) |> List.ofSeq), (src.SessionScope) (* 196 *), (src.TargetDeclarations |> Seq.map (fun src -> TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq)))
and [<RequireQualifiedAccess>] ExternalDataSourceStatement = 
  | AlterExternalDataSourceStatement of DataSourceType:ScriptDom.ExternalDataSourceType * ExternalDataSourceOptions:(ExternalDataSourceOption) list * Location:Literal option * Name:Identifier option
  | CreateExternalDataSourceStatement of DataSourceType:ScriptDom.ExternalDataSourceType * ExternalDataSourceOptions:(ExternalDataSourceOption) list * Location:Literal option * Name:Identifier option
  static member FromTs(src:ScriptDom.ExternalDataSourceStatement) : ExternalDataSourceStatement =
    match src with
    | :? ScriptDom.AlterExternalDataSourceStatement as src ->
      ExternalDataSourceStatement.AlterExternalDataSourceStatement((src.DataSourceType) (* 196 *), (src.ExternalDataSourceOptions |> Seq.map (ExternalDataSourceOption.FromTs) |> List.ofSeq), (src.Location |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateExternalDataSourceStatement as src ->
      ExternalDataSourceStatement.CreateExternalDataSourceStatement((src.DataSourceType) (* 196 *), (src.ExternalDataSourceOptions |> Seq.map (ExternalDataSourceOption.FromTs) |> List.ofSeq), (src.Location |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ExternalFileFormatStatement = 
  | CreateExternalFileFormatStatement of ExternalFileFormatOptions:(ExternalFileFormatOption) list * FormatType:ScriptDom.ExternalFileFormatType * Name:Identifier option
  static member FromTs(src:ScriptDom.ExternalFileFormatStatement) : ExternalFileFormatStatement =
    match src with
    | :? ScriptDom.CreateExternalFileFormatStatement as src ->
      ExternalFileFormatStatement.CreateExternalFileFormatStatement((src.ExternalFileFormatOptions |> Seq.map (ExternalFileFormatOption.FromTs) |> List.ofSeq), (src.FormatType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ExternalResourcePoolStatement = 
  | Base of ExternalResourcePoolParameters:(ExternalResourcePoolParameter) list * Name:Identifier option
  | AlterExternalResourcePoolStatement of ExternalResourcePoolParameters:(ExternalResourcePoolParameter) list * Name:Identifier option
  | CreateExternalResourcePoolStatement of ExternalResourcePoolParameters:(ExternalResourcePoolParameter) list * Name:Identifier option
  static member FromTs(src:ScriptDom.ExternalResourcePoolStatement) : ExternalResourcePoolStatement =
    match src with
    | :? ScriptDom.AlterExternalResourcePoolStatement as src ->
      ExternalResourcePoolStatement.AlterExternalResourcePoolStatement((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateExternalResourcePoolStatement as src ->
      ExternalResourcePoolStatement.CreateExternalResourcePoolStatement((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.ExternalResourcePoolStatement as src *)
      ExternalResourcePoolStatement.Base((* 297 *)((src.ExternalResourcePoolParameters |> Seq.map (fun src -> ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] ExternalTableStatement = 
  | CreateExternalTableStatement of ColumnDefinitions:(ExternalTableColumnDefinition) list * DataSource:Identifier option * ExternalTableOptions:(ExternalTableOption) list * SchemaObjectName:SchemaObjectName option
  static member FromTs(src:ScriptDom.ExternalTableStatement) : ExternalTableStatement =
    match src with
    | :? ScriptDom.CreateExternalTableStatement as src ->
      ExternalTableStatement.CreateExternalTableStatement((src.ColumnDefinitions |> Seq.map (fun src -> ExternalTableColumnDefinition.ExternalTableColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))) |> List.ofSeq), (src.DataSource |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ExternalTableOptions |> Seq.map (ExternalTableOption.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FullTextCatalogStatement = 
  | AlterFullTextCatalogStatement of Action:ScriptDom.AlterFullTextCatalogAction * Name:Identifier option * Options:(FullTextCatalogOption) list
  | CreateFullTextCatalogStatement of FileGroup:Identifier option * IsDefault:bool * Name:Identifier option * Options:(FullTextCatalogOption) list * Owner:Identifier option * Path:Literal option
  static member FromTs(src:ScriptDom.FullTextCatalogStatement) : FullTextCatalogStatement =
    match src with
    | :? ScriptDom.AlterFullTextCatalogStatement as src ->
      FullTextCatalogStatement.AlterFullTextCatalogStatement((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextCatalogOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateFullTextCatalogStatement as src ->
      FullTextCatalogStatement.CreateFullTextCatalogStatement((src.FileGroup |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (FullTextCatalogOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] IndexStatement = 
  | AlterIndexStatement of All:bool * AlterIndexType:ScriptDom.AlterIndexType * IndexOptions:(IndexOption) list * Name:Identifier option * OnName:SchemaObjectName option * Partition:PartitionSpecifier option * PromotedPaths:(SelectiveXmlIndexPromotedPath) list * XmlNamespaces:XmlNamespaces option
  | CreateIndexStatement of Clustered:(bool) option * Columns:(ColumnWithSortOrder) list * FileStreamOn:IdentifierOrValueExpression option * FilterPredicate:BooleanExpression option * IncludeColumns:(ColumnReferenceExpression) list * IndexOptions:(IndexOption) list * Name:Identifier option * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option * OnName:SchemaObjectName option * Translated80SyntaxTo90:bool * Unique:bool
  | CreateSelectiveXmlIndexStatement of IndexOptions:(IndexOption) list * IsSecondary:bool * Name:Identifier option * OnName:SchemaObjectName option * PathName:Identifier option * PromotedPaths:(SelectiveXmlIndexPromotedPath) list * UsingXmlIndexName:Identifier option * XmlColumn:Identifier option * XmlNamespaces:XmlNamespaces option
  | CreateXmlIndexStatement of IndexOptions:(IndexOption) list * Name:Identifier option * OnName:SchemaObjectName option * Primary:bool * SecondaryXmlIndexName:Identifier option * SecondaryXmlIndexType:ScriptDom.SecondaryXmlIndexType * XmlColumn:Identifier option
  static member FromTs(src:ScriptDom.IndexStatement) : IndexStatement =
    match src with
    | :? ScriptDom.AlterIndexStatement as src ->
      IndexStatement.AlterIndexStatement((src.All) (* 196 *), (src.AlterIndexType) (* 196 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Partition |> Option.ofObj |> Option.map (PartitionSpecifier.FromTs)) (* 193 *), (src.PromotedPaths |> Seq.map (fun src -> SelectiveXmlIndexPromotedPath.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.CreateIndexStatement as src ->
      IndexStatement.CreateIndexStatement((Option.ofNullable (src.Clustered)), (src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IncludeColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Translated80SyntaxTo90) (* 196 *), (src.Unique) (* 196 *))
    | :? ScriptDom.CreateSelectiveXmlIndexStatement as src ->
      IndexStatement.CreateSelectiveXmlIndexStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IsSecondary) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.PathName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PromotedPaths |> Seq.map (fun src -> SelectiveXmlIndexPromotedPath.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.UsingXmlIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.XmlColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.CreateXmlIndexStatement as src ->
      IndexStatement.CreateXmlIndexStatement((src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Primary) (* 196 *), (src.SecondaryXmlIndexName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecondaryXmlIndexType) (* 196 *), (src.XmlColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] MasterKeyStatement = 
  | AlterMasterKeyStatement of Option:ScriptDom.AlterMasterKeyOption * Password:Literal option
  | CreateMasterKeyStatement of Password:Literal option
  static member FromTs(src:ScriptDom.MasterKeyStatement) : MasterKeyStatement =
    match src with
    | :? ScriptDom.AlterMasterKeyStatement as src ->
      MasterKeyStatement.AlterMasterKeyStatement((src.Option) (* 196 *), (src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
    | :? ScriptDom.CreateMasterKeyStatement as src ->
      MasterKeyStatement.CreateMasterKeyStatement((src.Password |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] MessageTypeStatementBase = 
  | AlterMessageTypeStatement of Name:Identifier option * ValidationMethod:ScriptDom.MessageValidationMethod * XmlSchemaCollectionName:SchemaObjectName option
  | CreateMessageTypeStatement of Name:Identifier option * Owner:Identifier option * ValidationMethod:ScriptDom.MessageValidationMethod * XmlSchemaCollectionName:SchemaObjectName option
  static member FromTs(src:ScriptDom.MessageTypeStatementBase) : MessageTypeStatementBase =
    match src with
    | :? ScriptDom.AlterMessageTypeStatement as src ->
      MessageTypeStatementBase.AlterMessageTypeStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ValidationMethod) (* 196 *), (src.XmlSchemaCollectionName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.CreateMessageTypeStatement as src ->
      MessageTypeStatementBase.CreateMessageTypeStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ValidationMethod) (* 196 *), (src.XmlSchemaCollectionName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ProcedureStatementBodyBase = 
  | FunctionStatementBody of FunctionStatementBody
  | ProcedureStatementBody of ProcedureStatementBody
  static member FromTs(src:ScriptDom.ProcedureStatementBodyBase) : ProcedureStatementBodyBase =
    match src with
    | :? ScriptDom.FunctionStatementBody as src ->
      match src with
      | :? ScriptDom.AlterFunctionStatement as src-> (* 274 *)
        ProcedureStatementBodyBase.FunctionStatementBody((FunctionStatementBody.AlterFunctionStatement((src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FunctionOption.FromTs) |> List.ofSeq), (src.OrderHint |> Option.ofObj |> Option.map (OrderBulkInsertOption.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (FunctionReturnType.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateFunctionStatement as src-> (* 274 *)
        ProcedureStatementBodyBase.FunctionStatementBody((FunctionStatementBody.CreateFunctionStatement((src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FunctionOption.FromTs) |> List.ofSeq), (src.OrderHint |> Option.ofObj |> Option.map (OrderBulkInsertOption.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (FunctionReturnType.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
    | :? ScriptDom.ProcedureStatementBody as src ->
      match src with
      | :? ScriptDom.AlterProcedureStatement as src-> (* 274 *)
        ProcedureStatementBodyBase.ProcedureStatementBody((ProcedureStatementBody.AlterProcedureStatement((src.IsForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Options |> Seq.map (ProcedureOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
      | :? ScriptDom.CreateProcedureStatement as src-> (* 274 *)
        ProcedureStatementBodyBase.ProcedureStatementBody((ProcedureStatementBody.CreateProcedureStatement((src.IsForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Options |> Seq.map (ProcedureOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))))
and [<RequireQualifiedAccess>] QueueStatement = 
  | AlterQueueStatement of Name:SchemaObjectName option * QueueOptions:(QueueOption) list
  | CreateQueueStatement of Name:SchemaObjectName option * OnFileGroup:IdentifierOrValueExpression option * QueueOptions:(QueueOption) list
  static member FromTs(src:ScriptDom.QueueStatement) : QueueStatement =
    match src with
    | :? ScriptDom.AlterQueueStatement as src ->
      QueueStatement.AlterQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.QueueOptions |> Seq.map (QueueOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateQueueStatement as src ->
      QueueStatement.CreateQueueStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OnFileGroup |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.QueueOptions |> Seq.map (QueueOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] RemoteServiceBindingStatementBase = 
  | AlterRemoteServiceBindingStatement of Name:Identifier option * Options:(RemoteServiceBindingOption) list
  | CreateRemoteServiceBindingStatement of Name:Identifier option * Options:(RemoteServiceBindingOption) list * Owner:Identifier option * Service:Literal option
  static member FromTs(src:ScriptDom.RemoteServiceBindingStatementBase) : RemoteServiceBindingStatementBase =
    match src with
    | :? ScriptDom.AlterRemoteServiceBindingStatement as src ->
      RemoteServiceBindingStatementBase.AlterRemoteServiceBindingStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (RemoteServiceBindingOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateRemoteServiceBindingStatement as src ->
      RemoteServiceBindingStatementBase.CreateRemoteServiceBindingStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (RemoteServiceBindingOption.FromTs) |> List.ofSeq), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Service |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ResourcePoolStatement = 
  | Base of Name:Identifier option * ResourcePoolParameters:(ResourcePoolParameter) list
  | AlterResourcePoolStatement of Name:Identifier option * ResourcePoolParameters:(ResourcePoolParameter) list
  | CreateResourcePoolStatement of Name:Identifier option * ResourcePoolParameters:(ResourcePoolParameter) list
  static member FromTs(src:ScriptDom.ResourcePoolStatement) : ResourcePoolStatement =
    match src with
    | :? ScriptDom.AlterResourcePoolStatement as src ->
      ResourcePoolStatement.AlterResourcePoolStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.CreateResourcePoolStatement as src ->
      ResourcePoolStatement.CreateResourcePoolStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq))
    | _ -> (* :? ScriptDom.ResourcePoolStatement as src *)
      ResourcePoolStatement.Base((* 297 *)((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ResourcePoolParameters |> Seq.map (fun src -> ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq)))
and [<RequireQualifiedAccess>] RoleStatement = 
  | AlterRoleStatement of AlterRoleStatement
  | CreateRoleStatement of CreateRoleStatement
  static member FromTs(src:ScriptDom.RoleStatement) : RoleStatement =
    match src with
    | :? ScriptDom.AlterRoleStatement as src ->
      match src with
      | :? ScriptDom.AlterServerRoleStatement as src-> (* 274 *)
        RoleStatement.AlterRoleStatement((AlterRoleStatement.AlterServerRoleStatement((src.Action |> Option.ofObj |> Option.map (AlterRoleAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.AlterRoleStatement as src *)
        RoleStatement.AlterRoleStatement((AlterRoleStatement.Base((src.Action |> Option.ofObj |> Option.map (AlterRoleAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
    | :? ScriptDom.CreateRoleStatement as src ->
      match src with
      | :? ScriptDom.CreateServerRoleStatement as src-> (* 274 *)
        RoleStatement.CreateRoleStatement((CreateRoleStatement.CreateServerRoleStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
      | _ -> (* :? ScriptDom.CreateRoleStatement as src *)
        RoleStatement.CreateRoleStatement((CreateRoleStatement.Base((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))))
and [<RequireQualifiedAccess>] RouteStatement = 
  | AlterRouteStatement of Name:Identifier option * RouteOptions:(RouteOption) list
  | CreateRouteStatement of Name:Identifier option * Owner:Identifier option * RouteOptions:(RouteOption) list
  static member FromTs(src:ScriptDom.RouteStatement) : RouteStatement =
    match src with
    | :? ScriptDom.AlterRouteStatement as src ->
      RouteStatement.AlterRouteStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RouteOptions |> Seq.map (fun src -> RouteOption.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))) |> List.ofSeq))
    | :? ScriptDom.CreateRouteStatement as src ->
      RouteStatement.CreateRouteStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RouteOptions |> Seq.map (fun src -> RouteOption.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] SecurityPolicyStatement = 
  | AlterSecurityPolicyStatement of ActionType:ScriptDom.SecurityPolicyActionType * Name:SchemaObjectName option * NotForReplication:bool * SecurityPolicyOptions:(SecurityPolicyOption) list * SecurityPredicateActions:(SecurityPredicateAction) list
  | CreateSecurityPolicyStatement of ActionType:ScriptDom.SecurityPolicyActionType * Name:SchemaObjectName option * NotForReplication:bool * SecurityPolicyOptions:(SecurityPolicyOption) list * SecurityPredicateActions:(SecurityPredicateAction) list
  static member FromTs(src:ScriptDom.SecurityPolicyStatement) : SecurityPolicyStatement =
    match src with
    | :? ScriptDom.AlterSecurityPolicyStatement as src ->
      SecurityPolicyStatement.AlterSecurityPolicyStatement((src.ActionType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *), (src.SecurityPolicyOptions |> Seq.map (fun src -> SecurityPolicyOption.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))) |> List.ofSeq), (src.SecurityPredicateActions |> Seq.map (fun src -> SecurityPredicateAction.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.CreateSecurityPolicyStatement as src ->
      SecurityPolicyStatement.CreateSecurityPolicyStatement((src.ActionType) (* 196 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.NotForReplication) (* 196 *), (src.SecurityPolicyOptions |> Seq.map (fun src -> SecurityPolicyOption.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))) |> List.ofSeq), (src.SecurityPredicateActions |> Seq.map (fun src -> SecurityPredicateAction.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] SecurityStatement = 
  | DenyStatement of AsClause:Identifier option * CascadeOption:bool * Permissions:(Permission) list * Principals:(SecurityPrincipal) list * SecurityTargetObject:SecurityTargetObject option
  | GrantStatement of AsClause:Identifier option * Permissions:(Permission) list * Principals:(SecurityPrincipal) list * SecurityTargetObject:SecurityTargetObject option * WithGrantOption:bool
  | RevokeStatement of AsClause:Identifier option * CascadeOption:bool * GrantOptionFor:bool * Permissions:(Permission) list * Principals:(SecurityPrincipal) list * SecurityTargetObject:SecurityTargetObject option
  static member FromTs(src:ScriptDom.SecurityStatement) : SecurityStatement =
    match src with
    | :? ScriptDom.DenyStatement as src ->
      SecurityStatement.DenyStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))
    | :? ScriptDom.GrantStatement as src ->
      SecurityStatement.GrantStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *), (src.WithGrantOption) (* 196 *))
    | :? ScriptDom.RevokeStatement as src ->
      SecurityStatement.RevokeStatement((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.GrantOptionFor) (* 196 *), (src.Permissions |> Seq.map (fun src -> Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.Principals |> Seq.map (fun src -> SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))) |> List.ofSeq), (src.SecurityTargetObject |> Option.ofObj |> Option.map (SecurityTargetObject.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SecurityStatementBody80 = 
  | DenyStatement80 of CascadeOption:bool * SecurityElement80:SecurityElement80 option * SecurityUserClause80:SecurityUserClause80 option
  | GrantStatement80 of AsClause:Identifier option * SecurityElement80:SecurityElement80 option * SecurityUserClause80:SecurityUserClause80 option * WithGrantOption:bool
  | RevokeStatement80 of AsClause:Identifier option * CascadeOption:bool * GrantOptionFor:bool * SecurityElement80:SecurityElement80 option * SecurityUserClause80:SecurityUserClause80 option
  static member FromTs(src:ScriptDom.SecurityStatementBody80) : SecurityStatementBody80 =
    match src with
    | :? ScriptDom.DenyStatement80 as src ->
      SecurityStatementBody80.DenyStatement80((src.CascadeOption) (* 196 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *))
    | :? ScriptDom.GrantStatement80 as src ->
      SecurityStatementBody80.GrantStatement80((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *), (src.WithGrantOption) (* 196 *))
    | :? ScriptDom.RevokeStatement80 as src ->
      SecurityStatementBody80.RevokeStatement80((src.AsClause |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.CascadeOption) (* 196 *), (src.GrantOptionFor) (* 196 *), (src.SecurityElement80 |> Option.ofObj |> Option.map (SecurityElement80.FromTs)) (* 191 *), (src.SecurityUserClause80 |> Option.ofObj |> Option.map (SecurityUserClause80.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SequenceStatement = 
  | AlterSequenceStatement of Name:SchemaObjectName option * SequenceOptions:(SequenceOption) list
  | CreateSequenceStatement of Name:SchemaObjectName option * SequenceOptions:(SequenceOption) list
  static member FromTs(src:ScriptDom.SequenceStatement) : SequenceStatement =
    match src with
    | :? ScriptDom.AlterSequenceStatement as src ->
      SequenceStatement.AlterSequenceStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SequenceOptions |> Seq.map (SequenceOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateSequenceStatement as src ->
      SequenceStatement.CreateSequenceStatement((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SequenceOptions |> Seq.map (SequenceOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ServerAuditStatement = 
  | AlterServerAuditStatement of AuditName:Identifier option * AuditTarget:AuditTarget option * NewName:Identifier option * Options:(AuditOption) list * PredicateExpression:BooleanExpression option * RemoveWhere:bool
  | CreateServerAuditStatement of AuditName:Identifier option * AuditTarget:AuditTarget option * Options:(AuditOption) list * PredicateExpression:BooleanExpression option
  static member FromTs(src:ScriptDom.ServerAuditStatement) : ServerAuditStatement =
    match src with
    | :? ScriptDom.AlterServerAuditStatement as src ->
      ServerAuditStatement.AlterServerAuditStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditTarget |> Option.ofObj |> Option.map (AuditTarget.FromTs)) (* 193 *), (src.NewName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Options |> Seq.map (AuditOption.FromTs) |> List.ofSeq), (src.PredicateExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.RemoveWhere) (* 196 *))
    | :? ScriptDom.CreateServerAuditStatement as src ->
      ServerAuditStatement.CreateServerAuditStatement((src.AuditName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.AuditTarget |> Option.ofObj |> Option.map (AuditTarget.FromTs)) (* 193 *), (src.Options |> Seq.map (AuditOption.FromTs) |> List.ofSeq), (src.PredicateExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SetOnOffStatement = 
  | PredicateSetStatement of IsOn:bool * Options:ScriptDom.SetOptions
  | SetIdentityInsertStatement of IsOn:bool * Table:SchemaObjectName option
  | SetOffsetsStatement of IsOn:bool * Options:ScriptDom.SetOffsets
  | SetStatisticsStatement of IsOn:bool * Options:ScriptDom.SetStatisticsOptions
  static member FromTs(src:ScriptDom.SetOnOffStatement) : SetOnOffStatement =
    match src with
    | :? ScriptDom.PredicateSetStatement as src ->
      SetOnOffStatement.PredicateSetStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))
    | :? ScriptDom.SetIdentityInsertStatement as src ->
      SetOnOffStatement.SetIdentityInsertStatement((src.IsOn) (* 196 *), (src.Table |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.SetOffsetsStatement as src ->
      SetOnOffStatement.SetOffsetsStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))
    | :? ScriptDom.SetStatisticsStatement as src ->
      SetOnOffStatement.SetStatisticsStatement((src.IsOn) (* 196 *), (src.Options) (* 196 *))
and [<RequireQualifiedAccess>] SignatureStatementBase = 
  | AddSignatureStatement of Cryptos:(CryptoMechanism) list * Element:SchemaObjectName option * ElementKind:ScriptDom.SignableElementKind * IsCounter:bool
  | DropSignatureStatement of Cryptos:(CryptoMechanism) list * Element:SchemaObjectName option * ElementKind:ScriptDom.SignableElementKind * IsCounter:bool
  static member FromTs(src:ScriptDom.SignatureStatementBase) : SignatureStatementBase =
    match src with
    | :? ScriptDom.AddSignatureStatement as src ->
      SignatureStatementBase.AddSignatureStatement((src.Cryptos |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Element |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ElementKind) (* 196 *), (src.IsCounter) (* 196 *))
    | :? ScriptDom.DropSignatureStatement as src ->
      SignatureStatementBase.DropSignatureStatement((src.Cryptos |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.Element |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ElementKind) (* 196 *), (src.IsCounter) (* 196 *))
and [<RequireQualifiedAccess>] StatementWithCtesAndXmlNamespaces = 
  | DataModificationStatement of DataModificationStatement
  | SelectStatement of SelectStatement
  static member FromTs(src:ScriptDom.StatementWithCtesAndXmlNamespaces) : StatementWithCtesAndXmlNamespaces =
    match src with
    | :? ScriptDom.DataModificationStatement as src ->
      match src with
      | :? ScriptDom.DeleteStatement as src-> (* 274 *)
        StatementWithCtesAndXmlNamespaces.DataModificationStatement((DataModificationStatement.DeleteStatement((src.DeleteSpecification |> Option.ofObj |> Option.map (DeleteSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
      | :? ScriptDom.InsertStatement as src-> (* 274 *)
        StatementWithCtesAndXmlNamespaces.DataModificationStatement((DataModificationStatement.InsertStatement((src.InsertSpecification |> Option.ofObj |> Option.map (InsertSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
      | :? ScriptDom.MergeStatement as src-> (* 274 *)
        StatementWithCtesAndXmlNamespaces.DataModificationStatement((DataModificationStatement.MergeStatement((src.MergeSpecification |> Option.ofObj |> Option.map (MergeSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
      | :? ScriptDom.UpdateStatement as src-> (* 274 *)
        StatementWithCtesAndXmlNamespaces.DataModificationStatement((DataModificationStatement.UpdateStatement((src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.UpdateSpecification |> Option.ofObj |> Option.map (UpdateSpecification.FromTs)) (* 193 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
    | :? ScriptDom.SelectStatement as src ->
      match src with
      | :? ScriptDom.SelectStatementSnippet as src-> (* 274 *)
        StatementWithCtesAndXmlNamespaces.SelectStatement((SelectStatement.SelectStatementSnippet((src.ComputeClauses |> Seq.map (fun src -> ComputeClause.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Into |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (Option.ofObj (src.Script)) (* 198 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
      | _ -> (* :? ScriptDom.SelectStatement as src *)
        StatementWithCtesAndXmlNamespaces.SelectStatement((SelectStatement.Base((src.ComputeClauses |> Seq.map (fun src -> ComputeClause.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Into |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))))
and [<RequireQualifiedAccess>] SymmetricKeyStatement = 
  | AlterSymmetricKeyStatement of EncryptingMechanisms:(CryptoMechanism) list * IsAdd:bool * Name:Identifier option
  | CreateSymmetricKeyStatement of EncryptingMechanisms:(CryptoMechanism) list * KeyOptions:(KeyOption) list * Name:Identifier option * Owner:Identifier option * Provider:Identifier option
  static member FromTs(src:ScriptDom.SymmetricKeyStatement) : SymmetricKeyStatement =
    match src with
    | :? ScriptDom.AlterSymmetricKeyStatement as src ->
      SymmetricKeyStatement.AlterSymmetricKeyStatement((src.EncryptingMechanisms |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.IsAdd) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.CreateSymmetricKeyStatement as src ->
      SymmetricKeyStatement.CreateSymmetricKeyStatement((src.EncryptingMechanisms |> Seq.map (fun src -> CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))) |> List.ofSeq), (src.KeyOptions |> Seq.map (KeyOption.FromTs) |> List.ofSeq), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Provider |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] TextModificationStatement = 
  | UpdateTextStatement of Bulk:bool * Column:ColumnReferenceExpression option * DeleteLength:ScalarExpression option * InsertOffset:ScalarExpression option * SourceColumn:ColumnReferenceExpression option * SourceParameter:ValueExpression option * TextId:ValueExpression option * Timestamp:Literal option * WithLog:bool
  | WriteTextStatement of Bulk:bool * Column:ColumnReferenceExpression option * SourceParameter:ValueExpression option * TextId:ValueExpression option * Timestamp:Literal option * WithLog:bool
  static member FromTs(src:ScriptDom.TextModificationStatement) : TextModificationStatement =
    match src with
    | :? ScriptDom.UpdateTextStatement as src ->
      TextModificationStatement.UpdateTextStatement((src.Bulk) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.DeleteLength |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.InsertOffset |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SourceColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SourceParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextId |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Timestamp |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.WithLog) (* 196 *))
    | :? ScriptDom.WriteTextStatement as src ->
      TextModificationStatement.WriteTextStatement((src.Bulk) (* 196 *), (src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SourceParameter |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TextId |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Timestamp |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.WithLog) (* 196 *))
and [<RequireQualifiedAccess>] TransactionStatement = 
  | BeginTransactionStatement of Distributed:bool * MarkDefined:bool * MarkDescription:ValueExpression option * Name:IdentifierOrValueExpression option
  | CommitTransactionStatement of DelayedDurabilityOption:ScriptDom.OptionState * Name:IdentifierOrValueExpression option
  | RollbackTransactionStatement of Name:IdentifierOrValueExpression option
  | SaveTransactionStatement of Name:IdentifierOrValueExpression option
  static member FromTs(src:ScriptDom.TransactionStatement) : TransactionStatement =
    match src with
    | :? ScriptDom.BeginTransactionStatement as src ->
      TransactionStatement.BeginTransactionStatement((src.Distributed) (* 196 *), (src.MarkDefined) (* 196 *), (src.MarkDescription |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.CommitTransactionStatement as src ->
      TransactionStatement.CommitTransactionStatement((src.DelayedDurabilityOption) (* 196 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.RollbackTransactionStatement as src ->
      TransactionStatement.RollbackTransactionStatement((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.SaveTransactionStatement as src ->
      TransactionStatement.SaveTransactionStatement((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] TriggerStatementBody = 
  | AlterTriggerStatement of IsNotForReplication:bool * MethodSpecifier:MethodSpecifier option * Name:SchemaObjectName option * Options:(TriggerOption) list * StatementList:StatementList option * TriggerActions:(TriggerAction) list * TriggerObject:TriggerObject option * TriggerType:ScriptDom.TriggerType * WithAppend:bool
  | CreateTriggerStatement of IsNotForReplication:bool * MethodSpecifier:MethodSpecifier option * Name:SchemaObjectName option * Options:(TriggerOption) list * StatementList:StatementList option * TriggerActions:(TriggerAction) list * TriggerObject:TriggerObject option * TriggerType:ScriptDom.TriggerType * WithAppend:bool
  static member FromTs(src:ScriptDom.TriggerStatementBody) : TriggerStatementBody =
    match src with
    | :? ScriptDom.AlterTriggerStatement as src ->
      TriggerStatementBody.AlterTriggerStatement((src.IsNotForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TriggerOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TriggerActions |> Seq.map (fun src -> TriggerAction.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *), (src.TriggerType) (* 196 *), (src.WithAppend) (* 196 *))
    | :? ScriptDom.CreateTriggerStatement as src ->
      TriggerStatementBody.CreateTriggerStatement((src.IsNotForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (TriggerOption.FromTs) |> List.ofSeq), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *), (src.TriggerActions |> Seq.map (fun src -> TriggerAction.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))) |> List.ofSeq), (src.TriggerObject |> Option.ofObj |> Option.map (TriggerObject.FromTs)) (* 193 *), (src.TriggerType) (* 196 *), (src.WithAppend) (* 196 *))
and [<RequireQualifiedAccess>] UserStatement = 
  | AlterUserStatement of Name:Identifier option * UserOptions:(PrincipalOption) list
  | CreateUserStatement of Name:Identifier option * UserLoginOption:UserLoginOption option * UserOptions:(PrincipalOption) list
  static member FromTs(src:ScriptDom.UserStatement) : UserStatement =
    match src with
    | :? ScriptDom.AlterUserStatement as src ->
      UserStatement.AlterUserStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserOptions |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateUserStatement as src ->
      UserStatement.CreateUserStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserLoginOption |> Option.ofObj |> Option.map (UserLoginOption.FromTs)) (* 193 *), (src.UserOptions |> Seq.map (PrincipalOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ViewStatementBody = 
  | AlterViewStatement of Columns:(Identifier) list * SchemaObjectName:SchemaObjectName option * SelectStatement:SelectStatement option * ViewOptions:(ViewOption) list * WithCheckOption:bool
  | CreateViewStatement of Columns:(Identifier) list * SchemaObjectName:SchemaObjectName option * SelectStatement:SelectStatement option * ViewOptions:(ViewOption) list * WithCheckOption:bool
  static member FromTs(src:ScriptDom.ViewStatementBody) : ViewStatementBody =
    match src with
    | :? ScriptDom.AlterViewStatement as src ->
      ViewStatementBody.AlterViewStatement((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *), (src.ViewOptions |> Seq.map (fun src -> ViewOption.ViewOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.WithCheckOption) (* 196 *))
    | :? ScriptDom.CreateViewStatement as src ->
      ViewStatementBody.CreateViewStatement((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectStatement |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *), (src.ViewOptions |> Seq.map (fun src -> ViewOption.ViewOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.WithCheckOption) (* 196 *))
and [<RequireQualifiedAccess>] WaitForSupportedStatement = 
  | GetConversationGroupStatement of GroupId:VariableReference option * Queue:SchemaObjectName option
  | ReceiveStatement of Into:VariableTableReference option * IsConversationGroupIdWhere:bool * Queue:SchemaObjectName option * SelectElements:(SelectElement) list * Top:ScalarExpression option * Where:ValueExpression option
  static member FromTs(src:ScriptDom.WaitForSupportedStatement) : WaitForSupportedStatement =
    match src with
    | :? ScriptDom.GetConversationGroupStatement as src ->
      WaitForSupportedStatement.GetConversationGroupStatement((src.GroupId |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *), (src.Queue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.ReceiveStatement as src ->
      WaitForSupportedStatement.ReceiveStatement((src.Into |> Option.ofObj |> Option.map (VariableTableReference.FromTs)) (* 193 *), (src.IsConversationGroupIdWhere) (* 196 *), (src.Queue |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.SelectElements |> Seq.map (SelectElement.FromTs) |> List.ofSeq), (src.Top |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Where |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] WorkloadGroupStatement = 
  | AlterWorkloadGroupStatement of ExternalPoolName:Identifier option * Name:Identifier option * PoolName:Identifier option * WorkloadGroupParameters:(WorkloadGroupParameter) list
  | CreateWorkloadGroupStatement of ExternalPoolName:Identifier option * Name:Identifier option * PoolName:Identifier option * WorkloadGroupParameters:(WorkloadGroupParameter) list
  static member FromTs(src:ScriptDom.WorkloadGroupStatement) : WorkloadGroupStatement =
    match src with
    | :? ScriptDom.AlterWorkloadGroupStatement as src ->
      WorkloadGroupStatement.AlterWorkloadGroupStatement((src.ExternalPoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.WorkloadGroupParameters |> Seq.map (WorkloadGroupParameter.FromTs) |> List.ofSeq))
    | :? ScriptDom.CreateWorkloadGroupStatement as src ->
      WorkloadGroupStatement.CreateWorkloadGroupStatement((src.ExternalPoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PoolName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.WorkloadGroupParameters |> Seq.map (WorkloadGroupParameter.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] JoinTableReference = 
  | QualifiedJoin of FirstTableReference:TableReference option * JoinHint:ScriptDom.JoinHint * QualifiedJoinType:ScriptDom.QualifiedJoinType * SearchCondition:BooleanExpression option * SecondTableReference:TableReference option
  | UnqualifiedJoin of FirstTableReference:TableReference option * SecondTableReference:TableReference option * UnqualifiedJoinType:ScriptDom.UnqualifiedJoinType
  static member FromTs(src:ScriptDom.JoinTableReference) : JoinTableReference =
    match src with
    | :? ScriptDom.QualifiedJoin as src ->
      JoinTableReference.QualifiedJoin((src.FirstTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.JoinHint) (* 196 *), (src.QualifiedJoinType) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.SecondTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *))
    | :? ScriptDom.UnqualifiedJoin as src ->
      JoinTableReference.UnqualifiedJoin((src.FirstTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.SecondTableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.UnqualifiedJoinType) (* 196 *))
and [<RequireQualifiedAccess>] TableReferenceWithAlias = 
  | AdHocTableReference of Alias:Identifier option * DataSource:AdHocDataSource option * Object:SchemaObjectNameOrValueExpression option
  | BuiltInFunctionTableReference of Alias:Identifier option * Name:Identifier option * Parameters:(ScalarExpression) list
  | FullTextTableReference of Alias:Identifier option * Columns:(ColumnReferenceExpression) list * FullTextFunctionType:ScriptDom.FullTextFunctionType * Language:ValueExpression option * PropertyName:StringLiteral option * SearchCondition:ValueExpression option * TableName:SchemaObjectName option * TopN:ValueExpression option
  | InternalOpenRowset of Alias:Identifier option * Identifier:Identifier option * VarArgs:(ScalarExpression) list
  | NamedTableReference of Alias:Identifier option * SchemaObject:SchemaObjectName option * TableHints:(TableHint) list * TableSampleClause:TableSampleClause option * TemporalClause:TemporalClause option
  | OpenJsonTableReference of Alias:Identifier option * RowPattern:StringLiteral option * SchemaDeclarationItems:(SchemaDeclarationItemOpenjson) list * Variable:ValueExpression option
  | OpenQueryTableReference of Alias:Identifier option * LinkedServer:Identifier option * Query:StringLiteral option
  | OpenRowsetTableReference of Alias:Identifier option * DataSource:StringLiteral option * Object:SchemaObjectName option * Password:StringLiteral option * ProviderName:StringLiteral option * ProviderString:StringLiteral option * Query:StringLiteral option * UserId:StringLiteral option
  | OpenXmlTableReference of Alias:Identifier option * Flags:ValueExpression option * RowPattern:ValueExpression option * SchemaDeclarationItems:(SchemaDeclarationItem) list * TableName:SchemaObjectName option * Variable:VariableReference option
  | PivotedTableReference of AggregateFunctionIdentifier:MultiPartIdentifier option * Alias:Identifier option * InColumns:(Identifier) list * PivotColumn:ColumnReferenceExpression option * TableReference:TableReference option * ValueColumns:(ColumnReferenceExpression) list
  | SemanticTableReference of Alias:Identifier option * Columns:(ColumnReferenceExpression) list * MatchedColumn:ColumnReferenceExpression option * MatchedKey:ScalarExpression option * SemanticFunctionType:ScriptDom.SemanticFunctionType * SourceKey:ScalarExpression option * TableName:SchemaObjectName option
  | TableReferenceWithAliasAndColumns of TableReferenceWithAliasAndColumns
  | UnpivotedTableReference of Alias:Identifier option * InColumns:(ColumnReferenceExpression) list * PivotColumn:Identifier option * TableReference:TableReference option * ValueColumn:Identifier option
  | VariableTableReference of Alias:Identifier option * Variable:VariableReference option
  static member FromTs(src:ScriptDom.TableReferenceWithAlias) : TableReferenceWithAlias =
    match src with
    | :? ScriptDom.AdHocTableReference as src ->
      TableReferenceWithAlias.AdHocTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataSource |> Option.ofObj |> Option.map (AdHocDataSource.FromTs)) (* 193 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectNameOrValueExpression.FromTs)) (* 193 *))
    | :? ScriptDom.BuiltInFunctionTableReference as src ->
      TableReferenceWithAlias.BuiltInFunctionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.FullTextTableReference as src ->
      TableReferenceWithAlias.FullTextTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.FullTextFunctionType) (* 196 *), (src.Language |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.PropertyName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TopN |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.InternalOpenRowset as src ->
      TableReferenceWithAlias.InternalOpenRowset((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.VarArgs |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
    | :? ScriptDom.NamedTableReference as src ->
      TableReferenceWithAlias.NamedTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SchemaObject |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TableHints |> Seq.map (TableHint.FromTs) |> List.ofSeq), (src.TableSampleClause |> Option.ofObj |> Option.map (TableSampleClause.FromTs)) (* 193 *), (src.TemporalClause |> Option.ofObj |> Option.map (TemporalClause.FromTs)) (* 193 *))
    | :? ScriptDom.OpenJsonTableReference as src ->
      TableReferenceWithAlias.OpenJsonTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.RowPattern |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.SchemaDeclarationItems |> Seq.map (fun src -> SchemaDeclarationItemOpenjson.SchemaDeclarationItemOpenjson((src.AsJson) (* 196 *), (src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.Variable |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
    | :? ScriptDom.OpenQueryTableReference as src ->
      TableReferenceWithAlias.OpenQueryTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LinkedServer |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Query |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.OpenRowsetTableReference as src ->
      TableReferenceWithAlias.OpenRowsetTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataSource |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Object |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Password |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderString |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Query |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.UserId |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
    | :? ScriptDom.OpenXmlTableReference as src ->
      TableReferenceWithAlias.OpenXmlTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Flags |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.RowPattern |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.SchemaDeclarationItems |> Seq.map (SchemaDeclarationItem.FromTs) |> List.ofSeq), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
    | :? ScriptDom.PivotedTableReference as src ->
      TableReferenceWithAlias.PivotedTableReference((src.AggregateFunctionIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *), (src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.InColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PivotColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.ValueColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.SemanticTableReference as src ->
      TableReferenceWithAlias.SemanticTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.MatchedColumn |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.MatchedKey |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SemanticFunctionType) (* 196 *), (src.SourceKey |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TableName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.TableReferenceWithAliasAndColumns as src ->
      match src with
      | :? ScriptDom.BulkOpenRowset as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.BulkOpenRowset((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.DataFile |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq))))
      | :? ScriptDom.ChangeTableChangesTableReference as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.ChangeTableChangesTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SinceVersion |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Target |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.ChangeTableVersionTableReference as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.ChangeTableVersionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrimaryKeyColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrimaryKeyValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Target |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.DataModificationTableReference as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.DataModificationTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.DataModificationSpecification |> Option.ofObj |> Option.map (DataModificationSpecification.FromTs)) (* 191 *))))
      | :? ScriptDom.InlineDerivedTable as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.InlineDerivedTable((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.RowValues |> Seq.map (fun src -> RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))) |> List.ofSeq))))
      | :? ScriptDom.QueryDerivedTable as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.QueryDerivedTable((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))))
      | :? ScriptDom.SchemaObjectFunctionTableReference as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.SchemaObjectFunctionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.SchemaObject |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))))
      | :? ScriptDom.VariableMethodCallTableReference as src-> (* 274 *)
        TableReferenceWithAlias.TableReferenceWithAliasAndColumns((TableReferenceWithAliasAndColumns.VariableMethodCallTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.MethodName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))))
    | :? ScriptDom.UnpivotedTableReference as src ->
      TableReferenceWithAlias.UnpivotedTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.InColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.PivotColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.ValueColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | :? ScriptDom.VariableTableReference as src ->
      TableReferenceWithAlias.VariableTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] CaseExpression = 
  | SearchedCaseExpression of Collation:Identifier option * ElseExpression:ScalarExpression option * WhenClauses:(SearchedWhenClause) list
  | SimpleCaseExpression of Collation:Identifier option * ElseExpression:ScalarExpression option * InputExpression:ScalarExpression option * WhenClauses:(SimpleWhenClause) list
  static member FromTs(src:ScriptDom.CaseExpression) : CaseExpression =
    match src with
    | :? ScriptDom.SearchedCaseExpression as src ->
      CaseExpression.SearchedCaseExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenClauses |> Seq.map (fun src -> SearchedWhenClause.SearchedWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))) |> List.ofSeq))
    | :? ScriptDom.SimpleCaseExpression as src ->
      CaseExpression.SimpleCaseExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ElseExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.InputExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenClauses |> Seq.map (fun src -> SimpleWhenClause.SimpleWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] ValueExpression = 
  | GlobalVariableExpression of Collation:Identifier option * Name:String option
  | Literal of Literal
  | VariableReference of Collation:Identifier option * Name:String option
  static member FromTs(src:ScriptDom.ValueExpression) : ValueExpression =
    match src with
    | :? ScriptDom.GlobalVariableExpression as src ->
      ValueExpression.GlobalVariableExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))
    | :? ScriptDom.Literal as src ->
      match src with
      | :? ScriptDom.BinaryLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.BinaryLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.DefaultLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.DefaultLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.IdentifierLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.IdentifierLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.IntegerLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.IntegerLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.MaxLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.MaxLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.MoneyLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.MoneyLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.NullLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.NullLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.NumericLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.NumericLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.OdbcLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.OdbcLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsNational) (* 196 *), (src.LiteralType) (* 196 *), (src.OdbcLiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.RealLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.RealLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
      | :? ScriptDom.StringLiteral as src-> (* 274 *)
        ValueExpression.Literal((Literal.StringLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.IsNational) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))))
    | :? ScriptDom.VariableReference as src ->
      ValueExpression.VariableReference((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))
and [<RequireQualifiedAccess>] FunctionStatementBody = 
  | AlterFunctionStatement of MethodSpecifier:MethodSpecifier option * Name:SchemaObjectName option * Options:(FunctionOption) list * OrderHint:OrderBulkInsertOption option * Parameters:(ProcedureParameter) list * ReturnType:FunctionReturnType option * StatementList:StatementList option
  | CreateFunctionStatement of MethodSpecifier:MethodSpecifier option * Name:SchemaObjectName option * Options:(FunctionOption) list * OrderHint:OrderBulkInsertOption option * Parameters:(ProcedureParameter) list * ReturnType:FunctionReturnType option * StatementList:StatementList option
  static member FromTs(src:ScriptDom.FunctionStatementBody) : FunctionStatementBody =
    match src with
    | :? ScriptDom.AlterFunctionStatement as src ->
      FunctionStatementBody.AlterFunctionStatement((src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FunctionOption.FromTs) |> List.ofSeq), (src.OrderHint |> Option.ofObj |> Option.map (OrderBulkInsertOption.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (FunctionReturnType.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
    | :? ScriptDom.CreateFunctionStatement as src ->
      FunctionStatementBody.CreateFunctionStatement((src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Options |> Seq.map (FunctionOption.FromTs) |> List.ofSeq), (src.OrderHint |> Option.ofObj |> Option.map (OrderBulkInsertOption.FromTs)) (* 193 *), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ReturnType |> Option.ofObj |> Option.map (FunctionReturnType.FromTs)) (* 191 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ProcedureStatementBody = 
  | AlterProcedureStatement of IsForReplication:bool * MethodSpecifier:MethodSpecifier option * Options:(ProcedureOption) list * Parameters:(ProcedureParameter) list * ProcedureReference:ProcedureReference option * StatementList:StatementList option
  | CreateProcedureStatement of IsForReplication:bool * MethodSpecifier:MethodSpecifier option * Options:(ProcedureOption) list * Parameters:(ProcedureParameter) list * ProcedureReference:ProcedureReference option * StatementList:StatementList option
  static member FromTs(src:ScriptDom.ProcedureStatementBody) : ProcedureStatementBody =
    match src with
    | :? ScriptDom.AlterProcedureStatement as src ->
      ProcedureStatementBody.AlterProcedureStatement((src.IsForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Options |> Seq.map (ProcedureOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
    | :? ScriptDom.CreateProcedureStatement as src ->
      ProcedureStatementBody.CreateProcedureStatement((src.IsForReplication) (* 196 *), (src.MethodSpecifier |> Option.ofObj |> Option.map (MethodSpecifier.FromTs)) (* 193 *), (src.Options |> Seq.map (ProcedureOption.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (fun src -> ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.StatementList |> Option.ofObj |> Option.map (StatementList.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterRoleStatement = 
  | Base of Action:AlterRoleAction option * Name:Identifier option
  | AlterServerRoleStatement of Action:AlterRoleAction option * Name:Identifier option
  static member FromTs(src:ScriptDom.AlterRoleStatement) : AlterRoleStatement =
    match src with
    | :? ScriptDom.AlterServerRoleStatement as src ->
      AlterRoleStatement.AlterServerRoleStatement((src.Action |> Option.ofObj |> Option.map (AlterRoleAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.AlterRoleStatement as src *)
      AlterRoleStatement.Base((* 297 *)((src.Action |> Option.ofObj |> Option.map (AlterRoleAction.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] CreateRoleStatement = 
  | Base of Name:Identifier option * Owner:Identifier option
  | CreateServerRoleStatement of Name:Identifier option * Owner:Identifier option
  static member FromTs(src:ScriptDom.CreateRoleStatement) : CreateRoleStatement =
    match src with
    | :? ScriptDom.CreateServerRoleStatement as src ->
      CreateRoleStatement.CreateServerRoleStatement((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
    | _ -> (* :? ScriptDom.CreateRoleStatement as src *)
      CreateRoleStatement.Base((* 297 *)((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Owner |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *)))
and [<RequireQualifiedAccess>] DataModificationStatement = 
  | DeleteStatement of DeleteSpecification:DeleteSpecification option * OptimizerHints:(OptimizerHint) list * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  | InsertStatement of InsertSpecification:InsertSpecification option * OptimizerHints:(OptimizerHint) list * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  | MergeStatement of MergeSpecification:MergeSpecification option * OptimizerHints:(OptimizerHint) list * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  | UpdateStatement of OptimizerHints:(OptimizerHint) list * UpdateSpecification:UpdateSpecification option * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  static member FromTs(src:ScriptDom.DataModificationStatement) : DataModificationStatement =
    match src with
    | :? ScriptDom.DeleteStatement as src ->
      DataModificationStatement.DeleteStatement((src.DeleteSpecification |> Option.ofObj |> Option.map (DeleteSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.InsertStatement as src ->
      DataModificationStatement.InsertStatement((src.InsertSpecification |> Option.ofObj |> Option.map (InsertSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.MergeStatement as src ->
      DataModificationStatement.MergeStatement((src.MergeSpecification |> Option.ofObj |> Option.map (MergeSpecification.FromTs)) (* 193 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))
    | :? ScriptDom.UpdateStatement as src ->
      DataModificationStatement.UpdateStatement((src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.UpdateSpecification |> Option.ofObj |> Option.map (UpdateSpecification.FromTs)) (* 193 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SelectStatement = 
  | Base of ComputeClauses:(ComputeClause) list * Into:SchemaObjectName option * OptimizerHints:(OptimizerHint) list * QueryExpression:QueryExpression option * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  | SelectStatementSnippet of ComputeClauses:(ComputeClause) list * Into:SchemaObjectName option * OptimizerHints:(OptimizerHint) list * QueryExpression:QueryExpression option * Script:String option * WithCtesAndXmlNamespaces:WithCtesAndXmlNamespaces option
  static member FromTs(src:ScriptDom.SelectStatement) : SelectStatement =
    match src with
    | :? ScriptDom.SelectStatementSnippet as src ->
      SelectStatement.SelectStatementSnippet((src.ComputeClauses |> Seq.map (fun src -> ComputeClause.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Into |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (Option.ofObj (src.Script)) (* 198 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *))
    | _ -> (* :? ScriptDom.SelectStatement as src *)
      SelectStatement.Base((* 297 *)((src.ComputeClauses |> Seq.map (fun src -> ComputeClause.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))) |> List.ofSeq), (src.Into |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.OptimizerHints |> Seq.map (OptimizerHint.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *), (src.WithCtesAndXmlNamespaces |> Option.ofObj |> Option.map (WithCtesAndXmlNamespaces.FromTs)) (* 193 *)))
and [<RequireQualifiedAccess>] TableReferenceWithAliasAndColumns = 
  | BulkOpenRowset of Alias:Identifier option * Columns:(Identifier) list * DataFile:StringLiteral option * Options:(BulkInsertOption) list
  | ChangeTableChangesTableReference of Alias:Identifier option * Columns:(Identifier) list * SinceVersion:ValueExpression option * Target:SchemaObjectName option
  | ChangeTableVersionTableReference of Alias:Identifier option * Columns:(Identifier) list * PrimaryKeyColumns:(Identifier) list * PrimaryKeyValues:(ScalarExpression) list * Target:SchemaObjectName option
  | DataModificationTableReference of Alias:Identifier option * Columns:(Identifier) list * DataModificationSpecification:DataModificationSpecification option
  | InlineDerivedTable of Alias:Identifier option * Columns:(Identifier) list * RowValues:(RowValue) list
  | QueryDerivedTable of Alias:Identifier option * Columns:(Identifier) list * QueryExpression:QueryExpression option
  | SchemaObjectFunctionTableReference of Alias:Identifier option * Columns:(Identifier) list * Parameters:(ScalarExpression) list * SchemaObject:SchemaObjectName option
  | VariableMethodCallTableReference of Alias:Identifier option * Columns:(Identifier) list * MethodName:Identifier option * Parameters:(ScalarExpression) list * Variable:VariableReference option
  static member FromTs(src:ScriptDom.TableReferenceWithAliasAndColumns) : TableReferenceWithAliasAndColumns =
    match src with
    | :? ScriptDom.BulkOpenRowset as src ->
      TableReferenceWithAliasAndColumns.BulkOpenRowset((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.DataFile |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.Options |> Seq.map (BulkInsertOption.FromTs) |> List.ofSeq))
    | :? ScriptDom.ChangeTableChangesTableReference as src ->
      TableReferenceWithAliasAndColumns.ChangeTableChangesTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SinceVersion |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.Target |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.ChangeTableVersionTableReference as src ->
      TableReferenceWithAliasAndColumns.ChangeTableVersionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrimaryKeyColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrimaryKeyValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Target |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.DataModificationTableReference as src ->
      TableReferenceWithAliasAndColumns.DataModificationTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.DataModificationSpecification |> Option.ofObj |> Option.map (DataModificationSpecification.FromTs)) (* 191 *))
    | :? ScriptDom.InlineDerivedTable as src ->
      TableReferenceWithAliasAndColumns.InlineDerivedTable((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.RowValues |> Seq.map (fun src -> RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))) |> List.ofSeq))
    | :? ScriptDom.QueryDerivedTable as src ->
      TableReferenceWithAliasAndColumns.QueryDerivedTable((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
    | :? ScriptDom.SchemaObjectFunctionTableReference as src ->
      TableReferenceWithAliasAndColumns.SchemaObjectFunctionTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.SchemaObject |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
    | :? ScriptDom.VariableMethodCallTableReference as src ->
      TableReferenceWithAliasAndColumns.VariableMethodCallTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.MethodName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] Literal = 
  | BinaryLiteral of Collation:Identifier option * IsLargeObject:bool * LiteralType:ScriptDom.LiteralType * Value:String option
  | DefaultLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | IdentifierLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * QuoteType:ScriptDom.QuoteType * Value:String option
  | IntegerLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | MaxLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | MoneyLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | NullLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | NumericLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | OdbcLiteral of Collation:Identifier option * IsNational:bool * LiteralType:ScriptDom.LiteralType * OdbcLiteralType:ScriptDom.OdbcLiteralType * Value:String option
  | RealLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option
  | StringLiteral of Collation:Identifier option * IsLargeObject:bool * IsNational:bool * LiteralType:ScriptDom.LiteralType * Value:String option
  static member FromTs(src:ScriptDom.Literal) : Literal =
    match src with
    | :? ScriptDom.BinaryLiteral as src ->
      Literal.BinaryLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.DefaultLiteral as src ->
      Literal.DefaultLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.IdentifierLiteral as src ->
      Literal.IdentifierLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (src.QuoteType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.IntegerLiteral as src ->
      Literal.IntegerLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.MaxLiteral as src ->
      Literal.MaxLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.MoneyLiteral as src ->
      Literal.MoneyLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.NullLiteral as src ->
      Literal.NullLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.NumericLiteral as src ->
      Literal.NumericLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.OdbcLiteral as src ->
      Literal.OdbcLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsNational) (* 196 *), (src.LiteralType) (* 196 *), (src.OdbcLiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.RealLiteral as src ->
      Literal.RealLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
    | :? ScriptDom.StringLiteral as src ->
      Literal.StringLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.IsNational) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
// Rendering missing cases
and [<RequireQualifiedAccess>] StringLiteral =
  | StringLiteral of Collation:Identifier option * IsLargeObject:bool * IsNational:bool * LiteralType:ScriptDom.LiteralType * Value:String option 
  static member FromTs(src:ScriptDom.StringLiteral) : StringLiteral =
    StringLiteral.StringLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.IsNational) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
and [<RequireQualifiedAccess>] AlterAvailabilityGroupActionType =
  | AlterAvailabilityGroupActionType  
  static member FromTs(src:ScriptDom.AlterAvailabilityGroupActionType) : AlterAvailabilityGroupActionType =
    AlterAvailabilityGroupActionType.AlterAvailabilityGroupActionType 
and [<RequireQualifiedAccess>] AlterAvailabilityGroupFailoverOption =
  | AlterAvailabilityGroupFailoverOption of OptionKind:ScriptDom.FailoverActionOptionKind * Value:Literal option 
  static member FromTs(src:ScriptDom.AlterAvailabilityGroupFailoverOption) : AlterAvailabilityGroupFailoverOption =
    AlterAvailabilityGroupFailoverOption.AlterAvailabilityGroupFailoverOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FailoverActionOptionKind =
  | FailoverActionOptionKind  
  static member FromTs(src:ScriptDom.FailoverActionOptionKind) : FailoverActionOptionKind =
    FailoverActionOptionKind.FailoverActionOptionKind 
and [<RequireQualifiedAccess>] FullTextIndexColumn =
  | FullTextIndexColumn of LanguageTerm:IdentifierOrValueExpression option * Name:Identifier option * StatisticalSemantics:bool * TypeColumn:Identifier option 
  static member FromTs(src:ScriptDom.FullTextIndexColumn) : FullTextIndexColumn =
    FullTextIndexColumn.FullTextIndexColumn((src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StatisticalSemantics) (* 196 *), (src.TypeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SearchPropertyListFullTextIndexOption =
  | SearchPropertyListFullTextIndexOption of IsOff:bool * OptionKind:ScriptDom.FullTextIndexOptionKind * PropertyListName:Identifier option 
  static member FromTs(src:ScriptDom.SearchPropertyListFullTextIndexOption) : SearchPropertyListFullTextIndexOption =
    SearchPropertyListFullTextIndexOption.SearchPropertyListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.PropertyListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] StopListFullTextIndexOption =
  | StopListFullTextIndexOption of IsOff:bool * OptionKind:ScriptDom.FullTextIndexOptionKind * StopListName:Identifier option 
  static member FromTs(src:ScriptDom.StopListFullTextIndexOption) : StopListFullTextIndexOption =
    StopListFullTextIndexOption.StopListFullTextIndexOption((src.IsOff) (* 196 *), (src.OptionKind) (* 196 *), (src.StopListName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SimpleAlterFullTextIndexActionKind =
  | SimpleAlterFullTextIndexActionKind  
  static member FromTs(src:ScriptDom.SimpleAlterFullTextIndexActionKind) : SimpleAlterFullTextIndexActionKind =
    SimpleAlterFullTextIndexActionKind.SimpleAlterFullTextIndexActionKind 
and [<RequireQualifiedAccess>] AlterServerConfigurationBufferPoolExtensionOptionKind =
  | AlterServerConfigurationBufferPoolExtensionOptionKind  
  static member FromTs(src:ScriptDom.AlterServerConfigurationBufferPoolExtensionOptionKind) : AlterServerConfigurationBufferPoolExtensionOptionKind =
    AlterServerConfigurationBufferPoolExtensionOptionKind.AlterServerConfigurationBufferPoolExtensionOptionKind 
and [<RequireQualifiedAccess>] MemoryUnit =
  | MemoryUnit  
  static member FromTs(src:ScriptDom.MemoryUnit) : MemoryUnit =
    MemoryUnit.MemoryUnit 
and [<RequireQualifiedAccess>] AlterServerConfigurationDiagnosticsLogOptionKind =
  | AlterServerConfigurationDiagnosticsLogOptionKind  
  static member FromTs(src:ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind) : AlterServerConfigurationDiagnosticsLogOptionKind =
    AlterServerConfigurationDiagnosticsLogOptionKind.AlterServerConfigurationDiagnosticsLogOptionKind 
and [<RequireQualifiedAccess>] AlterServerConfigurationFailoverClusterPropertyOptionKind =
  | AlterServerConfigurationFailoverClusterPropertyOptionKind  
  static member FromTs(src:ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind) : AlterServerConfigurationFailoverClusterPropertyOptionKind =
    AlterServerConfigurationFailoverClusterPropertyOptionKind.AlterServerConfigurationFailoverClusterPropertyOptionKind 
and [<RequireQualifiedAccess>] AlterServerConfigurationHadrClusterOptionKind =
  | AlterServerConfigurationHadrClusterOptionKind  
  static member FromTs(src:ScriptDom.AlterServerConfigurationHadrClusterOptionKind) : AlterServerConfigurationHadrClusterOptionKind =
    AlterServerConfigurationHadrClusterOptionKind.AlterServerConfigurationHadrClusterOptionKind 
and [<RequireQualifiedAccess>] AlterServerConfigurationSoftNumaOptionKind =
  | AlterServerConfigurationSoftNumaOptionKind  
  static member FromTs(src:ScriptDom.AlterServerConfigurationSoftNumaOptionKind) : AlterServerConfigurationSoftNumaOptionKind =
    AlterServerConfigurationSoftNumaOptionKind.AlterServerConfigurationSoftNumaOptionKind 
and [<RequireQualifiedAccess>] TableElementType =
  | TableElementType  
  static member FromTs(src:ScriptDom.TableElementType) : TableElementType =
    TableElementType.TableElementType 
and [<RequireQualifiedAccess>] ApplicationRoleOptionKind =
  | ApplicationRoleOptionKind  
  static member FromTs(src:ScriptDom.ApplicationRoleOptionKind) : ApplicationRoleOptionKind =
    ApplicationRoleOptionKind.ApplicationRoleOptionKind 
and [<RequireQualifiedAccess>] IdentifierOrValueExpression =
  | IdentifierOrValueExpression of Identifier:Identifier option * Value:String option * ValueExpression:ValueExpression option 
  static member FromTs(src:ScriptDom.IdentifierOrValueExpression) : IdentifierOrValueExpression =
    IdentifierOrValueExpression.IdentifierOrValueExpression((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Value)) (* 198 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AssemblyOptionKind =
  | AssemblyOptionKind  
  static member FromTs(src:ScriptDom.AssemblyOptionKind) : AssemblyOptionKind =
    AssemblyOptionKind.AssemblyOptionKind 
and [<RequireQualifiedAccess>] OptionState =
  | OptionState  
  static member FromTs(src:ScriptDom.OptionState) : OptionState =
    OptionState.OptionState 
and [<RequireQualifiedAccess>] PermissionSetOption =
  | PermissionSetOption  
  static member FromTs(src:ScriptDom.PermissionSetOption) : PermissionSetOption =
    PermissionSetOption.PermissionSetOption 
and [<RequireQualifiedAccess>] AtomicBlockOptionKind =
  | AtomicBlockOptionKind  
  static member FromTs(src:ScriptDom.AtomicBlockOptionKind) : AtomicBlockOptionKind =
    AtomicBlockOptionKind.AtomicBlockOptionKind 
and [<RequireQualifiedAccess>] AuditOptionKind =
  | AuditOptionKind  
  static member FromTs(src:ScriptDom.AuditOptionKind) : AuditOptionKind =
    AuditOptionKind.AuditOptionKind 
and [<RequireQualifiedAccess>] AuditFailureActionType =
  | AuditFailureActionType  
  static member FromTs(src:ScriptDom.AuditFailureActionType) : AuditFailureActionType =
    AuditFailureActionType.AuditFailureActionType 
and [<RequireQualifiedAccess>] AuditActionGroup =
  | AuditActionGroup  
  static member FromTs(src:ScriptDom.AuditActionGroup) : AuditActionGroup =
    AuditActionGroup.AuditActionGroup 
and [<RequireQualifiedAccess>] DatabaseAuditAction =
  | DatabaseAuditAction of ActionKind:ScriptDom.DatabaseAuditActionKind 
  static member FromTs(src:ScriptDom.DatabaseAuditAction) : DatabaseAuditAction =
    DatabaseAuditAction.DatabaseAuditAction((src.ActionKind) (* 196 *))
and [<RequireQualifiedAccess>] SecurityPrincipal =
  | SecurityPrincipal of Identifier:Identifier option * PrincipalType:ScriptDom.PrincipalType 
  static member FromTs(src:ScriptDom.SecurityPrincipal) : SecurityPrincipal =
    SecurityPrincipal.SecurityPrincipal((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PrincipalType) (* 196 *))
and [<RequireQualifiedAccess>] SecurityTargetObject =
  | SecurityTargetObject of Columns:(Identifier) list * ObjectKind:ScriptDom.SecurityObjectKind * ObjectName:SecurityTargetObjectName option 
  static member FromTs(src:ScriptDom.SecurityTargetObject) : SecurityTargetObject =
    SecurityTargetObject.SecurityTargetObject((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ObjectKind) (* 196 *), (src.ObjectName |> Option.ofObj |> Option.map (SecurityTargetObjectName.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AuditTargetKind =
  | AuditTargetKind  
  static member FromTs(src:ScriptDom.AuditTargetKind) : AuditTargetKind =
    AuditTargetKind.AuditTargetKind 
and [<RequireQualifiedAccess>] AuditTargetOptionKind =
  | AuditTargetOptionKind  
  static member FromTs(src:ScriptDom.AuditTargetOptionKind) : AuditTargetOptionKind =
    AuditTargetOptionKind.AuditTargetOptionKind 
and [<RequireQualifiedAccess>] AvailabilityGroupOptionKind =
  | AvailabilityGroupOptionKind  
  static member FromTs(src:ScriptDom.AvailabilityGroupOptionKind) : AvailabilityGroupOptionKind =
    AvailabilityGroupOptionKind.AvailabilityGroupOptionKind 
and [<RequireQualifiedAccess>] AvailabilityReplicaOptionKind =
  | AvailabilityReplicaOptionKind  
  static member FromTs(src:ScriptDom.AvailabilityReplicaOptionKind) : AvailabilityReplicaOptionKind =
    AvailabilityReplicaOptionKind.AvailabilityReplicaOptionKind 
and [<RequireQualifiedAccess>] AvailabilityModeOptionKind =
  | AvailabilityModeOptionKind  
  static member FromTs(src:ScriptDom.AvailabilityModeOptionKind) : AvailabilityModeOptionKind =
    AvailabilityModeOptionKind.AvailabilityModeOptionKind 
and [<RequireQualifiedAccess>] FailoverModeOptionKind =
  | FailoverModeOptionKind  
  static member FromTs(src:ScriptDom.FailoverModeOptionKind) : FailoverModeOptionKind =
    FailoverModeOptionKind.FailoverModeOptionKind 
and [<RequireQualifiedAccess>] AllowConnectionsOptionKind =
  | AllowConnectionsOptionKind  
  static member FromTs(src:ScriptDom.AllowConnectionsOptionKind) : AllowConnectionsOptionKind =
    AllowConnectionsOptionKind.AllowConnectionsOptionKind 
and [<RequireQualifiedAccess>] BackupOptionKind =
  | BackupOptionKind  
  static member FromTs(src:ScriptDom.BackupOptionKind) : BackupOptionKind =
    BackupOptionKind.BackupOptionKind 
and [<RequireQualifiedAccess>] EncryptionAlgorithm =
  | EncryptionAlgorithm  
  static member FromTs(src:ScriptDom.EncryptionAlgorithm) : EncryptionAlgorithm =
    EncryptionAlgorithm.EncryptionAlgorithm 
and [<RequireQualifiedAccess>] CryptoMechanism =
  | CryptoMechanism of CryptoMechanismType:ScriptDom.CryptoMechanismType * Identifier:Identifier option * PasswordOrSignature:Literal option 
  static member FromTs(src:ScriptDom.CryptoMechanism) : CryptoMechanism =
    CryptoMechanism.CryptoMechanism((src.CryptoMechanismType) (* 196 *), (src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.PasswordOrSignature |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] BackupRestoreItemKind =
  | BackupRestoreItemKind  
  static member FromTs(src:ScriptDom.BackupRestoreItemKind) : BackupRestoreItemKind =
    BackupRestoreItemKind.BackupRestoreItemKind 
and [<RequireQualifiedAccess>] BooleanBinaryExpressionType =
  | BooleanBinaryExpressionType  
  static member FromTs(src:ScriptDom.BooleanBinaryExpressionType) : BooleanBinaryExpressionType =
    BooleanBinaryExpressionType.BooleanBinaryExpressionType 
and [<RequireQualifiedAccess>] BooleanComparisonType =
  | BooleanComparisonType  
  static member FromTs(src:ScriptDom.BooleanComparisonType) : BooleanComparisonType =
    BooleanComparisonType.BooleanComparisonType 
and [<RequireQualifiedAccess>] BooleanTernaryExpressionType =
  | BooleanTernaryExpressionType  
  static member FromTs(src:ScriptDom.BooleanTernaryExpressionType) : BooleanTernaryExpressionType =
    BooleanTernaryExpressionType.BooleanTernaryExpressionType 
and [<RequireQualifiedAccess>] EventSessionObjectName =
  | EventSessionObjectName of MultiPartIdentifier:MultiPartIdentifier option 
  static member FromTs(src:ScriptDom.EventSessionObjectName) : EventSessionObjectName =
    EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SourceDeclaration =
  | SourceDeclaration of Value:EventSessionObjectName option 
  static member FromTs(src:ScriptDom.SourceDeclaration) : SourceDeclaration =
    SourceDeclaration.SourceDeclaration((src.Value |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ScalarSubquery =
  | ScalarSubquery of Collation:Identifier option * QueryExpression:QueryExpression option 
  static member FromTs(src:ScriptDom.ScalarSubquery) : ScalarSubquery =
    ScalarSubquery.ScalarSubquery((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ColumnReferenceExpression =
  | ColumnReferenceExpression of Collation:Identifier option * ColumnType:ScriptDom.ColumnType * MultiPartIdentifier:MultiPartIdentifier option 
  static member FromTs(src:ScriptDom.ColumnReferenceExpression) : ColumnReferenceExpression =
    ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FullTextFunctionType =
  | FullTextFunctionType  
  static member FromTs(src:ScriptDom.FullTextFunctionType) : FullTextFunctionType =
    FullTextFunctionType.FullTextFunctionType 
and [<RequireQualifiedAccess>] SubqueryComparisonPredicateType =
  | SubqueryComparisonPredicateType  
  static member FromTs(src:ScriptDom.SubqueryComparisonPredicateType) : SubqueryComparisonPredicateType =
    SubqueryComparisonPredicateType.SubqueryComparisonPredicateType 
and [<RequireQualifiedAccess>] BoundingBoxParameterType =
  | BoundingBoxParameterType  
  static member FromTs(src:ScriptDom.BoundingBoxParameterType) : BoundingBoxParameterType =
    BoundingBoxParameterType.BoundingBoxParameterType 
and [<RequireQualifiedAccess>] BrokerPriorityParameterSpecialType =
  | BrokerPriorityParameterSpecialType  
  static member FromTs(src:ScriptDom.BrokerPriorityParameterSpecialType) : BrokerPriorityParameterSpecialType =
    BrokerPriorityParameterSpecialType.BrokerPriorityParameterSpecialType 
and [<RequireQualifiedAccess>] BrokerPriorityParameterType =
  | BrokerPriorityParameterType  
  static member FromTs(src:ScriptDom.BrokerPriorityParameterType) : BrokerPriorityParameterType =
    BrokerPriorityParameterType.BrokerPriorityParameterType 
and [<RequireQualifiedAccess>] BulkInsertOptionKind =
  | BulkInsertOptionKind  
  static member FromTs(src:ScriptDom.BulkInsertOptionKind) : BulkInsertOptionKind =
    BulkInsertOptionKind.BulkInsertOptionKind 
and [<RequireQualifiedAccess>] ColumnWithSortOrder =
  | ColumnWithSortOrder of Column:ColumnReferenceExpression option * SortOrder:ScriptDom.SortOrder 
  static member FromTs(src:ScriptDom.ColumnWithSortOrder) : ColumnWithSortOrder =
    ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))
and [<RequireQualifiedAccess>] CertificateOptionKinds =
  | CertificateOptionKinds  
  static member FromTs(src:ScriptDom.CertificateOptionKinds) : CertificateOptionKinds =
    CertificateOptionKinds.CertificateOptionKinds 
and [<RequireQualifiedAccess>] TimeUnit =
  | TimeUnit  
  static member FromTs(src:ScriptDom.TimeUnit) : TimeUnit =
    TimeUnit.TimeUnit 
and [<RequireQualifiedAccess>] DefaultConstraintDefinition =
  | DefaultConstraintDefinition of Column:Identifier option * ConstraintIdentifier:Identifier option * Expression:ScalarExpression option * WithValues:bool 
  static member FromTs(src:ScriptDom.DefaultConstraintDefinition) : DefaultConstraintDefinition =
    DefaultConstraintDefinition.DefaultConstraintDefinition((src.Column |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WithValues) (* 196 *))
and [<RequireQualifiedAccess>] ColumnEncryptionDefinition =
  | ColumnEncryptionDefinition of Parameters:(ColumnEncryptionDefinitionParameter) list 
  static member FromTs(src:ScriptDom.ColumnEncryptionDefinition) : ColumnEncryptionDefinition =
    ColumnEncryptionDefinition.ColumnEncryptionDefinition((src.Parameters |> Seq.map (ColumnEncryptionDefinitionParameter.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] GeneratedAlwaysType =
  | GeneratedAlwaysType  
  static member FromTs(src:ScriptDom.GeneratedAlwaysType) : GeneratedAlwaysType =
    GeneratedAlwaysType.GeneratedAlwaysType 
and [<RequireQualifiedAccess>] IdentityOptions =
  | IdentityOptions of IdentityIncrement:ScalarExpression option * IdentitySeed:ScalarExpression option * IsIdentityNotForReplication:bool 
  static member FromTs(src:ScriptDom.IdentityOptions) : IdentityOptions =
    IdentityOptions.IdentityOptions((src.IdentityIncrement |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IdentitySeed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.IsIdentityNotForReplication) (* 196 *))
and [<RequireQualifiedAccess>] IndexDefinition =
  | IndexDefinition of Columns:(ColumnWithSortOrder) list * FileStreamOn:IdentifierOrValueExpression option * FilterPredicate:BooleanExpression option * IndexOptions:(IndexOption) list * IndexType:IndexType option * Name:Identifier option * OnFileGroupOrPartitionScheme:FileGroupOrPartitionScheme option * Unique:bool 
  static member FromTs(src:ScriptDom.IndexDefinition) : IndexDefinition =
    IndexDefinition.IndexDefinition((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Unique) (* 196 *))
and [<RequireQualifiedAccess>] ColumnStorageOptions =
  | ColumnStorageOptions of IsFileStream:bool * SparseOption:ScriptDom.SparseColumnOption 
  static member FromTs(src:ScriptDom.ColumnStorageOptions) : ColumnStorageOptions =
    ColumnStorageOptions.ColumnStorageOptions((src.IsFileStream) (* 196 *), (src.SparseOption) (* 196 *))
and [<RequireQualifiedAccess>] ColumnEncryptionDefinitionParameterKind =
  | ColumnEncryptionDefinitionParameterKind  
  static member FromTs(src:ScriptDom.ColumnEncryptionDefinitionParameterKind) : ColumnEncryptionDefinitionParameterKind =
    ColumnEncryptionDefinitionParameterKind.ColumnEncryptionDefinitionParameterKind 
and [<RequireQualifiedAccess>] ColumnEncryptionType =
  | ColumnEncryptionType  
  static member FromTs(src:ScriptDom.ColumnEncryptionType) : ColumnEncryptionType =
    ColumnEncryptionType.ColumnEncryptionType 
and [<RequireQualifiedAccess>] ColumnEncryptionKeyValueParameterKind =
  | ColumnEncryptionKeyValueParameterKind  
  static member FromTs(src:ScriptDom.ColumnEncryptionKeyValueParameterKind) : ColumnEncryptionKeyValueParameterKind =
    ColumnEncryptionKeyValueParameterKind.ColumnEncryptionKeyValueParameterKind 
and [<RequireQualifiedAccess>] BinaryLiteral =
  | BinaryLiteral of Collation:Identifier option * IsLargeObject:bool * LiteralType:ScriptDom.LiteralType * Value:String option 
  static member FromTs(src:ScriptDom.BinaryLiteral) : BinaryLiteral =
    BinaryLiteral.BinaryLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.IsLargeObject) (* 196 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
and [<RequireQualifiedAccess>] ColumnMasterKeyParameterKind =
  | ColumnMasterKeyParameterKind  
  static member FromTs(src:ScriptDom.ColumnMasterKeyParameterKind) : ColumnMasterKeyParameterKind =
    ColumnMasterKeyParameterKind.ColumnMasterKeyParameterKind 
and [<RequireQualifiedAccess>] SparseColumnOption =
  | SparseColumnOption  
  static member FromTs(src:ScriptDom.SparseColumnOption) : SparseColumnOption =
    SparseColumnOption.SparseColumnOption 
and [<RequireQualifiedAccess>] SortOrder =
  | SortOrder  
  static member FromTs(src:ScriptDom.SortOrder) : SortOrder =
    SortOrder.SortOrder 
and [<RequireQualifiedAccess>] ComputeFunction =
  | ComputeFunction of ComputeFunctionType:ScriptDom.ComputeFunctionType * Expression:ScalarExpression option 
  static member FromTs(src:ScriptDom.ComputeFunction) : ComputeFunction =
    ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ComputeFunctionType =
  | ComputeFunctionType  
  static member FromTs(src:ScriptDom.ComputeFunctionType) : ComputeFunctionType =
    ComputeFunctionType.ComputeFunctionType 
and [<RequireQualifiedAccess>] DeleteUpdateAction =
  | DeleteUpdateAction  
  static member FromTs(src:ScriptDom.DeleteUpdateAction) : DeleteUpdateAction =
    DeleteUpdateAction.DeleteUpdateAction 
and [<RequireQualifiedAccess>] IndexType =
  | IndexType of IndexTypeKind:(ScriptDom.IndexTypeKind) option 
  static member FromTs(src:ScriptDom.IndexType) : IndexType =
    IndexType.IndexType((Option.ofNullable (src.IndexTypeKind)))
and [<RequireQualifiedAccess>] FileGroupOrPartitionScheme =
  | FileGroupOrPartitionScheme of Name:IdentifierOrValueExpression option * PartitionSchemeColumns:(Identifier) list 
  static member FromTs(src:ScriptDom.FileGroupOrPartitionScheme) : FileGroupOrPartitionScheme =
    FileGroupOrPartitionScheme.FileGroupOrPartitionScheme((src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PartitionSchemeColumns |> Seq.map (Identifier.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] MessageSender =
  | MessageSender  
  static member FromTs(src:ScriptDom.MessageSender) : MessageSender =
    MessageSender.MessageSender 
and [<RequireQualifiedAccess>] CryptoMechanismType =
  | CryptoMechanismType  
  static member FromTs(src:ScriptDom.CryptoMechanismType) : CryptoMechanismType =
    CryptoMechanismType.CryptoMechanismType 
and [<RequireQualifiedAccess>] CursorOption =
  | CursorOption of OptionKind:ScriptDom.CursorOptionKind 
  static member FromTs(src:ScriptDom.CursorOption) : CursorOption =
    CursorOption.CursorOption((src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] CursorOptionKind =
  | CursorOptionKind  
  static member FromTs(src:ScriptDom.CursorOptionKind) : CursorOptionKind =
    CursorOptionKind.CursorOptionKind 
and [<RequireQualifiedAccess>] OutputClause =
  | OutputClause of SelectColumns:(SelectElement) list 
  static member FromTs(src:ScriptDom.OutputClause) : OutputClause =
    OutputClause.OutputClause((src.SelectColumns |> Seq.map (SelectElement.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] OutputIntoClause =
  | OutputIntoClause of IntoTable:TableReference option * IntoTableColumns:(ColumnReferenceExpression) list * SelectColumns:(SelectElement) list 
  static member FromTs(src:ScriptDom.OutputIntoClause) : OutputIntoClause =
    OutputIntoClause.OutputIntoClause((src.IntoTable |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.IntoTableColumns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.SelectColumns |> Seq.map (SelectElement.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] TopRowFilter =
  | TopRowFilter of Expression:ScalarExpression option * Percent:bool * WithTies:bool 
  static member FromTs(src:ScriptDom.TopRowFilter) : TopRowFilter =
    TopRowFilter.TopRowFilter((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Percent) (* 196 *), (src.WithTies) (* 196 *))
and [<RequireQualifiedAccess>] InsertOption =
  | InsertOption  
  static member FromTs(src:ScriptDom.InsertOption) : InsertOption =
    InsertOption.InsertOption 
and [<RequireQualifiedAccess>] MergeActionClause =
  | MergeActionClause of Action:MergeAction option * Condition:ScriptDom.MergeCondition * SearchCondition:BooleanExpression option 
  static member FromTs(src:ScriptDom.MergeActionClause) : MergeActionClause =
    MergeActionClause.MergeActionClause((src.Action |> Option.ofObj |> Option.map (MergeAction.FromTs)) (* 191 *), (src.Condition) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] FromClause =
  | FromClause of TableReferences:(TableReference) list 
  static member FromTs(src:ScriptDom.FromClause) : FromClause =
    FromClause.FromClause((src.TableReferences |> Seq.map (TableReference.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] WhereClause =
  | WhereClause of Cursor:CursorId option * SearchCondition:BooleanExpression option 
  static member FromTs(src:ScriptDom.WhereClause) : WhereClause =
    WhereClause.WhereClause((src.Cursor |> Option.ofObj |> Option.map (CursorId.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SqlDataTypeOption =
  | SqlDataTypeOption  
  static member FromTs(src:ScriptDom.SqlDataTypeOption) : SqlDataTypeOption =
    SqlDataTypeOption.SqlDataTypeOption 
and [<RequireQualifiedAccess>] XmlDataTypeOption =
  | XmlDataTypeOption  
  static member FromTs(src:ScriptDom.XmlDataTypeOption) : XmlDataTypeOption =
    XmlDataTypeOption.XmlDataTypeOption 
and [<RequireQualifiedAccess>] DatabaseAuditActionKind =
  | DatabaseAuditActionKind  
  static member FromTs(src:ScriptDom.DatabaseAuditActionKind) : DatabaseAuditActionKind =
    DatabaseAuditActionKind.DatabaseAuditActionKind 
and [<RequireQualifiedAccess>] DatabaseConfigClearOptionKind =
  | DatabaseConfigClearOptionKind  
  static member FromTs(src:ScriptDom.DatabaseConfigClearOptionKind) : DatabaseConfigClearOptionKind =
    DatabaseConfigClearOptionKind.DatabaseConfigClearOptionKind 
and [<RequireQualifiedAccess>] DatabaseConfigSetOptionKind =
  | DatabaseConfigSetOptionKind  
  static member FromTs(src:ScriptDom.DatabaseConfigSetOptionKind) : DatabaseConfigSetOptionKind =
    DatabaseConfigSetOptionKind.DatabaseConfigSetOptionKind 
and [<RequireQualifiedAccess>] DatabaseConfigurationOptionState =
  | DatabaseConfigurationOptionState  
  static member FromTs(src:ScriptDom.DatabaseConfigurationOptionState) : DatabaseConfigurationOptionState =
    DatabaseConfigurationOptionState.DatabaseConfigurationOptionState 
and [<RequireQualifiedAccess>] DatabaseOptionKind =
  | DatabaseOptionKind  
  static member FromTs(src:ScriptDom.DatabaseOptionKind) : DatabaseOptionKind =
    DatabaseOptionKind.DatabaseOptionKind 
and [<RequireQualifiedAccess>] ContainmentOptionKind =
  | ContainmentOptionKind  
  static member FromTs(src:ScriptDom.ContainmentOptionKind) : ContainmentOptionKind =
    ContainmentOptionKind.ContainmentOptionKind 
and [<RequireQualifiedAccess>] DelayedDurabilityOptionKind =
  | DelayedDurabilityOptionKind  
  static member FromTs(src:ScriptDom.DelayedDurabilityOptionKind) : DelayedDurabilityOptionKind =
    DelayedDurabilityOptionKind.DelayedDurabilityOptionKind 
and [<RequireQualifiedAccess>] NonTransactedFileStreamAccess =
  | NonTransactedFileStreamAccess  
  static member FromTs(src:ScriptDom.NonTransactedFileStreamAccess) : NonTransactedFileStreamAccess =
    NonTransactedFileStreamAccess.NonTransactedFileStreamAccess 
and [<RequireQualifiedAccess>] HadrDatabaseOptionKind =
  | HadrDatabaseOptionKind  
  static member FromTs(src:ScriptDom.HadrDatabaseOptionKind) : HadrDatabaseOptionKind =
    HadrDatabaseOptionKind.HadrDatabaseOptionKind 
and [<RequireQualifiedAccess>] PageVerifyDatabaseOptionKind =
  | PageVerifyDatabaseOptionKind  
  static member FromTs(src:ScriptDom.PageVerifyDatabaseOptionKind) : PageVerifyDatabaseOptionKind =
    PageVerifyDatabaseOptionKind.PageVerifyDatabaseOptionKind 
and [<RequireQualifiedAccess>] PartnerDatabaseOptionKind =
  | PartnerDatabaseOptionKind  
  static member FromTs(src:ScriptDom.PartnerDatabaseOptionKind) : PartnerDatabaseOptionKind =
    PartnerDatabaseOptionKind.PartnerDatabaseOptionKind 
and [<RequireQualifiedAccess>] RecoveryDatabaseOptionKind =
  | RecoveryDatabaseOptionKind  
  static member FromTs(src:ScriptDom.RecoveryDatabaseOptionKind) : RecoveryDatabaseOptionKind =
    RecoveryDatabaseOptionKind.RecoveryDatabaseOptionKind 
and [<RequireQualifiedAccess>] DbccOptionKind =
  | DbccOptionKind  
  static member FromTs(src:ScriptDom.DbccOptionKind) : DbccOptionKind =
    DbccOptionKind.DbccOptionKind 
and [<RequireQualifiedAccess>] TableDefinition =
  | TableDefinition of ColumnDefinitions:(ColumnDefinition) list * Indexes:(IndexDefinition) list * SystemTimePeriod:SystemTimePeriodDefinition option * TableConstraints:(ConstraintDefinition) list 
  static member FromTs(src:ScriptDom.TableDefinition) : TableDefinition =
    TableDefinition.TableDefinition((src.ColumnDefinitions |> Seq.map (fun src -> ColumnDefinition.ColumnDefinition((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ComputedColumnExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Constraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DefaultConstraint |> Option.ofObj |> Option.map (DefaultConstraintDefinition.FromTs)) (* 193 *), (src.Encryption |> Option.ofObj |> Option.map (ColumnEncryptionDefinition.FromTs)) (* 193 *), (Option.ofNullable (src.GeneratedAlways)), (src.IdentityOptions |> Option.ofObj |> Option.map (IdentityOptions.FromTs)) (* 193 *), (src.Index |> Option.ofObj |> Option.map (IndexDefinition.FromTs)) (* 193 *), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.IsPersisted) (* 196 *), (src.IsRowGuidCol) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))) |> List.ofSeq), (src.Indexes |> Seq.map (fun src -> IndexDefinition.IndexDefinition((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.FileStreamOn |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.FilterPredicate |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.IndexOptions |> Seq.map (IndexOption.FromTs) |> List.ofSeq), (src.IndexType |> Option.ofObj |> Option.map (IndexType.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OnFileGroupOrPartitionScheme |> Option.ofObj |> Option.map (FileGroupOrPartitionScheme.FromTs)) (* 193 *), (src.Unique) (* 196 *))) |> List.ofSeq), (src.SystemTimePeriod |> Option.ofObj |> Option.map (SystemTimePeriodDefinition.FromTs)) (* 193 *), (src.TableConstraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] NullableConstraintDefinition =
  | NullableConstraintDefinition of ConstraintIdentifier:Identifier option * Nullable:bool 
  static member FromTs(src:ScriptDom.NullableConstraintDefinition) : NullableConstraintDefinition =
    NullableConstraintDefinition.NullableConstraintDefinition((src.ConstraintIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Nullable) (* 196 *))
and [<RequireQualifiedAccess>] ParameterModifier =
  | ParameterModifier  
  static member FromTs(src:ScriptDom.ParameterModifier) : ParameterModifier =
    ParameterModifier.ParameterModifier 
and [<RequireQualifiedAccess>] DeviceType =
  | DeviceType  
  static member FromTs(src:ScriptDom.DeviceType) : DeviceType =
    DeviceType.DeviceType 
and [<RequireQualifiedAccess>] DialogOptionKind =
  | DialogOptionKind  
  static member FromTs(src:ScriptDom.DialogOptionKind) : DialogOptionKind =
    DialogOptionKind.DialogOptionKind 
and [<RequireQualifiedAccess>] DiskStatementOptionKind =
  | DiskStatementOptionKind  
  static member FromTs(src:ScriptDom.DiskStatementOptionKind) : DiskStatementOptionKind =
    DiskStatementOptionKind.DiskStatementOptionKind 
and [<RequireQualifiedAccess>] DropClusteredConstraintOptionKind =
  | DropClusteredConstraintOptionKind  
  static member FromTs(src:ScriptDom.DropClusteredConstraintOptionKind) : DropClusteredConstraintOptionKind =
    DropClusteredConstraintOptionKind.DropClusteredConstraintOptionKind 
and [<RequireQualifiedAccess>] ChildObjectName =
  | ChildObjectName of BaseIdentifier:Identifier option * ChildIdentifier:Identifier option * Count:Int32 * DatabaseIdentifier:Identifier option * Identifiers:(Identifier) list * SchemaIdentifier:Identifier option * ServerIdentifier:Identifier option 
  static member FromTs(src:ScriptDom.ChildObjectName) : ChildObjectName =
    ChildObjectName.ChildObjectName((src.BaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ChildIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Count) (* 196 *), (src.DatabaseIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.SchemaIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ServerIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AffinityKind =
  | AffinityKind  
  static member FromTs(src:ScriptDom.AffinityKind) : AffinityKind =
    AffinityKind.AffinityKind 
and [<RequireQualifiedAccess>] EndpointProtocolOptions =
  | EndpointProtocolOptions  
  static member FromTs(src:ScriptDom.EndpointProtocolOptions) : EndpointProtocolOptions =
    EndpointProtocolOptions.EndpointProtocolOptions 
and [<RequireQualifiedAccess>] AuthenticationTypes =
  | AuthenticationTypes  
  static member FromTs(src:ScriptDom.AuthenticationTypes) : AuthenticationTypes =
    AuthenticationTypes.AuthenticationTypes 
and [<RequireQualifiedAccess>] IPv4 =
  | IPv4 of OctetFour:Literal option * OctetOne:Literal option * OctetThree:Literal option * OctetTwo:Literal option 
  static member FromTs(src:ScriptDom.IPv4) : IPv4 =
    IPv4.IPv4((src.OctetFour |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetOne |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetThree |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OctetTwo |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] PortTypes =
  | PortTypes  
  static member FromTs(src:ScriptDom.PortTypes) : PortTypes =
    PortTypes.PortTypes 
and [<RequireQualifiedAccess>] EventDeclarationSetParameter =
  | EventDeclarationSetParameter of EventField:Identifier option * EventValue:ScalarExpression option 
  static member FromTs(src:ScriptDom.EventDeclarationSetParameter) : EventDeclarationSetParameter =
    EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EventNotificationTarget =
  | EventNotificationTarget  
  static member FromTs(src:ScriptDom.EventNotificationTarget) : EventNotificationTarget =
    EventNotificationTarget.EventNotificationTarget 
and [<RequireQualifiedAccess>] EventNotificationEventGroup =
  | EventNotificationEventGroup  
  static member FromTs(src:ScriptDom.EventNotificationEventGroup) : EventNotificationEventGroup =
    EventNotificationEventGroup.EventNotificationEventGroup 
and [<RequireQualifiedAccess>] EventNotificationEventType =
  | EventNotificationEventType  
  static member FromTs(src:ScriptDom.EventNotificationEventType) : EventNotificationEventType =
    EventNotificationEventType.EventNotificationEventType 
and [<RequireQualifiedAccess>] ExecuteParameter =
  | ExecuteParameter of IsOutput:bool * ParameterValue:ScalarExpression option * Variable:VariableReference option 
  static member FromTs(src:ScriptDom.ExecuteParameter) : ExecuteParameter =
    ExecuteParameter.ExecuteParameter((src.IsOutput) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AdHocDataSource =
  | AdHocDataSource of InitString:StringLiteral option * ProviderName:StringLiteral option 
  static member FromTs(src:ScriptDom.AdHocDataSource) : AdHocDataSource =
    AdHocDataSource.AdHocDataSource((src.InitString |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.ProviderName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ProcedureReferenceName =
  | ProcedureReferenceName of ProcedureReference:ProcedureReference option * ProcedureVariable:VariableReference option 
  static member FromTs(src:ScriptDom.ProcedureReferenceName) : ProcedureReferenceName =
    ProcedureReferenceName.ProcedureReferenceName((src.ProcedureReference |> Option.ofObj |> Option.map (ProcedureReference.FromTs)) (* 193 *), (src.ProcedureVariable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ExecuteAsOption =
  | ExecuteAsOption  
  static member FromTs(src:ScriptDom.ExecuteAsOption) : ExecuteAsOption =
    ExecuteAsOption.ExecuteAsOption 
and [<RequireQualifiedAccess>] ExecuteOptionKind =
  | ExecuteOptionKind  
  static member FromTs(src:ScriptDom.ExecuteOptionKind) : ExecuteOptionKind =
    ExecuteOptionKind.ExecuteOptionKind 
and [<RequireQualifiedAccess>] ResultSetsOptionKind =
  | ResultSetsOptionKind  
  static member FromTs(src:ScriptDom.ResultSetsOptionKind) : ResultSetsOptionKind =
    ResultSetsOptionKind.ResultSetsOptionKind 
and [<RequireQualifiedAccess>] VariableReference =
  | VariableReference of Collation:Identifier option * Name:String option 
  static member FromTs(src:ScriptDom.VariableReference) : VariableReference =
    VariableReference.VariableReference((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (Option.ofObj (src.Name)) (* 198 *))
and [<RequireQualifiedAccess>] ExecuteContext =
  | ExecuteContext of Kind:ScriptDom.ExecuteAsOption * Principal:ScalarExpression option 
  static member FromTs(src:ScriptDom.ExecuteContext) : ExecuteContext =
    ExecuteContext.ExecuteContext((src.Kind) (* 196 *), (src.Principal |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ExternalDataSourceOptionKind =
  | ExternalDataSourceOptionKind  
  static member FromTs(src:ScriptDom.ExternalDataSourceOptionKind) : ExternalDataSourceOptionKind =
    ExternalDataSourceOptionKind.ExternalDataSourceOptionKind 
and [<RequireQualifiedAccess>] ExternalFileFormatOptionKind =
  | ExternalFileFormatOptionKind  
  static member FromTs(src:ScriptDom.ExternalFileFormatOptionKind) : ExternalFileFormatOptionKind =
    ExternalFileFormatOptionKind.ExternalFileFormatOptionKind 
and [<RequireQualifiedAccess>] ExternalFileFormatUseDefaultType =
  | ExternalFileFormatUseDefaultType  
  static member FromTs(src:ScriptDom.ExternalFileFormatUseDefaultType) : ExternalFileFormatUseDefaultType =
    ExternalFileFormatUseDefaultType.ExternalFileFormatUseDefaultType 
and [<RequireQualifiedAccess>] ExternalResourcePoolAffinityType =
  | ExternalResourcePoolAffinityType  
  static member FromTs(src:ScriptDom.ExternalResourcePoolAffinityType) : ExternalResourcePoolAffinityType =
    ExternalResourcePoolAffinityType.ExternalResourcePoolAffinityType 
and [<RequireQualifiedAccess>] ExternalResourcePoolAffinitySpecification =
  | ExternalResourcePoolAffinitySpecification of AffinityType:ScriptDom.ExternalResourcePoolAffinityType * IsAuto:bool * ParameterValue:Literal option * PoolAffinityRanges:(LiteralRange) list 
  static member FromTs(src:ScriptDom.ExternalResourcePoolAffinitySpecification) : ExternalResourcePoolAffinitySpecification =
    ExternalResourcePoolAffinitySpecification.ExternalResourcePoolAffinitySpecification((src.AffinityType) (* 196 *), (src.IsAuto) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.PoolAffinityRanges |> Seq.map (LiteralRange.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ExternalResourcePoolParameterType =
  | ExternalResourcePoolParameterType  
  static member FromTs(src:ScriptDom.ExternalResourcePoolParameterType) : ExternalResourcePoolParameterType =
    ExternalResourcePoolParameterType.ExternalResourcePoolParameterType 
and [<RequireQualifiedAccess>] ExternalTableOptionKind =
  | ExternalTableOptionKind  
  static member FromTs(src:ScriptDom.ExternalTableOptionKind) : ExternalTableOptionKind =
    ExternalTableOptionKind.ExternalTableOptionKind 
and [<RequireQualifiedAccess>] ExternalTableRejectType =
  | ExternalTableRejectType  
  static member FromTs(src:ScriptDom.ExternalTableRejectType) : ExternalTableRejectType =
    ExternalTableRejectType.ExternalTableRejectType 
and [<RequireQualifiedAccess>] FetchOrientation =
  | FetchOrientation  
  static member FromTs(src:ScriptDom.FetchOrientation) : FetchOrientation =
    FetchOrientation.FetchOrientation 
and [<RequireQualifiedAccess>] FileDeclarationOptionKind =
  | FileDeclarationOptionKind  
  static member FromTs(src:ScriptDom.FileDeclarationOptionKind) : FileDeclarationOptionKind =
    FileDeclarationOptionKind.FileDeclarationOptionKind 
and [<RequireQualifiedAccess>] FileDeclaration =
  | FileDeclaration of IsPrimary:bool * Options:(FileDeclarationOption) list 
  static member FromTs(src:ScriptDom.FileDeclaration) : FileDeclaration =
    FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] JsonForClauseOption =
  | JsonForClauseOption of OptionKind:ScriptDom.JsonForClauseOptions * Value:Literal option 
  static member FromTs(src:ScriptDom.JsonForClauseOption) : JsonForClauseOption =
    JsonForClauseOption.JsonForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] JsonForClauseOptions =
  | JsonForClauseOptions  
  static member FromTs(src:ScriptDom.JsonForClauseOptions) : JsonForClauseOptions =
    JsonForClauseOptions.JsonForClauseOptions 
and [<RequireQualifiedAccess>] XmlForClauseOption =
  | XmlForClauseOption of OptionKind:ScriptDom.XmlForClauseOptions * Value:Literal option 
  static member FromTs(src:ScriptDom.XmlForClauseOption) : XmlForClauseOption =
    XmlForClauseOption.XmlForClauseOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] XmlForClauseOptions =
  | XmlForClauseOptions  
  static member FromTs(src:ScriptDom.XmlForClauseOptions) : XmlForClauseOptions =
    XmlForClauseOptions.XmlForClauseOptions 
and [<RequireQualifiedAccess>] FullTextCatalogOptionKind =
  | FullTextCatalogOptionKind  
  static member FromTs(src:ScriptDom.FullTextCatalogOptionKind) : FullTextCatalogOptionKind =
    FullTextCatalogOptionKind.FullTextCatalogOptionKind 
and [<RequireQualifiedAccess>] FullTextIndexOptionKind =
  | FullTextIndexOptionKind  
  static member FromTs(src:ScriptDom.FullTextIndexOptionKind) : FullTextIndexOptionKind =
    FullTextIndexOptionKind.FullTextIndexOptionKind 
and [<RequireQualifiedAccess>] ChangeTrackingOption =
  | ChangeTrackingOption  
  static member FromTs(src:ScriptDom.ChangeTrackingOption) : ChangeTrackingOption =
    ChangeTrackingOption.ChangeTrackingOption 
and [<RequireQualifiedAccess>] FunctionOptionKind =
  | FunctionOptionKind  
  static member FromTs(src:ScriptDom.FunctionOptionKind) : FunctionOptionKind =
    FunctionOptionKind.FunctionOptionKind 
and [<RequireQualifiedAccess>] ExecuteAsClause =
  | ExecuteAsClause of ExecuteAsOption:ScriptDom.ExecuteAsOption * Literal:Literal option 
  static member FromTs(src:ScriptDom.ExecuteAsClause) : ExecuteAsClause =
    ExecuteAsClause.ExecuteAsClause((src.ExecuteAsOption) (* 196 *), (src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DeclareTableVariableBody =
  | DeclareTableVariableBody of AsDefined:bool * Definition:TableDefinition option * VariableName:Identifier option 
  static member FromTs(src:ScriptDom.DeclareTableVariableBody) : DeclareTableVariableBody =
    DeclareTableVariableBody.DeclareTableVariableBody((src.AsDefined) (* 196 *), (src.Definition |> Option.ofObj |> Option.map (TableDefinition.FromTs)) (* 193 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] GridParameterType =
  | GridParameterType  
  static member FromTs(src:ScriptDom.GridParameterType) : GridParameterType =
    GridParameterType.GridParameterType 
and [<RequireQualifiedAccess>] ImportanceParameterType =
  | ImportanceParameterType  
  static member FromTs(src:ScriptDom.ImportanceParameterType) : ImportanceParameterType =
    ImportanceParameterType.ImportanceParameterType 
and [<RequireQualifiedAccess>] GroupByOption =
  | GroupByOption  
  static member FromTs(src:ScriptDom.GroupByOption) : GroupByOption =
    GroupByOption.GroupByOption 
and [<RequireQualifiedAccess>] QuoteType =
  | QuoteType  
  static member FromTs(src:ScriptDom.QuoteType) : QuoteType =
    QuoteType.QuoteType 
and [<RequireQualifiedAccess>] IndexOptionKind =
  | IndexOptionKind  
  static member FromTs(src:ScriptDom.IndexOptionKind) : IndexOptionKind =
    IndexOptionKind.IndexOptionKind 
and [<RequireQualifiedAccess>] CompressionDelayTimeUnit =
  | CompressionDelayTimeUnit  
  static member FromTs(src:ScriptDom.CompressionDelayTimeUnit) : CompressionDelayTimeUnit =
    CompressionDelayTimeUnit.CompressionDelayTimeUnit 
and [<RequireQualifiedAccess>] DataCompressionLevel =
  | DataCompressionLevel  
  static member FromTs(src:ScriptDom.DataCompressionLevel) : DataCompressionLevel =
    DataCompressionLevel.DataCompressionLevel 
and [<RequireQualifiedAccess>] CompressionPartitionRange =
  | CompressionPartitionRange of From:ScalarExpression option * To:ScalarExpression option 
  static member FromTs(src:ScriptDom.CompressionPartitionRange) : CompressionPartitionRange =
    CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] OnlineIndexLowPriorityLockWaitOption =
  | OnlineIndexLowPriorityLockWaitOption of Options:(LowPriorityLockWaitOption) list 
  static member FromTs(src:ScriptDom.OnlineIndexLowPriorityLockWaitOption) : OnlineIndexLowPriorityLockWaitOption =
    OnlineIndexLowPriorityLockWaitOption.OnlineIndexLowPriorityLockWaitOption((src.Options |> Seq.map (LowPriorityLockWaitOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] IndexTypeKind =
  | IndexTypeKind  
  static member FromTs(src:ScriptDom.IndexTypeKind) : IndexTypeKind =
    IndexTypeKind.IndexTypeKind 
and [<RequireQualifiedAccess>] NullNotNull =
  | NullNotNull  
  static member FromTs(src:ScriptDom.NullNotNull) : NullNotNull =
    NullNotNull.NullNotNull 
and [<RequireQualifiedAccess>] ExecuteSpecification =
  | ExecuteSpecification of ExecutableEntity:ExecutableEntity option * ExecuteContext:ExecuteContext option * LinkedServer:Identifier option * Variable:VariableReference option 
  static member FromTs(src:ScriptDom.ExecuteSpecification) : ExecuteSpecification =
    ExecuteSpecification.ExecuteSpecification((src.ExecutableEntity |> Option.ofObj |> Option.map (ExecutableEntity.FromTs)) (* 191 *), (src.ExecuteContext |> Option.ofObj |> Option.map (ExecuteContext.FromTs)) (* 193 *), (src.LinkedServer |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] RowValue =
  | RowValue of ColumnValues:(ScalarExpression) list 
  static member FromTs(src:ScriptDom.RowValue) : RowValue =
    RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] KeyOptionKind =
  | KeyOptionKind  
  static member FromTs(src:ScriptDom.KeyOptionKind) : KeyOptionKind =
    KeyOptionKind.KeyOptionKind 
and [<RequireQualifiedAccess>] LowPriorityLockWaitOptionKind =
  | LowPriorityLockWaitOptionKind  
  static member FromTs(src:ScriptDom.LowPriorityLockWaitOptionKind) : LowPriorityLockWaitOptionKind =
    LowPriorityLockWaitOptionKind.LowPriorityLockWaitOptionKind 
and [<RequireQualifiedAccess>] AbortAfterWaitType =
  | AbortAfterWaitType  
  static member FromTs(src:ScriptDom.AbortAfterWaitType) : AbortAfterWaitType =
    AbortAfterWaitType.AbortAfterWaitType 
and [<RequireQualifiedAccess>] ValuesInsertSource =
  | ValuesInsertSource of IsDefaultValues:bool * RowValues:(RowValue) list 
  static member FromTs(src:ScriptDom.ValuesInsertSource) : ValuesInsertSource =
    ValuesInsertSource.ValuesInsertSource((src.IsDefaultValues) (* 196 *), (src.RowValues |> Seq.map (fun src -> RowValue.RowValue((src.ColumnValues |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq))) |> List.ofSeq))
and [<RequireQualifiedAccess>] MergeCondition =
  | MergeCondition  
  static member FromTs(src:ScriptDom.MergeCondition) : MergeCondition =
    MergeCondition.MergeCondition 
and [<RequireQualifiedAccess>] DeviceInfo =
  | DeviceInfo of DeviceType:ScriptDom.DeviceType * LogicalDevice:IdentifierOrValueExpression option * PhysicalDevice:ValueExpression option 
  static member FromTs(src:ScriptDom.DeviceInfo) : DeviceInfo =
    DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] OptimizerHintKind =
  | OptimizerHintKind  
  static member FromTs(src:ScriptDom.OptimizerHintKind) : OptimizerHintKind =
    OptimizerHintKind.OptimizerHintKind 
and [<RequireQualifiedAccess>] VariableValuePair =
  | VariableValuePair of IsForUnknown:bool * Value:ScalarExpression option * Variable:VariableReference option 
  static member FromTs(src:ScriptDom.VariableValuePair) : VariableValuePair =
    VariableValuePair.VariableValuePair((src.IsForUnknown) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ExpressionWithSortOrder =
  | ExpressionWithSortOrder of Expression:ScalarExpression option * SortOrder:ScriptDom.SortOrder 
  static member FromTs(src:ScriptDom.ExpressionWithSortOrder) : ExpressionWithSortOrder =
    ExpressionWithSortOrder.ExpressionWithSortOrder((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SortOrder) (* 196 *))
and [<RequireQualifiedAccess>] OrderByClause =
  | OrderByClause of OrderByElements:(ExpressionWithSortOrder) list 
  static member FromTs(src:ScriptDom.OrderByClause) : OrderByClause =
    OrderByClause.OrderByClause((src.OrderByElements |> Seq.map (fun src -> ExpressionWithSortOrder.ExpressionWithSortOrder((src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SortOrder) (* 196 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] WindowFrameClause =
  | WindowFrameClause of Bottom:WindowDelimiter option * Top:WindowDelimiter option * WindowFrameType:ScriptDom.WindowFrameType 
  static member FromTs(src:ScriptDom.WindowFrameClause) : WindowFrameClause =
    WindowFrameClause.WindowFrameClause((src.Bottom |> Option.ofObj |> Option.map (WindowDelimiter.FromTs)) (* 193 *), (src.Top |> Option.ofObj |> Option.map (WindowDelimiter.FromTs)) (* 193 *), (src.WindowFrameType) (* 196 *))
and [<RequireQualifiedAccess>] PayloadOptionKinds =
  | PayloadOptionKinds  
  static member FromTs(src:ScriptDom.PayloadOptionKinds) : PayloadOptionKinds =
    PayloadOptionKinds.PayloadOptionKinds 
and [<RequireQualifiedAccess>] AuthenticationProtocol =
  | AuthenticationProtocol  
  static member FromTs(src:ScriptDom.AuthenticationProtocol) : AuthenticationProtocol =
    AuthenticationProtocol.AuthenticationProtocol 
and [<RequireQualifiedAccess>] EncryptionAlgorithmPreference =
  | EncryptionAlgorithmPreference  
  static member FromTs(src:ScriptDom.EncryptionAlgorithmPreference) : EncryptionAlgorithmPreference =
    EncryptionAlgorithmPreference.EncryptionAlgorithmPreference 
and [<RequireQualifiedAccess>] EndpointEncryptionSupport =
  | EndpointEncryptionSupport  
  static member FromTs(src:ScriptDom.EndpointEncryptionSupport) : EndpointEncryptionSupport =
    EndpointEncryptionSupport.EndpointEncryptionSupport 
and [<RequireQualifiedAccess>] DatabaseMirroringEndpointRole =
  | DatabaseMirroringEndpointRole  
  static member FromTs(src:ScriptDom.DatabaseMirroringEndpointRole) : DatabaseMirroringEndpointRole =
    DatabaseMirroringEndpointRole.DatabaseMirroringEndpointRole 
and [<RequireQualifiedAccess>] SoapMethodAction =
  | SoapMethodAction  
  static member FromTs(src:ScriptDom.SoapMethodAction) : SoapMethodAction =
    SoapMethodAction.SoapMethodAction 
and [<RequireQualifiedAccess>] SoapMethodFormat =
  | SoapMethodFormat  
  static member FromTs(src:ScriptDom.SoapMethodFormat) : SoapMethodFormat =
    SoapMethodFormat.SoapMethodFormat 
and [<RequireQualifiedAccess>] SoapMethodSchemas =
  | SoapMethodSchemas  
  static member FromTs(src:ScriptDom.SoapMethodSchemas) : SoapMethodSchemas =
    SoapMethodSchemas.SoapMethodSchemas 
and [<RequireQualifiedAccess>] PrincipalOptionKind =
  | PrincipalOptionKind  
  static member FromTs(src:ScriptDom.PrincipalOptionKind) : PrincipalOptionKind =
    PrincipalOptionKind.PrincipalOptionKind 
and [<RequireQualifiedAccess>] PrivilegeType80 =
  | PrivilegeType80  
  static member FromTs(src:ScriptDom.PrivilegeType80) : PrivilegeType80 =
    PrivilegeType80.PrivilegeType80 
and [<RequireQualifiedAccess>] ProcedureOptionKind =
  | ProcedureOptionKind  
  static member FromTs(src:ScriptDom.ProcedureOptionKind) : ProcedureOptionKind =
    ProcedureOptionKind.ProcedureOptionKind 
and [<RequireQualifiedAccess>] ProcedureReference =
  | ProcedureReference of Name:SchemaObjectName option * Number:Literal option 
  static member FromTs(src:ScriptDom.ProcedureReference) : ProcedureReference =
    ProcedureReference.ProcedureReference((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Number |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] OffsetClause =
  | OffsetClause of FetchExpression:ScalarExpression option * OffsetExpression:ScalarExpression option 
  static member FromTs(src:ScriptDom.OffsetClause) : OffsetClause =
    OffsetClause.OffsetClause((src.FetchExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.OffsetExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] BinaryQueryExpressionType =
  | BinaryQueryExpressionType  
  static member FromTs(src:ScriptDom.BinaryQueryExpressionType) : BinaryQueryExpressionType =
    BinaryQueryExpressionType.BinaryQueryExpressionType 
and [<RequireQualifiedAccess>] GroupByClause =
  | GroupByClause of All:bool * GroupByOption:ScriptDom.GroupByOption * GroupingSpecifications:(GroupingSpecification) list 
  static member FromTs(src:ScriptDom.GroupByClause) : GroupByClause =
    GroupByClause.GroupByClause((src.All) (* 196 *), (src.GroupByOption) (* 196 *), (src.GroupingSpecifications |> Seq.map (GroupingSpecification.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] HavingClause =
  | HavingClause of SearchCondition:BooleanExpression option 
  static member FromTs(src:ScriptDom.HavingClause) : HavingClause =
    HavingClause.HavingClause((src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] UniqueRowFilter =
  | UniqueRowFilter  
  static member FromTs(src:ScriptDom.UniqueRowFilter) : UniqueRowFilter =
    UniqueRowFilter.UniqueRowFilter 
and [<RequireQualifiedAccess>] QueryStoreOptionKind =
  | QueryStoreOptionKind  
  static member FromTs(src:ScriptDom.QueryStoreOptionKind) : QueryStoreOptionKind =
    QueryStoreOptionKind.QueryStoreOptionKind 
and [<RequireQualifiedAccess>] QueryStoreCapturePolicyOptionKind =
  | QueryStoreCapturePolicyOptionKind  
  static member FromTs(src:ScriptDom.QueryStoreCapturePolicyOptionKind) : QueryStoreCapturePolicyOptionKind =
    QueryStoreCapturePolicyOptionKind.QueryStoreCapturePolicyOptionKind 
and [<RequireQualifiedAccess>] QueryStoreDesiredStateOptionKind =
  | QueryStoreDesiredStateOptionKind  
  static member FromTs(src:ScriptDom.QueryStoreDesiredStateOptionKind) : QueryStoreDesiredStateOptionKind =
    QueryStoreDesiredStateOptionKind.QueryStoreDesiredStateOptionKind 
and [<RequireQualifiedAccess>] QueryStoreSizeCleanupPolicyOptionKind =
  | QueryStoreSizeCleanupPolicyOptionKind  
  static member FromTs(src:ScriptDom.QueryStoreSizeCleanupPolicyOptionKind) : QueryStoreSizeCleanupPolicyOptionKind =
    QueryStoreSizeCleanupPolicyOptionKind.QueryStoreSizeCleanupPolicyOptionKind 
and [<RequireQualifiedAccess>] QueueOptionKind =
  | QueueOptionKind  
  static member FromTs(src:ScriptDom.QueueOptionKind) : QueueOptionKind =
    QueueOptionKind.QueueOptionKind 
and [<RequireQualifiedAccess>] RemoteDataArchiveDatabaseSettingKind =
  | RemoteDataArchiveDatabaseSettingKind  
  static member FromTs(src:ScriptDom.RemoteDataArchiveDatabaseSettingKind) : RemoteDataArchiveDatabaseSettingKind =
    RemoteDataArchiveDatabaseSettingKind.RemoteDataArchiveDatabaseSettingKind 
and [<RequireQualifiedAccess>] RemoteServiceBindingOptionKind =
  | RemoteServiceBindingOptionKind  
  static member FromTs(src:ScriptDom.RemoteServiceBindingOptionKind) : RemoteServiceBindingOptionKind =
    RemoteServiceBindingOptionKind.RemoteServiceBindingOptionKind 
and [<RequireQualifiedAccess>] ResourcePoolAffinityType =
  | ResourcePoolAffinityType  
  static member FromTs(src:ScriptDom.ResourcePoolAffinityType) : ResourcePoolAffinityType =
    ResourcePoolAffinityType.ResourcePoolAffinityType 
and [<RequireQualifiedAccess>] ResourcePoolAffinitySpecification =
  | ResourcePoolAffinitySpecification of AffinityType:ScriptDom.ResourcePoolAffinityType * IsAuto:bool * ParameterValue:Literal option * PoolAffinityRanges:(LiteralRange) list 
  static member FromTs(src:ScriptDom.ResourcePoolAffinitySpecification) : ResourcePoolAffinitySpecification =
    ResourcePoolAffinitySpecification.ResourcePoolAffinitySpecification((src.AffinityType) (* 196 *), (src.IsAuto) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.PoolAffinityRanges |> Seq.map (LiteralRange.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ResourcePoolParameterType =
  | ResourcePoolParameterType  
  static member FromTs(src:ScriptDom.ResourcePoolParameterType) : ResourcePoolParameterType =
    ResourcePoolParameterType.ResourcePoolParameterType 
and [<RequireQualifiedAccess>] RestoreOptionKind =
  | RestoreOptionKind  
  static member FromTs(src:ScriptDom.RestoreOptionKind) : RestoreOptionKind =
    RestoreOptionKind.RestoreOptionKind 
and [<RequireQualifiedAccess>] FileStreamDatabaseOption =
  | FileStreamDatabaseOption of DirectoryName:Literal option * NonTransactedAccess:(ScriptDom.NonTransactedFileStreamAccess) option * OptionKind:ScriptDom.DatabaseOptionKind 
  static member FromTs(src:ScriptDom.FileStreamDatabaseOption) : FileStreamDatabaseOption =
    FileStreamDatabaseOption.FileStreamDatabaseOption((src.DirectoryName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (Option.ofNullable (src.NonTransactedAccess)), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] ResultSetType =
  | ResultSetType  
  static member FromTs(src:ScriptDom.ResultSetType) : ResultSetType =
    ResultSetType.ResultSetType 
and [<RequireQualifiedAccess>] ResultColumnDefinition =
  | ResultColumnDefinition of ColumnDefinition:ColumnDefinitionBase option * Nullable:NullableConstraintDefinition option 
  static member FromTs(src:ScriptDom.ResultColumnDefinition) : ResultColumnDefinition =
    ResultColumnDefinition.ResultColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] RouteOptionKind =
  | RouteOptionKind  
  static member FromTs(src:ScriptDom.RouteOptionKind) : RouteOptionKind =
    RouteOptionKind.RouteOptionKind 
and [<RequireQualifiedAccess>] BinaryExpressionType =
  | BinaryExpressionType  
  static member FromTs(src:ScriptDom.BinaryExpressionType) : BinaryExpressionType =
    BinaryExpressionType.BinaryExpressionType 
and [<RequireQualifiedAccess>] SearchedWhenClause =
  | SearchedWhenClause of ThenExpression:ScalarExpression option * WhenExpression:BooleanExpression option 
  static member FromTs(src:ScriptDom.SearchedWhenClause) : SearchedWhenClause =
    SearchedWhenClause.SearchedWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SimpleWhenClause =
  | SimpleWhenClause of ThenExpression:ScalarExpression option * WhenExpression:ScalarExpression option 
  static member FromTs(src:ScriptDom.SimpleWhenClause) : SimpleWhenClause =
    SimpleWhenClause.SimpleWhenClause((src.ThenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WhenExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ColumnType =
  | ColumnType  
  static member FromTs(src:ScriptDom.ColumnType) : ColumnType =
    ColumnType.ColumnType 
and [<RequireQualifiedAccess>] OverClause =
  | OverClause of OrderByClause:OrderByClause option * Partitions:(ScalarExpression) list * WindowFrameClause:WindowFrameClause option 
  static member FromTs(src:ScriptDom.OverClause) : OverClause =
    OverClause.OverClause((src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *), (src.Partitions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.WindowFrameClause |> Option.ofObj |> Option.map (WindowFrameClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] WithinGroupClause =
  | WithinGroupClause of OrderByClause:OrderByClause option 
  static member FromTs(src:ScriptDom.WithinGroupClause) : WithinGroupClause =
    WithinGroupClause.WithinGroupClause((src.OrderByClause |> Option.ofObj |> Option.map (OrderByClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ParameterlessCallType =
  | ParameterlessCallType  
  static member FromTs(src:ScriptDom.ParameterlessCallType) : ParameterlessCallType =
    ParameterlessCallType.ParameterlessCallType 
and [<RequireQualifiedAccess>] LiteralType =
  | LiteralType  
  static member FromTs(src:ScriptDom.LiteralType) : LiteralType =
    LiteralType.LiteralType 
and [<RequireQualifiedAccess>] OdbcLiteralType =
  | OdbcLiteralType  
  static member FromTs(src:ScriptDom.OdbcLiteralType) : OdbcLiteralType =
    OdbcLiteralType.OdbcLiteralType 
and [<RequireQualifiedAccess>] UnaryExpressionType =
  | UnaryExpressionType  
  static member FromTs(src:ScriptDom.UnaryExpressionType) : UnaryExpressionType =
    UnaryExpressionType.UnaryExpressionType 
and [<RequireQualifiedAccess>] IntegerLiteral =
  | IntegerLiteral of Collation:Identifier option * LiteralType:ScriptDom.LiteralType * Value:String option 
  static member FromTs(src:ScriptDom.IntegerLiteral) : IntegerLiteral =
    IntegerLiteral.IntegerLiteral((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.LiteralType) (* 196 *), (Option.ofObj (src.Value)) (* 198 *))
and [<RequireQualifiedAccess>] CommandOptions =
  | CommandOptions  
  static member FromTs(src:ScriptDom.CommandOptions) : CommandOptions =
    CommandOptions.CommandOptions 
and [<RequireQualifiedAccess>] Privilege80 =
  | Privilege80 of Columns:(Identifier) list * PrivilegeType80:ScriptDom.PrivilegeType80 
  static member FromTs(src:ScriptDom.Privilege80) : Privilege80 =
    Privilege80.Privilege80((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.PrivilegeType80) (* 196 *))
and [<RequireQualifiedAccess>] SecurityPolicyOptionKind =
  | SecurityPolicyOptionKind  
  static member FromTs(src:ScriptDom.SecurityPolicyOptionKind) : SecurityPolicyOptionKind =
    SecurityPolicyOptionKind.SecurityPolicyOptionKind 
and [<RequireQualifiedAccess>] SecurityPredicateActionType =
  | SecurityPredicateActionType  
  static member FromTs(src:ScriptDom.SecurityPredicateActionType) : SecurityPredicateActionType =
    SecurityPredicateActionType.SecurityPredicateActionType 
and [<RequireQualifiedAccess>] FunctionCall =
  | FunctionCall of CallTarget:CallTarget option * Collation:Identifier option * FunctionName:Identifier option * OverClause:OverClause option * Parameters:(ScalarExpression) list * UniqueRowFilter:ScriptDom.UniqueRowFilter * WithinGroupClause:WithinGroupClause option 
  static member FromTs(src:ScriptDom.FunctionCall) : FunctionCall =
    FunctionCall.FunctionCall((src.CallTarget |> Option.ofObj |> Option.map (CallTarget.FromTs)) (* 191 *), (src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FunctionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.OverClause |> Option.ofObj |> Option.map (OverClause.FromTs)) (* 193 *), (src.Parameters |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.UniqueRowFilter) (* 196 *), (src.WithinGroupClause |> Option.ofObj |> Option.map (WithinGroupClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SecurityPredicateOperation =
  | SecurityPredicateOperation  
  static member FromTs(src:ScriptDom.SecurityPredicateOperation) : SecurityPredicateOperation =
    SecurityPredicateOperation.SecurityPredicateOperation 
and [<RequireQualifiedAccess>] SecurityPredicateType =
  | SecurityPredicateType  
  static member FromTs(src:ScriptDom.SecurityPredicateType) : SecurityPredicateType =
    SecurityPredicateType.SecurityPredicateType 
and [<RequireQualifiedAccess>] PrincipalType =
  | PrincipalType  
  static member FromTs(src:ScriptDom.PrincipalType) : PrincipalType =
    PrincipalType.PrincipalType 
and [<RequireQualifiedAccess>] SecurityObjectKind =
  | SecurityObjectKind  
  static member FromTs(src:ScriptDom.SecurityObjectKind) : SecurityObjectKind =
    SecurityObjectKind.SecurityObjectKind 
and [<RequireQualifiedAccess>] SecurityTargetObjectName =
  | SecurityTargetObjectName of MultiPartIdentifier:MultiPartIdentifier option 
  static member FromTs(src:ScriptDom.SecurityTargetObjectName) : SecurityTargetObjectName =
    SecurityTargetObjectName.SecurityTargetObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] UserType80 =
  | UserType80  
  static member FromTs(src:ScriptDom.UserType80) : UserType80 =
    UserType80.UserType80 
and [<RequireQualifiedAccess>] AssignmentKind =
  | AssignmentKind  
  static member FromTs(src:ScriptDom.AssignmentKind) : AssignmentKind =
    AssignmentKind.AssignmentKind 
and [<RequireQualifiedAccess>] SequenceOptionKind =
  | SequenceOptionKind  
  static member FromTs(src:ScriptDom.SequenceOptionKind) : SequenceOptionKind =
    SequenceOptionKind.SequenceOptionKind 
and [<RequireQualifiedAccess>] AlterAction =
  | AlterAction  
  static member FromTs(src:ScriptDom.AlterAction) : AlterAction =
    AlterAction.AlterAction 
and [<RequireQualifiedAccess>] SessionOptionKind =
  | SessionOptionKind  
  static member FromTs(src:ScriptDom.SessionOptionKind) : SessionOptionKind =
    SessionOptionKind.SessionOptionKind 
and [<RequireQualifiedAccess>] EventSessionEventRetentionModeType =
  | EventSessionEventRetentionModeType  
  static member FromTs(src:ScriptDom.EventSessionEventRetentionModeType) : EventSessionEventRetentionModeType =
    EventSessionEventRetentionModeType.EventSessionEventRetentionModeType 
and [<RequireQualifiedAccess>] EventSessionMemoryPartitionModeType =
  | EventSessionMemoryPartitionModeType  
  static member FromTs(src:ScriptDom.EventSessionMemoryPartitionModeType) : EventSessionMemoryPartitionModeType =
    EventSessionMemoryPartitionModeType.EventSessionMemoryPartitionModeType 
and [<RequireQualifiedAccess>] GeneralSetCommandType =
  | GeneralSetCommandType  
  static member FromTs(src:ScriptDom.GeneralSetCommandType) : GeneralSetCommandType =
    GeneralSetCommandType.GeneralSetCommandType 
and [<RequireQualifiedAccess>] FipsComplianceLevel =
  | FipsComplianceLevel  
  static member FromTs(src:ScriptDom.FipsComplianceLevel) : FipsComplianceLevel =
    FipsComplianceLevel.FipsComplianceLevel 
and [<RequireQualifiedAccess>] BoundingBoxParameter =
  | BoundingBoxParameter of Parameter:ScriptDom.BoundingBoxParameterType * Value:ScalarExpression option 
  static member FromTs(src:ScriptDom.BoundingBoxParameter) : BoundingBoxParameter =
    BoundingBoxParameter.BoundingBoxParameter((src.Parameter) (* 196 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] GridParameter =
  | GridParameter of Parameter:ScriptDom.GridParameterType * Value:ScriptDom.ImportanceParameterType 
  static member FromTs(src:ScriptDom.GridParameter) : GridParameter =
    GridParameter.GridParameter((src.Parameter) (* 196 *), (src.Value) (* 196 *))
and [<RequireQualifiedAccess>] StatisticsOptionKind =
  | StatisticsOptionKind  
  static member FromTs(src:ScriptDom.StatisticsOptionKind) : StatisticsOptionKind =
    StatisticsOptionKind.StatisticsOptionKind 
and [<RequireQualifiedAccess>] StatisticsPartitionRange =
  | StatisticsPartitionRange of From:IntegerLiteral option * To:IntegerLiteral option 
  static member FromTs(src:ScriptDom.StatisticsPartitionRange) : StatisticsPartitionRange =
    StatisticsPartitionRange.StatisticsPartitionRange((src.From |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.To |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] TSqlBatch =
  | TSqlBatch of Statements:(TSqlStatement) list 
  static member FromTs(src:ScriptDom.TSqlBatch) : TSqlBatch =
    TSqlBatch.TSqlBatch((src.Statements |> Seq.map (TSqlStatement.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] AlterCertificateStatementKind =
  | AlterCertificateStatementKind  
  static member FromTs(src:ScriptDom.AlterCertificateStatementKind) : AlterCertificateStatementKind =
    AlterCertificateStatementKind.AlterCertificateStatementKind 
and [<RequireQualifiedAccess>] EndpointAffinity =
  | EndpointAffinity of Kind:ScriptDom.AffinityKind * Value:Literal option 
  static member FromTs(src:ScriptDom.EndpointAffinity) : EndpointAffinity =
    EndpointAffinity.EndpointAffinity((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EndpointType =
  | EndpointType  
  static member FromTs(src:ScriptDom.EndpointType) : EndpointType =
    EndpointType.EndpointType 
and [<RequireQualifiedAccess>] EndpointProtocol =
  | EndpointProtocol  
  static member FromTs(src:ScriptDom.EndpointProtocol) : EndpointProtocol =
    EndpointProtocol.EndpointProtocol 
and [<RequireQualifiedAccess>] EndpointState =
  | EndpointState  
  static member FromTs(src:ScriptDom.EndpointState) : EndpointState =
    EndpointState.EndpointState 
and [<RequireQualifiedAccess>] ServiceContract =
  | ServiceContract of Action:ScriptDom.AlterAction * Name:Identifier option 
  static member FromTs(src:ScriptDom.ServiceContract) : ServiceContract =
    ServiceContract.ServiceContract((src.Action) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EnableDisableOptionType =
  | EnableDisableOptionType  
  static member FromTs(src:ScriptDom.EnableDisableOptionType) : EnableDisableOptionType =
    EnableDisableOptionType.EnableDisableOptionType 
and [<RequireQualifiedAccess>] DatabaseConfigurationClearOption =
  | DatabaseConfigurationClearOption of OptionKind:ScriptDom.DatabaseConfigClearOptionKind 
  static member FromTs(src:ScriptDom.DatabaseConfigurationClearOption) : DatabaseConfigurationClearOption =
    DatabaseConfigurationClearOption.DatabaseConfigurationClearOption((src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] AlterDatabaseTermination =
  | AlterDatabaseTermination of ImmediateRollback:bool * NoWait:bool * RollbackAfter:Literal option 
  static member FromTs(src:ScriptDom.AlterDatabaseTermination) : AlterDatabaseTermination =
    AlterDatabaseTermination.AlterDatabaseTermination((src.ImmediateRollback) (* 196 *), (src.NoWait) (* 196 *), (src.RollbackAfter |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ModifyFileGroupOption =
  | ModifyFileGroupOption  
  static member FromTs(src:ScriptDom.ModifyFileGroupOption) : ModifyFileGroupOption =
    ModifyFileGroupOption.ModifyFileGroupOption 
and [<RequireQualifiedAccess>] AlterFederationKind =
  | AlterFederationKind  
  static member FromTs(src:ScriptDom.AlterFederationKind) : AlterFederationKind =
    AlterFederationKind.AlterFederationKind 
and [<RequireQualifiedAccess>] FullTextStopListAction =
  | FullTextStopListAction of IsAdd:bool * IsAll:bool * LanguageTerm:IdentifierOrValueExpression option * StopWord:Literal option 
  static member FromTs(src:ScriptDom.FullTextStopListAction) : FullTextStopListAction =
    FullTextStopListAction.FullTextStopListAction((src.IsAdd) (* 196 *), (src.IsAll) (* 196 *), (src.LanguageTerm |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.StopWord |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterResourceGovernorCommandType =
  | AlterResourceGovernorCommandType  
  static member FromTs(src:ScriptDom.AlterResourceGovernorCommandType) : AlterResourceGovernorCommandType =
    AlterResourceGovernorCommandType.AlterResourceGovernorCommandType 
and [<RequireQualifiedAccess>] AlterServerConfigurationFailoverClusterPropertyOption =
  | AlterServerConfigurationFailoverClusterPropertyOption of OptionKind:ScriptDom.AlterServerConfigurationFailoverClusterPropertyOptionKind * OptionValue:OptionValue option 
  static member FromTs(src:ScriptDom.AlterServerConfigurationFailoverClusterPropertyOption) : AlterServerConfigurationFailoverClusterPropertyOption =
    AlterServerConfigurationFailoverClusterPropertyOption.AlterServerConfigurationFailoverClusterPropertyOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterServerConfigurationHadrClusterOption =
  | AlterServerConfigurationHadrClusterOption of IsLocal:bool * OptionKind:ScriptDom.AlterServerConfigurationHadrClusterOptionKind * OptionValue:OptionValue option 
  static member FromTs(src:ScriptDom.AlterServerConfigurationHadrClusterOption) : AlterServerConfigurationHadrClusterOption =
    AlterServerConfigurationHadrClusterOption.AlterServerConfigurationHadrClusterOption((src.IsLocal) (* 196 *), (src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterServerConfigurationSoftNumaOption =
  | AlterServerConfigurationSoftNumaOption of OptionKind:ScriptDom.AlterServerConfigurationSoftNumaOptionKind * OptionValue:OptionValue option 
  static member FromTs(src:ScriptDom.AlterServerConfigurationSoftNumaOption) : AlterServerConfigurationSoftNumaOption =
    AlterServerConfigurationSoftNumaOption.AlterServerConfigurationSoftNumaOption((src.OptionKind) (* 196 *), (src.OptionValue |> Option.ofObj |> Option.map (OptionValue.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ProcessAffinityType =
  | ProcessAffinityType  
  static member FromTs(src:ScriptDom.ProcessAffinityType) : ProcessAffinityType =
    ProcessAffinityType.ProcessAffinityType 
and [<RequireQualifiedAccess>] ProcessAffinityRange =
  | ProcessAffinityRange of From:Literal option * To:Literal option 
  static member FromTs(src:ScriptDom.ProcessAffinityRange) : ProcessAffinityRange =
    ProcessAffinityRange.ProcessAffinityRange((src.From |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AlterServiceMasterKeyOption =
  | AlterServiceMasterKeyOption  
  static member FromTs(src:ScriptDom.AlterServiceMasterKeyOption) : AlterServiceMasterKeyOption =
    AlterServiceMasterKeyOption.AlterServiceMasterKeyOption 
and [<RequireQualifiedAccess>] ConstraintEnforcement =
  | ConstraintEnforcement  
  static member FromTs(src:ScriptDom.ConstraintEnforcement) : ConstraintEnforcement =
    ConstraintEnforcement.ConstraintEnforcement 
and [<RequireQualifiedAccess>] AlterTableAlterColumnOption =
  | AlterTableAlterColumnOption  
  static member FromTs(src:ScriptDom.AlterTableAlterColumnOption) : AlterTableAlterColumnOption =
    AlterTableAlterColumnOption.AlterTableAlterColumnOption 
and [<RequireQualifiedAccess>] AlterIndexType =
  | AlterIndexType  
  static member FromTs(src:ScriptDom.AlterIndexType) : AlterIndexType =
    AlterIndexType.AlterIndexType 
and [<RequireQualifiedAccess>] AlterTableDropTableElement =
  | AlterTableDropTableElement of DropClusteredConstraintOptions:(DropClusteredConstraintOption) list * IsIfExists:bool * Name:Identifier option * TableElementType:ScriptDom.TableElementType 
  static member FromTs(src:ScriptDom.AlterTableDropTableElement) : AlterTableDropTableElement =
    AlterTableDropTableElement.AlterTableDropTableElement((src.DropClusteredConstraintOptions |> Seq.map (DropClusteredConstraintOption.FromTs) |> List.ofSeq), (src.IsIfExists) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableElementType) (* 196 *))
and [<RequireQualifiedAccess>] PartitionSpecifier =
  | PartitionSpecifier of All:bool * Number:ScalarExpression option 
  static member FromTs(src:ScriptDom.PartitionSpecifier) : PartitionSpecifier =
    PartitionSpecifier.PartitionSpecifier((src.All) (* 196 *), (src.Number |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] TriggerEnforcement =
  | TriggerEnforcement  
  static member FromTs(src:ScriptDom.TriggerEnforcement) : TriggerEnforcement =
    TriggerEnforcement.TriggerEnforcement 
and [<RequireQualifiedAccess>] ApplicationRoleOption =
  | ApplicationRoleOption of OptionKind:ScriptDom.ApplicationRoleOptionKind * Value:IdentifierOrValueExpression option 
  static member FromTs(src:ScriptDom.ApplicationRoleOption) : ApplicationRoleOption =
    ApplicationRoleOption.ApplicationRoleOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AddFileSpec =
  | AddFileSpec of File:ScalarExpression option * FileName:Literal option 
  static member FromTs(src:ScriptDom.AddFileSpec) : AddFileSpec =
    AddFileSpec.AddFileSpec((src.File |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.FileName |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] AuditSpecificationPart =
  | AuditSpecificationPart of Details:AuditSpecificationDetail option * IsDrop:bool 
  static member FromTs(src:ScriptDom.AuditSpecificationPart) : AuditSpecificationPart =
    AuditSpecificationPart.AuditSpecificationPart((src.Details |> Option.ofObj |> Option.map (AuditSpecificationDetail.FromTs)) (* 191 *), (src.IsDrop) (* 196 *))
and [<RequireQualifiedAccess>] AvailabilityReplica =
  | AvailabilityReplica of Options:(AvailabilityReplicaOption) list * ServerName:StringLiteral option 
  static member FromTs(src:ScriptDom.AvailabilityReplica) : AvailabilityReplica =
    AvailabilityReplica.AvailabilityReplica((src.Options |> Seq.map (AvailabilityReplicaOption.FromTs) |> List.ofSeq), (src.ServerName |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AlterAvailabilityGroupStatementType =
  | AlterAvailabilityGroupStatementType  
  static member FromTs(src:ScriptDom.AlterAvailabilityGroupStatementType) : AlterAvailabilityGroupStatementType =
    AlterAvailabilityGroupStatementType.AlterAvailabilityGroupStatementType 
and [<RequireQualifiedAccess>] MirrorToClause =
  | MirrorToClause of Devices:(DeviceInfo) list 
  static member FromTs(src:ScriptDom.MirrorToClause) : MirrorToClause =
    MirrorToClause.MirrorToClause((src.Devices |> Seq.map (fun src -> DeviceInfo.DeviceInfo((src.DeviceType) (* 196 *), (src.LogicalDevice |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *), (src.PhysicalDevice |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] BackupRestoreFileInfo =
  | BackupRestoreFileInfo of ItemKind:ScriptDom.BackupRestoreItemKind * Items:(ValueExpression) list 
  static member FromTs(src:ScriptDom.BackupRestoreFileInfo) : BackupRestoreFileInfo =
    BackupRestoreFileInfo.BackupRestoreFileInfo((src.ItemKind) (* 196 *), (src.Items |> Seq.map (ValueExpression.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] BrokerPriorityParameter =
  | BrokerPriorityParameter of IsDefaultOrAny:ScriptDom.BrokerPriorityParameterSpecialType * ParameterType:ScriptDom.BrokerPriorityParameterType * ParameterValue:IdentifierOrValueExpression option 
  static member FromTs(src:ScriptDom.BrokerPriorityParameter) : BrokerPriorityParameter =
    BrokerPriorityParameter.BrokerPriorityParameter((src.IsDefaultOrAny) (* 196 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] InsertBulkColumnDefinition =
  | InsertBulkColumnDefinition of Column:ColumnDefinitionBase option * NullNotNull:ScriptDom.NullNotNull 
  static member FromTs(src:ScriptDom.InsertBulkColumnDefinition) : InsertBulkColumnDefinition =
    InsertBulkColumnDefinition.InsertBulkColumnDefinition((src.Column |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullNotNull) (* 196 *))
and [<RequireQualifiedAccess>] CertificateOption =
  | CertificateOption of Kind:ScriptDom.CertificateOptionKinds * Value:Literal option 
  static member FromTs(src:ScriptDom.CertificateOption) : CertificateOption =
    CertificateOption.CertificateOption((src.Kind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ColumnEncryptionKeyValue =
  | ColumnEncryptionKeyValue of Parameters:(ColumnEncryptionKeyValueParameter) list 
  static member FromTs(src:ScriptDom.ColumnEncryptionKeyValue) : ColumnEncryptionKeyValue =
    ColumnEncryptionKeyValue.ColumnEncryptionKeyValue((src.Parameters |> Seq.map (ColumnEncryptionKeyValueParameter.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] ColumnEncryptionKeyAlterType =
  | ColumnEncryptionKeyAlterType  
  static member FromTs(src:ScriptDom.ColumnEncryptionKeyAlterType) : ColumnEncryptionKeyAlterType =
    ColumnEncryptionKeyAlterType.ColumnEncryptionKeyAlterType 
and [<RequireQualifiedAccess>] AssemblyName =
  | AssemblyName of ClassName:Identifier option * Name:Identifier option 
  static member FromTs(src:ScriptDom.AssemblyName) : AssemblyName =
    AssemblyName.AssemblyName((src.ClassName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ProcedureParameter =
  | ProcedureParameter of DataType:DataTypeReference option * IsVarying:bool * Modifier:ScriptDom.ParameterModifier * Nullable:NullableConstraintDefinition option * Value:ScalarExpression option * VariableName:Identifier option 
  static member FromTs(src:ScriptDom.ProcedureParameter) : ProcedureParameter =
    ProcedureParameter.ProcedureParameter((src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.IsVarying) (* 196 *), (src.Modifier) (* 196 *), (src.Nullable |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.VariableName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ContractMessage =
  | ContractMessage of Name:Identifier option * SentBy:ScriptDom.MessageSender 
  static member FromTs(src:ScriptDom.ContractMessage) : ContractMessage =
    ContractMessage.ContractMessage((src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.SentBy) (* 196 *))
and [<RequireQualifiedAccess>] AttachMode =
  | AttachMode  
  static member FromTs(src:ScriptDom.AttachMode) : AttachMode =
    AttachMode.AttachMode 
and [<RequireQualifiedAccess>] ContainmentDatabaseOption =
  | ContainmentDatabaseOption of OptionKind:ScriptDom.DatabaseOptionKind * Value:ScriptDom.ContainmentOptionKind 
  static member FromTs(src:ScriptDom.ContainmentDatabaseOption) : ContainmentDatabaseOption =
    ContainmentDatabaseOption.ContainmentDatabaseOption((src.OptionKind) (* 196 *), (src.Value) (* 196 *))
and [<RequireQualifiedAccess>] FileGroupDefinition =
  | FileGroupDefinition of ContainsFileStream:bool * ContainsMemoryOptimizedData:bool * FileDeclarations:(FileDeclaration) list * IsDefault:bool * Name:Identifier option 
  static member FromTs(src:ScriptDom.FileGroupDefinition) : FileGroupDefinition =
    FileGroupDefinition.FileGroupDefinition((src.ContainsFileStream) (* 196 *), (src.ContainsMemoryOptimizedData) (* 196 *), (src.FileDeclarations |> Seq.map (fun src -> FileDeclaration.FileDeclaration((src.IsPrimary) (* 196 *), (src.Options |> Seq.map (FileDeclarationOption.FromTs) |> List.ofSeq))) |> List.ofSeq), (src.IsDefault) (* 196 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] EventNotificationObjectScope =
  | EventNotificationObjectScope of QueueName:SchemaObjectName option * Target:ScriptDom.EventNotificationTarget 
  static member FromTs(src:ScriptDom.EventNotificationObjectScope) : EventNotificationObjectScope =
    EventNotificationObjectScope.EventNotificationObjectScope((src.QueueName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.Target) (* 196 *))
and [<RequireQualifiedAccess>] FullTextCatalogAndFileGroup =
  | FullTextCatalogAndFileGroup of CatalogName:Identifier option * FileGroupIsFirst:bool * FileGroupName:Identifier option 
  static member FromTs(src:ScriptDom.FullTextCatalogAndFileGroup) : FullTextCatalogAndFileGroup =
    FullTextCatalogAndFileGroup.FullTextCatalogAndFileGroup((src.CatalogName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.FileGroupIsFirst) (* 196 *), (src.FileGroupName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] PartitionParameterType =
  | PartitionParameterType of Collation:Identifier option * DataType:DataTypeReference option 
  static member FromTs(src:ScriptDom.PartitionParameterType) : PartitionParameterType =
    PartitionParameterType.PartitionParameterType((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] PartitionFunctionRange =
  | PartitionFunctionRange  
  static member FromTs(src:ScriptDom.PartitionFunctionRange) : PartitionFunctionRange =
    PartitionFunctionRange.PartitionFunctionRange 
and [<RequireQualifiedAccess>] SpatialIndexingSchemeType =
  | SpatialIndexingSchemeType  
  static member FromTs(src:ScriptDom.SpatialIndexingSchemeType) : SpatialIndexingSchemeType =
    SpatialIndexingSchemeType.SpatialIndexingSchemeType 
and [<RequireQualifiedAccess>] FederationScheme =
  | FederationScheme of ColumnName:Identifier option * DistributionName:Identifier option 
  static member FromTs(src:ScriptDom.FederationScheme) : FederationScheme =
    FederationScheme.FederationScheme((src.ColumnName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.DistributionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] CursorId =
  | CursorId of IsGlobal:bool * Name:IdentifierOrValueExpression option 
  static member FromTs(src:ScriptDom.CursorId) : CursorId =
    CursorId.CursorId((src.IsGlobal) (* 196 *), (src.Name |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] FetchType =
  | FetchType of Orientation:ScriptDom.FetchOrientation * RowOffset:ScalarExpression option 
  static member FromTs(src:ScriptDom.FetchType) : FetchType =
    FetchType.FetchType((src.Orientation) (* 196 *), (src.RowOffset |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DatabaseEncryptionKeyAlgorithm =
  | DatabaseEncryptionKeyAlgorithm  
  static member FromTs(src:ScriptDom.DatabaseEncryptionKeyAlgorithm) : DatabaseEncryptionKeyAlgorithm =
    DatabaseEncryptionKeyAlgorithm.DatabaseEncryptionKeyAlgorithm 
and [<RequireQualifiedAccess>] DbccCommand =
  | DbccCommand  
  static member FromTs(src:ScriptDom.DbccCommand) : DbccCommand =
    DbccCommand.DbccCommand 
and [<RequireQualifiedAccess>] DbccNamedLiteral =
  | DbccNamedLiteral of Name:String option * Value:ScalarExpression option 
  static member FromTs(src:ScriptDom.DbccNamedLiteral) : DbccNamedLiteral =
    DbccNamedLiteral.DbccNamedLiteral((Option.ofObj (src.Name)) (* 198 *), (src.Value |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DbccOption =
  | DbccOption of OptionKind:ScriptDom.DbccOptionKind 
  static member FromTs(src:ScriptDom.DbccOption) : DbccOption =
    DbccOption.DbccOption((src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] CursorDefinition =
  | CursorDefinition of Options:(CursorOption) list * Select:SelectStatement option 
  static member FromTs(src:ScriptDom.CursorDefinition) : CursorDefinition =
    CursorDefinition.CursorDefinition((src.Options |> Seq.map (fun src -> CursorOption.CursorOption((src.OptionKind) (* 196 *))) |> List.ofSeq), (src.Select |> Option.ofObj |> Option.map (SelectStatement.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] DiskStatementType =
  | DiskStatementType  
  static member FromTs(src:ScriptDom.DiskStatementType) : DiskStatementType =
    DiskStatementType.DiskStatementType 
and [<RequireQualifiedAccess>] DiskStatementOption =
  | DiskStatementOption of OptionKind:ScriptDom.DiskStatementOptionKind * Value:IdentifierOrValueExpression option 
  static member FromTs(src:ScriptDom.DiskStatementOption) : DiskStatementOption =
    DiskStatementOption.DiskStatementOption((src.OptionKind) (* 196 *), (src.Value |> Option.ofObj |> Option.map (IdentifierOrValueExpression.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] TriggerScope =
  | TriggerScope  
  static member FromTs(src:ScriptDom.TriggerScope) : TriggerScope =
    TriggerScope.TriggerScope 
and [<RequireQualifiedAccess>] DropSchemaBehavior =
  | DropSchemaBehavior  
  static member FromTs(src:ScriptDom.DropSchemaBehavior) : DropSchemaBehavior =
    DropSchemaBehavior.DropSchemaBehavior 
and [<RequireQualifiedAccess>] EventSessionScope =
  | EventSessionScope  
  static member FromTs(src:ScriptDom.EventSessionScope) : EventSessionScope =
    EventSessionScope.EventSessionScope 
and [<RequireQualifiedAccess>] TriggerObject =
  | TriggerObject of Name:SchemaObjectName option * TriggerScope:ScriptDom.TriggerScope 
  static member FromTs(src:ScriptDom.TriggerObject) : TriggerObject =
    TriggerObject.TriggerObject((src.Name |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.TriggerScope) (* 196 *))
and [<RequireQualifiedAccess>] EventDeclaration =
  | EventDeclaration of EventDeclarationActionParameters:(EventSessionObjectName) list * EventDeclarationPredicateParameter:BooleanExpression option * EventDeclarationSetParameters:(EventDeclarationSetParameter) list * ObjectName:EventSessionObjectName option 
  static member FromTs(src:ScriptDom.EventDeclaration) : EventDeclaration =
    EventDeclaration.EventDeclaration((src.EventDeclarationActionParameters |> Seq.map (fun src -> EventSessionObjectName.EventSessionObjectName((src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.EventDeclarationPredicateParameter |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.EventDeclarationSetParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] TargetDeclaration =
  | TargetDeclaration of ObjectName:EventSessionObjectName option * TargetDeclarationParameters:(EventDeclarationSetParameter) list 
  static member FromTs(src:ScriptDom.TargetDeclaration) : TargetDeclaration =
    TargetDeclaration.TargetDeclaration((src.ObjectName |> Option.ofObj |> Option.map (EventSessionObjectName.FromTs)) (* 193 *), (src.TargetDeclarationParameters |> Seq.map (fun src -> EventDeclarationSetParameter.EventDeclarationSetParameter((src.EventField |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.EventValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] AlterEventSessionStatementType =
  | AlterEventSessionStatementType  
  static member FromTs(src:ScriptDom.AlterEventSessionStatementType) : AlterEventSessionStatementType =
    AlterEventSessionStatementType.AlterEventSessionStatementType 
and [<RequireQualifiedAccess>] ExternalDataSourceType =
  | ExternalDataSourceType  
  static member FromTs(src:ScriptDom.ExternalDataSourceType) : ExternalDataSourceType =
    ExternalDataSourceType.ExternalDataSourceType 
and [<RequireQualifiedAccess>] ExternalFileFormatType =
  | ExternalFileFormatType  
  static member FromTs(src:ScriptDom.ExternalFileFormatType) : ExternalFileFormatType =
    ExternalFileFormatType.ExternalFileFormatType 
and [<RequireQualifiedAccess>] ExternalResourcePoolParameter =
  | ExternalResourcePoolParameter of AffinitySpecification:ExternalResourcePoolAffinitySpecification option * ParameterType:ScriptDom.ExternalResourcePoolParameterType * ParameterValue:Literal option 
  static member FromTs(src:ScriptDom.ExternalResourcePoolParameter) : ExternalResourcePoolParameter =
    ExternalResourcePoolParameter.ExternalResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ExternalResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] ExternalTableColumnDefinition =
  | ExternalTableColumnDefinition of ColumnDefinition:ColumnDefinitionBase option * NullableConstraint:NullableConstraintDefinition option 
  static member FromTs(src:ScriptDom.ExternalTableColumnDefinition) : ExternalTableColumnDefinition =
    ExternalTableColumnDefinition.ExternalTableColumnDefinition((src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.NullableConstraint |> Option.ofObj |> Option.map (NullableConstraintDefinition.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] AlterFullTextCatalogAction =
  | AlterFullTextCatalogAction  
  static member FromTs(src:ScriptDom.AlterFullTextCatalogAction) : AlterFullTextCatalogAction =
    AlterFullTextCatalogAction.AlterFullTextCatalogAction 
and [<RequireQualifiedAccess>] SelectiveXmlIndexPromotedPath =
  | SelectiveXmlIndexPromotedPath of IsSingleton:bool * MaxLength:IntegerLiteral option * Name:Identifier option * Path:Literal option * SQLDataType:DataTypeReference option * XQueryDataType:Literal option 
  static member FromTs(src:ScriptDom.SelectiveXmlIndexPromotedPath) : SelectiveXmlIndexPromotedPath =
    SelectiveXmlIndexPromotedPath.SelectiveXmlIndexPromotedPath((src.IsSingleton) (* 196 *), (src.MaxLength |> Option.ofObj |> Option.map (IntegerLiteral.FromTs)) (* 193 *), (src.Name |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Path |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.SQLDataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.XQueryDataType |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] XmlNamespaces =
  | XmlNamespaces of XmlNamespacesElements:(XmlNamespacesElement) list 
  static member FromTs(src:ScriptDom.XmlNamespaces) : XmlNamespaces =
    XmlNamespaces.XmlNamespaces((src.XmlNamespacesElements |> Seq.map (XmlNamespacesElement.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] SecondaryXmlIndexType =
  | SecondaryXmlIndexType  
  static member FromTs(src:ScriptDom.SecondaryXmlIndexType) : SecondaryXmlIndexType =
    SecondaryXmlIndexType.SecondaryXmlIndexType 
and [<RequireQualifiedAccess>] AlterMasterKeyOption =
  | AlterMasterKeyOption  
  static member FromTs(src:ScriptDom.AlterMasterKeyOption) : AlterMasterKeyOption =
    AlterMasterKeyOption.AlterMasterKeyOption 
and [<RequireQualifiedAccess>] MessageValidationMethod =
  | MessageValidationMethod  
  static member FromTs(src:ScriptDom.MessageValidationMethod) : MessageValidationMethod =
    MessageValidationMethod.MessageValidationMethod 
and [<RequireQualifiedAccess>] MethodSpecifier =
  | MethodSpecifier of AssemblyName:Identifier option * ClassName:Identifier option * MethodName:Identifier option 
  static member FromTs(src:ScriptDom.MethodSpecifier) : MethodSpecifier =
    MethodSpecifier.MethodSpecifier((src.AssemblyName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ClassName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.MethodName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] OrderBulkInsertOption =
  | OrderBulkInsertOption of Columns:(ColumnWithSortOrder) list * IsUnique:bool * OptionKind:ScriptDom.BulkInsertOptionKind 
  static member FromTs(src:ScriptDom.OrderBulkInsertOption) : OrderBulkInsertOption =
    OrderBulkInsertOption.OrderBulkInsertOption((src.Columns |> Seq.map (fun src -> ColumnWithSortOrder.ColumnWithSortOrder((src.Column |> Option.ofObj |> Option.map (ColumnReferenceExpression.FromTs)) (* 193 *), (src.SortOrder) (* 196 *))) |> List.ofSeq), (src.IsUnique) (* 196 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] RaiseErrorOptions =
  | RaiseErrorOptions  
  static member FromTs(src:ScriptDom.RaiseErrorOptions) : RaiseErrorOptions =
    RaiseErrorOptions.RaiseErrorOptions 
and [<RequireQualifiedAccess>] ResourcePoolParameter =
  | ResourcePoolParameter of AffinitySpecification:ResourcePoolAffinitySpecification option * ParameterType:ScriptDom.ResourcePoolParameterType * ParameterValue:Literal option 
  static member FromTs(src:ScriptDom.ResourcePoolParameter) : ResourcePoolParameter =
    ResourcePoolParameter.ResourcePoolParameter((src.AffinitySpecification |> Option.ofObj |> Option.map (ResourcePoolAffinitySpecification.FromTs)) (* 193 *), (src.ParameterType) (* 196 *), (src.ParameterValue |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] RestoreStatementKind =
  | RestoreStatementKind  
  static member FromTs(src:ScriptDom.RestoreStatementKind) : RestoreStatementKind =
    RestoreStatementKind.RestoreStatementKind 
and [<RequireQualifiedAccess>] RouteOption =
  | RouteOption of Literal:Literal option * OptionKind:ScriptDom.RouteOptionKind 
  static member FromTs(src:ScriptDom.RouteOption) : RouteOption =
    RouteOption.RouteOption((src.Literal |> Option.ofObj |> Option.map (Literal.FromTs)) (* 191 *), (src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] SecurityPolicyActionType =
  | SecurityPolicyActionType  
  static member FromTs(src:ScriptDom.SecurityPolicyActionType) : SecurityPolicyActionType =
    SecurityPolicyActionType.SecurityPolicyActionType 
and [<RequireQualifiedAccess>] SecurityPolicyOption =
  | SecurityPolicyOption of OptionKind:ScriptDom.SecurityPolicyOptionKind * OptionState:ScriptDom.OptionState 
  static member FromTs(src:ScriptDom.SecurityPolicyOption) : SecurityPolicyOption =
    SecurityPolicyOption.SecurityPolicyOption((src.OptionKind) (* 196 *), (src.OptionState) (* 196 *))
and [<RequireQualifiedAccess>] SecurityPredicateAction =
  | SecurityPredicateAction of ActionType:ScriptDom.SecurityPredicateActionType * FunctionCall:FunctionCall option * SecurityPredicateOperation:ScriptDom.SecurityPredicateOperation * SecurityPredicateType:ScriptDom.SecurityPredicateType * TargetObjectName:SchemaObjectName option 
  static member FromTs(src:ScriptDom.SecurityPredicateAction) : SecurityPredicateAction =
    SecurityPredicateAction.SecurityPredicateAction((src.ActionType) (* 196 *), (src.FunctionCall |> Option.ofObj |> Option.map (FunctionCall.FromTs)) (* 193 *), (src.SecurityPredicateOperation) (* 196 *), (src.SecurityPredicateType) (* 196 *), (src.TargetObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] Permission =
  | Permission of Columns:(Identifier) list * Identifiers:(Identifier) list 
  static member FromTs(src:ScriptDom.Permission) : Permission =
    Permission.Permission((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.Identifiers |> Seq.map (Identifier.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] SecurityUserClause80 =
  | SecurityUserClause80 of UserType80:ScriptDom.UserType80 * Users:(Identifier) list 
  static member FromTs(src:ScriptDom.SecurityUserClause80) : SecurityUserClause80 =
    SecurityUserClause80.SecurityUserClause80((src.UserType80) (* 196 *), (src.Users |> Seq.map (Identifier.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] AuditTarget =
  | AuditTarget of TargetKind:ScriptDom.AuditTargetKind * TargetOptions:(AuditTargetOption) list 
  static member FromTs(src:ScriptDom.AuditTarget) : AuditTarget =
    AuditTarget.AuditTarget((src.TargetKind) (* 196 *), (src.TargetOptions |> Seq.map (AuditTargetOption.FromTs) |> List.ofSeq))
and [<RequireQualifiedAccess>] SetOptions =
  | SetOptions  
  static member FromTs(src:ScriptDom.SetOptions) : SetOptions =
    SetOptions.SetOptions 
and [<RequireQualifiedAccess>] SetOffsets =
  | SetOffsets  
  static member FromTs(src:ScriptDom.SetOffsets) : SetOffsets =
    SetOffsets.SetOffsets 
and [<RequireQualifiedAccess>] SetStatisticsOptions =
  | SetStatisticsOptions  
  static member FromTs(src:ScriptDom.SetStatisticsOptions) : SetStatisticsOptions =
    SetStatisticsOptions.SetStatisticsOptions 
and [<RequireQualifiedAccess>] IsolationLevel =
  | IsolationLevel  
  static member FromTs(src:ScriptDom.IsolationLevel) : IsolationLevel =
    IsolationLevel.IsolationLevel 
and [<RequireQualifiedAccess>] SeparatorType =
  | SeparatorType  
  static member FromTs(src:ScriptDom.SeparatorType) : SeparatorType =
    SeparatorType.SeparatorType 
and [<RequireQualifiedAccess>] SignableElementKind =
  | SignableElementKind  
  static member FromTs(src:ScriptDom.SignableElementKind) : SignableElementKind =
    SignableElementKind.SignableElementKind 
and [<RequireQualifiedAccess>] WithCtesAndXmlNamespaces =
  | WithCtesAndXmlNamespaces of ChangeTrackingContext:ValueExpression option * CommonTableExpressions:(CommonTableExpression) list * XmlNamespaces:XmlNamespaces option 
  static member FromTs(src:ScriptDom.WithCtesAndXmlNamespaces) : WithCtesAndXmlNamespaces =
    WithCtesAndXmlNamespaces.WithCtesAndXmlNamespaces((src.ChangeTrackingContext |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *), (src.CommonTableExpressions |> Seq.map (fun src -> CommonTableExpression.CommonTableExpression((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExpressionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.XmlNamespaces |> Option.ofObj |> Option.map (XmlNamespaces.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] DeleteSpecification =
  | DeleteSpecification of FromClause:FromClause option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * Target:TableReference option * TopRowFilter:TopRowFilter option * WhereClause:WhereClause option 
  static member FromTs(src:ScriptDom.DeleteSpecification) : DeleteSpecification =
    DeleteSpecification.DeleteSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] InsertSpecification =
  | InsertSpecification of Columns:(ColumnReferenceExpression) list * InsertOption:ScriptDom.InsertOption * InsertSource:InsertSource option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * Target:TableReference option * TopRowFilter:TopRowFilter option 
  static member FromTs(src:ScriptDom.InsertSpecification) : InsertSpecification =
    InsertSpecification.InsertSpecification((src.Columns |> Seq.map (fun src -> ColumnReferenceExpression.ColumnReferenceExpression((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnType) (* 196 *), (src.MultiPartIdentifier |> Option.ofObj |> Option.map (MultiPartIdentifier.FromTs)) (* 191 *))) |> List.ofSeq), (src.InsertOption) (* 196 *), (src.InsertSource |> Option.ofObj |> Option.map (InsertSource.FromTs)) (* 191 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] MergeSpecification =
  | MergeSpecification of ActionClauses:(MergeActionClause) list * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * SearchCondition:BooleanExpression option * TableAlias:Identifier option * TableReference:TableReference option * Target:TableReference option * TopRowFilter:TopRowFilter option 
  static member FromTs(src:ScriptDom.MergeSpecification) : MergeSpecification =
    MergeSpecification.MergeSpecification((src.ActionClauses |> Seq.map (fun src -> MergeActionClause.MergeActionClause((src.Action |> Option.ofObj |> Option.map (MergeAction.FromTs)) (* 191 *), (src.Condition) (* 196 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *))) |> List.ofSeq), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SearchCondition |> Option.ofObj |> Option.map (BooleanExpression.FromTs)) (* 191 *), (src.TableAlias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.TableReference |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] UpdateSpecification =
  | UpdateSpecification of FromClause:FromClause option * OutputClause:OutputClause option * OutputIntoClause:OutputIntoClause option * SetClauses:(SetClause) list * Target:TableReference option * TopRowFilter:TopRowFilter option * WhereClause:WhereClause option 
  static member FromTs(src:ScriptDom.UpdateSpecification) : UpdateSpecification =
    UpdateSpecification.UpdateSpecification((src.FromClause |> Option.ofObj |> Option.map (FromClause.FromTs)) (* 193 *), (src.OutputClause |> Option.ofObj |> Option.map (OutputClause.FromTs)) (* 193 *), (src.OutputIntoClause |> Option.ofObj |> Option.map (OutputIntoClause.FromTs)) (* 193 *), (src.SetClauses |> Seq.map (SetClause.FromTs) |> List.ofSeq), (src.Target |> Option.ofObj |> Option.map (TableReference.FromTs)) (* 191 *), (src.TopRowFilter |> Option.ofObj |> Option.map (TopRowFilter.FromTs)) (* 193 *), (src.WhereClause |> Option.ofObj |> Option.map (WhereClause.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ComputeClause =
  | ComputeClause of ByExpressions:(ScalarExpression) list * ComputeFunctions:(ComputeFunction) list 
  static member FromTs(src:ScriptDom.ComputeClause) : ComputeClause =
    ComputeClause.ComputeClause((src.ByExpressions |> Seq.map (ScalarExpression.FromTs) |> List.ofSeq), (src.ComputeFunctions |> Seq.map (fun src -> ComputeFunction.ComputeFunction((src.ComputeFunctionType) (* 196 *), (src.Expression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] TriggerAction =
  | TriggerAction of EventTypeGroup:EventTypeGroupContainer option * TriggerActionType:ScriptDom.TriggerActionType 
  static member FromTs(src:ScriptDom.TriggerAction) : TriggerAction =
    TriggerAction.TriggerAction((src.EventTypeGroup |> Option.ofObj |> Option.map (EventTypeGroupContainer.FromTs)) (* 191 *), (src.TriggerActionType) (* 196 *))
and [<RequireQualifiedAccess>] TriggerType =
  | TriggerType  
  static member FromTs(src:ScriptDom.TriggerType) : TriggerType =
    TriggerType.TriggerType 
and [<RequireQualifiedAccess>] UserLoginOption =
  | UserLoginOption of Identifier:Identifier option * UserLoginOptionType:ScriptDom.UserLoginOptionType 
  static member FromTs(src:ScriptDom.UserLoginOption) : UserLoginOption =
    UserLoginOption.UserLoginOption((src.Identifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.UserLoginOptionType) (* 196 *))
and [<RequireQualifiedAccess>] ViewOption =
  | ViewOption of OptionKind:ScriptDom.ViewOptionKind 
  static member FromTs(src:ScriptDom.ViewOption) : ViewOption =
    ViewOption.ViewOption((src.OptionKind) (* 196 *))
and [<RequireQualifiedAccess>] WaitForOption =
  | WaitForOption  
  static member FromTs(src:ScriptDom.WaitForOption) : WaitForOption =
    WaitForOption.WaitForOption 
and [<RequireQualifiedAccess>] VariableTableReference =
  | VariableTableReference of Alias:Identifier option * Variable:VariableReference option 
  static member FromTs(src:ScriptDom.VariableTableReference) : VariableTableReference =
    VariableTableReference.VariableTableReference((src.Alias |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.Variable |> Option.ofObj |> Option.map (VariableReference.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] ColumnDefinition =
  | ColumnDefinition of Collation:Identifier option * ColumnIdentifier:Identifier option * ComputedColumnExpression:ScalarExpression option * Constraints:(ConstraintDefinition) list * DataType:DataTypeReference option * DefaultConstraint:DefaultConstraintDefinition option * Encryption:ColumnEncryptionDefinition option * GeneratedAlways:(ScriptDom.GeneratedAlwaysType) option * IdentityOptions:IdentityOptions option * Index:IndexDefinition option * IsHidden:bool * IsMasked:bool * IsPersisted:bool * IsRowGuidCol:bool * MaskingFunction:StringLiteral option * StorageOptions:ColumnStorageOptions option 
  static member FromTs(src:ScriptDom.ColumnDefinition) : ColumnDefinition =
    ColumnDefinition.ColumnDefinition((src.Collation |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ColumnIdentifier |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.ComputedColumnExpression |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.Constraints |> Seq.map (ConstraintDefinition.FromTs) |> List.ofSeq), (src.DataType |> Option.ofObj |> Option.map (DataTypeReference.FromTs)) (* 191 *), (src.DefaultConstraint |> Option.ofObj |> Option.map (DefaultConstraintDefinition.FromTs)) (* 193 *), (src.Encryption |> Option.ofObj |> Option.map (ColumnEncryptionDefinition.FromTs)) (* 193 *), (Option.ofNullable (src.GeneratedAlways)), (src.IdentityOptions |> Option.ofObj |> Option.map (IdentityOptions.FromTs)) (* 193 *), (src.Index |> Option.ofObj |> Option.map (IndexDefinition.FromTs)) (* 193 *), (src.IsHidden) (* 196 *), (src.IsMasked) (* 196 *), (src.IsPersisted) (* 196 *), (src.IsRowGuidCol) (* 196 *), (src.MaskingFunction |> Option.ofObj |> Option.map (StringLiteral.FromTs)) (* 193 *), (src.StorageOptions |> Option.ofObj |> Option.map (ColumnStorageOptions.FromTs)) (* 193 *))
and [<RequireQualifiedAccess>] SystemTimePeriodDefinition =
  | SystemTimePeriodDefinition of EndTimeColumn:Identifier option * StartTimeColumn:Identifier option 
  static member FromTs(src:ScriptDom.SystemTimePeriodDefinition) : SystemTimePeriodDefinition =
    SystemTimePeriodDefinition.SystemTimePeriodDefinition((src.EndTimeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.StartTimeColumn |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] TableHintKind =
  | TableHintKind  
  static member FromTs(src:ScriptDom.TableHintKind) : TableHintKind =
    TableHintKind.TableHintKind 
and [<RequireQualifiedAccess>] TableOptionKind =
  | TableOptionKind  
  static member FromTs(src:ScriptDom.TableOptionKind) : TableOptionKind =
    TableOptionKind.TableOptionKind 
and [<RequireQualifiedAccess>] DurabilityTableOptionKind =
  | DurabilityTableOptionKind  
  static member FromTs(src:ScriptDom.DurabilityTableOptionKind) : DurabilityTableOptionKind =
    DurabilityTableOptionKind.DurabilityTableOptionKind 
and [<RequireQualifiedAccess>] LockEscalationMethod =
  | LockEscalationMethod  
  static member FromTs(src:ScriptDom.LockEscalationMethod) : LockEscalationMethod =
    LockEscalationMethod.LockEscalationMethod 
and [<RequireQualifiedAccess>] MigrationState =
  | MigrationState  
  static member FromTs(src:ScriptDom.MigrationState) : MigrationState =
    MigrationState.MigrationState 
and [<RequireQualifiedAccess>] RdaTableOption =
  | RdaTableOption  
  static member FromTs(src:ScriptDom.RdaTableOption) : RdaTableOption =
    RdaTableOption.RdaTableOption 
and [<RequireQualifiedAccess>] DataCompressionOption =
  | DataCompressionOption of CompressionLevel:ScriptDom.DataCompressionLevel * OptionKind:ScriptDom.IndexOptionKind * PartitionRanges:(CompressionPartitionRange) list 
  static member FromTs(src:ScriptDom.DataCompressionOption) : DataCompressionOption =
    DataCompressionOption.DataCompressionOption((src.CompressionLevel) (* 196 *), (src.OptionKind) (* 196 *), (src.PartitionRanges |> Seq.map (fun src -> CompressionPartitionRange.CompressionPartitionRange((src.From |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.To |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *))) |> List.ofSeq))
and [<RequireQualifiedAccess>] JoinHint =
  | JoinHint  
  static member FromTs(src:ScriptDom.JoinHint) : JoinHint =
    JoinHint.JoinHint 
and [<RequireQualifiedAccess>] QualifiedJoinType =
  | QualifiedJoinType  
  static member FromTs(src:ScriptDom.QualifiedJoinType) : QualifiedJoinType =
    QualifiedJoinType.QualifiedJoinType 
and [<RequireQualifiedAccess>] UnqualifiedJoinType =
  | UnqualifiedJoinType  
  static member FromTs(src:ScriptDom.UnqualifiedJoinType) : UnqualifiedJoinType =
    UnqualifiedJoinType.UnqualifiedJoinType 
and [<RequireQualifiedAccess>] SchemaObjectNameOrValueExpression =
  | SchemaObjectNameOrValueExpression of SchemaObjectName:SchemaObjectName option * ValueExpression:ValueExpression option 
  static member FromTs(src:ScriptDom.SchemaObjectNameOrValueExpression) : SchemaObjectNameOrValueExpression =
    SchemaObjectNameOrValueExpression.SchemaObjectNameOrValueExpression((src.SchemaObjectName |> Option.ofObj |> Option.map (SchemaObjectName.FromTs)) (* 191 *), (src.ValueExpression |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] TableSampleClause =
  | TableSampleClause of RepeatSeed:ScalarExpression option * SampleNumber:ScalarExpression option * System:bool * TableSampleClauseOption:ScriptDom.TableSampleClauseOption 
  static member FromTs(src:ScriptDom.TableSampleClause) : TableSampleClause =
    TableSampleClause.TableSampleClause((src.RepeatSeed |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.SampleNumber |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.System) (* 196 *), (src.TableSampleClauseOption) (* 196 *))
and [<RequireQualifiedAccess>] TemporalClause =
  | TemporalClause of EndTime:ScalarExpression option * StartTime:ScalarExpression option * TemporalClauseType:ScriptDom.TemporalClauseType 
  static member FromTs(src:ScriptDom.TemporalClause) : TemporalClause =
    TemporalClause.TemporalClause((src.EndTime |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.StartTime |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.TemporalClauseType) (* 196 *))
and [<RequireQualifiedAccess>] SchemaDeclarationItemOpenjson =
  | SchemaDeclarationItemOpenjson of AsJson:bool * ColumnDefinition:ColumnDefinitionBase option * Mapping:ValueExpression option 
  static member FromTs(src:ScriptDom.SchemaDeclarationItemOpenjson) : SchemaDeclarationItemOpenjson =
    SchemaDeclarationItemOpenjson.SchemaDeclarationItemOpenjson((src.AsJson) (* 196 *), (src.ColumnDefinition |> Option.ofObj |> Option.map (ColumnDefinitionBase.FromTs)) (* 191 *), (src.Mapping |> Option.ofObj |> Option.map (ValueExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] SemanticFunctionType =
  | SemanticFunctionType  
  static member FromTs(src:ScriptDom.SemanticFunctionType) : SemanticFunctionType =
    SemanticFunctionType.SemanticFunctionType 
and [<RequireQualifiedAccess>] TableSampleClauseOption =
  | TableSampleClauseOption  
  static member FromTs(src:ScriptDom.TableSampleClauseOption) : TableSampleClauseOption =
    TableSampleClauseOption.TableSampleClauseOption 
and [<RequireQualifiedAccess>] TableSwitchOptionKind =
  | TableSwitchOptionKind  
  static member FromTs(src:ScriptDom.TableSwitchOptionKind) : TableSwitchOptionKind =
    TableSwitchOptionKind.TableSwitchOptionKind 
and [<RequireQualifiedAccess>] TemporalClauseType =
  | TemporalClauseType  
  static member FromTs(src:ScriptDom.TemporalClauseType) : TemporalClauseType =
    TemporalClauseType.TemporalClauseType 
and [<RequireQualifiedAccess>] TriggerActionType =
  | TriggerActionType  
  static member FromTs(src:ScriptDom.TriggerActionType) : TriggerActionType =
    TriggerActionType.TriggerActionType 
and [<RequireQualifiedAccess>] TriggerOptionKind =
  | TriggerOptionKind  
  static member FromTs(src:ScriptDom.TriggerOptionKind) : TriggerOptionKind =
    TriggerOptionKind.TriggerOptionKind 
and [<RequireQualifiedAccess>] UserLoginOptionType =
  | UserLoginOptionType  
  static member FromTs(src:ScriptDom.UserLoginOptionType) : UserLoginOptionType =
    UserLoginOptionType.UserLoginOptionType 
and [<RequireQualifiedAccess>] ViewOptionKind =
  | ViewOptionKind  
  static member FromTs(src:ScriptDom.ViewOptionKind) : ViewOptionKind =
    ViewOptionKind.ViewOptionKind 
and [<RequireQualifiedAccess>] WindowDelimiterType =
  | WindowDelimiterType  
  static member FromTs(src:ScriptDom.WindowDelimiterType) : WindowDelimiterType =
    WindowDelimiterType.WindowDelimiterType 
and [<RequireQualifiedAccess>] WindowDelimiter =
  | WindowDelimiter of OffsetValue:ScalarExpression option * WindowDelimiterType:ScriptDom.WindowDelimiterType 
  static member FromTs(src:ScriptDom.WindowDelimiter) : WindowDelimiter =
    WindowDelimiter.WindowDelimiter((src.OffsetValue |> Option.ofObj |> Option.map (ScalarExpression.FromTs)) (* 191 *), (src.WindowDelimiterType) (* 196 *))
and [<RequireQualifiedAccess>] WindowFrameType =
  | WindowFrameType  
  static member FromTs(src:ScriptDom.WindowFrameType) : WindowFrameType =
    WindowFrameType.WindowFrameType 
and [<RequireQualifiedAccess>] CommonTableExpression =
  | CommonTableExpression of Columns:(Identifier) list * ExpressionName:Identifier option * QueryExpression:QueryExpression option 
  static member FromTs(src:ScriptDom.CommonTableExpression) : CommonTableExpression =
    CommonTableExpression.CommonTableExpression((src.Columns |> Seq.map (Identifier.FromTs) |> List.ofSeq), (src.ExpressionName |> Option.ofObj |> Option.map (Identifier.FromTs)) (* 191 *), (src.QueryExpression |> Option.ofObj |> Option.map (QueryExpression.FromTs)) (* 191 *))
and [<RequireQualifiedAccess>] WorkloadGroupParameterType =
  | WorkloadGroupParameterType  
  static member FromTs(src:ScriptDom.WorkloadGroupParameterType) : WorkloadGroupParameterType =
    WorkloadGroupParameterType.WorkloadGroupParameterType 

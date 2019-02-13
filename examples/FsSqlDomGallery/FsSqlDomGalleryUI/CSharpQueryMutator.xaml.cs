using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FsSqlDomGalleryUI {
    /// <summary>
    /// Interaction logic for CSharpQueryMutator.xaml
    /// </summary>
    public partial class CSharpQueryMutatorView : UserControl {
        public CSharpQueryMutatorView() {
            InitializeComponent();
        }

        async void _build_syntax_btn_Click(object sender, RoutedEventArgs e) {
            var syntax_txt = _query_tb.Text;
            var bg_default = _analysis_tb.Background;
            _analysis_tb.Background = Brushes.Gold;

            var analysis_txt = await Task.Factory.StartNew(() => {
                var parser = new TSql140Parser(false);
                IList<ParseError> errors;
                var fragment = parser.Parse(new StringReader(syntax_txt), out errors);
                if (errors.Count > 0) {
                    return "ERROR:\n" + String.Join("\n", errors.Select(err => err.Message));
                }

                fragment.Accept(new MyNaiveMutator());
                var renderer = new Sql130ScriptGenerator();
                string sql;
                renderer.GenerateScript(fragment, out sql);
                return sql;
            });

            this.Dispatcher.Invoke(() => {
                _analysis_tb.Text = analysis_txt;
                _analysis_tb.Background = bg_default;
            });
        }
    }

    class MyNaiveMutator : TSqlFragmentVisitor {
        public MyNaiveMutator() { }

        static ColumnReferenceExpression ColRef(string identifier) {
            var ret = new ColumnReferenceExpression { MultiPartIdentifier = new MultiPartIdentifier() };
            foreach (var part in identifier.Split('.')) {
                var id = new Identifier { Value = part };
                ret.MultiPartIdentifier.Identifiers.Add(id);
            }
            return ret;
        }

        bool FilterSelectElement(SelectElement sel) {
            var scalar = sel as SelectScalarExpression;
            if (scalar == null) return true; // TODO - Filter select star
            var colref = scalar.Expression as ColumnReferenceExpression;
            if (colref != null) {
                var idents = colref.MultiPartIdentifier?.Identifiers;
                if (idents != null && idents.Count > 0)
                    return !String.Equals(idents.Last().Value, "SecretColumn", StringComparison.InvariantCultureIgnoreCase);
            }
            return true;
        }

        public override void Visit(QuerySpecification node) {
            var selElements = node.SelectElements.Where(FilterSelectElement).ToList();
            node.SelectElements.Clear();
            foreach (var item in selElements) node.SelectElements.Add(item);

            var extraCondition = new BooleanComparisonExpression {
                ComparisonType = BooleanComparisonType.Equals,
                FirstExpression = ColRef("CompanyID"),
                SecondExpression = new VariableReference { Name = "@CompanyId" }
            };

            if (node.WhereClause == null) node.WhereClause = new WhereClause();

            if (node.WhereClause.SearchCondition != null) {
                node.WhereClause.SearchCondition =
                    new BooleanBinaryExpression {
                        BinaryExpressionType = BooleanBinaryExpressionType.And,
                        FirstExpression = new BooleanParenthesisExpression {
                            Expression = node.WhereClause.SearchCondition
                        },
                        SecondExpression = extraCondition
                    };
            } else {
                node.WhereClause.SearchCondition = extraCondition;
            }
        }
    }
}

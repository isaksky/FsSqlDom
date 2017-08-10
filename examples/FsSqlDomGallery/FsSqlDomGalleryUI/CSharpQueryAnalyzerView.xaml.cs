using System;
using System.Collections.Generic;
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

using Microsoft.Data.ConnectionUI;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;

namespace FsSqlDomGalleryUI {
    /// <summary>
    /// Interaction logic for CSharpQueryAnalyzerView.xaml
    /// </summary>
    public partial class CSharpQueryAnalyzerView : UserControl {
        public CSharpQueryAnalyzerView() {
            InitializeComponent();
        }

        async void _build_syntax_btn_Click(object sender, RoutedEventArgs e) {
            var syntax_txt = _query_tb.Text;
            var bg_default = _analysis_tb.Background;
            _analysis_tb.Background = Brushes.Gold;

            var analysis_txt = await Task.Factory.StartNew(() => {
                var parser = new TSql130Parser(false);
                IList<ParseError> errors;
                var fragment = parser.Parse(new StringReader(syntax_txt), out errors);
                
                var analyzer = new MyNaiveAnalyzer();
                fragment.Accept(analyzer);

                return analyzer.GetResult();
            });

            this.Dispatcher.Invoke(() => {
                _analysis_tb.Text = analysis_txt;
                _analysis_tb.Background = bg_default;
            });
        }
    }

    class MyNaiveAnalyzer : TSqlFragmentVisitor {
        StringBuilder _sb = new StringBuilder();
        public MyNaiveAnalyzer() {
        }

        public override void Visit(AddAlterFullTextIndexAction node) {
            base.Visit(node);
        }

        public override void Visit(ColumnReferenceExpression node) {
            var col = String.Join(".", node.MultiPartIdentifier.Identifiers.Select(id => id.Value));
            _sb.AppendFormat("Found column: {0}.\n", col);
        }

        public override void Visit(NamedTableReference node) {
            var table = String.Join(".", node.SchemaObject.Identifiers.Select(id => id.Value));
            _sb.AppendFormat("Found named table: {0}.\n", table);
        }

        public string GetResult() => _sb.ToString();
    }
}

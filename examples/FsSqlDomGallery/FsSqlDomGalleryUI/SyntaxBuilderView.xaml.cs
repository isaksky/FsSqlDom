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
using FsSqlDomGallery;
using System.IO;
using static Microsoft.FSharp.Compiler.Interactive.Shell;
using Microsoft.FSharp.Core;
using System.Reflection;
using System.Threading;

namespace FsSqlDomGalleryUI {

    public class DisposableLock : IDisposable {
        object _lock_obj;
        public DisposableLock(object o) {
            _lock_obj = o;
            Monitor.Enter(o);
        }
        public void Dispose() {
            Monitor.Exit(_lock_obj);
        }
    }
    /// <summary>
    /// Interaction logic for SyntaxBuilderView.xaml
    /// </summary>
    public partial class SyntaxBuilderView : UserControl {
        FsiEvaluationSession _fsi;
        object _fsi_lock = new object();

        public SyntaxBuilderView() {
            InitializeComponent();
            _static_tb.Text = EVAL_STR;
            // Initialize Fsi on another thread.
            Task.Factory.StartNew(() => GetFsi());
        }

        FsiEvaluationSession GetFsi() {
            lock (_fsi_lock) {
                if (_fsi != null) {
                    return _fsi;
                }

                var noneFalse = FSharpOption<bool>.None;
                var sbOut = new StringBuilder();
                var outStream = new StringWriter(sbOut);
                var sbErr = new StringBuilder();
                var errStream = new StringWriter(sbErr);

                var exePath = Assembly.GetExecutingAssembly().CodeBase;
                //var scriptDomDll = Path.Combine(exePath, "Microsoft.SqlServer.TransactSql.ScriptDom.dll");
                var libPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

                var inSb = new StringBuilder();
                var inStream = new StringReader(inSb.ToString());
                var fsiConfig = FsiEvaluationSession.GetDefaultConfiguration();

                var argvBuilder = new List<string>();

                // C:\Program Files (x86)\Microsoft SDKs\F#\3.0\Framework\v4.0
                argvBuilder.Add(@"C:\Program Files (x86)\Microsoft SDKs\F#\4.1\Framework\v4.0\fsi.exe");
                //argvBuilder.Add(Path.Combine(exePath, "fsi.exe"));
                argvBuilder.Add($"--lib:{libPath}");
                //argvBuilder.Add(libPath); // Path.Combine(exePath, "Microsoft.SqlServer.TransactSql.ScriptDom.dll"));

                var argv = argvBuilder.ToArray();
                var fsi = FsiEvaluationSession.Create(fsiConfig, argv, inStream, outStream, errStream, noneFalse, noneFalse);
                foreach (var line in new[] {
                    "open System",
                    "open System.IO",
                    "open System.Text",
                    "open System.Collections.Generic",
                    @"#r ""Microsoft.SqlServer.TransactSql.ScriptDom.dll""",
                    "open Microsoft.SqlServer.TransactSql"}) {
                    fsi.EvalInteraction(line);
                }
                sbOut.Clear();
                _fsi = fsi;
                return fsi;
            }
        }

        static readonly string EVAL_STR =
@"let opts = ScriptDom.SqlScriptGeneratorOptions()
let gen = ScriptDom.Sql140ScriptGenerator(opts)
let tr = new StringWriter()
gen.GenerateScript(tSqlScript0, (tr :> TextWriter))
tr.ToString()";

        async void Syntax_Click(object sender, RoutedEventArgs e) {
            var syntax_txt = _syntax_tb.Text;
            var bg_default = _syntax_tb.Background;
            _syntax_tb.Background = Brushes.Gold;

            var query_txt = await Task.Factory.StartNew(() => {
                var fsi = GetFsi();
                lock (_fsi_lock) {
                    var ret = fsi.EvalInteractionNonThrowing(syntax_txt);
                    if (ret.Item1.IsChoice2Of2) {
                        var er = ((FSharpChoice<Microsoft.FSharp.Core.Unit, Exception>.Choice2Of2)ret.Item1).Item;
                        var errSb = new StringBuilder();
                        errSb.Append(er.Message);
                        return "";

                        if (ret.Item2 != null) {
                            var errs = ret.Item2;
                            var errStr = String.Join("\n", errs.Select(err => err.Message));
                            errSb.AppendLine(errStr);
                            return "";
                        }
                        if (errSb.Length > 0)
                            MessageBox.Show(errSb.ToString().Substring(0, Math.Min(400, errSb.Length)));
                    }

                    var script_gen_result = fsi.EvalExpressionNonThrowing(EVAL_STR);

                    if (script_gen_result.Item1 != null) {
                        if (script_gen_result.Item1.IsChoice1Of2) {
                            var v = ((FSharpChoice<FSharpOption<FsiValue>, Exception>.Choice1Of2)script_gen_result.Item1).Item.Value;

                            var str = (string)v.ReflectionValue;
                            if (str != null) {
                                return str;
                            }

                        } else {
                            var er = ((FSharpChoice<FSharpOption<FsiValue>, Exception>.Choice2Of2)script_gen_result.Item1).Item;
                            MessageBox.Show(er.Message);
                        }
                    } else if (script_gen_result.Item2 != null && script_gen_result.Item2.Length > 0) {
                        var errs = script_gen_result.Item2;
                        var errmsg = String.Join("\n", errs.Select(err => err.Message));
                        return "ERROR:\n" + errmsg;
                    }
                    return "";
                }
            });

            this.Dispatcher.Invoke(() => {
                _query_tb.Text = query_txt;
                _syntax_tb.Background = bg_default;
            });
        }

        async void Button_Click(object sender, RoutedEventArgs e) {
            var query = _query_tb.Text;
            var reuse_vars = _reuse_vars_cb.IsChecked ?? false;
            var use_fsharp_syntax = _lang_combo_box.SelectedIndex == 0;

            try {
                var syntax = await Task.Factory.StartNew(() => {
                    return SyntaxBuilding.build_syntax(query, reuse_vars, use_fsharp_syntax);
                });
                this.Dispatcher.Invoke(() => {
                    _syntax_tb.Text = syntax;
                });
            } catch (SyntaxBuilding.SyntaxException ex) {
                var sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                foreach (var err in ex.errors) {
                    sb.AppendLine($"{err.Line}: {err.Message}");
                }

                this.Dispatcher.Invoke(() => {
                    _syntax_tb.Text = sb.ToString();
                });
            }

        }

        private void _lang_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (_build_query_btn != null /* it is null on startup */ ) { 
                _build_query_btn.IsEnabled = _lang_combo_box.SelectedIndex == 0;
            }
        }
    }
}

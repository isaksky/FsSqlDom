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
using System.Data;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;

namespace FsSqlDomGalleryUI {
    public partial class AnalyzeTableRelsView : System.Windows.Controls.UserControl {
        ConsoleContent dc = new ConsoleContent();
        public AnalyzeTableRelsView() {
            InitializeComponent();
            DataContext = dc;
        }

        public string ConnectionString { get; set; }

        bool TryGetDataConnectionStringFromUser(out string outConnectionString) {
            using (var dialog = new DataConnectionDialog()) {
                dialog.DataSources.Add(DataSource.SqlDataSource);
                DialogResult userChoice = DataConnectionDialog.Show(dialog);

                if (userChoice == DialogResult.OK) {
                    outConnectionString = dialog.ConnectionString;
                    return true;
                } else {
                    outConnectionString = null;
                    return false;
                }
            }
        }

        async void _begin_btn_Click(object sender, RoutedEventArgs e) {
            string connstr;
            if (TryGetDataConnectionStringFromUser(out connstr)) {
                log($"Got connection string: {connstr}");
                Action<string> dispatch_log = (s) => {
                    Dispatcher.Invoke(() => log(s));
                };
                await Task.Factory.StartNew(() =>
                    FsSqlDomGallery.GraphTableRelationships.analyzeAndVisualize(connstr, dispatch_log));
            }
        }

        void log(string str) {
            dc.Log(str);
            Scroller.ScrollToBottom();
        }
    }
    public class ConsoleContent : INotifyPropertyChanged {
        string consoleInput = string.Empty;
        ObservableCollection<string> consoleOutput = new ObservableCollection<string>();

        public ObservableCollection<string> ConsoleOutput {
            get
            { return consoleOutput; }
            set
            {
                consoleOutput = value;
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public void Log(string str) {
            var output = ConsoleOutput;
            output.Add(str);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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

namespace FsSqlDomGalleryUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void _analyze_button_Click(object sender, RoutedEventArgs e) {
            _tab_control.SelectedIndex = 1;
        }

        private void _build_syntax_button_Click(object sender, RoutedEventArgs e) {
            _tab_control.SelectedIndex = 2;
        }

        private void _analyze_rels_button_Click(object sender, RoutedEventArgs e) {
            _tab_control.SelectedIndex = 3;
        }
    }
}

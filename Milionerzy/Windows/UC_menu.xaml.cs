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


namespace Milionerzy.Windows {
    /// <summary>
    /// Logika interakcji dla klasy UC_menu.xaml
    /// </summary>
    public partial class UC_menu : UserControl {
        MainWindow parent;
        public UC_menu(MainWindow parent) {
            InitializeComponent();
            this.parent = parent; 
        }

        private void ui_start_game_Click(object sender, RoutedEventArgs e) {
            parent.SwitchTo(parent.UCstartGame);
        }
        private void ui_credits_Click(object sender, RoutedEventArgs e) {
            parent.SwitchTo(parent.UCcredits);
        }

        private void ui_exit_Click(object sender, RoutedEventArgs e) {
            parent.Close();
        }

        
    }
}

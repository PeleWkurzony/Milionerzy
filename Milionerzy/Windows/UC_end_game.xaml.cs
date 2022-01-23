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
using Milionerzy.Scripts;

namespace Milionerzy.Windows {
    /// <summary>
    /// Logika interakcji dla klasy UC_end_game.xaml
    /// </summary>
    public partial class UC_end_game : UserControl {
        MainWindow parent;

        private float time;
        private uint questionNumer;
        private String wrongAnswer;
        private DB_controller controller;

        public UC_end_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
            controller = new DB_controller();
        }
        private void ui_back_button_Click(object sender, RoutedEventArgs e) {
            parent.Close();
        }

        private void OnLoad(object sender, RoutedEventArgs e) {
            Result game = parent.UCgame.GetResult();
            controller.SaveResult(game);

        }
    }
}

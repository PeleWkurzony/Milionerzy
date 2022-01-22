﻿using System;
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
    /// Logika interakcji dla klasy UC_end_game.xaml
    /// </summary>
    public partial class UC_end_game : UserControl {
        MainWindow parent;
        public UC_end_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
        }
        private void ui_back_button_Click(object sender, RoutedEventArgs e) {
            parent.Close();
        }
    }
}

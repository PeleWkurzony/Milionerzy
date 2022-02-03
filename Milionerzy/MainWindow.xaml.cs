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

using Milionerzy.Windows;
using Milionerzy.Scripts;

namespace Milionerzy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //UC - skrót od User Control
        public UC_menu UCmenu;
        public UC_start_game UCstartGame;
        public UC_credits UCcredits;
        public UC_game UCgame;
        public UC_end_game UCendGame;

        public MainWindow() {
            InitializeComponent();
            UCmenu = new UC_menu(this);
            UCstartGame = new UC_start_game(this);
            UCcredits = new UC_credits(this);
            UCgame = new UC_game(this);
            UCendGame = new UC_end_game(this);
            ReturnToMenu();
            
        }
        /// <summary>
        /// Przechodzi do kontrolek Menu
        /// </summary>
        public void ReturnToMenu() {
            this.userContent.Children.Clear();
            this.userContent.Children.Add(UCmenu);
        }
        /// <summary>
        /// Wyświetla konkretne kontrolki dzięki polimorfizmowi
        /// </summary>
        /// <param name="userControl"> 
        /// Kontrolka klasy User Control, która ma zostać wyświetlona
        /// </param>
        public void SwitchTo(UserControl userControl) {
            this.Dispatcher.Invoke(() => { 
                this.userContent.Children.Clear();
                this.userContent.Children.Add(userControl);
            });
        }

        private void on_media_end(object sender, RoutedEventArgs e)
        {
            mp4.Position = new TimeSpan(0, 0, 1);
            mp4.Play();
        }

    }
}

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
    /// Logika interakcji dla klasy UC_settings.xaml
    /// </summary>
    public partial class UC_settings : UserControl {

        MainWindow parent;
        public UC_settings(MainWindow parent) {
            try {
                this.parent = parent;
                InitializeComponent();
            } catch { }
        }

        private void ui_back_button_Click(object sender, RoutedEventArgs e) {
            this.Dispatcher.Invoke(() => {
                parent.ReturnToMenu();
            });
        }
        private void ui_database_saving_checkbox_Click(object sender, RoutedEventArgs e) {
            this.Dispatcher.Invoke(() => {
                parent.DBcontroller.ChangeSaving(ui_database_saving_checkbox.IsChecked ?? true);
            });
        }

        private void ui_audio_checkbox_Click(object sender, RoutedEventArgs e) {
            this.Dispatcher.Invoke(() => {
                parent.mp4.IsMuted = !ui_audio_checkbox.IsChecked ?? false;
            });
        }

        private void ui_backgorund_checkbox_Click(object sender, RoutedEventArgs e) {
            this.Dispatcher.Invoke(() => {
                bool flag = !ui_backgorund_checkbox.IsChecked ?? false;
                if (flag) {
                    parent.mp4.Pause();
                } else {
                    parent.mp4.Play();
                }
            });
            
        }

        private void ui_save_settings_Click(object sender, RoutedEventArgs e) {
            this.Dispatcher.Invoke(() => {
                parent.DBcontroller.ChangeConnectionString(
                    ui_address.Text,
                    ui_user.Text,
                    ui_database.Text,
                    ui_port.Text,
                    ui_password.Text);
                parent.DBcontroller.DownloadQuestions();
            });
        }
    }
}

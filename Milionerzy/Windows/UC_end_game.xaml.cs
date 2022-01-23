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
        
        public class Stats {
            public Stats(String name, ulong time, uint number) {
                this.name = name;
                this.time = time;
                this.number = number;
            }
            public String name;
            public ulong time;
            public uint number;
        }
        
        MainWindow parent;

        private DB_controller controller;
        private Result result;

        public UC_end_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
            controller = new DB_controller();
        }
        private void ui_back_button_Click(object sender, RoutedEventArgs e) {
            parent.Close();
        }
        private void PrintBoard(Result result) {
            List<Stats> stats = controller.GetStats(result.questionNumer);
            List<List<TextBox>> list = new List<List<TextBox>> {
                new List<TextBox> { ui_names_1, ui_times_1, ui_correct_a_1 },
                new List<TextBox> { ui_names_2, ui_times_2, ui_correct_a_2 },
                new List<TextBox> { ui_names_4, ui_times_4, ui_correct_a_4 },
                new List<TextBox> { ui_names_5, ui_times_5, ui_correct_a_5 },
            };

            ui_player_name.Text = result.name;
            { 
                uint minutes = (uint)(result.time / 60);
                uint seconds = (uint)(result.time % 60);
                String min, sec;
                if (minutes < 10)
                    min = "0" + minutes.ToString();
                else
                    min = minutes.ToString();

                if (seconds < 10)
                    sec = "0" + seconds.ToString();
                else
                    sec = seconds.ToString();
                ui_player_time.Text = min + ":" + sec; 
            }
            ui_player_correct_a.Text = result.questionNumer.ToString();

            for (int i = 0; i < stats.Count; i++) {
                list[i][0].Text = stats[i].name;
                {
                    ui_player_name.Text = result.name;
                    uint minutes = (uint)(stats[i].time / 60);
                    uint seconds = (uint)(stats[i].time % 60);
                    String min, sec;
                    if (minutes < 10)
                        min = "0" + minutes.ToString();
                    else
                        min = minutes.ToString();

                    if (seconds < 10)
                        sec = "0" + seconds.ToString();
                    else
                        sec = seconds.ToString();
                    list[i][1].Text = min + ":" + sec;
                }

                list[i][2].Text = stats[i].number.ToString();
            }

        }
        private void OnLoad(object sender, RoutedEventArgs e) {
            result = parent.UCgame.GetResult();
            PrintBoard(result);
            controller.SaveResult(result);
        }

    }
}

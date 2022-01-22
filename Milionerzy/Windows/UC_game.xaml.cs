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
using System.Timers;

namespace Milionerzy.Windows {
    

    /// <summary>
    /// Logika interakcji dla klasy UC_game.xaml
    /// </summary>
    public partial class UC_game : UserControl {

        public MainWindow parent;

        private DB_controller controller;

        private Question? question;
        private List<Button> buttons;
        private int correctAnswerPos;

        private bool fiftyFifty = true;
        private bool audienceQuestion = true;
        private bool friendTalk = true;


        private ulong time = 0;

        public UC_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
            controller = new DB_controller();
            buttons = new List<Button> { ui_answer_a, ui_answer_b, ui_answer_c, ui_answer_d };
        }
        private void SetUpAnswers(Question question) {
            var generator = new Random();
            correctAnswerPos = generator.Next(4);
            buttons[correctAnswerPos].Content = question.poprawna;
            List<int> positions = new List<int> { 0, 1, 2, 3 };
            positions.Remove(correctAnswerPos);

            for (int i = 0; i < 3; i++) {
                var r = new Random();
                int randomInt = r.Next(positions.Count);
                buttons[positions[randomInt]].Content = question.niepoprawne[i];
                positions.RemoveAt(randomInt);

            }

        }
        private void LoadQuestion(object sender, RoutedEventArgs e) {
            question = controller.GetQuestion();
            SetUpAnswers(question);
            ui_question.Content = question.pytanie;
        }
        private void SetUpTimer(object sender, RoutedEventArgs e) {
            Timer timer = new Timer(1000);
            timer.Interval = 1000;
            timer.Elapsed += OnTimerChange;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void OnTimerChange(object? sender, EventArgs? e) {
            this.Dispatcher.Invoke(() => {
                time++;
                ulong minutes = (time / 60ul);
                short seconds = (short)(time % 60ul);
                String minStr = minutes.ToString();
                String secStr = seconds.ToString();
                if (minutes < 10) {
                    
                    minStr = "0" + minutes.ToString();
                }
                if (seconds < 10) {
                    secStr = "0" + seconds.ToString();
                }
                ui_timer.Content = "Czas: " + minStr + ":" + secStr;
            });
        }
        private void CheckAnswer(int button) {
            if (button != correctAnswerPos) {
                buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 173, 36, 26));
            }
            else {
                buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 38, 163, 0));
            }
        }
        private void ui_answer_a_Click(object sender, RoutedEventArgs e) {
            CheckAnswer(0);
        }
        private void ui_answer_b_Click(object sender, RoutedEventArgs e) {
            CheckAnswer(1);
        }
        private void ui_answer_c_Click(object sender, RoutedEventArgs e) {
            CheckAnswer(2);
        }
        private void ui_answer_d_Click(object sender, RoutedEventArgs e) {
            CheckAnswer(3);
        }
    }
}

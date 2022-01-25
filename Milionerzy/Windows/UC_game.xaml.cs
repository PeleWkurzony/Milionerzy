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

        /// <summary>
        /// Kontroler służący do komunikacji z bazą danych
        /// </summary>
        private DB_controller controller;

        /// <summary>
        /// Obiekt przechowujący aktualne pytanie
        /// </summary>
        private Question? question;
        /// <summary>
        /// Lista elementów UI zawierających odpowiedzi
        /// </summary>
        private List<Button> buttons;
        /// <summary>
        /// Pozycja na liście buttons poprawnej odpowiedzi
        /// </summary>
        private int correctAnswerPos;

        /// Nie używane
        //private bool fiftyFifty = true;
        //private bool audienceQuestion = true;
        //private bool friendsTalk = true;
        /// Nie używane

        private double time = 0;
        private bool canAnswer = true;
        private uint questionNumer = 1;

        private Timer? timer;
        private int chosenAnswer;
        private String nickname;

        public UC_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
            controller = new DB_controller();
            buttons = new List<Button> { ui_answer_a, ui_answer_b, ui_answer_c, ui_answer_d };
        }
        /// <summary>
        /// Tworzy obiekt Result zawierający wynik końcowy rozgrywki
        /// </summary>
        /// <returns> Zwraca obiekt Result zawierający wynik końcowy rozgrywki </returns>
        public Result GetResult() {
            Result result = new Result();
            result.time = time;
            result.questionNumer = questionNumer - 1;
            result.questionId = question.id;
            result.chosenAnswer = buttons[chosenAnswer].Content.ToString();
            result.name = nickname;
            return result;

        }
        /// <summary>
        /// Ustawia możliwe odopowiedzi w odpowiednich miejscach oraz wyświetla je na ekranie
        /// </summary>
        /// <param name="question"> Pytanie, które ma zostać wyświetlone </param>
        private void SetUpAnswers(Question question) {
            this.Dispatcher.Invoke(() => {
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
            });
        }
        /// <summary>
        /// Pobiera wszystkie pytania z bazy danych oraz ustawia nazwę gracza
        /// </summary>
        private void LoadQuestion(object? sender, RoutedEventArgs? e) {
            this.Dispatcher.Invoke(() => {
                nickname = parent.UCstartGame.ui_nickname.Text;
                question = controller.GetQuestion();
                SetUpAnswers(question);
                ui_question.Text = question.pytanie;
            });
        }
        /// <summary>
        /// Ustawia zegar i wszystkie ustawienia związane z nim
        /// </summary>
        private void SetUpTimer(object sender, RoutedEventArgs e) {
            timer = new Timer(1000);
            timer.Interval = 1000;
            timer.Elapsed += OnTimerChange;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        /// <summary>
        /// Funkcja zmieniająca czas zegaru oraz wyświetlająca informacje na ekranie
        /// </summary>
        private void OnTimerChange(object? sender, EventArgs? e) {
            try {
                this.Dispatcher.Invoke(() => {
                    time += 0.5;
                    ulong minutes = (ulong)(time / 60);
                    short seconds = (short)(time % 60);
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
            } catch (Exception) { }
        }
        /// <summary>
        /// Funkcja sprawdzająca wybraną odpowiedź
        /// </summary>
        /// <param name="button"> Numer przycisku, który został wybrany </param>
        private void CheckAnswer(int button) {
            this.Dispatcher.Invoke(() => { 
                if (!canAnswer) return;
                canAnswer = false;
                chosenAnswer = button;
                //For wrong answer
                if (button != correctAnswerPos) {
                    timer.Stop();
                    buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 173, 36, 26));
                    buttons[correctAnswerPos].Background = new SolidColorBrush(Color.FromArgb(200, 38, 163, 0));
                    Task.Delay(5000).ContinueWith(t => {
                        this.parent.SwitchTo(parent.UCendGame);
                    });
                }
                //For good answer
                else {
                  buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 0xC0, 0xFF, 0));
                    Task.Delay(5000).ContinueWith(t => {
                        questionNumer++;
                        this.Dispatcher.Invoke(() => { 
                            ui_counter.Content = "Pytanie nr. " + questionNumer;
                        });
                        LoadQuestion(null, null);
                        this.Dispatcher.Invoke(() => { 
                            buttons[button].Background = new SolidColorBrush(Color.FromArgb(0x99, 0xDD, 0xDD, 0xDD));
                        });
                        canAnswer = true;
                    });
                
                }
            });
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

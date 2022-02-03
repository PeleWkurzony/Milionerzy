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



namespace Milionerzy.Windows
{

    /// <summary>
    /// Logika interakcji dla klasy UC_game.xaml
    /// </summary>
    public partial class UC_game : UserControl
    {

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

        private bool lastQuestionHave = false;

        private double time = 0;
        private bool canAnswer = true;
        private uint questionNumer = 1;

        private Timer? timer;
        private int chosenAnswer;
        private String nickname;

        public UC_game(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            controller = new DB_controller();
            buttons = new List<Button> { ui_answer_a, ui_answer_b, ui_answer_c, ui_answer_d };
        }
        /// <summary>
        /// Tworzy obiekt Result zawierający wynik końcowy rozgrywki
        /// </summary>
        /// <returns> Zwraca obiekt Result zawierający wynik końcowy rozgrywki </returns>
        public Result GetResult()
        {
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
        private void SetUpAnswers(Question question)
        {
            this.Dispatcher.Invoke(() =>
            {
                var generator = new Random();
                correctAnswerPos = generator.Next(4);
                buttons[correctAnswerPos].Content = question.poprawna;
                List<int> positions = new List<int> { 0, 1, 2, 3 };
                positions.Remove(correctAnswerPos);

                for (int i = 0; i < 3; i++)
                {
                    var r = new Random();
                    int randomInt = r.Next(positions.Count);
                    buttons[positions[randomInt]].Content = question.niepoprawne[i];
                    positions.RemoveAt(randomInt);

                }
            });
        }

        private void AppendChars()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = ((char)('a' + i)).ToString() + ": " + buttons[i].Content;
            }
        }

        /// <summary>
        /// Pobiera wszystkie pytania z bazy danych oraz ustawia nazwę gracza
        /// </summary>
        private void LoadQuestion(object? sender, RoutedEventArgs? e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (lastQuestionHave)
                {
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = true;
                        lastQuestionHave = false;
                    }
                }
                nickname = parent.UCstartGame.ui_nickname.Text;
                question = controller.GetQuestion();
                SetUpAnswers(question);
                ui_question.Text = question.pytanie;
                AppendChars();
            });
        }
        /// <summary>
        /// Ustawia zegar i wszystkie ustawienia związane z nim
        /// </summary>
        private void SetUpTimer(object sender, RoutedEventArgs e)
        {
            timer = new Timer(1000);
            timer.Interval = 1000;
            timer.Elapsed += OnTimerChange;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        /// <summary>
        /// Funkcja zmieniająca czas zegaru oraz wyświetlająca informacje na ekranie
        /// </summary>
        private void OnTimerChange(object? sender, EventArgs? e)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    time += 0.5;
                    ulong minutes = (ulong)(time / 60);
                    short seconds = (short)(time % 60);
                    String minStr = minutes.ToString();
                    String secStr = seconds.ToString();
                    if (minutes < 10)
                    {

                        minStr = "0" + minutes.ToString();
                    }
                    if (seconds < 10)
                    {
                        secStr = "0" + seconds.ToString();
                    }
                    ui_timer.Content = "Czas: " + minStr + ":" + secStr;
                });
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Funkcja sprawdzająca wybraną odpowiedź
        /// </summary>
        /// <param name="button"> Numer przycisku, który został wybrany </param>
        private void CheckAnswer(int button)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (!canAnswer) return;
                canAnswer = false;
                chosenAnswer = button;
                //For wrong answer
                if (button != correctAnswerPos)
                {
                    timer.Stop();
                    buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 173, 36, 26));
                    buttons[correctAnswerPos].Background = new SolidColorBrush(Color.FromArgb(200, 38, 163, 0));
                    Task.Delay(5000).ContinueWith(t =>
                    {
                        this.parent.SwitchTo(parent.UCendGame);
                    });
                }
                //For good answer
                else
                {
                    buttons[button].Background = new SolidColorBrush(Color.FromArgb(200, 0xC0, 0xFF, 0));
                    Task.Delay(5000).ContinueWith(t =>
                    {
                        questionNumer++;
                        this.Dispatcher.Invoke(() =>
                        {
                            ui_counter.Content = "Pytanie nr. " + questionNumer;
                        });
                        LoadQuestion(null, null);
                        this.Dispatcher.Invoke(() =>
                        {
                            buttons[button].Background = new SolidColorBrush(Color.FromArgb(0x99, 0xDD, 0xDD, 0xDD));
                        });
                        canAnswer = true;
                    });

                }
            });
        }

        private void ui_answer_a_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(0);
        }
        private void ui_answer_b_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(1);
        }
        private void ui_answer_c_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(2);
        }
        private void ui_answer_d_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(3);
        }

        private void ui_next_question_Click(object sender, RoutedEventArgs e)
        {
            ui_next_question.IsEnabled = false;
            LoadQuestion(null, null); 
        }

        private void ui_half_Click(object sender, RoutedEventArgs e)
        {
            lastQuestionHave = true;
            ui_half.IsEnabled = false;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].IsEnabled = false;
            }
            buttons[correctAnswerPos].IsEnabled = true;
            int randomPos;
            var generator = new Random();
            do {
                randomPos = generator.Next(4);
            } while (randomPos == correctAnswerPos);

            buttons[randomPos].IsEnabled = true;
        }

        private List<int> PercentDraw()
        {
            var random = new Random();
            int percent = 100;
            int next = 0;
            List<int> percents = new List<int> { 0,0,0,0 };
            next = random.Next(40, percent);
            percents[correctAnswerPos] = next;
            percent -= next;
            for (int i = 0; i < percents.Count; i++)
            {
                if (percents[i] != 0) continue;
                next = random.Next(percent);
                percents[i] = next;
                percent -= next;
            }
            return percents;
        }

        private void ui_audience_question_Click(object sender, RoutedEventArgs e)
        {
            ui_audience_question.IsEnabled = false;
            var stats = new Window();
            stats.Width = 200;
            stats.Height = 200;
            stats.Title = "Odpowiedzi publiczności";
            
            var percentes = PercentDraw();
            for (int i = 0; i < percentes.Count; i++)
            {
                stats.Content += "Odp " + (char)('a' + i) + $": {percentes[i]}%" + "\n";
            }
            int withNoAnswer = 100;
            foreach (int i in percentes)
            {
                withNoAnswer -= i;
            }
            stats.Content += $"Nie wzieło udziału: {withNoAnswer}%";
            stats.Show();
        }
    }
}

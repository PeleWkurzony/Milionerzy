using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
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
using Stats = Milionerzy.Windows.UC_end_game.Stats;

namespace Milionerzy.Scripts {
    /// <summary>
    /// Klasa zajmująca się zarządzaniem bazą danych MySQL
    /// </summary>
    public class DB_controller {

        /// <summary>
        /// Lista id pytań, które już zostały wykorzystane
        /// </summary>
        private static List<int> previousQuestions = new List<int>();
        /// <summary>
        /// Lista wszyskich pytań tworzona podczas konstruowania DB_controller funkcją DownloadQuestions()
        /// </summary>
        private static List<Question> questions = new List<Question>();
        /// <summary>
        /// Sformatowany string zawierający wszyskie informacje o bazie danych
        /// </summary>
        private String connStr = "";

        /*  -----------------------------------------------------------------------------------------------------
         * 
         *              Public  
         * 
         *  -----------------------------------------------------------------------------------------------------   
         */
        /// <summary>
        /// Tworzy kontroler do zarządzania bazą danych MySQL
        /// </summary>
        /// <param name="host"> Adres serwera bazy danych { domyślnie: localhost } </param>
        /// <param name="user"> Nazwa użytkownika bazy danych { domyślnie: root }</param>
        /// <param name="database"> Baza zawierająca tabele { domyślnie: milionerzy }</param>
        /// <param name="port"> Port dla bazy danych MySQL { domyślnie: 3306 }</param>
        /// <param name="password"> Hasło do bazy danych { domyślnie: }</param>
        public DB_controller(String host = "localhost", String user = "root", String database = "milionerzy", String port = "3306", String password = "") {
            connStr = "server=" + host + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password;
            DownloadQuestions();
        }
        /// <summary>
        /// Zwraca jedno pytanie z bazy danych bez powtórek
        /// </summary>
        /// <returns> Obiekt Question zawierający najważniejsze informacje o pytaniu </returns>
        public Question? GetQuestion() {
            if (questions.Count == 0) return null;
            var generator = new Random();
            int random = generator.Next(questions.Count);
            Question toReturn = questions[random];
            previousQuestions.Add(toReturn.id);
            questions.RemoveAt(random);
            return toReturn;
        }
        /// <summary>
        /// Zapisuje wynik gracza w bazie danych MySql
        /// </summary>
        /// <param name="result"> Obiekt Result zawierający wszystkie informacje o rozgrywce gracza </param>
        public void SaveResult(Result result) {
            try {

                var conn = new MySqlConnection(connStr);
                conn.Open();
                String sql = $"INSERT INTO ranking VALUES" +
                    $"(NULL, \"{result.name}\", {result.time}, {result.questionId}, \'{result.chosenAnswer}\', " +
                    $"{result.questionNumer} );";
                var command = new MySqlCommand(sql, conn);
                var smt = command.ExecuteScalar();
                conn.Close();

            } catch (Exception e) {
                Window w = new Window();
                w.Height = 300;
                w.Width = 300;
                var txt = new TextBox();
                txt.Text = e.Message;
                w.Content = txt;
                w.Show();
            }
        }
        /// <summary>
        /// Funkcja zwraca liste 4 - elementową zawierającą 2 najlepsze wyniki (dwa pierwsze) 
        /// oraz 2 najgorsze wyniki (dwa ostatnie)
        /// </summary>
        /// <param name="number"> Liczba rund jaką gracz rozegrał zanim przegrał </param>
        /// <returns> Lista obiektów Stats zawierająca informacje o 2 najlepszych wynikach (dwa pierwsze) 
        /// i 2 najgorszych (dwa ostatnie)
        /// </returns>
        public List<Stats> GetStats(uint number) {
            var list = new List<Stats>();
            try {

                var conn = new MySqlConnection(connStr);
                conn.Open();
                String sql = $"SELECT nazwa, czas_rozgrywki, ilosc_dobrych_odp FROM ranking WHERE ilosc_dobrych_odp >= {number} ORDER BY ilosc_dobrych_odp ASC , czas_rozgrywki ASC  LIMIT 2;";
                var command = new MySqlCommand(sql, conn);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read()) {
                    list.Add(new Stats(dataReader.GetString(0), (ulong)dataReader.GetInt32(1), (uint)dataReader.GetInt32(2)));
                }

                if (list.Count == 2) {
                    var s = list[0];
                    list[0] = list[1];
                    list[1] = s;
                }

                dataReader.Close();

                sql = $"SELECT nazwa, czas_rozgrywki, ilosc_dobrych_odp FROM ranking WHERE ilosc_dobrych_odp <= {number} ORDER BY ilosc_dobrych_odp DESC, czas_rozgrywki DESC LIMIT 2;";
                command = new MySqlCommand(sql, conn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read()) {
                    list.Add(new Stats(dataReader.GetString(0), (ulong)dataReader.GetInt32(1), (uint)dataReader.GetInt32(2)));
                }
                conn.Close();

            } catch (Exception e) {
                Window w = new Window();
                w.Height = 300;
                w.Width = 300;
                var txt = new TextBox();
                txt.Text = e.Message;
                w.Content = txt;
                w.Show();
            }
            return list;
        }
        /*  -----------------------------------------------------------------------------------------------------
         * 
         *              Private
         * 
         *  -----------------------------------------------------------------------------------------------------   
         */
        /// <summary>
        /// Funkcja pomocnicza do tworzenia zapytań SQL
        /// </summary>
        /// <returns> Zwraca String, który jest sformatowany, aby wstawić go do zapytania SQL </returns>
        private String PrintList() {
            if (previousQuestions.Count != 0) {
                String toReturn = " WHERE ID NOT IN (";
                foreach (int id in previousQuestions) {
                    toReturn += id.ToString() + ",";
                }
                try {
                    toReturn = toReturn.Remove(toReturn.Length - 1);
                } catch (Exception) { return ""; }
                return toReturn + ")";
            } else {
                return "";
            }
        }
        /// <summary>
        /// Pobiera wszystkie pytania z bazy danych i zapisuje je w zmiennej questions
        /// </summary>
        /// <returns> Zwraca true w przypadku pełnego powodzenia </returns>
        private bool DownloadQuestions() {
            try {
                
                var conn = new MySqlConnection(connStr);
                conn.Open();
                String sql = "SELECT ID, pytanie, poprawna, npoprawna1, npoprawna2, npoprawna3 FROM milionerzy" + PrintList();
                var command = new MySqlCommand(sql, conn);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read()) {
                    questions.Add(new Question(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), new String[] { dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5) }));
                }
                conn.Close();

            } catch (Exception e) {
                Window w = new Window();
                w.Height = 300;
                w.Width = 300;
                var txt = new TextBox();
                txt.Text = e.Message;
                w.Content = txt;
                w.Show();
                return false;
            }
            return true;
        }
    }
}

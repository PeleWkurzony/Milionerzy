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
        public void SaveResult(Result result) {
            try {

                var conn = new MySqlConnection(connStr);
                conn.Open();
                String sql = $"INSERT INTO ranking VALUES" +
                    $"(NULL, \"{result.name}\", {result.time}, {result.questionId}, \"{result.chosenAnswer}\", " +
                    $"{result.questionNumer} );";
                var command = new MySqlCommand(sql, conn);
                var smt = command.ExecuteScalar();


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
                    Question quest = new Question(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), new String[] { dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5) });
                    questions.Add(quest);
                }

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

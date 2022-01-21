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
using System.Data.SqlClient;

namespace Milionerzy.Windows {
    public class Row {
        public Row(int i, String p, String[] n) {
            this.id = i;
            this.pytanie = p;
            this.niepoprawne = n;
        }

        public int id;
        public String pytanie;
        public String[] niepoprawne;

        
    }

    /// <summary>
    /// Logika interakcji dla klasy UC_game.xaml
    /// </summary>
    public partial class UC_game : UserControl {


        /*
                                                                              
                   d888888o.    8 8888 8 8888      88 8 888888888o.   8 888888888o.   
                 .`8888:' `88.  8 8888 8 8888      88 8 8888    `88.  8 8888    `88.  
                 8.`8888.   Y8  8 8888 8 8888      88 8 8888     `88  8 8888     `88  
                 `8.`8888.      8 8888 8 8888      88 8 8888     ,88  8 8888     ,88  
                  `8.`8888.     8 8888 8 8888      88 8 8888.   ,88'  8 8888.   ,88'  
                   `8.`8888.    8 8888 8 8888      88 8 888888888P'   8 888888888P'   
                    `8.`8888.   8 8888 8 8888      88 8 8888`8b       8 8888`8b       
                8b   `8.`8888.  8 8888 ` 8888     ,8P 8 8888 `8b.     8 8888 `8b.     
                `8b.  ;8.`8888  8 8888   8888   ,d8P  8 8888   `8b.   8 8888   `8b.   
                 `Y8888P ,88P'  8 8888    `Y88888P'   8 8888     `88. 8 8888     `88. 

        */
        public MainWindow parent;

        private String question = "";
        private String answer = "";
        private String[] wrongAnswers = { "", "", "" };

        private static List<int> previousQuestions = new List<int>();

        public UC_game(MainWindow parent) {
            InitializeComponent();
            this.parent = parent;
        }
        /// <summary>
        /// Funkcja pomocnicza do tworzenia zapytań SQL
        /// </summary>
        /// <returns> Zwraca String, który jest sformatowany, aby wstawić go do zapytania </returns>
        private String PrintList() {
            String toReturn = " WHERE ID NOT IN (";
            foreach (int id in previousQuestions) {
                toReturn += id.ToString() + ",";
            }
            try {
                toReturn = toReturn.Remove(toReturn.Length - 1);
            } catch (Exception) { return ""; }
            return toReturn + ")";
        }
        
        private bool DownloadQuestion() {
            try {
                var builder = new SqlConnectionStringBuilder();

                builder.DataSource = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.InitialCatalog = "milionerzy";

                using (var conn = new SqlConnection(builder.ConnectionString)) {
                    String sql = "SELECT ID, pytanie, poprawna, npoprawna1, npoprawna2, npoprawna3 FROM milionerzy" + PrintList();
                    conn.Open();

                    using (var cmd = new SqlCommand(sql, conn)) {
                        using (var dataReader = cmd.ExecuteReader()) {
                            while (dataReader.Read()) {
                                Row row = new Row(dataReader.GetInt32(0), dataReader.GetString(1), new String[] { dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4) });
                            }
                        }
                    }
                }
            } catch (SqlException e) {
                Window w = new Window();
                var txt = new TextBox();
                txt.Text = e.Message;
                w.Content = txt;
                w.Show();
                return false;
            }
            return true;
        }

        private void DownloadQuestion(object sender, RoutedEventArgs e) {
            DownloadQuestion();
        }
    }
}

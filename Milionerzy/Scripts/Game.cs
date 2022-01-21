using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Scripts {
    internal class GameManager {
        /// <summary>
        /// Licznik rund
        /// </summary>
        int round = 0;
        /// <summary>
        /// Nazwa gracza używana do rankingu
        /// </summary>
        String nickname = "";
        /// <summary>
        /// Flagi oznaczające dostępne koła ratunkowe
        /// </summary>
        String powerups = "111";

        /// <summary>
        /// Aktualne pytanie
        /// </summary>
        String question = "";
        /// <summary>
        /// Dobra odpowiedź
        /// </summary>
        String goodAnswer = "";
        /// <summary>
        /// Trzy złe odpowiedzi
        /// </summary>
        String[] answers = { };

        /// <summary>
        /// Lista przetrzymująca id pytań, które już wystąpiły
        /// </summary>
        List<int> lastQuestions = new List<int>();

        /// <summary>
        /// Konstruktor wykorzystywany do ładowania ustawień gry
        /// </summary>
        /// <param name="nick"> Nazwa gracza </param>
        public GameManager(String nick) {

        }
        /// <summary>
        /// Funkcja pobierająca pytania z bazy danych
        /// </summary>
        /// <returns> Zwraca false w przypadku niepowodzenia </returns>
        private bool DownloadQuestions() {
            return true;
        }
    }
}

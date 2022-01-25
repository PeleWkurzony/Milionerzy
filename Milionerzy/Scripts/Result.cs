using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Scripts {
    /// <summary>
    /// Klasa przechowująca wynik gracza po przegraniu gry
    /// </summary>
    public class Result {
        /// <summary>
        /// Czas trwania gry
        /// </summary>
        public double time;
        /// <summary>
        /// Ilość poprawnie odpowiedzianych pytań
        /// </summary>
        public uint questionNumer;
        /// <summary>
        /// Id pytania
        /// </summary>
        public int questionId;
        /// <summary>
        /// Wybrana odpowiedź przez gracza, która okazała się błędna
        /// </summary>
        public String chosenAnswer = "";
        /// <summary>
        /// Nazwa gracza
        /// </summary>
        public String name = "";
    }
}

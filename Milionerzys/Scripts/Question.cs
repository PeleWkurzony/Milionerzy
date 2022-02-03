using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Scripts {

    /// <summary>
    /// Klasa przechowująca wszyskie informacje o pytaniu
    /// </summary>
    public class Question {
        /// <summary>
        /// Konstruktor przypisujący wszystkie informacje o pytaniu
        /// </summary>
        /// <param name="id"> Id pytania </param>
        /// <param name="pytanie"> Treść pytania </param>
        /// <param name="poprawna"> Treść poprawnej odpowiedzi </param>
        /// <param name="niepoprawne"> Treść trzech niepoprawnych odpowiedzi </param>
        public Question(int id, String pytanie, String poprawna, String[] niepoprawne) {
            this.id = id;
            this.pytanie = pytanie;
            this.poprawna = poprawna;
            this.niepoprawne = niepoprawne;
        }
        /// <summary>
        /// Id pytania
        /// </summary>
        public int id;
        /// <summary>
        /// Treść pytania
        /// </summary>
        public String pytanie;
        /// <summary>
        /// Treść poprawnej odpowiedzi
        /// </summary>
        public String poprawna;
        /// <summary>
        /// Trzy treści niepoprawnych odpowiedzi
        /// </summary>
        public String[] niepoprawne;
    }
}

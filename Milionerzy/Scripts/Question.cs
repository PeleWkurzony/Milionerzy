using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionerzy.Scripts {

    /// <summary>
    /// Klasa przechowująca wszyskie wiersze pytania
    /// </summary>
    public class Question {
        public Question(int id, String pytanie, String poprawna, String[] niepoprawne) {
            this.id = id;
            this.pytanie = pytanie;
            this.poprawna = poprawna;
            this.niepoprawne = niepoprawne;
        }

        public int id;
        public String pytanie;
        public String poprawna;
        public String[] niepoprawne;
    }
}

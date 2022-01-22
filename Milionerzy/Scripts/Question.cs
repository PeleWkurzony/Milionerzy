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
        public Question(int i, String p, String pop, String[] n) {
            this.id = i;
            this.pytanie = p;
            this.poprawna = pop;
            this.niepoprawne = n;
        }

        public int id;
        public String pytanie;
        public String poprawna;
        public String[] niepoprawne;
    }
}

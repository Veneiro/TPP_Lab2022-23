using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo
{

    public class Origen {

        public Origen(string pais, string ciudad) {
            Pais = pais; 
            Ciudad = ciudad;
        }

        public string Pais { get; private set;}
        public string Ciudad { get; private set; }

        public override string ToString() {
            return String.Format("[Origen: {0}\\{1}]", Pais, Ciudad);
        }
    }
}

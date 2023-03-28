using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo {

    public class Emparejamiento {

        public DateTime Fecha { get; set; }

        public string Id_animal1 { get; set; }

        public string Id_animal2 { get; set; }	

        public int Duracion { get; set; } 

        public override string ToString() {
            return String.Format("[Emparejamiento:  {0} con {1}]", Id_animal1, Id_animal2);
        }
    }
}

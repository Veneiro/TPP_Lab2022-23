using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.tpplab_poo_pfunc
{

    public class Jugador {

        public Jugador(string name, string surname, string dni, string nacionalidad) {
            Name = name;
            Surname = surname;
            Dni = dni;
            Nacionalidad = nacionalidad;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Nacionalidad { get; set; }

        public override string ToString() {
            return String.Format("[Jugador: {0} {1}]", Name, Surname);
        }
    }

}

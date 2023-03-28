using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.tpplab_poo_pfunc
{

    public class Equipo {

        public Equipo(string name, IEnumerable<Jugador> jugadores) {
            Name = name; 
            Jugadores = jugadores;
        }

        public readonly string Name;

        public readonly IEnumerable<Jugador> Jugadores;

        public override string ToString() {
            return String.Format("[Equipo: {0}]", Name);
        }
    }
}

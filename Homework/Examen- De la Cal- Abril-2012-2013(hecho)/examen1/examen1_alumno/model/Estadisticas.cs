using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.tpplab_poo_pfunc
{

    //Esta clase representa una simplificación de las estadísticas reales tomadas en un partido de la liga ACB española.
    public class  Estadistica{

        public int Njornada { get; set; } //Número de jornada del partido.

        public string Dni { get; set; }	   //DNI del jugador

        public bool Fuera { get; set; }    //True si el partido se jugaba fuera, false en caso contrario. No se ha incluido la entidad Partido por no complicar demasiado del modelo.	

        public int MinJugados { get; set; } //Minutos jugados.

        public int Canastas1P { get; set; }  //Canastas de 1 punto.

        public int Canastas2P { get; set; }  //Canastas de 2 puntos.

        public int Canastas3P { get; set; }  //Canastas de 3 puntos.

        public int BalonesRecuperados { get; set; }   //Recuperaciones de balón. 

        public int BalonesPerdidos { get; set; }      //Pérdidas de balón. 

        public int TaponesFavor { get; set; }         //Tapones a favor

        public int TaponesContra { get; set; }      //Tapones en contra

        public override string ToString() {
            return String.Format("[Nj{0} F{1} mj{2} 1p{3} 2p{4} 3p{5} br{6} bp{7} bp{8} tf{9} tc{10}]", Njornada, Dni, Fuera, MinJugados, Canastas1P, Canastas2P, Canastas3P, BalonesRecuperados, BalonesPerdidos, TaponesFavor, TaponesContra);
        }
    }
}

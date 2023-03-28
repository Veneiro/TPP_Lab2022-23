using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TPP.Laboratory.tpplab_poo_pfunc
{


    public class Modelo {
        static Random rand = new Random();
        public IList<Equipo> Equipos { get { return equipos; } }
        public IList<Jugador> Jugadores { get { return jugadores; } }
        public IList<Estadistica> Estadisticas { get { return estadisticas; } }


        static Modelo() {
            ResetModel();
        }

        public static void ResetModel() {
            jugadores = new List<Jugador> {
                // Valencia Basquet
			    new Jugador ("R.", "San Miguel", "xxxxxxx0X", "ESP" ),
			    new Jugador ("Stefan", "Marcovich", "xxxxxxx1X", "SRV" ),
                new Jugador ("Pau", "Ribas", "xxxxxxx2X", "ESP" ),
			    new Jugador ("Justin", "Doellman", "xxxxxxx3X", "USA" ),
                new Jugador ("Bojan", "Dubljevic", "xxxxxxx4X", "MNE" ),
                // Fuenlabrada
			    new Jugador ("Leo", "Mainoldi", "xxxxxxx5X", "ARG" ),
                new Jugador ("Mouhamed S.", "Sene", "xxxxxxx6X", "SEN" ),
			    new Jugador ("Sergii", "Gladyr", "xxxxxxx7X", "UKR" ),
                new Jugador ("Alvaro", "Muñoz", "xxxxxxx8X", "ESP" ),
			    new Jugador ("James", "Feldaine", "xxxxxxx9X", "USA" ),
                // Caja Laboral
                new Jugador ("Omar", "Cook", "xxxxxx10X", "MNE" ),
			    new Jugador ("Andrés", "Nocioni", "xxxxxx11X", "ITA" ),
                new Jugador ("Milko", "Bjelica", "xxxxxx12X", "MNE" ),
			    new Jugador ("Fernando", "San Emeterio", "xxxxxx13X", "ESP" ),
                new Jugador ("Tibor", "Pleiss", "xxxxxx14X", "ALE" ),
                // Unicaja
			    new Jugador ("Krunoslav", "Simon", "xxxxxx15X", "HRV" ),
                new Jugador ("Marcus", "Williams", "xxxxxx16X", "USA" ),
			    new Jugador ("Augusto", "Lima", "xxxxxx17X", "BRA" ),
                new Jugador ("Andy", "Panko", "xxxxxx18X", "USA" ),
			    new Jugador ("Earl", "Calloway", "xxxxxx19X", "USA" ),
                };
  
            equipos = new List<Equipo> {
			    new Equipo ( "Valencia Basquet", new List<Jugador> {jugadores[0], jugadores[1], jugadores[2], jugadores[3], jugadores[4] } ),
			    new Equipo ( "Fuenlabrada", new List<Jugador> {jugadores[5], jugadores[6], jugadores[7], jugadores[8], jugadores[9]}),
			    new Equipo ( "Caja Laboral",new List<Jugador> {jugadores[10], jugadores[11], jugadores[12], jugadores[13], jugadores[14]}),
			    new Equipo ( "Unicaja",new List<Jugador> {jugadores[15], jugadores[16], jugadores[17], jugadores[18], jugadores[19]}),
    		    };


            //Hemos incluido estadísticas para dos partidos para cada jugador pero los cálculo deberán hacerse teniendo en cuenta que pudieran ser N partidos
            estadisticas = new List<Estadistica> {
			   new Estadistica {Njornada = 0 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 27 , Canastas1P = 7, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 39 , Canastas1P = 5, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 27 , Canastas1P = 3, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 37 , Canastas1P = 7, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 28 , Canastas1P = 7, Canastas2P = 1, Canastas3P = 0, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 15 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 24 , Canastas1P = 7, Canastas2P = 6, Canastas3P = 1, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 28 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 15 , Canastas1P = 3, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 23 , Canastas1P = 10, Canastas2P = 4, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx0X" , Fuera = false, MinJugados= 37 , Canastas1P = 2, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx0X" , Fuera = true, MinJugados= 18 , Canastas1P = 1, Canastas2P = 4, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 37 , Canastas1P = 0, Canastas2P = 3, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 14 , Canastas1P = 2, Canastas2P = 6, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 35 , Canastas1P = 5, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 16 , Canastas1P = 6, Canastas2P = 0, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 12 , Canastas1P = 5, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 25 , Canastas1P = 2, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 37 , Canastas1P = 5, Canastas2P = 0, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 38 , Canastas1P = 3, Canastas2P = 0, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 22 , Canastas1P = 2, Canastas2P = 1, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 32 , Canastas1P = 8, Canastas2P = 6, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx1X" , Fuera = false, MinJugados= 35 , Canastas1P = 9, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx1X" , Fuera = true, MinJugados= 27 , Canastas1P = 6, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 28 , Canastas1P = 6, Canastas2P = 8, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 31 , Canastas1P = 10, Canastas2P = 4, Canastas3P = 6, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 34 , Canastas1P = 7, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 23 , Canastas1P = 8, Canastas2P = 5, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 39 , Canastas1P = 5, Canastas2P = 1, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 26 , Canastas1P = 2, Canastas2P = 8, Canastas3P = 5, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 11 , Canastas1P = 6, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 35 , Canastas1P = 0, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 29 , Canastas1P = 0, Canastas2P = 0, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 39 , Canastas1P = 4, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx2X" , Fuera = false, MinJugados= 18 , Canastas1P = 2, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx2X" , Fuera = true, MinJugados= 39 , Canastas1P = 6, Canastas2P = 6, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 31 , Canastas1P = 1, Canastas2P = 0, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 20 , Canastas1P = 7, Canastas2P = 0, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 15 , Canastas1P = 0, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 18 , Canastas1P = 2, Canastas2P = 4, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 19 , Canastas1P = 8, Canastas2P = 6, Canastas3P = 5, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 35 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 0, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 38 , Canastas1P = 10, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 15 , Canastas1P = 7, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 39 , Canastas1P = 10, Canastas2P = 7, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 13 , Canastas1P = 4, Canastas2P = 0, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx3X" , Fuera = false, MinJugados= 25 , Canastas1P = 6, Canastas2P = 4, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx3X" , Fuera = true, MinJugados= 20 , Canastas1P = 5, Canastas2P = 5, Canastas3P = 1, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 17 , Canastas1P = 10, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 10 , Canastas1P = 4, Canastas2P = 4, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 25 , Canastas1P = 0, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 37 , Canastas1P = 9, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 30 , Canastas1P = 1, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 12 , Canastas1P = 4, Canastas2P = 2, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 34 , Canastas1P = 3, Canastas2P = 6, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 12 , Canastas1P = 4, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 29 , Canastas1P = 8, Canastas2P = 1, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 15 , Canastas1P = 9, Canastas2P = 7, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx4X" , Fuera = false, MinJugados= 15 , Canastas1P = 2, Canastas2P = 0, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx4X" , Fuera = true, MinJugados= 32 , Canastas1P = 0, Canastas2P = 4, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 24 , Canastas1P = 10, Canastas2P = 7, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 31 , Canastas1P = 2, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 20 , Canastas1P = 7, Canastas2P = 6, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 29 , Canastas1P = 3, Canastas2P = 3, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 18 , Canastas1P = 5, Canastas2P = 5, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 17 , Canastas1P = 3, Canastas2P = 1, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 32 , Canastas1P = 10, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 31 , Canastas1P = 7, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 23 , Canastas1P = 9, Canastas2P = 2, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 16 , Canastas1P = 1, Canastas2P = 0, Canastas3P = 2, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx5X" , Fuera = false, MinJugados= 22 , Canastas1P = 0, Canastas2P = 0, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx5X" , Fuera = true, MinJugados= 31 , Canastas1P = 1, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 12 , Canastas1P = 9, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 40 , Canastas1P = 8, Canastas2P = 7, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 36 , Canastas1P = 3, Canastas2P = 4, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 38 , Canastas1P = 4, Canastas2P = 7, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 34 , Canastas1P = 10, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 28 , Canastas1P = 3, Canastas2P = 4, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 26 , Canastas1P = 4, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 35 , Canastas1P = 7, Canastas2P = 4, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 20 , Canastas1P = 2, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 27 , Canastas1P = 4, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx6X" , Fuera = false, MinJugados= 39 , Canastas1P = 6, Canastas2P = 1, Canastas3P = 5, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx6X" , Fuera = true, MinJugados= 35 , Canastas1P = 9, Canastas2P = 1, Canastas3P = 2, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  3},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 33 , Canastas1P = 5, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 21 , Canastas1P = 6, Canastas2P = 8, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 11 , Canastas1P = 4, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 37 , Canastas1P = 7, Canastas2P = 5, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 40 , Canastas1P = 8, Canastas2P = 8, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 29 , Canastas1P = 2, Canastas2P = 4, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 29 , Canastas1P = 8, Canastas2P = 3, Canastas3P = 2, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 22 , Canastas1P = 9, Canastas2P = 7, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 39 , Canastas1P = 2, Canastas2P = 7, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 35 , Canastas1P = 10, Canastas2P = 2, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx7X" , Fuera = false, MinJugados= 27 , Canastas1P = 1, Canastas2P = 6, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx7X" , Fuera = true, MinJugados= 27 , Canastas1P = 10, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 31 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 25 , Canastas1P = 2, Canastas2P = 5, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 19 , Canastas1P = 6, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 26 , Canastas1P = 3, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 22 , Canastas1P = 3, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 10 , Canastas1P = 7, Canastas2P = 1, Canastas3P = 0, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 15 , Canastas1P = 7, Canastas2P = 8, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 20 , Canastas1P = 6, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 12 , Canastas1P = 6, Canastas2P = 5, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 13 , Canastas1P = 0, Canastas2P = 1, Canastas3P = 0, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx8X" , Fuera = false, MinJugados= 40 , Canastas1P = 5, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx8X" , Fuera = true, MinJugados= 13 , Canastas1P = 9, Canastas2P = 1, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 0 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 13 , Canastas1P = 7, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 1,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 32 , Canastas1P = 5, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 26 , Canastas1P = 3, Canastas2P = 4, Canastas3P = 4, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 3 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 15 , Canastas1P = 5, Canastas2P = 7, Canastas3P = 2, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 4 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 13 , Canastas1P = 9, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 5 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 10 , Canastas1P = 3, Canastas2P = 8, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 6 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 32 , Canastas1P = 1, Canastas2P = 3, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 17 , Canastas1P = 6, Canastas2P = 7, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 37 , Canastas1P = 2, Canastas2P = 3, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 9 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 33 , Canastas1P = 10, Canastas2P = 6, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 10 , Dni = "xxxxxxx9X" , Fuera = false, MinJugados= 27 , Canastas1P = 7, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxxx9X" , Fuera = true, MinJugados= 39 , Canastas1P = 8, Canastas2P = 7, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 0 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 22 , Canastas1P = 2, Canastas2P = 5, Canastas3P = 0, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 1 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 23 , Canastas1P = 10, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 22 , Canastas1P = 6, Canastas2P = 0, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 3 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 25 , Canastas1P = 5, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  3},
new Estadistica {Njornada = 4 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 10 , Canastas1P = 8, Canastas2P = 6, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 5 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 30 , Canastas1P = 10, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 6 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 22 , Canastas1P = 4, Canastas2P = 2, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 11 , Canastas1P = 0, Canastas2P = 4, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 29 , Canastas1P = 9, Canastas2P = 4, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 9 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 39 , Canastas1P = 1, Canastas2P = 2, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx10X" , Fuera = false, MinJugados= 14 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 11 , Dni = "xxxxxx10X" , Fuera = true, MinJugados= 21 , Canastas1P = 4, Canastas2P = 5, Canastas3P = 1, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 0 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 26 , Canastas1P = 10, Canastas2P = 8, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 1 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 22 , Canastas1P = 10, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 40 , Canastas1P = 3, Canastas2P = 8, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 39 , Canastas1P = 5, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 4 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 29 , Canastas1P = 3, Canastas2P = 0, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 5 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 12 , Canastas1P = 2, Canastas2P = 3, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 6 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 32 , Canastas1P = 1, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 18 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 17 , Canastas1P = 3, Canastas2P = 1, Canastas3P = 2, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 34 , Canastas1P = 3, Canastas2P = 1, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 10 , Dni = "xxxxxx11X" , Fuera = false, MinJugados= 16 , Canastas1P = 9, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 11 , Dni = "xxxxxx11X" , Fuera = true, MinJugados= 20 , Canastas1P = 0, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 0 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 31 , Canastas1P = 9, Canastas2P = 4, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 1 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 20 , Canastas1P = 5, Canastas2P = 4, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 23 , Canastas1P = 0, Canastas2P = 0, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 30 , Canastas1P = 9, Canastas2P = 0, Canastas3P = 5, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 10 , Canastas1P = 5, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 14 , Canastas1P = 2, Canastas2P = 5, Canastas3P = 6, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 6 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 19 , Canastas1P = 0, Canastas2P = 0, Canastas3P = 2, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 7 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 33 , Canastas1P = 7, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 16 , Canastas1P = 10, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 21 , Canastas1P = 7, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx12X" , Fuera = false, MinJugados= 33 , Canastas1P = 0, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 11 , Dni = "xxxxxx12X" , Fuera = true, MinJugados= 18 , Canastas1P = 9, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 16 , Canastas1P = 7, Canastas2P = 6, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 19 , Canastas1P = 4, Canastas2P = 8, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 2 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 37 , Canastas1P = 9, Canastas2P = 4, Canastas3P = 4, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 3 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 24 , Canastas1P = 3, Canastas2P = 4, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 4 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 11 , Canastas1P = 0, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 23 , Canastas1P = 6, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 4, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 34 , Canastas1P = 10, Canastas2P = 8, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 11 , Canastas1P = 5, Canastas2P = 5, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 8 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 20 , Canastas1P = 1, Canastas2P = 3, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 23 , Canastas1P = 0, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx13X" , Fuera = false, MinJugados= 39 , Canastas1P = 1, Canastas2P = 5, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 11 , Dni = "xxxxxx13X" , Fuera = true, MinJugados= 22 , Canastas1P = 2, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  0},
new Estadistica {Njornada = 0 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 32 , Canastas1P = 10, Canastas2P = 5, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 29 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 14 , Canastas1P = 1, Canastas2P = 6, Canastas3P = 4, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 3 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 15 , Canastas1P = 3, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 25 , Canastas1P = 0, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 39 , Canastas1P = 7, Canastas2P = 3, Canastas3P = 1, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 6 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 29 , Canastas1P = 9, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 27 , Canastas1P = 6, Canastas2P = 5, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 8 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 33 , Canastas1P = 7, Canastas2P = 4, Canastas3P = 4, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 17 , Canastas1P = 4, Canastas2P = 6, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx14X" , Fuera = false, MinJugados= 38 , Canastas1P = 6, Canastas2P = 1, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 11 , Dni = "xxxxxx14X" , Fuera = true, MinJugados= 20 , Canastas1P = 3, Canastas2P = 6, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 0 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 19 , Canastas1P = 1, Canastas2P = 4, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 1 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 27 , Canastas1P = 1, Canastas2P = 6, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 2 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 26 , Canastas1P = 4, Canastas2P = 3, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 3 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 11 , Canastas1P = 9, Canastas2P = 3, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 25 , Canastas1P = 1, Canastas2P = 4, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  1},
new Estadistica {Njornada = 5 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 27 , Canastas1P = 9, Canastas2P = 1, Canastas3P = 3, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 10 , Canastas1P = 2, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 7 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 29 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 4, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 19 , Canastas1P = 0, Canastas2P = 1, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 9 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 28 , Canastas1P = 0, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 10 , Dni = "xxxxxx15X" , Fuera = false, MinJugados= 17 , Canastas1P = 9, Canastas2P = 2, Canastas3P = 2, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 11 , Dni = "xxxxxx15X" , Fuera = true, MinJugados= 31 , Canastas1P = 9, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 0 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 16 , Canastas1P = 4, Canastas2P = 2, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 1 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 26 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 1, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 2 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 21 , Canastas1P = 2, Canastas2P = 3, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 3 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 30 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 4 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 13 , Canastas1P = 5, Canastas2P = 0, Canastas3P = 1, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 5 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 31 , Canastas1P = 2, Canastas2P = 7, Canastas3P = 4, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 6 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 34 , Canastas1P = 0, Canastas2P = 5, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 22 , Canastas1P = 3, Canastas2P = 5, Canastas3P = 0, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 26 , Canastas1P = 4, Canastas2P = 0, Canastas3P = 2, BalonesRecuperados = 1, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 9 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 40 , Canastas1P = 8, Canastas2P = 6, Canastas3P = 2, BalonesRecuperados = 2, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx16X" , Fuera = false, MinJugados= 19 , Canastas1P = 8, Canastas2P = 5, Canastas3P = 1, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 11 , Dni = "xxxxxx16X" , Fuera = true, MinJugados= 20 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 0 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 23 , Canastas1P = 1, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 17 , Canastas1P = 4, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 10 , Canastas1P = 1, Canastas2P = 6, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 3 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 35 , Canastas1P = 5, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 0, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 28 , Canastas1P = 9, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 5 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 25 , Canastas1P = 8, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 6 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 31 , Canastas1P = 7, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 3,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 29 , Canastas1P = 1, Canastas2P = 3, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 8 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 34 , Canastas1P = 4, Canastas2P = 4, Canastas3P = 6, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 9 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 10 , Canastas1P = 5, Canastas2P = 1, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 10 , Dni = "xxxxxx17X" , Fuera = false, MinJugados= 32 , Canastas1P = 5, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 11 , Dni = "xxxxxx17X" , Fuera = true, MinJugados= 11 , Canastas1P = 0, Canastas2P = 6, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  1},
new Estadistica {Njornada = 0 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 10 , Canastas1P = 1, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 0, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 1 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 28 , Canastas1P = 6, Canastas2P = 3, Canastas3P = 6, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 25 , Canastas1P = 0, Canastas2P = 0, Canastas3P = 4, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  2},
new Estadistica {Njornada = 3 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 16 , Canastas1P = 4, Canastas2P = 8, Canastas3P = 5, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 4 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 22 , Canastas1P = 9, Canastas2P = 3, Canastas3P = 3, BalonesRecuperados = 2, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 5 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 31 , Canastas1P = 7, Canastas2P = 7, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 6 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 35 , Canastas1P = 8, Canastas2P = 4, Canastas3P = 5, BalonesRecuperados = 2, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 7 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 21 , Canastas1P = 5, Canastas2P = 7, Canastas3P = 4, BalonesRecuperados = 4, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 24 , Canastas1P = 9, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 9 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 35 , Canastas1P = 1, Canastas2P = 7, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 1, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 10 , Dni = "xxxxxx18X" , Fuera = false, MinJugados= 33 , Canastas1P = 2, Canastas2P = 8, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 11 , Dni = "xxxxxx18X" , Fuera = true, MinJugados= 18 , Canastas1P = 6, Canastas2P = 0, Canastas3P = 0, BalonesRecuperados = 3, BalonesPerdidos = 3, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 0 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 18 , Canastas1P = 3, Canastas2P = 8, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 1 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 16 , Canastas1P = 6, Canastas2P = 8, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 1,TaponesContra =  0},
new Estadistica {Njornada = 2 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 27 , Canastas1P = 9, Canastas2P = 7, Canastas3P = 4, BalonesRecuperados = 0, BalonesPerdidos = 4, TaponesFavor = 3,TaponesContra =  0},
new Estadistica {Njornada = 3 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 31 , Canastas1P = 8, Canastas2P = 2, Canastas3P = 2, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 0,TaponesContra =  0},
new Estadistica {Njornada = 4 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 11 , Canastas1P = 2, Canastas2P = 7, Canastas3P = 0, BalonesRecuperados = 1, BalonesPerdidos = 0, TaponesFavor = 1,TaponesContra =  2},
new Estadistica {Njornada = 5 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 26 , Canastas1P = 10, Canastas2P = 2, Canastas3P = 6, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 0,TaponesContra =  3},
new Estadistica {Njornada = 6 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 14 , Canastas1P = 10, Canastas2P = 4, Canastas3P = 6, BalonesRecuperados = 3, BalonesPerdidos = 1, TaponesFavor = 2,TaponesContra =  1},
new Estadistica {Njornada = 7 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 22 , Canastas1P = 9, Canastas2P = 1, Canastas3P = 5, BalonesRecuperados = 4, BalonesPerdidos = 1, TaponesFavor = 0,TaponesContra =  2},
new Estadistica {Njornada = 8 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 26 , Canastas1P = 7, Canastas2P = 2, Canastas3P = 3, BalonesRecuperados = 3, BalonesPerdidos = 2, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 9 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 22 , Canastas1P = 2, Canastas2P = 1, Canastas3P = 1, BalonesRecuperados = 2, BalonesPerdidos = 4, TaponesFavor = 2,TaponesContra =  3},
new Estadistica {Njornada = 10 , Dni = "xxxxxx19X" , Fuera = false, MinJugados= 29 , Canastas1P = 5, Canastas2P = 2, Canastas3P = 5, BalonesRecuperados = 0, BalonesPerdidos = 0, TaponesFavor = 2,TaponesContra =  2},
new Estadistica {Njornada = 11 , Dni = "xxxxxx19X" , Fuera = true, MinJugados= 30 , Canastas1P = 4, Canastas2P = 5, Canastas3P = 3, BalonesRecuperados = 4, BalonesPerdidos = 3, TaponesFavor = 3,TaponesContra =  1}

			    
		    };
        }

        private static List<Equipo> equipos;
        private static List<Jugador> jugadores;
        private static List<Estadistica> estadisticas;

        public void calculaEstadisticaAleatoria(out int minJugados, out int Canastas1P, out int Canastas2P, out int Canastas3P, out int BalonesRecuperados, out int BalonesPerdidos, out int TaponesFavor, out int TaponesContra)
        {
           minJugados=10+rand.Next(31); //Genera minutos jugados entre 10 y 40 min
           Canastas1P= rand.Next(11); //Genera canastas de 1p. Valores entre 0 y 10.
           Canastas2P= rand.Next(9);  //Genera canastas de 2p. Valores entre 0 y 8.
           Canastas3P= rand.Next(7); //Genera canastas de 3p. Valores entre 0 y 6.
           BalonesRecuperados= rand.Next(5); //Genera numero de balones recuperados. Valores entre 0 y 4.
           BalonesPerdidos= rand.Next(5);//Genera numero de balones perdidos. Valores entre 0 y 4.
           TaponesFavor= rand.Next(4);//Genera numero de topones a favor. Valores entre 0 y 3.
           TaponesContra = rand.Next(4);//Genera numero de topones en contra. Valores entre 0 y 3.
        
        }

         public  void generacionAleatoriaEstadisticas()
        {
          const int NIdaVuelta = 6;   
          int jornada;
          int minJugados, Canastas1P, Canastas2P, Canastas3P, BalonesRecuperados, BalonesPerdidos, TaponesFavor,  TaponesContra;
          StreamWriter sw = new StreamWriter("salida.txt");

          foreach (var jugador in jugadores)
           for(jornada = 0; jornada < NIdaVuelta*2; jornada+=2)  
            {
                calculaEstadisticaAleatoria(out minJugados, out Canastas1P, out Canastas2P, out Canastas3P, out BalonesRecuperados, out BalonesPerdidos, out TaponesFavor,  out TaponesContra);
                sw.WriteLine("new Estadistica {{" + "Njornada = {0} , Dni = \"{1}\" , Fuera = false, MinJugados= {2} , Canastas1P = {3}, Canastas2P = {4}, Canastas3P = {5}, BalonesRecuperados = {6}, BalonesPerdidos = {7}, TaponesFavor = {8},TaponesContra =  {9}" + "}},", jornada, jugador.Dni, minJugados, Canastas1P, Canastas2P, Canastas3P, BalonesRecuperados, BalonesPerdidos, TaponesFavor, TaponesContra);
                calculaEstadisticaAleatoria(out minJugados, out Canastas1P, out Canastas2P, out Canastas3P, out BalonesRecuperados, out BalonesPerdidos, out TaponesFavor,  out TaponesContra);
                sw.WriteLine("new Estadistica {{" + "Njornada = {0} , Dni = \"{1}\" , Fuera = true, MinJugados= {2} , Canastas1P = {3}, Canastas2P = {4}, Canastas3P = {5}, BalonesRecuperados = {6}, BalonesPerdidos = {7}, TaponesFavor = {8},TaponesContra =  {9}" + "}},", jornada + 1, jugador.Dni, minJugados, Canastas1P, Canastas2P, Canastas3P, BalonesRecuperados, BalonesPerdidos, TaponesFavor, TaponesContra);
            }

         sw.Close();
        }

    }
}
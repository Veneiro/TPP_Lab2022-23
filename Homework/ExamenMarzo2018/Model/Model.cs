using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo {


    public class Model {

        public IList<Jaula> Jaulas { get { return jaulas; } }
        public IList<Animal> Animales { get { return animales; } }
        public IList<Origen> Origenes { get { return origenes; } }
        public IList<Emparejamiento> Emparejamientos { get { return emparejamientos; } }


        static Model() {
            ResetModel();
        }

        private static void ResetModel() {

            origenes = new List<Origen> {
			    new Origen("Canada", "Toronto"), 
			    new Origen("USA", "Nueva York"), 
			    new Origen("Italia", "Roma"), 
			    new Origen("Italia", "Corcega"), 
			    new Origen("Francia", "Anglet"),
			    new Origen("Francia", "Paris")
    		    };

            animales = new List<Animal> {
			    new Animal ("Chinchin", new DateTime(2015,1,22), "001", 1,"Cobaya", origenes[0] ),
			    new Animal ("Pardo",  new DateTime(2010,6,02), "002", 2, "Raton",origenes[4]),
			    new Animal ("Rufo",  new DateTime(2011,3,30), "003", 1 , "Raton",origenes[4]),
			    new Animal ("Pelao", new DateTime(2012,11,12), "004", 2, "Cobaya",origenes[2]),
			    new Animal ("Cascote", new DateTime(2012,12,16), "005", 1, "Conejo",origenes[5]),
			    new Animal ("Rulin", new DateTime(2013,9,11), "006", 2, "Gato",origenes[2]),
    		    };

            jaulas = new List<Jaula> {
			    new Jaula ( "Conejos", new List<Animal> {animales[4]} ),
			    new Jaula ( "Ratones",new List<Animal> {animales[1], animales[2]}),
			    new Jaula ( "Cobayas",new List<Animal> {animales[0], animales[3]}),
			    new Jaula ( "Gatos",new List<Animal> {animales[5]}),
    		    };

            animales[4].Jaula = jaulas[0];
            animales[1].Jaula = animales[2].Jaula = jaulas[1];
            animales[0].Jaula = animales[3].Jaula = jaulas[2];
            animales[5].Jaula = jaulas[3];

            emparejamientos = new List<Emparejamiento> {
			    new Emparejamiento { Id_animal1 = "001", Id_animal2 = "003", Duracion = 02, Fecha = new DateTime(2017,	3,	7,	8,	12,	0)},
			    new Emparejamiento { Id_animal1 = "001", Id_animal2 = "002", Duracion = 15, Fecha = new DateTime(2017,	4,	7,	13,	12,	0) },
			    new Emparejamiento { Id_animal1 = "002", Id_animal2 = "006", Duracion = 15, Fecha = new DateTime(2017,	2,	7,	9,	23,	0) },
			    new Emparejamiento { Id_animal1 = "002", Id_animal2 = "001", Duracion = 01, Fecha = new DateTime(2017,	1,	7,	10,	5,	0) },
			    new Emparejamiento { Id_animal1 = "003", Id_animal2 = "002", Duracion = 23, Fecha = new DateTime(2017,	2,	8,	10,	40,	0) },
			    new Emparejamiento { Id_animal1 = "004", Id_animal2 = "002", Duracion = 63, Fecha = new DateTime(2017,	3,	8,	14,	0,	0) },
			    new Emparejamiento { Id_animal1 = "005", Id_animal2 = "001", Duracion = 07, Fecha = new DateTime(2017,	4,	8,	14,	37,	0) },
			    new Emparejamiento { Id_animal1 = "006", Id_animal2 = "001", Duracion = 20, Fecha = new DateTime(2017,	5,	8,	17,	12,	0) },
			    new Emparejamiento { Id_animal1 = "001", Id_animal2 = "006", Duracion = 05, Fecha = new DateTime(2017,	4,	12,	8,	12,	0)},
			    new Emparejamiento { Id_animal1 = "004", Id_animal2 = "001", Duracion = 22, Fecha = new DateTime(2017,	3,	5,	10,	35,	0) },
			    new Emparejamiento { Id_animal1 = "003", Id_animal2 = "002", Duracion = 10, Fecha = new DateTime(2017,	2,	7,	13,	12,	0) },
			    new Emparejamiento { Id_animal1 = "002", Id_animal2 = "001", Duracion = 07, Fecha = new DateTime(2017,	1,	7,	20,	34,	0) },
			    new Emparejamiento { Id_animal1 = "001", Id_animal2 = "005", Duracion = 03, Fecha = new DateTime(2017,	2,	8,	10,	40,	0) },
			    new Emparejamiento { Id_animal1 = "001", Id_animal2 = "002", Duracion = 32, Fecha = new DateTime(2017,	2,	8,	14,	0,	0) },
		    };
        }

        private static List<Jaula> jaulas;
        private static List<Animal> animales;
        private static List<Origen> origenes;
        private static List<Emparejamiento> emparejamientos;
    }
}
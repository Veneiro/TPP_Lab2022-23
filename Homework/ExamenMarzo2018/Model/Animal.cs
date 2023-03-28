using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo {

    public class Animal {

        public Animal(string nombre,  DateTime fecha, string id, 
            int genero, string especie, Origen origen) {
            Nombre = nombre;
            Id = id;
            F_nacimiento = fecha;
            Especie = especie;
            Origen = origen;
        }

        public string Nombre { get; set; }        
        
        public string Id { get; set; }
        public DateTime F_nacimiento { get; set; }
        public string Especie { get; set; }
        public Origen Origen { get; set; }
        public Jaula Jaula { get; set; }
        public int Edad { get { return (DateTime.Now - F_nacimiento).Days / 365; } }

        public override string ToString() {
            return String.Format("[Animal: {0} Id {1}]", Nombre,Id);
        }
    }

}

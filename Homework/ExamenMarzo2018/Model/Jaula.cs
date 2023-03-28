using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo {

    public class Jaula {

        public Jaula(string id, IEnumerable<Animal> animales) {
            Id = id;
            Animales = animales;
        }

        public string Id { get; private set; }

        public IEnumerable<Animal> Animales { get; private set; }

        public override string ToString() {
            return String.Format("[Jaula: {0}]", Id);
        }
    }
}

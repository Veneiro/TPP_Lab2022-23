using System;

namespace lab03TPP.Classes
{

    /// <summary>
    /// Clase Persona utilizada en diversos ejemplos
    /// </summary>
    public class Person
    {

        private string nombre, apellido1, apellido2;

        public string Nombre
        {
            get { return nombre; }
        }
        public string Apellido1
        {
            get { return apellido1; }
        }
        public string Apellido2
        {
            get { return apellido2; }
        }

        private string nif;
        public string Nif
        {
            get { return nif; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} con NIF {3}", nombre, apellido1, apellido2, nif);
        }

        public Person(string nombre, string apellido1, string apellido2, string nif)
        {
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.nif = nif;
        }
    }
}

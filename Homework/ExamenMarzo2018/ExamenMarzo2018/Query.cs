using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TPP.Laboratory.Functional.Modelo;

namespace ExamenMarzo2018
{
    internal class Query
    {
        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args)
        {
            Query query1 = new();
            Query query = query1;
            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();
            query.Query5();
            query.Query6();
            Console.ReadLine();
        }

        /// <summary>
        /// Emparejamientos con una duración mayor a 60 de conejos con origen en París y ordenados por edad
        /// </summary>
        private void Query6()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 6**********");
            Console.WriteLine("****************************");
            var conejosDeParis = model.Animales.Where(animales => animales.Especie.Equals("Conejo") && animales.Origen.Ciudad.Equals("Paris"))
                .OrderBy(c=>c.Edad);

            var emparejamientos = model.Emparejamientos.Join(conejosDeParis, x => x.Id_animal1, y => y.Id, (x, y) => new
            {
                ConejoDeParís=y.Nombre,
                Duracion=x.Duracion
            }).Where(c=>c.Duracion > 6);

            Show(emparejamientos);
        }

        /// <summary>
        /// Lista de animales agrupados por especie y luego por nombre
        /// </summary>
        private void Query5()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 5**********");
            Console.WriteLine("****************************");

            var aux = model.Animales.GroupBy(a => a.Especie)
                .Select(oa => new
                {
                    Especie = oa.Key,
                    Animales = oa.GroupBy(a=>a.Nombre)
                });

            foreach (var especie in aux)
            {
                Console.WriteLine(especie.Especie);
                foreach (var animal in especie.Animales)
                {
                    Show(animal);
                }
            }

            var aux2 = model.Animales.GroupBy(a => a.Especie)
                .Select(oa => new
                {
                    Especie = oa.Key,
                    Animales = oa.OrderBy(a => a.Nombre)
                });

            foreach (var especie in aux2)
            {
                Console.WriteLine(especie.Especie);
                Show(especie.Animales);
            }
        }

        /// <summary>
        /// Emparejamientos, duración y nombre del primer animal de la pareja
        /// </summary>
        private void Query4()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 4**********");
            Console.WriteLine("****************************");
            var aux = model.Emparejamientos.Join(model.Animales, e => e.Id_animal1, a => a.Id, (e,a) => new
            {
                Nombre=a.Nombre,
                Duracion=e.Duracion
            });
            Show(aux);
        }

        /// <summary>
        /// Bucamos jaulas con más de 1 animal cuyas edades sean mayores de 2
        /// y el pais de origen empiece por Fr, para cada elemento
        /// seleccionamos el id
        /// </summary>
        private void Query3()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 3**********");
            Console.WriteLine("****************************");

            var aux = model.Jaulas.Where(j => j.Animales.Count() > 1)
                .Select(a => a.Animales).Where(a => a.Any(a => a.Edad > 2 && a.Origen.Pais.StartsWith("Fr")))
                .Select(a=>a.Select(a=>a.Id));
            Show(aux);
        }

        /// <summary>
        /// Usando objetos anonimos (ojo con el tostring->por defecto) 
        /// para los gatos recuperamos el nombre y especia(mirar en Gato)
        /// </summary>
        private void Query2()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 2**********");
            Console.WriteLine("****************************");

            var aux = model.Animales.Where(a=>a.Especie.Equals("Gato")).Select(g=> new
            {
                Nombre=g.Nombre,
                Especie=g.Especie
            });

            Show(aux);

            //var aux2 = model.Jaulas.Where(j => j.Id.Equals("Gatos")).Select(j=>j.Animales.Select(a=> new
            //{
            //    Nombre=a.Nombre,
            //    Especie=a.Especie
            //}));
            //Show(aux2);
        }

        /// <summary>
        /// Nombres de los animales con edad mayor a 3 años
        /// </summary>
        private void Query1()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***********QUERY 1**********");
            Console.WriteLine("****************************");
            var aux = model.Animales.Where(a => a.Edad > 3).Select(a=>a.Nombre);
            Show(aux);
        }
    }
}

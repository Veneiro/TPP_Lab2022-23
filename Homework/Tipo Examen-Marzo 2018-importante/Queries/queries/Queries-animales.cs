using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Modelo
{

    class Query
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
            Query query = new Query();
            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();            
            query.Query5();
            query.Query6();
            System.Console.ReadLine();
        }

        private void Query1()
        {
            //nombres de animales con edad mayor de 3 años
            var animales = model.Animales;
            var animales_may_3 = model.Animales.Where(e => e.Edad > 3);
            var nombres = animales_may_3.Select(e => e.Nombre);
            Console.WriteLine("Animales:");
            Show(nombres);
            //_______________________________________
            nombres = model.Animales.Where(e => e.Edad > 3).Select(e => e.Nombre);
            Console.WriteLine("Animales:");
            Show(nombres);
            //_______________________________________
            nombres = model.Animales
                .Where(e => e.Edad > 3)
                .Select(e => e.Nombre);
            Console.WriteLine("Animales:");
            Show(nombres);
            //_______________________________________
            nombres = from x in model.Animales
                where(x.Edad > 3)
                select(x.Nombre);
            Console.WriteLine("Animales:");
            Show(nombres);
            Console.ReadKey();


        }

        private void Query2()
        {    //Usando objetos anonimos (ojo con el tostring->por defecto)
            // para los gatos recuperamos el nombre y especia(mirar en Gato)
            var result = model.Animales.Where(e => e.Especie.Equals("Cobaya")).
                Select(e => new
                {
                    Nombre = e.Nombre,
                    Especie = e.Especie,                    
                });
            Show(result);
            Console.ReadKey();
           
        }



        private void Query3()
        {
            //Buscamos jaulas con mas de 1 animal cuyas edades sean mayores de 2
            //y el pais de origen Empiece por Fr, para cada elemento
            //seleccionamos el id
            var result = model.Jaulas.Where(d =>
              d.Animales.Count(e => e.Edad >= 3) > 1)
             .Where(d => d.Animales.Any(f => f.Origen.Pais.StartsWith("Fr")))
            .Select(g => g.Id);
            Show(result);
            Console.ReadKey();
        }
	
		
       /* private void Query4()
        {  // Emparejamientos . duracion y nombre del primer animal de la pareja
                        
            var result = model.Emparejamientos.Where(par => model.Animales.Any
            (e => e.Id.Equals(par.Id_animal1)));
            

            var result2 = result.Select(par => new
            {
                Duracion = par.Duracion,
                Nombre = model.Animales.First
                     (e => e.Id.Equals(par.Id_animal1)).Nombre,
            });
            Show(result2);
            Console.ReadKey();
        }*/
		
		// Emparejamientos . duracion y nombre del primer animal de la pareja
		private void Query4-Otra()
		{
		 var result = model.Emparejamientos.Join(model.Animales,
                e => e.Id_animal1, a => a.Id,
                (e, a) => new
                {
                    Nombre = a.Nombre,
					Duracion=e.Duracion,
                    Pareja=e.Id_animal2,
                });
			Show(result);
		}
  
	
        private void Query5()
        {
            //lista de animales agrupados por especie y luego por nombre
            var grupos = model.Animales.GroupBy(e => e.Especie);
            
            var gruposordenados = grupos.OrderBy(g => g.Key);
        
			var gruposordenados = grupos.OrderBy(g => g.Key).Select(
			(x=>new
			{
				especie=x.Key,
				animales=x.OrderBy(y=>y.Nombre)
			});
			
            foreach (var grupo in gruposordenados)
            {
                Console.WriteLine(grupo.Key);
                var Animalesordenados = grupo.OrderBy(e => e.Nombre);
                foreach (var ani in Animalesordenados)
                {
                    Console.WriteLine(ani);
                }
            }
        }


        private void Query6()
        {
            
            //conejos con origen Paris ordenados por edad
            var Animales_de_Paris = model.Animales.Where(e => e.Jaula.Id == "Conejos").
                Where(e => e.Origen.Ciudad == "Paris").OrderBy(e => e.Edad);

            //a partir de ellos obtenemos sus emparejamientos
            var result = model.Emparejamientos.Join(Animales_de_Paris,
                par => par.Id_animal1, ani => ani.Id,
                (par, ani) => new
                {
                    Nombre = ani.Nombre,
                    Duracion = par.Duracion,
                }).Where(v => v.Duracion > 60).Select(v => v.Nombre);


            Show(result);
            Console.ReadKey();
        }




    }
}


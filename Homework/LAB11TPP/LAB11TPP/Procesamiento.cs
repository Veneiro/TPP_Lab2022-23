using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace contarPalabras
{
    class Procesamiento
    {
        public static String LeerFicheroTextoMonoHilo(string nombreFichero)
        {
          
            using (StreamReader stream = File.OpenText(nombreFichero))
            {
                StringBuilder texto = new StringBuilder();
                string linea;
                while ((linea = stream.ReadLine()) != null)
                {
                    texto.AppendLine(linea);
                }
                return texto.ToString();
            }
        }
        /*
         * yield:
         * Se utiliza en un bloque iterator para proporcionar un valor al objeto enumerador 
         * o señalar el fin de la iteración. 
         * La expresión se evalúa y se devuelve como valor al objeto enumerador; 
         * expression se debe poder convertir implícitamente al tipo yield del iterador
         * */

        public static IEnumerable<String> LeerFicheroTextoMultiHilo(string nombreFichero)
        {
            using (StreamReader stream = File.OpenText(nombreFichero))
            {          
                string linea;
                while ((linea = stream.ReadLine()) != null)
                {
                  
                    yield return linea.ToString();
                }
             
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string[] PartirEnPalabras(String texto)
        {
            return texto.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«', 
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        public static int SignosPuntuación(string texto)
        {
            return texto.Count(carácter => carácter == '.' || carácter == ',' || carácter == ';' || carácter == ':');
        }

       
        public static string[] PalabrasMasLargas(string[] palabras)
        {
            return palabras
                .GroupBy(palabra => palabra.Length)  // emparejamos por longitud
                .OrderByDescending(grupo => grupo.Key)  // ordenamos descendentemente por longitud
                .Select(grupo => grupo.Distinct()) // eliminamos repetidos
                .First() // nos quedamos con los de mayor logitud (el primer grupo)
                .ToArray(); // convertimos a array
        }

        public static string[] PalabrasMasCortas(string[] palabras)
        {
            return palabras
                .GroupBy(palabra => palabra.Length) // emparejamos por longitud
                .OrderBy(grupo => grupo.Key) // ordenamos ascendentemente por longitud
                .Select(grupo => grupo.Distinct()) // eliminamos repetidos
                .First() // nos quedamos con las de menor longitud (el primer grupo)
                .ToArray(); // convertimos a array

        }

        public static string[] PalabrasConMenosApariciones(string[] palabras, out int apariciones)
        {
            var palabrasYApariciones = palabras
                .GroupBy(palabra => palabra.ToLower()) // emparejamos por palabra en minúsculas
                .Select(grupo => new { Palabra = grupo.Key, Apariciones = grupo.Count() }) // nos quedamos con una lista de pares {palabra, apariciones}
                .OrderBy(par => par.Apariciones); // ordenamos los pares ascendentemente por las aparariciones
            // Nos quedamos con el menor número de apariciones en el texto (el primer elemento al estar ordenadas por apariciones)
            int numeroMenorApariciones = apariciones = palabrasYApariciones.First().Apariciones;
            return palabrasYApariciones
                .Where(par => par.Apariciones == numeroMenorApariciones) // Filtramos por el número menor de apariciones
                .Select(par => par.Palabra)  // Nos quedamos con la palabra en minúscula
                .ToArray(); // Lo devolvemos como un array
        }

        public static string[] PalabrasConMasApariciones(string[] palabras, out int apariciones)
        {
            var palabrasYApariciones = palabras
                .GroupBy(palabra => palabra.ToLower()) // emparejamos por palabra en minúsculas
                .Select(grupo => new { Palabra = grupo.Key, Apariciones = grupo.Count() }) // nos quedamos con una lista de pares {palabra, apariciones}
                .OrderByDescending(par => par.Apariciones); // ordenamos los pares descendentemente por las aparariciones
            // Nos quedamos con el mayor número de apariciones en el texto (el primer elemento al estar ordenadas por apariciones)
            int numeroMayorApariciones = apariciones = palabrasYApariciones.First().Apariciones;
            return palabrasYApariciones
                .Where(par => par.Apariciones == numeroMayorApariciones) // Filtramos por el número menor de apariciones
                .Select(par => par.Palabra)  // Nos quedamos con la palabra en minúscula
                .ToArray(); // Lo devolvemos como un array
        }

        public static IDictionary<String, int> contarPalabra2(string[] palabras)
        {
            IDictionary<String, int> apariciones = new Dictionary<String, int>();
            
			var palabrasYApariciones = palabras
                .AsParallel().GroupBy(palabra => palabra.ToString()) // emparejamos por palabra en minúsculas
                .Select(grupo => new 
				{ 
				
				Palabra = grupo.Key, 
				Apariciones = grupo.Count() 
				});
				
            foreach (var x in palabrasYApariciones)
            {
                apariciones.Add(x.Palabra, x.Apariciones);
            }
            return apariciones;
        }
        /// <returns></returns>
        public static IDictionary<String, int> contarPalabra(string[] palabras)
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();

            palabras.AsParallel().Aggregate(diccionario, (dic, palabra) =>
            {
                if (dic.ContainsKey(palabra))
                    dic[palabra]++;
                else dic.Add(palabra, 1);
                return dic;
            });
            return diccionario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaDiccionarios"></param>
        /// <returns></returns>
        public static IDictionary<String, int> procesarDiccionarios(IList<IDictionary<string, int>> listaDiccionarios)
        {
            IDictionary<string, int> diccionarioFinal = new Dictionary<string, int>();
            listaDiccionarios.AsParallel().Aggregate(diccionarioFinal,(dic, minidic) =>
            {
                foreach (KeyValuePair<string, int> x in minidic)
                {
                    if (dic.ContainsKey(x.Key))
                    {
                        dic[x.Key]++;
                    }
                    else dic.Add(x.Key, 1);
                }
                return dic;
            });
            return diccionarioFinal;
        }



    }
}
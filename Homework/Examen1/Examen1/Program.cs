using Lab09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba Ejercicio 1
            Console.WriteLine("####Ejercicio1####");
            int[] vector0 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] vector00 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Master master = new Master(vector0, vector00, 4);
            int[] resultado = master.ComputeVectorialSum(4);
            foreach (var item in resultado)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //    //Prueba Ejercicio 2
            //    Console.WriteLine("####Ejercicio2####");
            //    int[] vector = new int[] { 0, 1, 2, 3, 4, 5 };
            //    int[] vector1 = new int[] { 0, 1, 1, 3, 4, 5 };
            //    int[] vector2 = new int[] { 1, 1, 2, 3, 4, 5 };
            //    int[] vector3 = new int[] { 0, 2, 2, 3, 4, 5 };
            //    int numero = 1;

            //    Console.WriteLine("El número {0} esta en la posicion {1}", numero, ejer2For(vector, numero));//Posicion = 1
            //    Console.WriteLine("El número {0} esta en la posicion {1}", numero, ejer2For(vector1, numero));//Posicion = 1
            //    Console.WriteLine("El número {0} esta en la posicion {1}", numero, ejer2For(vector2, numero));//Posicion = 0
            //    Console.WriteLine("El número {0} esta en la posicion {1}", numero, ejer2For(vector3, numero));//Posicion = -1

            //    Console.WriteLine();

            //    //Prueba Ejercicio 3
            //    Console.WriteLine("####Ejercicio3####");
            //    int[] vector4 = new int[] { 2, 1, 1, 2 };
            //    int[] vector5 = new int[] { 1, 1, 1, 1 };
            //    int[] sumaVectorial = ejer3Invoke(vector4, vector5);
            //    foreach (var item in sumaVectorial)
            //    {
            //        Console.Write(item);
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();

            //    //Prueba Ejercicio 4
            //    Console.WriteLine("####Ejercicio4####");
            //    int[] vector6 = new int[] { 1, 3, 2, 0, 0 };
            //    int suma = ejer4Invoke(vector6);
            //    Console.WriteLine("La suma de los cuadrados de los elementos impares del vector es: {0}", suma);
            //}

            //Ejercicio 1
            //Clases Master y Worker

            //Ejercicio 2
            //private static int ejer2For(int[] vector, int numero)
            //{
            //    int posicion = -1;

            //    return posicion;
            //}

            //      //Ejercicio 3
            //      private static int[] ejer3Invoke(int[] vector, int[] vector1)
            //      {

            //      }

            //      //Ejercicio 4
            //      private static int ejer4Invoke(int[] vector){

            //      }
            //  }
            //private static double ejer4InvokeVersionLock(int[] vector){

            //      }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFibonacci
{
    internal class FibonacciHW
    {
        static internal IEnumerable<int> FibonacciInfinito()
        {
            int first = 1, second = 2;
            while(true)
            {
                yield return first;
                int suma = first + second;
                first = second;
                second = suma;
            }
        }

        /// <summary>
        /// Skip: Obtener la colección de todos los elementos, excepto los x primeros pasados por parámetro
        /// Take: Devuelve un número especificado de elementos contiguos desde el principio de una secuencia
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        static internal IEnumerable<int> FibonacciLazy(int desde, int hasta)
        {
            return FibonacciInfinito().Skip(desde).Take(hasta - desde);
        }

        static internal IEnumerable<int> FibonacciEager(int desde, int hasta)
        {
            IList<int> fib = new List<int>();

            int primero = 1, segundo = 1, suma = 0;
            while(segundo <= hasta)
            {
                suma = primero + segundo;
                primero = segundo;
                segundo = suma;
                fib.Add(suma);
            }
            return fib;
        }

        public static IDictionary<int, int> valores = new Dictionary<int, int>();
        public static IList<int> primos = new List<int>();

        internal static int FibonacciMem(int n)
        {
            if (valores.Keys.Contains(n))
            {
                return valores[n];
            }
            int valor = n <= 2 ? 1 : FibonacciMem(n - 2) + FibonacciMem(n - 1);
            valores.Add(n, valor);
            return valor;
        }

        internal static int PrimosMem(int n)
        {
            if (primos.Contains(n))
                return n;
            /*
            if (!esPrimo(n))
                n = PrimosMem(n + 1);
            */
            if(esPrimo(n))
                primos.Add(n);
            return n;
        }

        private static bool esPrimo(int n)
        {
            if(n==0)
                return false;
            if(n==1)
                return true;
            for(int i=2; i<n;i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}

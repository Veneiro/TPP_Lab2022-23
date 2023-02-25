
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.ObjectOrientation.Generics {


    public static class Algorithms {

        static public void Sort<T>(T[] vector) where T: IComparable<T> {
            for (int i=0; i<vector.Length; i++)
                for (int j = vector.Length-1; j > i; j--)
                    if (vector[i].CompareTo(vector[j]) >0) {
                        T aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
        }

        // Implement Show here
        static public void Show<T>(T[] vector)
        {
            foreach (var e in vector)
                Console.Write(e);
            Console.WriteLine();
        }

        // Implement Max here, use bounded generics, do not sort
        static public T Max<T>(T[] vector) where T:IComparable<T>
        {
            T max = vector[0];
            foreach(var e in vector)
                if(max.CompareTo(e) < 0)
                    max = e;

            return max;
        }

        // and return the last/first element, use CompareTo
    }
}

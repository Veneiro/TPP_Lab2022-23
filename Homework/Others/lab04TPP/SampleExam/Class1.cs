using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleExam
{
    internal  static class Class1
    {
        public static K ReduceRange<T,K>(this IEnumerable<T> colection, Func<K, T, K> f, int leftBound, int rightBound, K r = default(K))
        {
            K resultado = r;
            for (int i = leftBound; i < rightBound; i++)
            {
                resultado = f(resultado, colection.ElementAt(i));
            }
            return resultado;
        }
    }
}

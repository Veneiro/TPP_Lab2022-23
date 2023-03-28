using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace UsoDeLinQ
{
    public class LinQ
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementos"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public T Buscar<T>(IEnumerable<T> elementos, Func<T, bool> f)
        {
            var resultado = elementos.FirstOrDefault(f);
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementos"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public IEnumerable<T> Filtrar<T>(IEnumerable<T> elementos, Func<T, bool> f)
        {
            return elementos.Where(f);
        }

        public K Reducir<T, K>(IEnumerable<T> elementos, Func<K, T, K> f) //
        {
            K resultado = default(K);
            resultado= elementos.Aggregate(resultado,f);
            return resultado;
        }
       
        /// <summary>
        /// 
       
        public IEnumerable<K> Map<T, K>(IEnumerable<T> elementos, Func<T, K> f)
        {
            return elementos.Select(f);
        }

       
    }
}

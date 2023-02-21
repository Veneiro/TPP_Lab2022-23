using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Classes
{
    public class Functions
    {
        /// <summary>
        /// Find an element based on a condition passed as a Predicate
        /// </summary>
        /// <typeparam name="T"> Type of the elements we are searching </typeparam>
        /// <param name="elems"> List of elements where we are searching </param>
        /// <param name="condition"> Condition to fullfill to find an object in the list </param>
        /// <returns> The element if we find it or the default if we could not find and element that fulfills the conditions </returns>
        public T Find<T>(IEnumerable<T> elems, Predicate<T> condition)
        {
            foreach (T elem in elems)
            {
                if(condition(elem))
                    return elem;
            }
            return default(T);
        }

        /// <summary>
        /// Returns all the elements in a collection that fulfills a given predicate
        /// </summary>
        /// <typeparam name="T"> Type of the elements we are searching </typeparam>
        /// <param name="elems"> List of elements we are filtering </param>
        /// <param name="condition"> Condition to fulfill the filter </param>
        /// <returns> A list with the elements that fulfill the predicate </returns>
        public IList<T> Filter<T>(IEnumerable<T> elems, Predicate<T> condition)
        {
            IList<T> res = new List<T>();
            foreach (T elem in elems)
            {
                if (condition(elem))
                {
                    res.Add(elem);
                }
            }
            return res;
        }

        /// <summary>
        /// A function that is applied to all the elements in a collection, returning a single value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="elems"> Elements where the function is going to be applied </param>
        /// <param name="reducer"> The function that is going to be applied to the elements </param>
        /// <param name="r"> Default value for K </param>
        /// <returns> The result after applying the function to all the elements </returns>
        public K Reduce<T, K>(IEnumerable<T> elems, Func<K, T, K> reducer, K r=default(K))
        {
            K res = r;
            foreach (T elem in elems)
            {
                res = reducer(res, elem);
            }
            return res;
        }
    }
}

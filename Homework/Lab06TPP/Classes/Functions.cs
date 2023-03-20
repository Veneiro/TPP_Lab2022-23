using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <typeparam name="Q"></typeparam>
        /// <param name="l"> Elements where the function is going to be applied </param>
        /// <param name="f"> The function that is going to be applied to the elements </param>
        /// <returns> The result after applying the function to all the elements </returns>
        public T Reduce<T, Q>(T[] l, Func<T, T, T> f)
        {
            T res = f(l[0], l[0]);
            for (int i = 1; i < l.Count(); i++)
            {
                res = f(res, l[i]);
            }
            return res;
        }
    }
}

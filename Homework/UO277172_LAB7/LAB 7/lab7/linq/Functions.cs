using System.Linq;
using System;
using PolymorphicSimplyLinkedList;
using System.Collections.Generic;

namespace TPP.Laboratory.Functional.Lab07 {

    static public class Functions {

        public static IEnumerable<TResult> Map<TElement, TResult>(this IEnumerable<TElement> collection, Func<TElement, TResult> function) {
            foreach(var elem in collection)
            {
                yield return function(elem);
            }
            yield break;
        }

    }
}

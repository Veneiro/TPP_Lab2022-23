using lab02TPP;
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Class1
    {
        public static IEnumerable<T> RangeCount<T>(this SinglyLinkedList<T> list, int n, int m, ref int counter)
        {
            IList<T> res = new List<T>();
            for (var i = n + 1; i < m; i++)
            {
                res.Add(list.GetElement(i));
                counter++;
            }
            return res;
        }

        public static IEnumerable<T> FuncRange<T>(this SinglyLinkedList<T> list, Func<int> f1, Func<int> f2)
        {
            IList<T> res = new List<T>();
            for (var i = f1() + 1; i < f2(); i++)
            {
                res.Add(list.GetElement(i));
            }
            return res;
        }
    }
}

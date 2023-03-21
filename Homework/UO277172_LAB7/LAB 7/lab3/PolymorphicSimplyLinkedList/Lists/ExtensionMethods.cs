using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicSimplyLinkedList
{
    public class ExtensionMethods
    {
        public Q[] Map<T,Q>(T[] l, Func<T,Q> f)
        {
            Q[] res = new Q[l.Count()];

            for(int i = 0; i < l.Count(); i++)
            {
               res[i] = f(l[i]);
            }
            return res;
        }

        public T Find<T>(T[] r, Predicate<T> p)
        {
            foreach(T elem in r)
            {
                if ((p(elem)))
                {
                    return elem;
                }
            }
            return default(T);
        }

        public T[] Filter<T>(T[] l, Predicate<T> p)
        {
            T[] res = new T[l.Count()];
            var j = 0;
            for (int i = 0; i < l.Count(); i++)
            {
                if ((p(l[i])))
                {
                    res[j] = l[i];
                    j++;
                }
            }
            return res;
        }

        public Q Reduce<T,Q>(Q a, T[] l, Func<Q, T, Q> f)
        {
            Q res = f(a, l[0]);
            for(int i = 1; i < l.Count(); i++)
            {
                res = f(res, l[i]);
            }
            return res;
        }

        public void Show<T>(T[] l)
        {
            foreach (T elem in l)
            {
                try
                {
                    Console.WriteLine(elem.ToString());
                }
                catch (NullReferenceException e){}
            }
        }
    }
}

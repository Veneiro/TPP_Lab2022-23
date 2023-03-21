using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    interface IComparator<T>
    {
        public bool Compare(T o1, T o2);
    }
}

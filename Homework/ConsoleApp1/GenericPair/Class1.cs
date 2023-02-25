using System;

namespace GenericPair
{
    public class Pair<T> : IComparable<Pair<T>> where T : IComparable<T>
    {
        T first, second;
        public Pair()
        {
            first= default(T);
            second= default(T);
        }

        // Implement a constructor from two T
        public Pair(T first, T second)
        {
            this.first= first;
            this.second= second;
        }

        // Code here CompareTo use T CompareTo
        public int CompareTo(Pair<T> other)
        {
            var f = this.first.CompareTo(other.first);
            
            if (f != 0)
                return f;
            
            return this.second.CompareTo(other.second);
        }

        // Implement ToString and GetHashCode
        public override string ToString()
        {
            return "[" + first.ToString() + ", " + second.ToString() + "]";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace PolymorphicSimplyLinkedList
{
#pragma warning disable CS0659
    public abstract class AbstractList<T> : List<T>
#pragma warning restore CS0659 
    {
		protected int numberOfElements = 0;

		public virtual int Size()
		{
			return numberOfElements;
		}

		public virtual Boolean IsEmpty()
		{
			return Size() == 0;
		}

		public virtual Boolean Contains(Object o)
		{
			return IndexOf(o) != -1;
		}

		override
		public Boolean Equals(Object o)
		{
			if (o == null)
				return false;
			if (o == this)
				return true;
			if (!(o.GetType() == typeof(List<T>)))
			return false;

			List<T> that = (List<T>)o;
			if (this.Size() != that.Size())
				return false;

			for (int i = 0; i < Size(); i++)
			{
				Object e1 = this.GetElement(i);
				Object e2 = that.GetElement(i);
				if (!(e1.Equals(e2)))
					return false;
			}
			return true;
		}

		public virtual int HashCode()
		{
			int result = 1;
			for (int i = 0; i < Size(); i++)
			{
				Object element = this.GetElement(i);
				result = 31 * result + element.GetHashCode();
			}
			return result;
		}

		public virtual Boolean Add(T element)
		{
			if (element == null)
			{
				throw new ArgumentException("Illegal Object");
			}
			Add(Size(), element);
			return true;
		}

		public virtual Boolean Remove(T o)
		{
			int index = IndexOf(o);
			if (index == -1) return false;
			Remove(index);
			return true;
		}

        public abstract T GetElement(int index);
        public abstract T Set(int index, T element);
        public abstract void Add(int index, T element);
        public abstract T Remove(int index);
        public abstract int IndexOf(object o);
        public abstract void Clear();
        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

		public abstract Q Reduce<T, Q>(Q a, IEnumerable<T> l, Func<Q, T, Q> f);
		public abstract IEnumerable<Q> Map<T, Q>(IEnumerable<T> l, Func<T, Q> f);
		public abstract T Find<T>(IEnumerable<T> r, Predicate<T> p);
		public abstract List<T> Filter<T>(IEnumerable<T> l, Predicate<T> p);

		public abstract IEnumerable<T1> Divide<T1>(IEnumerable<T1> list, Predicate<T1> p);
	}
}

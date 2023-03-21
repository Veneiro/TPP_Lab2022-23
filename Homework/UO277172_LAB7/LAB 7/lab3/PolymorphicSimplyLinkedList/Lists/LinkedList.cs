using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicSimplyLinkedList
{
    public class LinkedList<T> : AbstractList<T>, List<T>
    {
		private Node<T> head;
		private int NumberOfElements;

		override
		public int Size()
		{
			return NumberOfElements;
		}

		override
		public Boolean IsEmpty()
		{
			return (Size() == 0);
		}

		override
		public Boolean Contains(Object o)
			{
				Node<T> node = this.head;
				int counter = 0;
				Boolean result = false;
				while (counter < Size() && !result)
				{
					if (node.GetValue().Equals(o))
					{
						result = true;
					}
					else
					{
						node = node.GetNext();
					}
					counter++;
				}
				return result;
			}

		override
		public Boolean Add(T element)
			{
				if (element == null)
				{
					throw new ArgumentException("Invalid object");
				}
				if (IsEmpty())
				{
					AddFirst(element);
				}
				else
				{
					Node<T> aux = GetNode(Size() - 1);
					aux.SetNext(new Node<T>(element, null));
					NumberOfElements++;
				}
				return true;
			}

        override
        public void Clear()
			{
				head = null;
				NumberOfElements = 0;

			}

		override
		public T GetElement(int index)
			{
				if (index < 0 || index >= Size())
				{
					throw new IndexOutOfRangeException("Illegal index");
				}
				return (T)GetNode(index).GetValue();
			}

			private Node<T> GetNode(int index)
			{
				int pos = 0;
				Node<T> node = head;
				while (pos < index)
				{
					node = node.GetNext();
					pos++;
				}
				return node;
			}

		override
		public T Set(int index, T element)
			{
				if (index < 0 || index >= Size())
				{
					throw new IndexOutOfRangeException("Illegal index");
				}
				Node<T> aux = GetNode(index);
				T auxVal = aux.GetValue();
				aux.SetValue(element);
				return auxVal;
			}

		override
		public void Add(int index, T element)
			{
				if (index < 0 || index > Size())
				{
					throw new IndexOutOfRangeException("Invalid index");
				}
				if (element == null)
				{
					throw new ArgumentException("Invalid object");
				}
				if (index == 0)
				{
					AddFirst(element);
				}
				else
				{
					Node<T> aux = GetNode(index - 1);
					aux.SetNext(new Node<T>(element, aux.GetNext()));
					NumberOfElements++;
				}
			}

			private void AddFirst(T element)
			{
				head = new Node<T>(element, head);
				this.NumberOfElements++;
			}

		override
		public T Remove(int index)
			{
				if (index < 0 || index >= Size())
				{
					throw new IndexOutOfRangeException("Illegal index");
				}
				else
				{
					if (IsEmpty())
					{
						return default(T);
					}
					T value;
					if (index == 0)
					{
						value = head.GetValue();
						head = head.GetNext();
					}
					else
					{
						Node<T> aux = GetNode(index - 1);
						value = aux.GetNext().GetValue();
						aux.SetNext(aux.GetNext().GetNext());
					}
					NumberOfElements--;
					return value;
				}
			}


		override
		public int IndexOf(Object o)
			{
				if (o == null)
				{
					return -1;
				}
				Node<T> node = this.head;
				for (int i = 0; i < Size(); i++)
				{
					if (node.GetValue().Equals(o))
					{
						return i;
					}
					else
					{
						node = node.GetNext();
					}
				}
				return -1;
			}

		override
		public String ToString()
			{
				String result;
				if (NumberOfElements == 0)
				{
					result = "[]";
				}
				else
				{
					result = "[";
					int pos = 0;
					Node<T> node = head;
					while (pos < NumberOfElements)
					{
						if (pos != NumberOfElements - 1)
						{
							result += node.GetValue() + ", ";
							node = node.GetNext();
							pos++;
						}
						else
						{
							result += node.GetValue();
							pos++;
						}
					}
					result += "]";
				}
				return result;
			}

		public override IEnumerator<T> GetEnumerator()
		{
			return new LinkedListIterator<T>(this);
		}

		//----------------------------------------------------------------------------------------------------------

		/// <summary>
		/// ENUMERATOR
		/// </summary>
		/// <typeparam name="U"></typeparam>
		public class LinkedListIterator<U> : IEnumerator<T>
		{
			private Node<T> front;
			private Node<T> current;
			public T Current
            {
                get
                {
					return current.GetValue();
                }
            }

            object IEnumerator.Current
            {
                get
                {
					return Current;
                }
            }

            public LinkedListIterator(LinkedList<T> list)
			{
				front = list.head;
				current = null;
			}

            public Boolean MoveNext()
			{
				if(current == null)
                {
					current = front;
					return true;
                }
				else if(current.GetNext() == null)
                {
					return false;
                }
				else
				{
					Next();
					return true;
				}
			}
			private T Next()
			{
				T res = (T)current.GetValue();
				current = current.GetNext();
				return res;
			}

			public void Reset()
            {
				current = null;
            }
			public void Dispose() {}
		}

		//----------------------------------------------------------------------------------------------------------



		// Methods to implement LAB 7

		public override IEnumerable<Q> Map<T, Q>(IEnumerable<T> l, Func<T, Q> f)
		{
			foreach(T elem in l)
            {
				yield return f(elem);
            }
		}

		public override T Find<T>(IEnumerable<T> r, Predicate<T> p)
		{
			foreach (T elem in r)
			{
				if ((p(elem)))
				{
					return elem;
				}
			}
			return default(T);
		}

		public override List<T> Filter<T>(IEnumerable<T> l, Predicate<T> p)
		{
			List < T > res = new LinkedList<T>();
			foreach(T elem in l)
            {
                if (p(elem))
                {
					res.Add(elem);
                }
            }
			return res;
		}

		public void Show<T>(List<T> l)
		{
			foreach (T elem in l)
			{
				try
				{
					Console.WriteLine(elem.ToString());
				}
				catch (NullReferenceException e) { }
			}
		}

        public override Q Reduce<T, Q>(Q a, IEnumerable<T> l, Func<Q, T, Q> f)
        {
			Q res = f(a, l.ElementAt(0));
			for (int i = 1; i < l.Count(); i++)
			{
				res = f(res, l.ElementAt(i));
			}
			return res;
		}

		public override IEnumerable<T> Divide<T>(IEnumerable<T> list, Predicate<T> p)
		{
			List<T> aux = new LinkedList<T>();
			List<T> aux2 = new LinkedList<T>();
			if (p != null)
			{
				foreach (var elem in list)
				{
					if (p(elem))
					{
						aux.Add(elem);
					}
					else
					{
						aux2.Add(elem);
					}
				}
			}
			else
			{
				var half = list.Count() / 2;
				int counter = 0;

				foreach (var elem in list)
				{
					if (counter <= half)
					{
						aux.Add(elem);
						counter++;
					}
					else
					{
						aux2.Add(elem);
						counter++;
					}
				}
			}
			return aux2;
		}
	}
}


using lab02TPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10TPP
{
    internal class ConcurrentQueue<T>
    {
        // My Generic list
        public SinglyLinkedList<T> list;

        // Static object that can be used for lock
        // public static Object staticObject = new Object();

        /// <summary>
        /// Property that returns if the list is empty or not
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return list.IsEmpty();
            }
        }

        /// <summary>
        /// Property that returns the number of elements
        /// </summary>
        public int NumberOfElements
        {
            get
            {
                return list.NumberOfElements;
            }
        }

        public ConcurrentQueue()
        {
            this.list = new SinglyLinkedList<T>();
        }

        public void Add(T value)
        {
            Object ob = new Object();
            lock(ob)
                list.Add(value);

            /*
             * lock(this)
             *  list.Add(value);
             */

            /*
             * lock(staticObj)
             *  list.Add(value);
             */
        }

        public T Extract()
        {
            T value = default(T);
            Object ob = new Object();
            lock (ob)
            {
                value = list.Remove(0);
            }
            return value;
        }

        public T Peek()
        {
            T value = default(T);
            Object ob = new Object();
            lock (ob)
            {
                value = list.GetElement(0);
            }
            return value;
        }
    }
}

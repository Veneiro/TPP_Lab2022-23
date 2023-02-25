using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02TPP
{
    /// <summary>
    /// Enumerator Class of the SinglyLinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Current { get { return current.GetValue();} }

        /// <summary>
        /// 
        /// </summary>
        object IEnumerator.Current { get{ return current.GetValue(); } }

        /// <summary>
        /// 
        /// </summary>
        Node<T> current;

        /// <summary>
        /// 
        /// </summary>
        Node<T> next;

        /// <summary>
        /// 
        /// </summary>
        Node<T> head;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        public SinglyLinkedListEnumerator(Node<T> head)
        {
            this.head = head;
            Reset();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.head = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (current == null)
            {
                current = head;
                return true;
            }
            else if (current.GetNext() != null)
            {
                current = current.GetNext();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            current = null;
        }
    }
}

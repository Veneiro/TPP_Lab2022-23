using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02TPP
{
    /// <summary>
    /// Class node representing each element in the list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Value for the Node
        /// </summary>
        private T value;

        /// <summary>
        /// The node Node<int> which is in the next position
        /// </summary>
        private Node<T> next;

        /// <summary>
        /// Constructor for the class node
        /// </summary>
        /// <param name="value"> Value for the node </param>
        /// <param name="next"> The node in the next position </param>
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        /// <summary>
        /// Get the value for the node
        /// </summary>
        /// <returns> Returns an int with the value of the node </returns>
        public T GetValue()
        {
            return value;
        }

        /// <summary>
        /// Set the value for the node
        /// </summary>
        /// <param name="value"> What value you want to set to the node </param>
        public void SetValue(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Get the next node
        /// </summary>
        /// <returns> A Node<int> with the next node in the list </returns>
        public Node<T> GetNext()
        {
            return next;
        }

        /// <summary>
        /// Set the next node
        /// </summary>
        /// <param name="next"> The Node<int> you want to be the next </param>
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
    }
}

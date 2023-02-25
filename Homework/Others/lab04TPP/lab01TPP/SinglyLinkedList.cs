using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace lab02TPP
{
    /// <summary>
    /// Class that allows us to create list of Integers
    /// </summary>
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Node attribute that have the head of the list
        /// </summary>
        private Node<T> head;

        /// <summary>
        /// Returns the Size of the Linked List
        /// </summary>
        /// <returns>Size of the List</returns>
        public int NumberOfElements
        {
            get {
                int cont = 0;
                Node<T> aux = head;
                while(aux != null)
            {
                    aux = aux.GetNext();
                    cont++;
                }
                return cont;
            }
        }

        /// <summary>
        /// Checks if the list is empty or not
        /// </summary>
        /// <returns>True if the list is empty and false if it is not</returns>
        public Boolean IsEmpty()
        {
            return (NumberOfElements == 0);
        }

        /// <summary>
        /// Add an element to the list
        /// </summary>
        /// <param name="element">Element to add to the list</param>
        /// <returns> A Boolean telling if the element was succesfully added or not</returns>
        public Boolean Add(T element)
        {
            if (IsEmpty())
            {
                AddFirst(element);
            }
            else
            {
                Node<T> aux = GetNode(NumberOfElements - 1);
                aux.SetNext(new Node<T>(element, null));
            }
            return true;
        }

        /// <summary>
        /// Returns the node in a provided index
        /// </summary>
        /// <param name="index">Position of the node you want to get</param>
        /// <returns> A Node<int> representing the node in that index </int></returns>
        private Node<T> GetNode(int index)
        {
            int pos = 0;
            Node<T> node = this.head;
            while (pos < index)
            {
                node = node.GetNext();
                pos++;
            }
            return node;
        }

        /// <summary>
        /// Add the node to the first position of the list
        /// </summary>
        /// <param name="element">Node to be added</param>
        private void AddFirst(T element)
        {
            head = new Node<T>(element, this.head);
        }

        /// <summary>
        /// Remove the node of the position provided
        /// </summary>
        /// <param name="index">Position of the node you want to remove</param>
        /// <returns> The value of the node of the node</returns>
        public T Remove(int index)
        {
            if (index < 0 || index >= NumberOfElements)
            {
                throw new Exception("Illegal index");
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
                return value;
            }
        }

        /// <summary>
        /// Returns the index of a gived node
        /// </summary>
        /// <param name="o">Node to be checked</param>
        /// <returns> Return an int with the index of the element </returns>
        public int IndexOf(T o)
        {
            Node<T> node = this.head;
            for (int i = 0; i < NumberOfElements; i++)
            {
                if (node.GetValue().Equals(null))
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

        /// <summary>
        /// Returns the node of a given index
        /// </summary>
        /// <param name="index">Index of the node you want to get</param>
        /// <returns>The node of the index provided</returns>
        public T GetElement(int index)
        {
            if (index < 0 || index >= NumberOfElements)
            {
                throw new Exception("Illegal index");
            }
            return GetNode(index).GetValue();
        }

        /// <summary>
        /// Tells if the list contains an element or not
        /// </summary>
        /// <param name="searchElem"></param>
        /// <returns></returns>
        public bool Contains(T searchElem)
        {
            for(int i = 0; i < NumberOfElements; i++)
            {
                if (searchElem.Equals(GetElement(i)))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// To String method for the List Class
        /// </summary>
        /// <returns>A String with all the nodes contained by the list</returns>
        override
        public String ToString()
        {
            String result;
            if (IsEmpty())
            {
                result = "[]";
            }
            else
            {
                result = "[";
                int pos = 0;
                Node<T> node = this.head;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(this.head);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(this.head);
        }
    }
}

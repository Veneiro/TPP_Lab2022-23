using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab02TPP;

namespace lab03TPP.lab03
{
    public class Stack
    {
        /// <summary>
        /// My list implementation
        /// </summary>
        private SinglyLinkedList list = new SinglyLinkedList();

        /// <summary>
        /// UInt with the maximum number of elements supported by the stack
        /// </summary>
        private uint manNumberOfElements;

        /// <summary>
        /// Property NumberOfElements, returns the total number of elements
        /// </summary>
        public int NumberOfElements
        {
            get
            {
                return list.NumberOfElements;
            }
        }

        /// <summary>
        /// Property isEmpty, returns if the stack is empty or not
        /// </summary>
        public bool isEmpty
        {
            get
            {
                return list.NumberOfElements== 0;
            }
        }

        /// <summary>
        /// Property isFull, returns if the stack is full already or not
        /// </summary>
        public bool isFull
        {
            get
            {
                return list.NumberOfElements >= manNumberOfElements;
            }
        }

        /// <summary>
        /// Constructor for the class stack
        /// </summary>
        /// <param name="manNumberOfElements"></param>
        public Stack(uint manNumberOfElements)
        {
            this.manNumberOfElements = manNumberOfElements;
        }

        /// <summary>
        /// Method to check the invariant by using the Contract class
        /// </summary>
        private void CheckInvariant()
        {
            Contract.Invariant(list != null);
        }

        /// <summary>
        /// Push method for the stack
        /// </summary>
        /// <param name="o"> Object to introduce </param>
        /// <exception cref="InvalidOperationException"> Thrown if the params are not valid</exception>
        public void Push(Object o)
        {
            // We can do the checks by using the class Contract or just by doing the checks with conditionals
            // Contract.Requires(o != null);
            if(o == null)
            {
                throw new InvalidOperationException("The object cannot be null");
            }
            if(isFull)
            {
                throw new InvalidOperationException("The list is full");
            }
            CheckInvariant();

            list.Add(o);
            // Contract.Ensures(list != null, "The object is null");
            Debug.Assert(list != null, "The object is null");
        }
        
        /// <summary>
        /// Pop method for the stack
        /// </summary>
        /// <returns> The Object that was removed </returns>
        /// <exception cref="InvalidOperationException"> Thrown if the list is empty when doind the remove </exception>
        public Object Pop()
        {
            // Contract.Requires(!isEmpty);
            if (isEmpty)
            {
                throw new InvalidOperationException("The list is Empty");
            }
            CheckInvariant();

            object toReturn = list.Remove(list.NumberOfElements - 1);

            // Contract.Ensures(list != null, "The Stack is null");
            Debug.Assert(list != null, "The Stack is null");
            return toReturn;
        }
    }
}

using System;
using System.Text;
using System.Diagnostics;
using PolymorphicSimplyLinkedList;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Stack {

        private int maxNumberOfElements;
        private LinkedList<uint?> stack = new LinkedList<uint?>();

        public bool IsEmpty { 
            get
            {
                return stack.IsEmpty();
            } 
        }
        public int MaxSize
        {
            get
            {
                return maxNumberOfElements;
            }
        }
        public bool IsFull
        {
            get
            {
                if (stack.Size() - 1 == maxNumberOfElements)
                    return true;
                return false;
            }
        }

        public static void Main() {
            //Debug.Assert(false, "Message of the assertion not fulfilled ");
            //Stack s = new Stack(10);
            //s.Push(2);
            //s.Push(3);
            //Console.WriteLine(s.stack.ToString());
            //s.Pop();
            //s.Pop();
            //Console.WriteLine(s.stack.ToString());

            List<int> l = new LinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            foreach (var elem in l)
            {
                Console.WriteLine(elem);
            }
        }

        public Stack(int maxElems)
        {
            this.maxNumberOfElements = maxElems;
        }

        public void Push(uint? i)
        {
            if(i == null)
            {
                throw new ArgumentNullException("The introduced number is null");
            }
            if (stack.Contains(i))
            {
                throw new ArgumentException("The element is already in the stack");
            }
            if (IsFull == true)
            {
                throw new ArgumentOutOfRangeException("Stack is full");
            }
            stack.Add(i);
        }

        public void Pop()
        {
            if(IsEmpty == true)
            {
                throw new ArgumentNullException("The Stack is Empty");
            }
            stack.Remove(stack.IndexOf(stack.GetElement(stack.Size() - 1)));
        }
    }

}
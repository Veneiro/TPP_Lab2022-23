using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02TPP
{
    /// <summary>
    /// Definition for the Set class
    /// </summary>
    internal class Set
    {
        private SinglyLinkedList list = new SinglyLinkedList();
        static Set set = new Set();
        //set+"hola";

        /// <summary>
        /// Redefine of the '+' operator
        /// </summary>
        public static SinglyLinkedList operator+(Set a, Object data)
        {
            if (!set.list.Contains(data))
            {
                set.list.Add(data);
            }
            return set.list;
        }

        /// <summary>
        /// Redefine of the '-' operator
        /// </summary>
        public static SinglyLinkedList operator- (Set a, int pos)
        {
            set.list.Remove(pos);
            return set.list;
        }

        /// <summary>
        /// Redefine of the '[]' operator
        /// </summary>
        public Object this[int pos]
        {
            get
            {
                return list.GetElement(pos);
            }
        }

        /// <summary>
        /// Redefinition of the '|' operator
        /// </summary>
        public static Set operator| (Set a, Set b)
        {
            Set c = new Set();
            for(int i = 0; i < a.list.NumberOfElements; i++)
            {
                c.list.Add(a.list.GetElement(i));
            }
            for(int i = 0; i < b.list.NumberOfElements; i++)
            {
                if (!c.list.Contains(b.list.GetElement(i)))
                {
                    c.list.Add(b.list.GetElement(i));
                }
            }
            return c;
        }

        /// <summary>
        /// Redefinition of the '&' operator
        /// </summary>
        public static Set operator& (Set a, Set b)
        {
            Set c = new Set();
            for(int i = 0; i < b.list.NumberOfElements; i++)
            {
                String n = (String)b.list.GetElement(i);
                if (a.list.Contains(n))
                {
                    c.list.Add(n);
                }
            }
            return c;
        }

        // Diferencia, los elementos de la unión que no están en la intersección
        /// <summary>
        /// Redefinition of the '-' operator
        /// </summary>
        public static Set operator- (Set a, Set b)
        {

        }

        /// <summary>
        /// Redefinition of the '^' operator
        /// </summary>
        public static Set operator -(Set a, Set b)
        {

        }

        /// <summary>
        /// Redefinition of the NumberOfElements property
        /// </summary>
        public static Set operator -(Set a, Set b)
        {

        }
        /// <summary>
        /// Redefinition of the ToString property
        /// </summary>
        public static Set operator -(Set a, Set b)
        {

        }
    }
}

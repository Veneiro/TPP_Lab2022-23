using System;
using System.Collections;
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
        public static Set operator- (Set c1, Set c2)
        {
            Set minus = new Set();
            Set union = c1 | c2;
            Set interseccion = c1 & c2;
            for (int i = 0; i < union.list.NumberOfElements; i++)
            {
                Object n = union.list.GetElement(i);
                if (!interseccion.list.Contains(n))
                    minus.list.Add(minus.list.NumberOfElements);
            }
            return minus;
        }

        /// <summary>
        /// Redefinition of the '^' operator
        /// </summary>
        public static bool operator^ (Set a, Object o)
        {
            return a.list.Contains(o);
        }

        /// <summary>
        /// Redefinition of the NumberOfElements property
        /// </summary>
        public int NumberOfElements
        {
            get
            {
                return list.NumberOfElements;
            }
        }
        /// <summary>
        /// Redefinition of the ToString property
        /// </summary>
        public override string ToString()
        {
            String cadena = "";
            for (int i = 0; i < list.NumberOfElements; i++)
                cadena += list.GetElement(i) + "\n";
            return cadena;
        }
    }
}

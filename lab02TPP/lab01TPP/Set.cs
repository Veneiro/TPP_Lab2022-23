using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02TPP
{
    internal class Set
    {
        private SinglyLinkedList list = new SinglyLinkedList();
        static Set set = new Set();
        //set+"hola";

        public static SinglyLinkedList operator+(Set a, Object data)
        {
            if (!set.list.Contains(data))
            {
                set.list.Add(data);
            }
            return set.list;
        }

        public static SinglyLinkedList operator- (Set a, int pos)
        {
            set.list.Remove(pos);
            return set.list;
        }

        public Object this[int pos]
        {
            get
            {
                return list.GetElement(pos);
            }
        }
        /**
         * public bool this[Object valor]{
         * get{
         * if(list.Contains(valor){
         * return true;
         * }
         * }
         * }
         */

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
    }
}

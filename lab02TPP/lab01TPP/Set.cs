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
    }
}

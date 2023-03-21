using System;
using System.Collections.Generic;
using System.Text;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace algorithms
{
    class PersonByNameComparator : IComparator<Person>
    {
        public bool Compare(Person o1, Person o2)
        {
            if(o1.FirstName.Equals(o2.FirstName))
            {
                return true;
            }
            return false;
        }
    }
}

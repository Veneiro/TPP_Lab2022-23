using System;
using System.Collections.Generic;
using System.Text;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace algorithms
{
    class AnglesInTheSameQuadrantComparator : IComparator<Angle>
    {
        public bool Compare(Angle o1, Angle o2)
        {
            if (o1.Quadrant.Equals(o2.Quadrant))
            {
                return true;
            }
            return false;
        }
    }
}

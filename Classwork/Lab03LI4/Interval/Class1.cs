using System;
using System.Diagnostics;

namespace Lab03
{
    public class Interval : IMedible
    {
        public double? left, right;
        public double? L
        {
            get{ return left; }

        }

        public double? R
        {
            get { return right;}
        }

        public Interval()
        {
            left = null;
            right= null;
        }

        public Interval(double? left, double? right)
        {
            if((left == null || right == null) || (left == null && right == null))
            {
                throw new ArgumentNullException("The arguments cannot be null");
            }
            if(left > right)
            {
                throw new ArgumentException("Left side of the interval cannot be greater than the right side");
            }
            this.left = left;
            this.right = right;
        }

        protected bool Check()
        {
            return left == null && right == null || left <= right;
        }

        public virtual double? Size()
        {
            if(left == null) 
            {
                return null;
            }
            /*
            //This is somthing incorrectly coded
            left = null;
            */
            //This code protects us against this kind of situations
#if DEBUG
            Debug.Assert(Check());
#endif
            return right - left;
        }

        public override string ToString()
        {
            return '[' + left.ToString() + ',' + right.ToString() + ']';
        }

        public override int GetHashCode()
        {
            // This is not correct if diferently valued objects share the same representation
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            /*if(!(obj is Interval))
                return false;
            Interval other = (Interval)obj;
            return left == other.left && right == other.right;*/

            Interval other = obj as Interval;
            if(other == null)
            {
                return false;
            }

            //This is a good place to assert that the invariant holds
            return left == other.left && right == other.right;
        }

        public Interval Intersection(Interval a)
        {
            //Use this three cases
            //1) Intersection with Interval (null, null) (this or a) result Interval (null, null)
            //2) Non overlapping intervals, result Interval(null, null)
            //left.right < a.left or this.left >= a.right
            //3) Otherwise, sort the 4 values and return the second [1] and third [2]
            return new Interval(6, 9);
        }
    }
}

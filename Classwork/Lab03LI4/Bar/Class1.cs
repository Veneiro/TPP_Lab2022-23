using System;

namespace Lab03
{
    public class Bar:Interval
    {
        //It has an addition attribute holding the height
        double height;
        //Countinue here, make use of base if possible
        public Bar() : base() { height = 0; }
        //You can also use base.Size() the intersection and so on 

        public Bar(Interval interval, double height) : base(interval.L, interval.R)
        {
            this.height = height;
        }

        public override double? Size()
        {
            if (this.L == null)
            {
                return null;
            }
            return base.Size() * height;
        }

        public override string ToString()
        {
            return base.ToString() + height.ToString();
        }
    }
}

using System;

namespace ComplexNumbers.Test
{
    internal class Complex
    {
        private double re;
        private double im;

        public Complex(double v1, double v2)
        {
            this.re = v1;
            this.im = v2;
        }

        internal Complex Conjugate()
        {
            throw new NotImplementedException();
        }

        public static Complex operator+ (Complex x, Complex y)
        {

        }

        public static Complex operator. (Complex x, Complex y)
        {

        }

        internal object Module()
        {
            return Math.Sqrt(re * re + im * im);
        }
    }
}
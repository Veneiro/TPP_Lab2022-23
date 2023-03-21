
using algorithms;
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Angle {


        public double Radians { set; get; }
        public int Quadrant;

        public float Degrees {
            get {
                return (float)(this.Radians / Math.PI * 180);
            }
            set {
                this.Radians = value / 180 * Math.PI;
            }
        }
        public void checkQuadrant(double radians)
        {
            if(radians >= 0 && radians <= 90)
            {
                this.Quadrant = 1;
            } 
            else if (radians > 90 && radians <= 180)
            {
                this.Quadrant = 2;
            } 
            else if (radians > 180 && radians <= 270)
            {
                this.Quadrant = 3;
            }
            else
            {
                this.Quadrant = 4;
            }
        }

        public Angle(double radians) {
            this.Radians = radians;
            checkQuadrant(this.Radians);
        }

        static public Angle CreateAngleDegrees(float degrees) {
            Angle angle = new Angle(0);
            angle.Degrees = degrees;
            return angle;
        }

        public double Sine() {
            return Math.Sin(this.Radians);
        }

        public double Cosine() {
            return Math.Cos(this.Radians);
        }

        public double Tangent() {
            return Sine() / Cosine();
        }

        public override Boolean Equals(Object o)
        {
            Angle angle = o as Angle;
            if (angle == null)
                return false;
            return this.Radians.Equals(angle.Radians);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override String ToString()
        {
            string aux = "";
            aux += "D = " + this.Degrees + "º   ";
            aux += "Q = " + this.Quadrant;
            return aux;
        }
    }

}
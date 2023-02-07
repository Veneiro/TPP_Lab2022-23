using System;
using System.Linq;
using TPP.Lab01;
using IntExtensionMethods;

namespace Lab02LI4
{
    internal class Program
    {
        /**
         * IncrementTwoDouble. Takes four double parmeters,
         * first and second by reference.
         * Modifies these two parameters adding third and fourth parameters value
         * respectively, return void.
         */
        static void IncrementTwoDouble(ref double x, ref double y, double deltaX, double deltaY) 
        {
            // Modify x and y adding the corresponding delta
            // no return
            x += deltaX;
            y += deltaY;
        }

        /**
         * GenerateTrajectory.Takes a length parameter(int, default value 10), start
         * coordinates x and y(double, default value both 0.0), x and y increment(double,
         * default value both 1.0). Returns a trajectory, stored in a Point2d array with the
         * number of elements length, where all the points except the first one are obtained
         * adding to the previous point in the trajectory the indicated increments using
         * previously defined function IncrementTwoDouble.
         */
        static Point2D[] GenerateTrajectory(int len=10, double startX=0.0, double startY=0.0, double deltaX=1.0, double deltaY = 1.0)
        {
            // Use the previous defined function to obtain each point in the trajectory
            // return the trajectory
            Point2D[] res= new Point2D[len];
            res[0] = new Point2D(startX, startY);
            for(int i = 1; i<len; i++)
            {
                IncrementTwoDouble(ref startX, ref startY, deltaX, deltaY);
                res[i] = new Point2D(res[i-1].X + deltaX, res[i-1].Y + deltaY);
            }
            return res;
        }

        /**
         * ShowTrajectory, takes an array representing a trajectory as described previously
         *  and an optional boolean, true if only first quadrant points are to be shown (x>=0 and
         *  y>=0) false otherwise. Outputs trajectory points textual representation to console.
         */
        static void ShowTrajectory(Point2D[] trajectory, bool firstQ = false)
        {
            foreach(Point2D p in trajectory)
            {
                p.ToString();
            }
        }

        /**
         * DistanceStartEnd, takes a Point2d array and, as output references, three
         * parameters: trajectory covered distance (the summation of the distances between
         * each point and the following one), starting and ending points.
         */
        static void DistanceStartEnd(Point2D[] t, out double distance, out Point2D start, out Point2D end)
        {
            distance = 0;
            for(int i = 0; i < t.Length-1; i++)
            {
                distance += t[i].Distance(t[i + 1]);
            }
            start = t[0];
            end = t[t.Length-1];
        }

        static void Main(string[] args)
        {
            //Check that everything works fine
            Point2D[] t = new Point2D[10];

            Console.WriteLine(12345.Reverse());
        }
    }
}

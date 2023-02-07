using System;

namespace IntExtensionMethods
{
    public static class IntExtension
    {
        /**
         * Reverse, returns the int obtained reversing caller digits order: 123456.Reverse()
         * returns 654321 as int.
         */
        static public int Reverse(this int a)
        {
            int r=0;
            while (a != 0)
            {
                r = r * 10 + a % 10;
                a=a / 10;
            }
            return r;
        }

        /**
         * IsPrime, returns true if the caller is prime, false otherwise: 13.IsPrime() returns true,
         * 14.IsPrime() returns false as boolean.
         */
        static public bool IsPrime(this int a)
        {
            int m = a / 2;
            for (int i = 2; i <= m; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * G cd and L cm, optional: 24.Gcd(36) is 12, again an integer.
         */

        /**
         * Concatenate, optional: 123.Concatenate(456) returns 123456 as int. Caution when
         * the second one is negative, choose any solution for this case, drop the sign or
         * whatever.
         */
    }
}

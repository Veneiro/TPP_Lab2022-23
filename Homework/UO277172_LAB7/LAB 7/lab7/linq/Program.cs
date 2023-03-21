using System.Collections.Generic;
using System;

namespace TPP.Laboratory.Functional.Lab07 {

    class Program {

        static void Main() {
            IEnumerable<int> integers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            foreach( var i in integers.Map(num => { Console.WriteLine(num + 1); return num + 1; }))
            {
                Console.WriteLine(i);
            }
        }
    }
}

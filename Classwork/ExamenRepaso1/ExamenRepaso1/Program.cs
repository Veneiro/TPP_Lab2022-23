using lab02TPP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TPP.Laboratory.Functional.Lab08;

namespace ExamenRepaso1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();
            var employees = model.Employees.Where(e => e.Department.Equals("Computer Science")).Select((x) => new
            {
                TelephoneNumber = x.TelephoneNumber
            });

            var numbers = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber,
            (x, y) => new
            {
                Number = y.SourceNumber,
                Duracion = y.Seconds
            });


            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }
            
        }
    }
}

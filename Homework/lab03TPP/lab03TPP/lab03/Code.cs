using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03TPP.lab03
{
    public enum ContractType
    {
        Full, Partial
    }

    public class Employee
    {
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string NIF { get; set; }
        public ContractType NumberOfHours { get; set; }
        public int ID { get; set; }
    }

    public class Code
    {
        /// <summary>
        /// Creates a random Employee array
        /// </summary>
        /// <returns>An employee array</returns>
        public static Employee[] CreateEmployees(int numEmployees = 100)
        {
            string[] names = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] surnames = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };

            Employee[] listing = new Employee[numEmployees];
            Random random = new Random();
            for (int i = 0; i < numEmployees; i++)
                listing[i] = new Employee
                {
                    Name = names[random.Next(0, names.Length)],
                    FirstSurname = surnames[random.Next(0, surnames.Length)],
                    SecondSurname = surnames[random.Next(0, surnames.Length)],
                    NIF = random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z'),
                    NumberOfHours = i % 2 == 0 ? ContractType.Full : ContractType.Partial,
                    ID = i,
                };

            return listing;
        }
    }
}

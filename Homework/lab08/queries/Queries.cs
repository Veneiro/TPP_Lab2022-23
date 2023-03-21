using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08
{

    class Query
    {
        private Model model = new Model();

        static void Main(string[] args)
        {
            Query query = new Query();

            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();
            query.Query5();
            query.Query6();

            query.QueryExam1();

            query.Extra6();
            query.Extra7();
            query.Extra8();
            query.Extra9();
            
            query.Homework1();
            query.Homework2();
            query.Homework3();
            query.Homework4();
            query.Homework5();

            Console.ReadLine();
        }

        // Check out:
        //  http://msdn.microsoft.com/en-us/library/9eekhta0.aspx
        //  https://msdn.microsoft.com/es-es/library/bb397933.aspx


        private void Query1()
        {
            // Show the phone calls that lasted more than 15 seconds
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 1 *** *** ***");
            Console.WriteLine();

            // Query syntax
            var q1 =
                from pc in model.PhoneCalls
                where pc.Seconds > 15
                select pc;

            foreach (var item in q1)
                Console.WriteLine(item);


            // Method syntax
            Console.WriteLine();

            var q1_m = model.PhoneCalls.Where(pc => pc.Seconds > 15);

            foreach (var item in q1_m)
                Console.WriteLine(item);
        }
		
		private void Query2()
        {
            // Show the name and surname of the employees older than 50 that work in Cantabria

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 2 *** *** ***");
            Console.WriteLine();

            var aux = model.Employees.Where(x=>x.Age > 50 && x.Province.Equals("Cantabria")).Select(x => x.Name + " " + x.Surname);
            Show(aux);
			
        }
		
		private void Query3()
        {
            // Show the names of the departments with more than one employee

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 3 *** *** ***");
            Console.WriteLine();

            var aux = model.Departments.Where(d => d.Employees.Count() > 1);
            Show(aux);

            // If departments didn't have a list of employees
            var aux2 = model.Departments.Select(d => new
            {
                Department=d,
                NumberOfEmployees=model.Employees.Where(e=>e.Department.Equals(d)).Count()
            }).Where(a=>a.NumberOfEmployees > 1);
            Show(aux2);

            var aux3 = model.Employees.GroupBy(emp => emp.Department).Where(x=>x.Count() > 1).Select(x=>x.Key);
            foreach (var elem in aux3)
            {
                Console.WriteLine(elem);
            }
            
        }
        
        private void Query4()
        {
            // Show the phone calls of each employee ordered by employee name. 
            // Each line should show the name of the employee and the phone call duration in seconds.

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 4 *** *** ***");
            Console.WriteLine();

            var aux = model.PhoneCalls.Join(model.Employees, x => x.SourceNumber, y => y.TelephoneNumber, (x, y) => new
            {
                EmployeeName=y.Name,
                PhoneCallDuration=x.Seconds
            }).GroupBy(z=>z.EmployeeName).OrderBy(k=>k.Key);


            foreach (var elem in aux)
            {
                Console.WriteLine(elem.Key);
                Show(elem);
                Console.WriteLine();
            }
        }
		
		private void Query5()
        {
            // Show, grouped by province, the name of the employees 
			
			Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 5 *** *** ***");
            Console.WriteLine();

            var aux = model.Employees.GroupBy(e => e.Province, x=> new
            {
                EmployeeName=x.Name
            });

            foreach(var i in aux)
            {
                Console.WriteLine(i.Key);
                Show(i);
            }
		}
		
		private void Query6()
        {
            // Show the phone calls done by employees in each department (grouped by departement)

            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 6 *** *** ***");
            Console.WriteLine();

            var aux = model.PhoneCalls.Join(model.Employees, x => x.SourceNumber, y => y.TelephoneNumber, (x, y) => new
            {
               x,y
            }).GroupBy(ep=>ep.y.Department);

            foreach(var i in aux)
            {
                Console.WriteLine(i.Key);
                Show(i);
            }
        }
        // Building with more outgoing calls
        private void QueryExam1()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY EXAM 1 *** *** ***");
            Console.WriteLine();

            var aux = model.Employees.Join(model.PhoneCalls, x=>x.TelephoneNumber, y=>y.SourceNumber, (x,y) => new
            {
                x,
                y
            }).GroupBy(xy=>xy.x.Office.Building)
            .Select(xy=>new { 
                Building=xy.Key,
                NumberOfCalls=xy.Count()
            })
            .Aggregate((acc,ep)=>ep.NumberOfCalls>acc.NumberOfCalls?ep:acc);

            Console.WriteLine(aux);

        }

        /************* Extra ************************************/

        /**
         * Calcular la lista de edificios que han realizado más de 100 sec de llamada 
         */
        public void Extra6()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 6 *** *** ***");
            Console.WriteLine();

            var res = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber,
            (x, y) => new
            {
                Building = x.Office.Building,
                Duracion = y.Seconds
            }).GroupBy(x => x.Building).Select(x =>
            new
            {
                Building = x.Key,
                DuracionSegundos = x.Sum(y => y.Duracion)
            }).Where(x => x.DuracionSegundos > 100);

            Show(res);
        }

        /**
         * Obtener las lista de departamentos desde cuyo telefonos no se hayan realizado llamadas
         */
        public void Extra7()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 7 *** *** ***");
            Console.WriteLine();

            var res = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber, 
            (x, y) => new
            {
                Department = x.Department
            });

            var noCallsD = new List<Department>();

            var allDCalls = model.Departments.Select(d => d.Name);

            foreach(var d in res)
            {
                if(!allDCalls.Contains(d.Department.Name))
                    noCallsD.Add(d.Department);
            }

            Show(noCallsD);

            var aux = model.Departments.Except(res.Select(d=>d.Department));
            Show(aux);
        }

        /**
         * Calcular la lista de numeros que no han realizado llamadas
         */
        public void Extra8()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 8 *** *** ***");
            Console.WriteLine();

            var noCalls = new List<String>();
            var empNum = model.Employees.Select(x => x.TelephoneNumber);
            var allNumber = model.PhoneCalls.Select(x => x.SourceNumber);

            foreach(var t in empNum)
            {
                if (!allNumber.Contains(t))
                    noCalls.Add(t);
            }

            Console.WriteLine("Using foreach and Contains: ");
            Show(noCalls);

            Console.WriteLine();

            // All employee numbers except the ones that are in the PhoneCalls List
            var except = empNum.Except(allNumber);
            Console.WriteLine("Using Except from linq: ");
            Show(except);
        }

        /**
         * Mostrar agrupados por provincia el nombre del empleado ordenado por provincias y empleados
         */
        public void Extra9()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** EXTRA 9 *** *** ***");
            Console.WriteLine();

            var res = model.Employees.OrderBy(x=>x.Name).GroupBy(x=>x.Province,
                emp=>
                new
                {
                    Province=emp.Province,
                    Nombre=emp.Name
                }).OrderBy(x=>x.Key);

            /*var i = res.GetEnumerator();
            while(i.MoveNext()) {
                Console.WriteLine(i.Current.Key);
                var j = i.Current.GetEnumerator();
                while (j.MoveNext())
                {
                    Console.WriteLine("Province: " + j.Current);
                }
            }*/

            var a = res.Select(x => x);

            Show(a);

        }

        /************ Homework **********************************/

        private void Show<T>(IEnumerable<T> list)
        {
            foreach(var e in list)
                Console.WriteLine(e);
            Console.WriteLine("Items in the collection {0}", list.Count());
        }

        private void Homework1()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 1 *** *** ***");
            Console.WriteLine();
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute
            IEnumerable<Employee> employees = model.Employees.Where(x => x.Department.Name.Equals("Computer Science") && x.Office.Building.Equals("Faculty of Science"));
            employees.OrderBy(x => x.Age);
            var res = employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber, (x, y) => new
            {
                NameOfTheEmployee = x.Name,
                CallLengthInSeconds = y.Seconds
            });

            Console.WriteLine("All the phone calls:");
            Show(res);

            var resBigger60 = res.Where(x => x.CallLengthInSeconds > 60);

            Console.WriteLine("Phone calls larger than 60 seconds:");
            Show(resBigger60);
        }

        private void Homework2()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 2 *** *** ***");
            Console.WriteLine();
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department

            IEnumerable<Employee> employees = model.Employees.Where(x => x.Department.Name.Equals("Computer Science"));

            var res = employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber, (x, y) => new
            {
                NameOfTheEmployee = x.Name,
                CallLengthInSeconds = y.Seconds
            });
            var resSum = res.Sum(x => x.CallLengthInSeconds);
            Console.WriteLine("Total time of Computer Science Department calls: {0}", resSum);
        }

        private void Homework3()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 3 *** *** ***");
            Console.WriteLine();
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            var res = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber, (x, y) => new
            {
                EmployeeDepartment = x.Department.Name,
                CallLengthInSeconds = y.Seconds
            });

            var resGroupedAndOrdered = res.GroupBy(x => x.EmployeeDepartment).OrderBy(x => x.Key).Select(x=> new
            {
                departament = x.Key,
                CallLengthInSeconds = x.Sum(x =>x.CallLengthInSeconds)
            });

            Show(resGroupedAndOrdered);
        }

        private void Homework4()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 4 *** *** ***");
            Console.WriteLine();
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)

            var employees = model.Employees.Join(model.Departments, x => x.Department.Name, y => y.Name, (x, y) => new
            {
                Department = x.Department.Name,
                EmployeeAge = x.Age
            });

            var minAge = employees.Min(x => x.EmployeeAge);

            var res = employees.Where(x => x.EmployeeAge == minAge);

            Show(res);


            var listDep = model.Departments.GroupBy(dep => dep.Name, emp => new
            {
                Name = emp.Employees.FirstOrDefault(x => x.Age == emp.Employees.Min(e => e.Age)),
                Age = emp.Employees.Min(e => e.Age)
            }).Select(x => new
            {
                Name = x.Key,
                Age = x.Min(x => x.Age)
            });

            /*
            foreach(var d in listDep)
            {
                Console.Write("Department " + d.Key);
                foreach(var e in d)
                {
                    Console.WriteLine(" =" + e.Age);
                    Console.WriteLine(e.Name);
                }
            }
            */

            Show(listDep);


        }

        private void Homework5()
        {
            Console.WriteLine();
            Console.WriteLine("*** *** *** HOMEWORK 5 *** *** ***");
            Console.WriteLine();
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)

            var res = model.Employees.Join(model.PhoneCalls, x => x.TelephoneNumber, y => y.SourceNumber, (x, y) => new
            {
                NameOfTheEmployee = x.Name,
                CallLengthInSeconds = y.Seconds,
                Department = x.Department.Name
            }).GroupBy(x => x.Department);

            var res2 = res.OrderBy(x => x.Key).Select(x => new
            {
                departament = x.Key,
                CallLengthInSeconds = x.Sum(x => x.CallLengthInSeconds)
            });
            
            var aux = res2.Max(x => x.CallLengthInSeconds);


            var res3 = res2.Where(x => x.CallLengthInSeconds == aux);


            Show(res3);

        }


    }

}

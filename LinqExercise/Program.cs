using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine(avg);
            //TODO: Order numbers in ascending order and print to the console
            var orderAsc = numbers.OrderBy( numb=> numb);
            foreach (var numb in orderAsc)
            {
                Console.WriteLine(numb);
            }
            var orderDes = numbers.OrderByDescending( num => num);
            foreach (var num in orderDes)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order and print to the console

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item); 
            }
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("first four ascending");
            var firstFour = orderAsc.Take(4);
            foreach (var item in firstFour)
            {
                Console.WriteLine(item);    
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("My age at index four");
            numbers[4] = 24;
            foreach (var item in orderDes)
            {
                Console.WriteLine(item);    
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filter = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName.StartsWith('S'))
            .OrderBy(person => person.FirstName);

            Console.WriteLine("C or S Employees");
            foreach(var employee in filter)
            {
                Console.WriteLine(employee.FullName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            Console.WriteLine("Employees over 26 ordered by age and then first name");
            foreach(var employee in overTwentySix)
            {
                Console.WriteLine(employee.FullName);
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var years = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);
            var sumExp = years.Sum(person => person.YearsOfExperience);
            var avgExp = years.Average(person => person.YearsOfExperience);
            Console.WriteLine($"Sum {sumExp} Avergae {avgExp}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Grant", "Bradley", 24, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

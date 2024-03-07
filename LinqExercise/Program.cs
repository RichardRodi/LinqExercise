using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            var numbersSum = numbers.Sum();
            Console.WriteLine($"Number Sum: {numbersSum}\n\n");

            //TODO: Print the Average of numbers
            var NumberAverage = numbers.Average();
            Console.WriteLine($"Number Average: {NumberAverage}\n\n");

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Ascending Number List :\n\n");
            numbers.OrderBy(numbers => numbers).ToList().ForEach(number => Console.WriteLine($"{number}"));

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("\n\nDescending Number List: ");
            numbers.OrderByDescending(numbers => numbers).ToList().ForEach(number => Console.WriteLine($"{number}"));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("\n\nNumbers greater than Six List: ");
            numbers.Where(numbers => numbers > 6).ToList().ForEach(number => Console.WriteLine($"{number}"));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("\n\n First Four Numbers: ");
            var firstFour = numbers.Take(4);
            foreach (var numbersFour in firstFour)
            {
                Console.WriteLine(numbersFour);
            }
            
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("\n\nChanged 4th Index to My Age: ");
            
            numbers.Select((number, index) => index == 4 ? 36 : number).OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("\n\nList of Employees with First Names starting with C or S:");
            var employeeFirstNameCorS = employees.Where(name => name.FirstName.StartsWith("C") || name.FirstName.StartsWith("S")).ToList();
            foreach (var employee in employeeFirstNameCorS)
            {
                Console.WriteLine(employee.FirstName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            
            var employeesListover26 = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            Console.WriteLine("\n\nEmployees over 26");
            foreach (var person in employeesListover26)

            { 
                Console.WriteLine($"Name: {person.FullName}\tAge: {person.Age}"); 
            
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var YOE = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).ToList();
            var yearsSum = YOE.Sum(x => x.YearsOfExperience);

            Console.WriteLine($"\n\nSum of years of experience of employees over the age of 35 with less than 10 years of experience: {yearsSum}");
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yearsAverage = YOE.Average(x => x.YearsOfExperience);

            Console.WriteLine($"\n\nThis is the Average of years of experience of employees over the age of 35 with less than 10 years of experience: {yearsAverage}");
            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Rich","Rodi", 36, 1)).ToList();
            Console.Write($"\n\nNew Employee List");
            foreach (var employee in employees) 
            { 
                Console.Write($"\n{employee.FirstName}");
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

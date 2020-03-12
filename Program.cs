/*
// Sample code to perform I/O:

name = Console.ReadLine();                  // Reading input from STDIN
Console.WriteLine("Hi, {0}.", name);        // Writing output to STDOUT

// Warning: Printing unwanted or ill-formatted data to output will cause the test cases to fail
*/

// Write your code here
using System;
using System.Collections.Generic;

namespace SkyPointCoding
{

    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();

            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {

                var employee = new Employee();
                var input = Console.ReadLine().Split(' ');
                employee.Department = input[0];
                employee.Name = input[1];
                employeeList.Add(employee);
            }

            foreach (var employeeData in employeeList)
            {
                var department = getReference(employeeData.Department);
                if (department != null)
                {
                    department.setName(removeSpecialChar(employeeData.Name));
                    department.display();
                }
                else
                    Console.WriteLine("No department found" + employeeData.Department);
            }
        }

        static IDepartment getReference(String name)
        {
            IDepartment department = null;
            switch (name)
            {
                case "ProblemSetter":
                    department = new ProblemSetter();
                    break;

                case "Developer":
                    department = new Developer();
                    break;

                case "Sales":
                    department = new Sales();
                    break;

                    //default:
            }

            return department;
        }

        static string removeSpecialChar(String inp)
        {
            return inp.Replace("$", string.Empty).Replace("#", string.Empty).Replace("&", string.Empty);
        }

    }

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
    }
    

    public class ProblemSetter : IDepartment
    {
        private string _name;
        public void setName(string name)
        {
            _name = name;
        }

        public void display()
        {
            Console.WriteLine("ProblemSetter");
            Console.WriteLine("Name:" + _name);
        }

    }

    public class Developer : IDepartment
    {
        private string _name;
        public void setName(string name)
        {
            _name = name;
        }

        public void display()
        {
            Console.WriteLine("Developer");
            Console.WriteLine("Name:" + _name);
        }
    }

    public class Sales : IDepartment
    {
        private string _name;
        public void setName(string name)
        {
            _name = name;
        }

        public void display()
        {
            Console.WriteLine("Sales");
            Console.WriteLine("Name:" + _name);
        }
    }
}
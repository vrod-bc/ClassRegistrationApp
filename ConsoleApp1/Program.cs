using System;
using ConsoleApp1.Database; // import the file 
using System.Linq;
using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static public DbService _dbservice = new DbService(); //initiated at the highest level - defining the variable

        #region Example
        public static class Test
        {

        }
        //var t = new Test();
        //Test.GetTest();
        #endregion

        public static void DisplayDepartment()
        { 
            foreach (var element in _dbservice.GetDepartments())
            {
                Console.WriteLine(string.Format("Id:{0} Department Name: {1}", element.DepartmentId, element.DepartmentName));
            }
        }
        public static void DisplayCourse()
        {
            foreach (var item in _dbservice.GetCourses())
            {
                Console.WriteLine(string.Format("Id: {0} Course Name: {1} Department Id: {2}", item.CourseId, item.CourseName, item.DepartmentId));
            }
        }
        static void Main(string[] args)
        {
            List<Departments> fe = new List<Departments>();
            fe = _dbservice.GetDepartments();
            Console.WriteLine(fe.Count());

            Console.WriteLine("Welcome to your class registration Please select a number for which task you want to do:");
            Console.WriteLine("1 - Get the list of departments");
            Console.WriteLine("2 - Search for department by id");
            Console.WriteLine("3 - Save new department");
            Console.WriteLine("4 - Get the list of courses");
            Console.WriteLine("5 - Search for course by id"); 
            Console.WriteLine("6 - Get the list of courses by department id");
            Console.WriteLine("7 - Get user account info");
            Console.WriteLine("8 - Save new course");

 
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Get the list of departments");
                    DisplayDepartment();
                    break;

                case "2":
                    Console.WriteLine("Input Department Id: ");
                    var id = Console.ReadLine();
                 
                    if (id.Any(x => !char.IsLetter(x))) // if no letter then return true
                    {
                        var value = _dbservice.GetDeparmentById(Convert.ToInt32(id)); //Console.WriteLine(s1.GetDeparmentById(Convert.ToInt32(id))?.DepartmentName);

                        if (value == null)
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        else
                        {
                            Console.WriteLine(value.DepartmentName);
                        }
                        #region Veros Changes
                        //foreach (var items in s1.GetDepartments())
                        //{
                        //    //int item = items.DepartmentId;
                        //    if (Convert.ToInt32(id) == items.DepartmentId)
                        //    {
                        //        var department = s1.GetDeparmentById(Convert.ToInt32(id));
                        //        Console.WriteLine(department.DepartmentName);
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Invalid Input");
                        //        break; 
                        //    }
                        //}
                        #endregion
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    break;

                case "3":
                    Console.WriteLine("Save new department");
                    var department = new Departments();

                    Console.WriteLine("Department Name: ");
                    department.DepartmentName= Console.ReadLine();

                    Console.WriteLine("Department Id: ");
                    department.DepartmentId= Convert.ToInt32(Console.ReadLine());

                    _dbservice.SaveDepartment(department);
                    DisplayDepartment();
                    break;

                case "4":
                    Console.WriteLine("Get the list of courses");
                    DisplayCourse();
                    break;

                case "5":
                    Console.WriteLine("Input Course Id");
                    string v = Console.ReadLine();
                    int number;
                    bool success = Int32.TryParse(v, out number);
                    if (success) // if no letter then return true
                    {
                        var val = _dbservice.GetCoursesById(number); //Console.WriteLine(s1.GetDeparmentById(Convert.ToInt32(id))?.DepartmentName);

                        if (val == null)
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        else
                        {
                            Console.WriteLine(val.CourseName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    break;

                case "6":
                    Console.WriteLine("Get the list of courses by department id"); // Make method for this 
                    int depID = Convert.ToInt32(Console.ReadLine());

                    foreach (var course in _dbservice.GetCourses())
                    {
                        int c = course.DepartmentId;
                        if (depID == c)
                        {
                            Console.WriteLine("Courses based on Department Id");
                            Console.WriteLine(course.CourseName);
                        }
                    }
                    break;

                case "7":
                    Console.WriteLine("Get user account info");
                    break;

                case "8":
                    Console.WriteLine("Save new course");
                    var d = new Courses();
                    Console.WriteLine("Course Name: ");
                    d.CourseName = Console.ReadLine();
                    Console.WriteLine("Course Id: ");
                    d.CourseId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(d.CourseId);
                    Console.WriteLine("Department Id: ");
                    d.DepartmentId = Convert.ToInt32(Console.ReadLine());
                    _dbservice.SaveCourse(d);
                    DisplayCourse();
                    break;

                default:
                    Console.WriteLine("invalid input");
                    break;
        
            }
          
        }


    }
}

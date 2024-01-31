using System;
using System.Runtime.CompilerServices;
using Canvas.Helpers;
using Canvas.Models;
using Canvas.Services;

namespace Canvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courseHelper = new CourseHelper();
            var personHelper = new PersonHelper();
            PrintMenu();
            Console.WriteLine("Choose an option:");
            var choice = Console.ReadLine();
            while(choice != "0")
            {   
                switch(choice)
                {
                    case "1":   courseHelper.AddCourse();
                        break;
                    case "2":   courseHelper.ListCourses();
                        break;
                    case "3":   courseHelper.AddStudentToCourse();
                        break;
                    case "4":   courseHelper.RemoveStudentFromCourse();
                        break;
                    case "5":   courseHelper.SearchCourse();
                        break;
                    case "6":   courseHelper.AddAssignment();
                        break;
                    case "7":   courseHelper.UpdateCourse();
                        break;
                    case "8":   personHelper.AddStudent();
                        break;
                    case "9":   personHelper.ListStudents();
                        break;
                    case "10":  personHelper.SearchStudentByName();
                        break;
                    case "11":  courseHelper.ListCoursesTakenByStudent();
                        break;
                    case "12":  personHelper.UpdateStudent();
                        break;
                    case "0":
                        break;
                }
                Console.WriteLine();
                PrintMenu();
                Console.WriteLine("Choose an option:");
                choice = Console.ReadLine();
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("1. Add a course");
            Console.WriteLine("2. List courses");
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. Search for a course");
            Console.WriteLine("6. Add an assignment to a course");
            Console.WriteLine("7. Update course information");
            Console.WriteLine();
            Console.WriteLine("8. Add a student");
            Console.WriteLine("9. List students");
            Console.WriteLine("10. Search for a student");
            Console.WriteLine("11. List courses taken by a student");
            Console.WriteLine("12. Update student information");
            Console.WriteLine();
            Console.WriteLine("0. Exit menu");
        }        
    }
}
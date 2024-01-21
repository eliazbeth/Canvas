using System;
using Canvas.Models;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            AddCourse(courses);
            foreach(Course c in courses)
            {
                Console.WriteLine(c);
            }

        }
        public static void AddCourse(List<Course> courses)
        {
                Console.WriteLine("Code:");
                var code = Console.ReadLine();

                Console.WriteLine("Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Description:");
                var description = Console.ReadLine();

                Course myCourse = new Course{Code = code, Name = name, Description = description};
                courses.Add(myCourse);
        }

    }
}
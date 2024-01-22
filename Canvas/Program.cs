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
            Console.WriteLine();
            Course myCourse = courses[0];

            List<Person> students = new List<Person>();
            AddStudent(students);
            AddStudent(students);
            foreach(Person s in students)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            myCourse.Roster = new List<Person>();
            AddStudentToCourse(students[0], myCourse);
            AddStudentToCourse(students[1], myCourse);
            Console.WriteLine(myCourse + " roster:");
            foreach(Person s in myCourse.Roster)
            {
                Console.WriteLine(s);
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
        public static void AddStudent(List<Person> students)
        {
                Console.WriteLine("Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Classification:");
                var classification = Console.ReadLine();

                Person myStudent = new Person{Name = name, Classification = classification};
                students.Add(myStudent);
        }

        public static void AddStudentToCourse(Person student, Course course)
        {
            course.Roster?.Add(student);
        }

    }
}
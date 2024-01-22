using System;
using Canvas.Models;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create list of courses and add a course to it
            List<Course> courses = new List<Course>();
            AddCourse(courses);
            // Print list of courses
            ListCourses(courses);
            Console.WriteLine();
            Course myCourse = courses[0];

            // Create list of students and add a student to it
            List<Person> students = new List<Person>();
            AddStudent(students);
            AddStudent(students);
            // Print list of students
            ListStudents(students);
            Console.WriteLine();

            // Create course roster and add students to it
            myCourse.Roster = new List<Person>();
            AddStudentToCourse(students[0], myCourse);
            AddStudentToCourse(students[1], myCourse);
            // Print course roster
            Console.WriteLine(myCourse + " roster:");
            myCourse.Roster.ForEach(Console.WriteLine);

            // Remove student from roster and print it again
            RemoveStudentFromCourse(students[0], myCourse);
            Console.WriteLine(myCourse + " roster:");
            myCourse.Roster.ForEach(Console.WriteLine);
        }
        public static void AddCourse(List<Course> courses)
        {
                Console.WriteLine("Course Code:");
                var code = Console.ReadLine();

                Console.WriteLine("Course Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Course Description:");
                var description = Console.ReadLine();

                Course myCourse = new Course{Code = code, Name = name, Description = description};
                courses.Add(myCourse);
        }
        public static void AddStudent(List<Person> students)
        {
                Console.WriteLine("Student Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Student Classification:");
                var classification = Console.ReadLine();

                Person myStudent = new Person{Name = name, Classification = classification};
                students.Add(myStudent);
        }
        public static void AddStudentToCourse(Person student, Course course)
        {
            course.Roster?.Add(student);
        }
        public static void RemoveStudentFromCourse(Person student, Course course)
        {
            course.Roster?.Remove(student);
        }

        public static void ListCourses(List<Course> courses)
        {
            courses.ForEach(Console.WriteLine);
        }

        public static void ListStudents(List<Person> students)
        {
            students.ForEach(Console.WriteLine);
        }

    }
}
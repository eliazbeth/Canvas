using System;
using Canvas.Models;

namespace Canvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            List<Person> students = new List<Person>();
            PrintMenu();
            Console.WriteLine("Choose an option:");
            var choice = Console.ReadLine();
            while(choice != "0")
            {   
                switch(choice)
                {
                    case "1":   AddCourse(courses);
                        break;
                    case "2":   ListCourses(courses);
                        break;
                    case "3":   
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":   AddStudent(students);
                        break;
                    case "9":   ListStudents(students);
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "0":
                        break;
                }
                PrintMenu();
                Console.WriteLine("Choose an option:");
                choice = Console.ReadLine();
            }

            /*Course myCourse = courses[0];
            // Create course roster and add students to it
            myCourse.Roster = new List<Person>();)
            AddStudentToCourse(students[0], myCourse);
            // Print course roster
            Console.WriteLine(myCourse + " roster:");
            myCourse.Roster.ForEach(Console.WriteLine);

            // Remove student from roster and print it again
            RemoveStudentFromCourse(students[0], myCourse);
            Console.WriteLine(myCourse + " roster:");
            myCourse.Roster.ForEach(Console.WriteLine);

            // Search for course by name
            if(SearchCourseByName("cop4870", courses))
                Console.WriteLine("Found course by name");
            // Search for course by description
            if(SearchCourseByDescription("full-stack development in c#", courses))
                Console.WriteLine("Found course by description\n");
            // Search for student by name
            if(SearchStudentByName("John Snow", students))
                Console.WriteLine("Found student by name\n");
            */
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
            Console.WriteLine("Courses:");
            courses.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public static void ListStudents(List<Person> students)
        {
            Console.WriteLine("Students:");
            students.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public static bool SearchCourseByName(string name, List<Course> courses)
        {
            if(courses.Find(c => c.Name == name) != null)
                return true;
            return false;
        }
        public static bool SearchCourseByDescription(string description, List<Course> courses)
        {
            if(courses.Find(c => c.Description == description) != null)
                return true;
            return false;
        }

        public static bool SearchStudentByName(string name, List<Person> students)
        {
            if(students.Find(s => s.Name == name) != null)
                return true;
            return false;
        }
    }
}
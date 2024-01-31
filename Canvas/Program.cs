using System;
using System.Runtime.CompilerServices;
using Canvas.Models;
using Canvas.Services;

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
                    case "1":   AddCourse();
                        break;
                    case "2":   ListCourses();
                        break;
                    case "3":   AddStudentToCourse();
                        break;
                    case "4":   RemoveStudentFromCourse();
                        break;
                    case "5":   SearchCourse();
                        break;
                    case "6":   AddAssignment(courses);
                        break;
                    case "7":   UpdateCourse();
                        break;
                    case "8":   AddStudent();
                        break;
                    case "9":   ListStudents();
                        break;
                    case "10":  SearchStudentByName();
                        break;
                    case "11":  ListCoursesTakenByStudent(students, courses);
                        break;
                    case "12":  UpdateStudent();
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
        public static void AddCourse()
        {
                Console.WriteLine("Course Code:");
                var code = Console.ReadLine();

                Console.WriteLine("Course Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Course Description:");
                var description = Console.ReadLine();

                Course myCourse = new Course{Code = code, Name = name, Description = description};
                CourseService.Current.Add(myCourse);
        }
        public static void AddStudent()
        {
                Console.WriteLine("Student Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Student Classification:");
                var classification = Console.ReadLine();

                Person myStudent = new Person{Name = name, Classification = classification};
                PersonService.Current.AddStudent(myStudent);
        }
        public static void AddStudentToCourse()
        {
            Course course = ChooseACourse();
            Person student = ChooseAStudent();

            CourseService.Current.AddStudentToCourse(student, course);
            Console.WriteLine($"Roster for {course.Name}:");
            foreach(Person s in course.Roster)
            {
                Console.WriteLine(s);
            }
        }
        public static void RemoveStudentFromCourse()
        {
            Course course = ChooseACourse(); 
            Person student = ChooseAStudentFromRoster(course);

            CourseService.Current.RemoveStudentFromCourse(student, course);
            Console.WriteLine($"Roster for {course.Name}:");
            foreach(Person s in course.Roster)
            {
                Console.WriteLine(s);
            }
        }
        public static void ListCourses()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c.Code} - {c.Name}"));
        }
        public static void ListCoursesFull()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));
        }

        public static void ListStudents()
        {
            int count = 0;
            PersonService.Current.Students.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));
        }

        public static void ListStudentsInCourse(Course course)
        {
            int count = 0;
            course.Roster.ForEach(s => Console.WriteLine($"{++count}. {s}"));
        }

        public static void SearchCourse()
        {
            Console.WriteLine("Enter a query to search for: ");
            var query = Console.ReadLine();
            var found = CourseService.Current.Search(query ?? string.Empty);
            found.ToList().ForEach(Console.WriteLine);
        }
        
        public static void SearchStudentByName()
        {
            Console.WriteLine("Enter a name to search for: ");
            var query = Console.ReadLine();
            var found = PersonService.Current.Search(query ?? string.Empty);
            Console.WriteLine("Found:");
            found.ToList().ForEach(Console.WriteLine);
        }
        public static void AddAssignment(List<Course> courses)
        {
            Course course = ChooseACourse();

            Console.WriteLine("Enter name for assignment ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter description: ");
            var description = Console.ReadLine();
            Console.WriteLine("Enter available points: ");
            var points = Console.ReadLine();   
            double pointsDbl = double.Parse(points ?? "100"); 
            Console.WriteLine("Enter the due date and time in the form 'dd/mm/yy hh:mm:ss'");
            var datetimeStr = Console.ReadLine();
            DateTime datetime = DateTime.Parse(datetimeStr ?? "0");

            Assignment assignment = new Assignment{Name = name, Description = description, TotalAvailablePoints = pointsDbl, DueDate = datetime};
            course.Assignments.Add(assignment);
            Console.WriteLine($"Assignments for {course.Name}:");
            foreach(Assignment a in course.Assignments)
            {
                Console.WriteLine($"{a.Name} Due {a.DueDate}");
            }
            Console.WriteLine();
        }
        public static void UpdateCourse()
        {
            Course course = ChooseACourse();
            Console.WriteLine("Choose what to update - enter 'n' for name, 'd' for description, or 'c' for code: ");
            var choice = Console.ReadLine();
            string? updated;
            switch(choice)
            {
                case "n": Console.WriteLine("Enter the new name: ");
                    break;
                case "d": Console.WriteLine("Enter the new description: ");
                    break;
                case "c": Console.WriteLine("Enter the new code: ");
                    break;
            }
            updated = Console.ReadLine();
            CourseService.Current.UpdateCourse(choice ?? " ", updated ?? " ", course);
            Console.WriteLine("Course updated.\n");
        }
        public static void UpdateStudent()
        {
            Person student = ChooseAStudent();
            Console.WriteLine("Choose what to update - enter 'n' for name or 'c' for classification: ");
            var choice = Console.ReadLine();
            string? updated;
            switch(choice)
            {
                case "n": Console.WriteLine("Enter the new name: ");
                    break;
                case "d": Console.WriteLine("Enter the new description: ");
                    break;
                case "c": Console.WriteLine("Enter the new code: ");
                    break;
            }
            updated = Console.ReadLine();
            PersonService.Current.UpdateStudent(choice ?? " ", updated ?? " ", student);
            Console.WriteLine("Student updated.\n");
        }
        public static void ListCoursesTakenByStudent(List<Person> students, List<Course> courses)
        {
            Person student = ChooseAStudent();
            Console.WriteLine($"Courses being taken by {student.Name}:");
            int count = 1;
            foreach(Course c in courses)
            {
                if(c.Roster.Contains(student))
                {
                    Console.WriteLine($"{count++}. {c.Code}-{c.Name}");
                }
            }
            Console.WriteLine();
        }
        public static Course ChooseACourse()
        {
            ListCoursesFull();
            Console.WriteLine("Choose a course: ");
            var course = Console.ReadLine();
            var courseInt = int.Parse(course ?? "0");
            courseInt--;
            return CourseService.Current.CourseAt(courseInt);
        }

        public static Person ChooseAStudent()
        {
            ListStudents();
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "0");
            studentInt--;
            return PersonService.Current.StudentAt(studentInt);
        }
        public static Person ChooseAStudentFromRoster(Course course)
        {
            ListStudentsInCourse(course);
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "0");
            studentInt--;
            return course.Roster[studentInt];
        }
        
    }
}
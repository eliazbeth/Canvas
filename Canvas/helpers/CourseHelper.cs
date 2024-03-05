using Library.Canvas.Models;
using Library.Canvas.Services;

namespace Canvas.Helpers
{
    public class CourseHelper
    {
        StudentHelper studentHelper = new StudentHelper();
        public void AddCourse()
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
    
        public void ListCourses()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c.Code} - {c.Name}"));
        }
        public void ListCoursesFull()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));
        }

        public void SearchCourse()
        {
            Console.WriteLine("Enter a query to search for: ");
            var query = Console.ReadLine();
            var found = CourseService.Current.Search(query ?? string.Empty);
            Console.WriteLine("Found:");
            found.ToList().ForEach(Console.WriteLine);
        }

        public Course ChooseACourse()
        {
            ListCoursesFull();
            Console.WriteLine("Choose a course: ");
            var course = Console.ReadLine();
            var courseInt = int.Parse(course ?? "1");
            courseInt--;
            return CourseService.Current.CourseAt(courseInt);
        }

        public void UpdateCourse()
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

        public void AddAssignment()
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

        public void AddStudentToCourse()
        {
            Course course = ChooseACourse();
            Student student = studentHelper.ChooseAStudent();

            CourseService.Current.AddStudentToCourse(student, course);
            Console.WriteLine($"Roster for {course.Name}:");
            foreach(Person s in course.Roster)
            {
                Console.WriteLine(s);
            }
        }
        public void RemoveStudentFromCourse()
        {
            Course course = ChooseACourse(); 
            Student student = studentHelper.ChooseAStudentFromRoster(course);

            CourseService.Current.RemoveStudentFromCourse(student, course);
            Console.WriteLine($"Roster for {course.Name}:");
            foreach(Person s in course.Roster)
            {
                Console.WriteLine(s);
            }
        }

        public void ListCoursesTakenByStudent()
        {
            Student student = studentHelper.ChooseAStudent();
            Console.WriteLine($"Courses being taken by {student.Name}:");
            int count = 1;
            foreach(Course c in CourseService.Current.Courses)
            {
                if(c.Roster.Contains(student))
                {
                    Console.WriteLine($"{count++}. {c.Code}-{c.Name}");
                }
            }
            Console.WriteLine();
        }
    }
}
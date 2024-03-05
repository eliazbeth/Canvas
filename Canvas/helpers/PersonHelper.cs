using Library.Canvas.Models;
using Library.Canvas.Services;
namespace Canvas.Helpers
{
    public class StudentHelper
    {
        public void AddStudent()
        {
                Console.WriteLine("Student Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Student Classification:");
                var classification = Console.ReadLine();

                Student myStudent = new Student{Name = name, Classification = classification};
                StudentService.Current.AddStudent(myStudent);
        }
        public void ListStudents()
        {
            int count = 0;
            StudentService.Current.Students.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));
        }
        public static void ListStudentsInCourse(Course course)
        {
            int count = 0;
            course.Roster.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));
        }

        public void SearchStudentByName()
        {
            Console.WriteLine("Enter a name to search for: ");
            var query = Console.ReadLine();
            var found = StudentService.Current.Search(query ?? string.Empty);
            Console.WriteLine("Found:");
            found.ToList().ForEach(Console.WriteLine);
        }

        public Student ChooseAStudent()
        {
            ListStudents();
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "1");
            studentInt--;
            return StudentService.Current.StudentAt(studentInt);
        }
        public Student ChooseAStudentFromRoster(Course course)
        {
            ListStudentsInCourse(course);
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "1");
            studentInt--;
            return course.Roster[studentInt];
        }
        public void UpdateStudent()
        {
            Student student = ChooseAStudent();
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
            StudentService.Current.UpdateStudent(choice ?? " ", updated ?? " ", student);
            Console.WriteLine("Student updated.\n");
        }
    }
}
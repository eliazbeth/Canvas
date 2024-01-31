using Canvas.Models;
using Canvas.Services;
namespace Canvas.Helpers
{
    public class PersonHelper
    {
        public void AddStudent()
        {
                Console.WriteLine("Student Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Student Classification:");
                var classification = Console.ReadLine();

                Person myStudent = new Person{Name = name, Classification = classification};
                PersonService.Current.AddStudent(myStudent);
        }
        public void ListStudents()
        {
            int count = 0;
            PersonService.Current.Students.ToList().ForEach(s => Console.WriteLine($"{++count}. {s}"));
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
            var found = PersonService.Current.Search(query ?? string.Empty);
            Console.WriteLine("Found:");
            found.ToList().ForEach(Console.WriteLine);
        }

        public Person ChooseAStudent()
        {
            ListStudents();
            Console.WriteLine("Choose a student: ");
            var student = Console.ReadLine();
            var studentInt = int.Parse(student ?? "1");
            studentInt--;
            return PersonService.Current.StudentAt(studentInt);
        }
        public Person ChooseAStudentFromRoster(Course course)
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
    }
}
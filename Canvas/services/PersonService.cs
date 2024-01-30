using Canvas.Models;

namespace Canvas.Services
{
    public class PersonService
    {
        private List<Person> students;
        private static PersonService? instance;
        public static PersonService Current
        {
            get
            {
                if(instance == null)
                    instance = new PersonService();
                return instance;
            }
        }
        
        public IEnumerable<Person> Students
        {
            get
            {
                return students;
            }
        }

        private PersonService()
        {
            students = new List<Person>();
        }

        public void AddStudent(Person student)
        {
            students.Add(student);
        }

        public void ListStudents()
        {
            int count = 0;
            students.ForEach(s => Console.WriteLine($"{++count}. {s}"));
        }
    }
}
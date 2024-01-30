using Canvas.Models;

namespace Canvas.Services
{
    public class PersonService
    {
        private List<Person> students;
        private string? query; 
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
                return students.Where(s => (s.Name ?? " ").ToLower().Contains(query?.ToLower() ?? string.Empty));
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

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }
    }
}
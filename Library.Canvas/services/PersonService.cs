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
        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students.Where(s => (s.Name ?? " ").ToLower().Contains(query?.ToLower() ?? string.Empty));
        }
        
        public Person StudentAt(int index)
        {
            return students[index];
        }
        public void UpdateStudent(string choice, string updated, Person student)
        {
            switch(choice)
            {
                case "n": student.Name = updated;
                    break;
                case "c": student.Classification = updated;
                    break;
            }
        }
    }
}
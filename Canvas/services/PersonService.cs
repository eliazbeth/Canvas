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
    }
}
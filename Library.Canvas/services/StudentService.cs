using Library.Canvas.Models;

namespace Library.Canvas.Services
{
    public class StudentService
    {
        private List<Student> students;
        private string? query; 
        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                if(instance == null)
                    instance = new StudentService();
                return instance;
            }
        }
        
        public IEnumerable<Student> Students
        {
            get
            {
                return students;
            }
        }

        private StudentService()
        {
            students = new List<Student>
            {
                new Student{Name = "TestStudent1"},
                new Student{Name = "TestStudent2"},
                new Student{Name = "TestStudent3"},
                new Student{Name = "TestStudent4"},
                new Student{Name = "TestStudent5"}
            };
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public IEnumerable<Student> Search(string query)
        {
            this.query = query;
            return Students.Where(s => (s.Name ?? " ").ToLower().Contains(query?.ToLower() ?? string.Empty));
        }
        
        public Student StudentAt(int index)
        {
            return students[index];
        }
        public void UpdateStudent(string choice, string updated, Student student)
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
using System.Net.WebSockets;
using Library.Canvas.Models;

namespace Library.Canvas.Services
{
    public class StudentService
    {
        private List<Student> students;
        private int LastId
        {
            get
            {
                return students.Select(c => c.Id).Max();
            }
        }
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
                new Student{Name = "TestStudent1", Id = 1},
                new Student{Name = "TestStudent2", Id = 2},
                new Student{Name = "TestStudent3", Id = 3},
                new Student{Name = "TestStudent4", Id = 4},
                new Student{Name = "TestStudent5", Id = 5}
            };
        }

        public void AddStudent(Student student)
        {
            if(student.Id <= 0)
            {
                student.Id = LastId + 1;
                students.Add(student);
            }
        }
        public void RemoveStudent(Student student)
        {
            students.Remove(student);
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
        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(s =>s .Id == id);
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
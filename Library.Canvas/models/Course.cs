namespace Library.Canvas.Models
{
    public class Course
    {
          public string? Code{get; set;}
          public string? Name{get; set;}
          public string? Description{get; set;}
          public List<Student> Roster{get; set;}
          public List<Assignment> Assignments{get; set;}
          public List<Module> Modules{get; set;}
          public Course()
          {
                Roster = new List<Student>();
                Assignments = new List<Assignment>();
                Modules = new List<Module>();
          }

        public override string ToString()
        {
            return $"({Code}) {Name} - {Description}";
        }
    }
}
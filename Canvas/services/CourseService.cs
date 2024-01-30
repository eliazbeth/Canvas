using Canvas.Models;

namespace Canvas.Services
{
    public class CourseService
    {
        private List<Course> courses;
        private string? query;
        private static CourseService? instance;
        public static CourseService Current
        {
            get
            {
                if(instance == null)
                    instance = new CourseService();
                return instance;
            }
        }
        
        public IEnumerable<Course> Courses
        {
            get
            {
                return courses.Where(
                    c => 
                    (c.Name??" ").ToLower().Contains(query?.ToLower() ?? string.Empty) || 
                    (c.Description??" ").ToLower().Contains(query?.ToLower() ?? string.Empty));
            }
        }
        private CourseService()
        {
            courses = new List<Course>();
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses;
        }

        public void Add(Course course)
        {
            courses.Add(course);
        }
    }
}
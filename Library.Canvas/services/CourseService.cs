using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Library.Canvas.Models;
using Microsoft.VisualBasic;

namespace Library.Canvas.Services
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
                return courses;
            }
        }
        private CourseService()
        {
            courses = new List<Course>
            {
                new Course{Name = "TestCourse1", Code = "1", Roster=new List<Student>{StudentService.Current.GetStudent(1), StudentService.Current.GetStudent(2)}},
                new Course
                {
                    Name = "TestCourse2", Code = "2", 
                    Modules=
                    new List<Module>
                    {
                        new Module
                        {
                            Name = "Test Module 1",
                            Description = "module description 1",
                            Content=new List<ContentItem>
                            {
                                new ContentItem{Name="Test ContentItem 1", Description = "contentItem description 1"}, 
                                new ContentItem{Name="Test ContentItem 2", Description = "contentItem description 2"}
                            }
                        },
                        new Module
                        {
                            Name = "Test Module 2",
                            Description = "module description 2",
                            Content=new List<ContentItem>
                            {
                                new ContentItem{Name="Test ContentItem 1", Description = "contentItem description 1"}, 
                                new ContentItem{Name="Test ContentItem 2", Description = "contentItem description 2"}
                            }
                        }
                    }
                },
                new Course{Name = "TestCourse3", Code = "3",
                Assignments = 
                new List<Assignment>
                {new Assignment{Name="Test Assignment 1", Description = "assignment 1 description", TotalAvailablePoints=100, DueDate=new DateTime(2025,10,31)},
                new Assignment{Name="Test Assignment 2", Description = "assignment 2 description", TotalAvailablePoints=150, DueDate=new DateTime(2025,12,31)}}},
                new Course{Name = "TestCourse4", Code = "4"},
                new Course{Name = "TestCourse5", Code = "5"}
            };
        }
        public Course GetCourse(string code)
        {
            return courses.FirstOrDefault(c =>c.Code.ToLower() == code.ToLower());
        }

        public void AddStudentToCourse(Student student, Course course)
        {
            if(!course.Roster.Contains(student))
                course.Roster.Add(student);
        }

        public IEnumerable<Course> Search(string query)
        {
            this.query = query;
            return Courses.Where(
                    c => 
                    (c.Name??" ").ToLower().Contains(query?.ToLower() ?? string.Empty) || 
                    (c.Description??" ").ToLower().Contains(query?.ToLower() ?? string.Empty));;
        }

        public void AddCourse(Course course)
        {
            if(!courses.Contains(course))
                courses.Add(course);
        }
        public void AddModule(Course course, Module module, ContentItem contentItem)
        {
            if (contentItem != null)
                module.Content.Add(contentItem);
            course.Modules.Add(module);
        }
        public void AddAssignment(Course course, Assignment assignment)
        {
            if (course != null)
                course.Assignments.Add(assignment);
        }


        public Course CourseAt(int index)
        {
            return courses[index];
        }

        public void UpdateCourse(string choice, string updated, Course course)
        {
            switch(choice)
            {
                case "n": course.Name = updated;
                    break;
                case "d": course.Description = updated;
                    break;
                case "c": course.Code = updated;
                    break;
            }
        }

        /*public void AddStudentToCourse(Student student, Course course)
        {
            if(!course.Roster.Contains(student))
                course.Roster.Add(student);
        }*/

        public void RemoveStudentFromCourse(Student student, Course course)
        {
            course.Roster.Remove(student);
        }
    }
}
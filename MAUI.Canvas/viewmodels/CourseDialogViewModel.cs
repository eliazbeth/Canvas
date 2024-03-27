using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class CourseDialogViewModel
{
    private Course course;
    private StudentService studentService;
    public Course Course
    {
        get{return course;}
    }
    public IEnumerable<Student> Students
    {
        get
        {
            return studentService.Students;
        }
    }
    public string Name
    {
        get{return course?.Name ?? string.Empty;}
        set{if (course==null) course = new Course();
        course.Name=value;}
    }
    public string Code
    {
        get{return course?.Code ?? string.Empty;}
        set{if (course==null) course = new Course();
        course.Code = value;}
    }
    public string Description
    {
        get{return course?.Description ?? string.Empty;}
        set{if (course==null) course = new Course();
        course.Description = value;}
    }
    public List<Student> Roster
    {
        get{return course.Roster ?? new List<Student>();}
        set{if (course==null) course = new Course();
        course.Roster = value;}
    }

    public CourseDialogViewModel(string code)
    {
        if(code == string.Empty)
            course = new Course();
        else
        {
            course = CourseService.Current.GetCourse(code) ?? new Course();
        }
        studentService = StudentService.Current;
    }
    public void AddCourse()
    {
        if(course != null)
        {
            CourseService.Current.AddCourse(course);
        }
    }
    public void AddStudent()
    {
        if(course != null)
        {
            CourseService.Current.AddCourse(course);
        }
    }
}

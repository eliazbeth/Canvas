using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class CourseDialogViewModel
{
    private Course course;
    public Course Course
    {
        get{return course;}
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

    public CourseDialogViewModel(string code)
    {
        if(code == string.Empty)
            course = new Course();
        else
        {
            course = CourseService.Current.GetCourse(code) ?? new Course();
        }
    }
    public void AddCourse()
    {
        if(course != null)
        {
            CourseService.Current.AddCourse(course);
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class CourseDialogViewModel :INotifyPropertyChanged
{
    private Course course;
    private StudentService studentService;
    private CourseService courseService;
    public event PropertyChangedEventHandler? PropertyChanged;
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
    
    public Student SelectedStudent
    {
        get; set;
    }
    private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    public ObservableCollection<Student> Roster
    {
        get{return new ObservableCollection<Student>(course.Roster);}
    }
    public ObservableCollection<Module> Modules
    {
        get{return new ObservableCollection<Module>(course.Modules);}
    }
    public CourseDialogViewModel(string code)
    {
        studentService = StudentService.Current;
        courseService = CourseService.Current;
        if(code == string.Empty)
            course = new Course();
        else
        {
            course = courseService.GetCourse(code) ?? new Course();
        }
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
        courseService.AddStudentToCourse(SelectedStudent, course);
        Refresh();
    }
    public void Refresh()
    {
        NotifyPropertyChanged(nameof(course.Roster));
    }
}

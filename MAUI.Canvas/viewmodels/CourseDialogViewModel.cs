using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class CourseDialogViewModel :INotifyPropertyChanged
{
    private Course course;
    private Assignment assignment;
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
    public string AssignmentName
    {
        get{return assignment?.Name ?? string.Empty;}
        set{if (assignment==null) assignment = new Assignment();
        assignment.Name=value;}
    }
    public string AssignmentDescription
    {
        get{return assignment?.Description ?? string.Empty;}
        set{if (assignment==null) assignment = new Assignment();
        assignment.Description = value;}
    }
    public double AssignmentPoints
    {
        get{return assignment.TotalAvailablePoints;}
        set{if (assignment==null) assignment = new Assignment();
        assignment.TotalAvailablePoints = value;}
    }
    public ObservableCollection<Student> Roster
    {
        get{return new ObservableCollection<Student>(course.Roster);}
    }
    public ObservableCollection<Module> Modules
    {
        get{return new ObservableCollection<Module>(course.Modules);}
    }
    public ObservableCollection<Assignment> Assignments
    {
        get{return new ObservableCollection<Assignment>(course.Assignments);}
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

        if (assignment == null)
            assignment = new Assignment();
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
    public void AddAssignment()
    {
        courseService.AddAssignment(course, assignment);
        assignment = null;
        Refresh();
    }
    public void Refresh()
    {
        NotifyPropertyChanged(nameof(course.Roster));
        NotifyPropertyChanged(nameof(course.Assignments));
    }
}

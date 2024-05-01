using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class StudentsViewViewModel : INotifyPropertyChanged
{
    private CourseService courseService;
    private StudentService studentService;
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public string Query{get; set;}
 
    public ObservableCollection<Student> Students
    {
        get
        {
            return new ObservableCollection<Student>(studentService.Students.ToList().Where(s => (s.Name ?? " ").ToLower().Contains(Query?.ToLower() ?? string.Empty)));
        }
    }
    public Student SelectedStudent
    {
        get; set;
    }
    public Dictionary<int,double> Grades
    {
        get{return SelectedStudent?.Grades ?? new Dictionary<int, double>();}
    }

    public ObservableCollection<Course> Courses
    {
        get
        {
            return new ObservableCollection<Course>(courseService.Courses.ToList().Where(c => c.Roster.Contains(SelectedStudent)));
        }
    }

    public Course SelectedCourse
    {
        get; set;
    }
    public List<Assignment> Assignments
    {
        get{return SelectedCourse?.Assignments ?? new List<Assignment>();}
    }
    public Assignment SelectedAssignment
    {
        get; set;
    }
    public List<Module> Modules
    {
        get{return SelectedCourse?.Modules ?? new List<Module>();}
    }
    public ObservableCollection<Submission> Submissions
    {
        get{return new ObservableCollection<Submission>(SelectedCourse?.Submissions?.ToList().Where(s=>s.Student==SelectedStudent) ?? new List<Submission>());}
    }
    public string SubmissionContent
    {
        get; set;
    }

    public StudentsViewViewModel()
    {
        studentService = StudentService.Current;
        courseService = CourseService.Current;
        Query = string.Empty;
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void Submit()
    {
        courseService.AddSubmission(SelectedCourse, SelectedAssignment, SelectedStudent, SubmissionContent);
        NotifyPropertyChanged(nameof(Submissions));
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Courses));
        NotifyPropertyChanged(nameof(Assignments));
        NotifyPropertyChanged(nameof(Modules));
        NotifyPropertyChanged(nameof(Submissions));
    }
    public void RefreshStudents()
    {
        NotifyPropertyChanged(nameof(Students));
    }
    

}

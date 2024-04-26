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
    public ObservableCollection<Course> Courses
    {
        get
        {
            return new ObservableCollection<Course>(courseService.Courses.ToList().Where(c => c.Roster.Contains(SelectedStudent)));
        }
    }

    public Student SelectedStudent
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

    public void AddStudent()
    {
        studentService.AddStudent(new Student{Name = "New student"});
        NotifyPropertyChanged(nameof(Students));
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Students));
        NotifyPropertyChanged(nameof(Courses));
    }
    public void Remove()
    {
        studentService.RemoveStudent(SelectedStudent);
        Refresh();
    }
}

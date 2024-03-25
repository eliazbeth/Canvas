using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class InstructorsViewViewModel : INotifyPropertyChanged
{
    private StudentService studentService;
    private CourseService courseService;
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
    public ObservableCollection<Course> Courses
    {
        get
        {
            return new ObservableCollection<Course>(courseService.Courses.ToList());
        }
    }
    public Course SelectedCourse
    {
        get; set;
    }
    public InstructorsViewViewModel()
    {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
            Query = string.Empty;
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /*public void AddStudent()
    {
        studentService.AddStudent(new Student{Name = "New student"});
        Refresh();
    }*/

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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class StudentsViewViewModel : INotifyPropertyChanged
{
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
    public StudentsViewViewModel()
    {
        studentService = StudentService.Current;
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
    }
    public void Remove()
    {
        studentService.RemoveStudent(SelectedStudent);
        Refresh();
    }
}

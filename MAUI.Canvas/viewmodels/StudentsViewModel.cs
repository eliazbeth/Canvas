using System.Collections.ObjectModel;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class StudentsViewModel
{
    private StudentService studentService;

    public ObservableCollection<Student> Students
    {
        get
        {
            return new ObservableCollection<Student>(studentService.Students);
        }
    }

    public StudentsViewModel()
    {
        studentService = StudentService.Current;
    }
}

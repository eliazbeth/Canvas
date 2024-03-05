using System.Collections.ObjectModel;
using Canvas.Models;
using Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class StudentsViewModel
{
    private PersonService studentService;

    public ObservableCollection<Person> Students
    {
        get
        {
            return new ObservableCollection<Person>(studentService.Students);
        }
    }

    public StudentsViewModel()
    {
        studentService = PersonService.Current;
    }
}

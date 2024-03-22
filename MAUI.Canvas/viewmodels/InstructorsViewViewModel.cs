using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class InstructorsViewViewModel
{
    private StudentService studentService;
    public IEnumerable<Student> Students
    {
        get
        {
            return studentService.Students;
        }
    }
    public InstructorsViewViewModel()
    {
            studentService = StudentService.Current;
    }
}

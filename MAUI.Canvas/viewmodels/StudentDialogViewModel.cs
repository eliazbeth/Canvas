using Library.Canvas.Services;
using Library.Canvas.Models;

namespace MAUI.Canvas.viewmodels;

public class StudentDialogViewModel
{
    private Student student;
    public Student Student
    {
        get{return student;}
    }
    public string Name
    {
        get{return student?.Name ?? string.Empty;}
        set{if (student==null) student = new Student();
        student.Name=value;}
    }
    public string Classification
    {
        get{return student?.Classification ?? string.Empty;}
        set{if (student==null) student = new Student();
        student.Classification = value;}
    }

    public StudentDialogViewModel(int sId)
    {
        if(sId == 0)
            student = new Student();
        else
        {
            student = StudentService.Current.GetStudent(sId) ?? new Student();
        }
    }

    public void AddStudent()
    {
        if(student != null)
        {
            StudentService.Current.AddStudent(student);
        }
    }
}


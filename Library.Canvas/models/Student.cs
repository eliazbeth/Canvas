namespace Library.Canvas.Models;

public class Student : Person
{
    public string? Classification{get; set;}
    public string? Grades{get; set;}

    public override string ToString()
    {
       return $"{Name} - {Classification}";
    }
}

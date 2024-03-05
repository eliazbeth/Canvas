namespace Library.Canvas.Models
{
    public class Person
    {   
        public string? Name{get; set;}
        
        public Person()
        {

        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
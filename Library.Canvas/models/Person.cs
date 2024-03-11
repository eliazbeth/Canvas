namespace Library.Canvas.Models
{
    public class Person
    {      
        public int Id{get; set;}
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
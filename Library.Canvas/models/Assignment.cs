namespace Library.Canvas.Models
{
    public class Assignment
    {
        public int Id{get; set;}
        private static int lastId = 0;
        public string? Name{get; set;}
        public string? Description{get; set;}
        public double TotalAvailablePoints{get; set;}
        public DateTime DueDate{get; set;}
        public Assignment()
        {
            Id = lastId++;
        }
        public override string ToString()
        {
            return $"{Name}: {Description}  [{TotalAvailablePoints} points. Due: {DueDate}]";
        }
    }
}
namespace Canvas.Models
{
    public class Assignment
    {
        public string? Name{get; set;}
        public string? Description{get; set;}
        public double TotalAvailablePoints{get; set;}
        public DateTime DueDate{get; set;}
        public Assignment()
        {

        }
    }
}
namespace Library.Canvas.Models
{
    public class Submission
    {
        public int Id{get; set;}
        private static int lastId = 0;
        public Student Student{get; set;}
        public Assignment Assignment{get; set;}
        public string Content{get; set;}
        public double Grade{get; set;}
        public Submission()
        {
            Id = lastId++;
        }
        public override string ToString()
        {
            return $"{Student.Name}'s Submission for '{Assignment.Name}':{"\n"} {Content}{"\n"} Grade: {Grade}/{Assignment.TotalAvailablePoints}";
        }
    }
}

namespace Library.Canvas.Models
{
    public class ContentItem
    {
        public string? Name{get; set;}
        public string? Description{get; set;}
        public string? Path{get; set;}
        public ContentItem()
        {

        }
        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
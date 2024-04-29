using System.Text;

namespace Library.Canvas.Models
{
    public class Module
    {
        public string? Name{get; set;}
        public string? Description{get; set;}
        public List<ContentItem>? Content{get; set;}
        public Module()
        {

        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach(var item in Content)
            {
                stringBuilder.Append("\t");
                stringBuilder.Append(item.ToString());
                stringBuilder.Append("\n");
            }
            return String.Join(" ", Name, ":", Description, "\n", stringBuilder.ToString());
        }
    }
}
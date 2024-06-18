using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box() 
        {
            Elements = new();
        }
        public List<T> Elements { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var element in Elements)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString();
        }
    }
}

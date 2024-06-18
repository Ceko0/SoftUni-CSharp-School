using System.Text;

namespace _02.GenericBoxOfInteger
{
    internal class Box<T>
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

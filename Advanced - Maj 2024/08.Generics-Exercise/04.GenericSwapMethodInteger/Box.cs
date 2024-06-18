using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box()
        {
            Elements = new();
        }
        public List<T> Elements { get; set; }
        public void Swap(int firstIndex, int secondIndex)
            => (Elements[firstIndex], Elements[secondIndex])
                = (Elements[secondIndex], Elements[firstIndex]);

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

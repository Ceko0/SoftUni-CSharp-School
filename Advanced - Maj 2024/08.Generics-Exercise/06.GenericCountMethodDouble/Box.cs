using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T>
        where T : IComparable<T>
    {
        public Box()
        {
            Elements = new();
        }
        public List<T> Elements { get; set; }
        public void Swap(int firstIndex, int secondIndex)
            => (Elements[firstIndex], Elements[secondIndex])
                = (Elements[secondIndex], Elements[firstIndex]);
        public int CountOFLargetThenValue(T value)
        {
            int couner = 0;
            foreach (T element in Elements)
            {
                if(element.CompareTo(value) > 0)
                {
                    couner++;
                } 
            }
            return couner;
        }
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

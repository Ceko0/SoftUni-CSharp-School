using System.Collections;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> Elements;
        private int index = 0;

        public ListyIterator(params T[] elements)
            => Elements = elements.ToList();
        public bool Move()
        {
            if (index < Elements.Count - 1)
            {
                index++;
                return true;

            }
            return false;
        }

        public bool HasNext()
            => this.index < this.Elements.Count - 1;
        public void Print()
        {
            if (Elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(Elements[index]);
        }
        public string PrintAll()
        {
            StringBuilder sb = new();
            foreach (T element in Elements)
            {
                sb.Append($"{element.ToString()} ");
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Elements[index];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}

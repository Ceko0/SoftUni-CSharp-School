using System.Collections;

namespace CustomStack
{
    public class CustomStack<T> :IEnumerable<T>
    {
        public List<T> Elements = new();
        
        public void Push(T element)
        {
            this.Elements.Add(element);
        }
        public void Pop()
        {
            if (this.Elements.Count == 0)
            {
                throw new IndexOutOfRangeException("No elements");
            }
            Elements.RemoveAt(Elements.Count - 1);
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Elements.Count -1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}

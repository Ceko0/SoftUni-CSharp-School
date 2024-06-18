namespace BocOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new();
        }

        public int Count { get => this.elements.Count;}
        public void Add(T element)
        {
            elements.Add(element);
        }
        public T Remove()
        {
            T current = this.elements[elements.Count - 1];
            this.elements.Remove(current);
            return current;
        }
    }
}

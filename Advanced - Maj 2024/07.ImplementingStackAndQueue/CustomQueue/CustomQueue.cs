using System.Diagnostics.Metrics;

namespace CustomQueue
{
    internal class CustomQueue<T>
    {
        private T[] elements;
        private int counter;
        public int Count => counter;
        public CustomQueue(params T[] elements)
        {
            this.elements = new T[elements.Length];
            this.elements = elements;
            counter = elements.Length;
        }
        public void Enqueue(T element)
        {
            Resize();
            elements[counter++] = element;
        }
        public T Dequeue()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException("Custom Queue is empty");
            }
            T firstElement = this.elements[0];
            Shift();
            counter--;
            return firstElement;
        }
        public T Peek()
        {
            T firstElement = this.elements[0];
            return firstElement;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < counter; i++) 
            {
                action(elements[i]);
            }
        }
        private void Shift()
        {            
            for (int i = 0; i < counter - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }
        private void Resize()
        {
            if (elements.Length <= counter)
            {
                T[] newArray = new T[elements.Length * 2];
                ResizeArray(newArray);
            }
        }
        private void ResizeArray(T[] newArray)
        {
            Array.Copy(elements, newArray, counter);
            elements = newArray;
        }
    }
}

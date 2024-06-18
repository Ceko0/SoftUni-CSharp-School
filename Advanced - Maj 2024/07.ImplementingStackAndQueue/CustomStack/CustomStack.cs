
using System.Diagnostics.Metrics;

namespace CustomStack
{
    internal class CustomStack<T>
    {
        public T[] elements { get; set; }
        private int counter;
        public int Count => this.counter;
        public CustomStack(params T[] elements)
        {
            this.elements = new T[elements.Length];
            this.elements = elements;
            counter = elements.Length;
        }

        public void push(T value)
        {
            Resize();
            elements[counter++] = value;
        }
        public T pop()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException(" CustomStack is empty");
            }
            T elementToPop = elements[--counter];
            return elementToPop;
        }
        public T Peek()
        {
            if (counter == 0)
            {
                throw new InvalidOperationException(" CustomStack is empty");
            }
            T lastElement = elements[counter -1];            
            return lastElement;
        }        
        public void ForEach(Action<T> action)
        {

            for (int i = 0; i < counter; i++)
            {
                action(elements[i]);
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

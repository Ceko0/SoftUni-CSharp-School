using System.Collections;
namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] elements;
        public int Counter { get; private set; }
        public CustomList(params T[] elements)
        {
            this.elements = new T[elements.Length];
            elements.CopyTo(this.elements, 0);
            Counter = elements.Length;
        }
        public void Add(T element)
        {
            Resize();
            elements[Counter++] = element;
        }
        public T RemoveAt(int index)
        {
            RangeCheck(index);
            T elementToRemove = elements[index];
            Shift(index);
            elements[Counter] = default(T);
            Counter--;
            if (Counter <= (this.elements.Length / 2))
            {
                Shrink();
            }
            return elementToRemove;
        }
        private void Shrink()
        {
            T[] newArray = new T[elements.Length / 2];
            ResizeArray(newArray);
        }
        private void Shift(int index)
        {
            RangeCheck(index);
            for (int i = index; i < Counter - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }
        private void ShiftToRight (int index)
        {
            for (int i = Counter; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }
            
        }
        public void Insert (int index, T element)
        {
            
            Resize();
            ShiftToRight(index);
            elements[index] = element;
            Counter++;
        }
        public bool Contains(T element)
        {
            for (int i = 0; i < Counter; i++)
            {
                if (elements[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            RangeCheck(firstIndex);
            RangeCheck(secondIndex);
            T firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Counter; i++)
            {
                action(elements[i]);
            }
        }
        private void Resize()
        {
            if (elements.Length <= Counter)
            {
                T[] newArray = new T[elements.Length * 2];
                ResizeArray(newArray);
            }
        }
        private void ResizeArray(T[] newArray)
        {
            Array.Copy(elements, newArray, Counter);
            elements = newArray;
        }
        private void RangeCheck(int index)
        {
            
            if (index < 0 || index >= Counter)
            {
                throw new IndexOutOfRangeException ($"index {index} is out of range");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Counter; i++)
            {
                yield return elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

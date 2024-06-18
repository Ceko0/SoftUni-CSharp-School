namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }
        //public DoublyLinkedList(params T[] input)
        //{
        //    if (input != null)
        //    {
        //        for (int i = 0; i < input.Length; i++)
        //        {
        //            AddLast(input[i]);
        //        }

        //    }
        //}
        public void AddFirst(T value)
        {
            ListNode<T> newHead = new(value);
            if (head == default)
            {
                head = newHead;
                tail = newHead;

                Count++;
                return;
            }
            head.Previous = newHead;
            newHead.Next = head;
            head = newHead;
            Count++;
        }
        public void AddLast(T value)
        {
            ListNode<T> newTail = new(value);
            if (tail == null)
            {
                head = newTail;
                tail = newTail;

                Count++;
                return;
            }
            tail.Next = newTail;
            newTail.Previous = tail;
            tail = newTail;
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T elementToRemove = head.Value; 
            head = head.Next;
            if (head != default) head.Previous = null;
            else tail = null;
            Count--;
            return elementToRemove;
        }
        public T RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException("The list is empty");

            T elementToRemove = tail.Value;
            tail = tail.Previous;
            if (tail != default) tail.Next = null;
            else head = null;
            Count--;
            return elementToRemove;

        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> node = head;
            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }
    }
}

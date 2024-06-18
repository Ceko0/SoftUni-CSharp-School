namespace CustomDoublyLinkedList;

public class ListNode<T>
{
    public ListNode(T value ) 
    {
        Value = value; 
    }
    
    public ListNode<T> Previous { get; set; }
    public ListNode<T> Next { get; set; }
    public T Value { get; set; }

    public override string ToString()
    {       
        return $"{Previous.Value} <- {Value} -> {Next.Value}";
    }
}

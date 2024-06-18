namespace CustomDoublyLinkedList;

public class StartUp
{
    public static void Main()
    {
        DoublyLinkedList<int> list = new();
        Console.WriteLine("Enter int numbers , then end for stop");
        string input = String.Empty;
        while ((input = Console.ReadLine()) != "end") list.AddLast(int.Parse(input));
        
        Console.WriteLine("removing last element");
        Console.WriteLine( list.RemoveLast());
        Console.WriteLine("removing first element");
        Console.WriteLine(list.RemoveFirst());

        
        Console.WriteLine("Print all left elements in List");
        
        list.ForEach(x => Console.WriteLine(x));
        
        Console.WriteLine("Print all left elements in Array");
        int[] intAray = list.ToArray();
        foreach (var item in intAray)
        {
            Console.WriteLine(item);
        }
    }

}

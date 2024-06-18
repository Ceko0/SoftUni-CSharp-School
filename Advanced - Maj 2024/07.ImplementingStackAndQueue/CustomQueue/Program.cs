namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<string> queue = new("asd" , "sdsa", "bsfd");
            queue.Enqueue("hello");
            Console.WriteLine("print elements");
            queue.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine("Dequeue 1-st element");
            Console.WriteLine (queue.Dequeue());
            Console.WriteLine("print elements");
            queue.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine("Queue -> Dequeue");
            queue.Enqueue(queue.Dequeue());
            Console.WriteLine("print elements");
            queue.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine($"print count {queue.Count}");
            Console.WriteLine($"print peek {queue.Peek()}");

        }
    }
}

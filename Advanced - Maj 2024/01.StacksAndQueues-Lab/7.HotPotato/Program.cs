namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int counter = int.Parse(Console.ReadLine());
            int currentCount = 0;
            while (names.Count > 1)
            {
                currentCount++;
                if (counter == currentCount)
                {
                    Console.WriteLine($"Removed {names.Dequeue()}");
                    currentCount = 0;
                }
                else
                {
                    names.Enqueue(names.Dequeue());                    
                }
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}

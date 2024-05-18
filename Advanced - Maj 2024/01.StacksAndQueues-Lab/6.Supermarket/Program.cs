namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (people.Any())
                    {
                        Console.WriteLine(people.Dequeue());
                    }                  
                }
                else
                {
                    people.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}

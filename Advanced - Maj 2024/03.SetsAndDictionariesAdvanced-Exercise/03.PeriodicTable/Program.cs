namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            HashSet<string> elements = new();

            for (int i = 0; i < counter; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in input)
                {
                    elements.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}

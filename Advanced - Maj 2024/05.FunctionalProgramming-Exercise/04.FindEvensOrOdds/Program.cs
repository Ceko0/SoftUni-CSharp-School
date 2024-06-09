namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" " ,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();
            int startNumber = range[0];
            int endNumber = range[1];
            List<int> numbers = Enumerable.Range(startNumber, endNumber - startNumber + 1).ToList();

            Predicate<int> isEven = x => x % 2 == 0;            

            Console.WriteLine(string.Join(" ", numbers.FindAll( type == "even" ? x => isEven(x) : x => !isEven(x))));
        }
    }
}

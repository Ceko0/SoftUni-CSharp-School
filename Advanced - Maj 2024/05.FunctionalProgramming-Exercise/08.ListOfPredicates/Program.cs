namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbersToCheck = Enumerable.Range(1, endOfRange).ToArray();

            Func<int , int[] , bool> filter = (number , dividers) => dividers.All(x => number % x == 0);

            Console.WriteLine(string.Join(" ", numbersToCheck.Where(x => filter(x , dividers))));
        }
    }
}

namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> filter = str => int.Parse(str);
            Func<int , bool> evenCheck = x => x % 2 == 0;
            Func<int , int> order = x => x;

            List<int> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(filter)
                .Where(evenCheck)
                .OrderBy(order)
                .ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}

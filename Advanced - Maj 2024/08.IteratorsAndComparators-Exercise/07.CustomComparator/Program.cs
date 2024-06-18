namespace _07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, new Comparison<int>((a, b) =>
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    return a.CompareTo(b);
                }
                
                if (a % 2 != 0 && b % 2 != 0)
                {
                    return a.CompareTo(b);
                }
                
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                return 0;
            }));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

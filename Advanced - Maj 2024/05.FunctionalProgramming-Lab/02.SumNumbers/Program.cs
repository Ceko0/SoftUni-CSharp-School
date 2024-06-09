namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> filter = str => int.Parse(str);                      

            List<int> input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(filter)                
                .ToList();

            Console.WriteLine(input.Count);
            Console.WriteLine(input.Sum());
        }
    }
}

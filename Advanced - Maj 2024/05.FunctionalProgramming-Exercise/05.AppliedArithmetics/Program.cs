using System.Linq;
using System.Threading.Channels;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<List<int>, string, List<int>> action =
                (numbers, operation) =>
                {
                    return operation == "add"
                    ? numbers.Select(x => x + 1).ToList()
                    : operation == "multiply"
                    ? numbers.Select(x => x * 2).ToList()
                    : numbers.Select(x => x - 1).ToList();
                };

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    numbers = action(numbers, input);
                }

            }
        }
    }
}

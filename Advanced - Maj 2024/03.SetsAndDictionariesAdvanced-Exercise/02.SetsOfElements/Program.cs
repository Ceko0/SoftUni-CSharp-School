
namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstLine = new();
            HashSet<int> secondLine = new();
            for (int i = 0; i < length[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                firstLine.Add(input);
            }
            for (int i = 0;i < length[1]; i++)
            {
                int input = int.Parse(Console.ReadLine());
               
                    secondLine.Add(input);
               
            }
            HashSet<int> output = new();
            foreach (int input in firstLine)
            {
                if (secondLine.Contains(input))
                {
                    output.Add(input);
                }
            }
            Console.WriteLine(string.Join(" ",output));
        }
    }
}

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();
            List<int> newLine = new List<int>();
            ;
            for (int i = 0; i < list.Count; i++)
            {
                List<int> current = new List<int>();
                current = list[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                for (int j = 0; j < current.Count; j++)
                {
                    newLine.Add(current[j]);
                }

            }
            Console.WriteLine(string.Join(" ", newLine));
        }
    }
}
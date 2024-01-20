namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int letterSum = 0;
            for (int i = 0; i < counter; i++)
            {
                char income = char.Parse(Console.ReadLine());
                letterSum += income;
            }
            Console.WriteLine($"The sum equals: {letterSum}");
        }
    }
}

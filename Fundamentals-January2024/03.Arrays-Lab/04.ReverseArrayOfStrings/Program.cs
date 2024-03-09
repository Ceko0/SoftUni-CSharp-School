namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] incomes = Console.ReadLine()
                .Split()
                .ToArray();
            Array.Reverse(incomes);
            Console.WriteLine(string.Join(" ", incomes));
        }
    }
}

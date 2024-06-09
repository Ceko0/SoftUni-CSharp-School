namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperCheck = x => char.IsUpper(x[0]);

            string[] text = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCheck)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine , text));
        }
    }
}

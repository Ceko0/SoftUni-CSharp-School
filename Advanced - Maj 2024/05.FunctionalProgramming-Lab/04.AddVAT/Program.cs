namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string , double> parseAndAddingVAT = s => double.Parse(s) *1.20;

            double[] priceses = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(parseAndAddingVAT)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine , priceses.Select(x => x.ToString("f2"))));
        }
    }
}

namespace _02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal incomePounds = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"{incomePounds * 1.31m :f3}");
        }
    }
}

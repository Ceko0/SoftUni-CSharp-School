namespace _03.ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            decimal totalsum = 0;
            for (int i = 1; i <= counter; i++)
            {
                decimal incomeNumber = decimal.Parse(Console.ReadLine());
                totalsum += incomeNumber;
            }
            Console.WriteLine(totalsum);
        }
    }
}

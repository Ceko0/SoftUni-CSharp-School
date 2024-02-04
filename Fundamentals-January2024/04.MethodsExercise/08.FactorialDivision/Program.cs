namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong factorialNumberOne = ulong.Parse(Console.ReadLine());
            ulong factorialNumberTwo = ulong.Parse(Console.ReadLine());

            SumDivide(FactorialCalculator(factorialNumberOne) , FactorialCalculator(factorialNumberTwo));

        }

        private static void SumDivide(ulong factorialSumOne, ulong factorialSumTwo)
        {
            Console.WriteLine($"{(decimal)factorialSumOne / factorialSumTwo :f2}");
        }

        private static ulong FactorialCalculator(ulong factorialNumber)
        {
            
            ulong factorialSum = factorialNumber;
            if (factorialNumber == 0) 
            {
                factorialSum = 1;
            }
            else
            {
                for (ulong i = 1; i < factorialNumber - 1; i++)
                {
                    factorialSum *= factorialNumber - i;
                }
            }

            return factorialSum;
        }
    }
}

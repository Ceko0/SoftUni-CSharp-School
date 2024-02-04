namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int incomeAbsNumber = Math.Abs(int.Parse(Console.ReadLine()));
            string incomeNumber = incomeAbsNumber.ToString();
            Console.WriteLine(GetMultipleOfEvenAndOdds(incomeNumber));
        }

        static int GetMultipleOfEvenAndOdds(string incomeNumber) 
        {
            
            return (GetSumOfEvenDigits(incomeNumber) * GetSumOfOddDigits(incomeNumber));        
        }
        static int GetSumOfEvenDigits(string incomeNumber)
        {
            int sum = 0;
            for (int i = 0; i < incomeNumber.Length; i++)
            {
                if (incomeNumber[i] % 2 == 1)
                {
                    sum += incomeNumber[i] - '0';
                }
            }
            return sum;
        }

        static int GetSumOfOddDigits(string incomeNumber)
        {
            int sum = 0;
            for (int i = 0; i < incomeNumber.Length; i++)
            {
                if (incomeNumber[i] % 2 == 0)
                {
                    sum += incomeNumber[i] - '0';
                }
            }
            return sum;
        }
    }
}

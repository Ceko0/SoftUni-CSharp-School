namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string incomeNumber;
            
                while ((incomeNumber = Console.ReadLine()) != "END")
            {
                Console.WriteLine(PalindromeCheck(incomeNumber));
            }
        }

        private static bool PalindromeCheck(string incomeNumber)
        {
            if (incomeNumber.Length %2 == 0)
            {
                string firstPart = "";
                string secondPart = "";

                for (int i = 0; i < incomeNumber.Length / 2; i++)
                {
                    firstPart += incomeNumber[i];
                }

                for (int i = incomeNumber.Length - 1; i >= incomeNumber.Length / 2; i--)
                {
                    secondPart += incomeNumber[i];
                }

                if (int.Parse(firstPart) == int.Parse(secondPart)) return true;
                return false;
            }
            else
            {
                string firstPart = "";
                string secondPart = "";

                for (int i = 0; i < incomeNumber.Length / 2; i++)
                {
                    firstPart += incomeNumber[i];
                }

                for (int i = incomeNumber.Length - 1; i > incomeNumber.Length / 2; i--)
                {
                    secondPart += incomeNumber[i];
                }

                if (int.Parse(firstPart) == int.Parse(secondPart)) return true;
                return false;
            }
            
        }
    }
}

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int incomeNumber = int.Parse(Console.ReadLine());
            int total = 0;
            int sumOfDigits = 0;
            bool isSpecialNum = false;
            for (int i = 1; i <= incomeNumber; i++)
            {
                sumOfDigits = i;
                while (i > 0)
                {
                    total += i % 10;
                    i = i / 10;
                }
                isSpecialNum = (total == 5 || total == 7 || total == 11);
                Console.WriteLine($"{sumOfDigits} -> {isSpecialNum}");
                total = 0;
                i = sumOfDigits;
            }

        }
    }
}

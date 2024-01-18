namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigit = 0;
                string numberDigit = i.ToString();
                for (int j = 0; j < numberDigit.Length; j++)
                {
                    sumOfDigit += numberDigit[j] - '0';
                }
                if (sumOfDigit == 5 || sumOfDigit == 7 || sumOfDigit == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}

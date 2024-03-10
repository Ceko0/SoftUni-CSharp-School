using System.Numerics;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            int[] numberDigits = new int[firstNumber.Length];
            for (int i = 0; i < firstNumber.Length; i++)
            {
                numberDigits[i] = firstNumber[i] - '0';
            }
            int carry = 0;
            for (int i = numberDigits.Length - 1; i >= 0; i--)
            {
                int product = numberDigits[i] * secondNumber + carry;
                numberDigits[i] = product % 10;
                carry = product / 10;
            }

            if (carry > 0)
            {
                Console.Write(carry);
            }
            foreach (int digit in numberDigits)
            {
                Console.Write(digit);
            }
        }
    }
}

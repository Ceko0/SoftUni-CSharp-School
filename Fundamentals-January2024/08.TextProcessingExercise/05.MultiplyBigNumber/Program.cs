using System.Numerics;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static string Multiply(string num, int digit)
        {
            if (digit == 0) return "0"; 

            int carry = 0;
            string result = "";

            for (int i = num.Length - 1; i >= 0; i--)
            {
                int product = (num[i] - '0') * digit + carry;
                result = (product % 10) + result;
                carry = product / 10;
            }

            if (carry > 0) result = carry + result;

            return result;
        }

        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());

            string result = Multiply(num, digit);
            Console.WriteLine(result);
        }
    }
}
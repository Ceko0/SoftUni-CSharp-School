namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            bool num1Positive = PositiveOrNegativeCheck(num1);
            bool num2Positive = PositiveOrNegativeCheck(num2);
            bool num3Positive = PositiveOrNegativeCheck(num3);

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if ((!num1Positive && num2Positive && num3Positive) || (num1Positive && !num2Positive && num3Positive) || (num1Positive && num2Positive && !num3Positive) || (!num1Positive && !num2Positive && !num3Positive))
            {
                Console.WriteLine("negative");
            }
            else if ((num1Positive && num2Positive && num3Positive) ||
                     (!num1Positive && num2Positive && !num3Positive) || (num1Positive && !num2Positive && !num3Positive) || (!num1Positive && !num2Positive && num3Positive))
            {
                Console.WriteLine("positive");
            }
        }

        private static bool PositiveOrNegativeCheck(int num)
        {
            if (num > 0) return true;

            return false;
        }
    }
}

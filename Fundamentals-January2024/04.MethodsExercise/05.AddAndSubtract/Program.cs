namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int tiredNumber = int.Parse(Console.ReadLine());

            int sum = SumTwoNumbers(firstNumber, secondNumber);
            int subtracts = subtractTwoNumbers(sum, tiredNumber);
            Console.WriteLine(subtracts);
        }

        private static int subtractTwoNumbers(int sum, int tiredNumber)
        {
            return sum - tiredNumber;
        }

        private static int SumTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber+ secondNumber;
        }
    }
}

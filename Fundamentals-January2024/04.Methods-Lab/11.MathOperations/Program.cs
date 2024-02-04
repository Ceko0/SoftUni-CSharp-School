namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char incomeOperator = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculations(firstNumber, incomeOperator, secondNumber));
        }

        private static double Calculations(double firstNumber, char incomeOperator, double secondNumber)
        {
            double result = 0;
            switch (incomeOperator)
            {
                case '/':
                    result = firstNumber / secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
            }

            return result;
        }
    }
}

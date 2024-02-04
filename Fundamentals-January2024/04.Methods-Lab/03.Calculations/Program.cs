namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    CalculationAdd(firstNumber, secondNumber);
                    break;
                case "multiply":
                    CalculationMultiply(firstNumber, secondNumber);
                    break;
                case "subtract":
                    CalculationSubtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    CalculationDivide(firstNumber, secondNumber);
                    break;

            }
        }

        static void CalculationDivide(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }

        static void CalculationSubtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void CalculationMultiply(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void CalculationAdd(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}

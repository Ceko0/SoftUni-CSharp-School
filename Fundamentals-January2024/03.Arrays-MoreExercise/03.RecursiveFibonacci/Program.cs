namespace _03.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberLength = int.Parse(Console.ReadLine());

            long morePreviousNumber = 1;
            long previousNumber = 1;

            for (int i = 2; i < numberLength; i++)
            {
                long currentNumber = previousNumber + morePreviousNumber;
                morePreviousNumber = previousNumber;
                previousNumber = currentNumber;
            }
            Console.WriteLine(previousNumber);
        }
    }
}

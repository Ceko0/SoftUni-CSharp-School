using System.Text.RegularExpressions;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intCollection = new();
            int startNumber = 1;
            const int endNumber = 100;

            while (intCollection.Count != 10)
            {
                try
                {
                    int number = ReadNumber(startNumber, endNumber);
                    intCollection.Add(number);
                    startNumber = number;
                }
                catch (Exception e )
                {

                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine(string.Join(", ", intCollection).TrimEnd());
        }
        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int currentNumber))
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (currentNumber <= start || currentNumber >= end) throw new ArgumentException($"Your number is not in range {start} - {end}!");

            return currentNumber;
        }
    }
}

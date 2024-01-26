namespace _08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                    
            while (numbers.Length > 1)
            {
                int[] sumOfNumbers = new int[numbers.Length - 1];
                for (int j = 0; j < sumOfNumbers.Length ; j++)
                {
                    sumOfNumbers[j] = numbers[j] + numbers[j + 1];
                }
                numbers = sumOfNumbers;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

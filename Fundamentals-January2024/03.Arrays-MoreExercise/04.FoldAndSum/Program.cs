namespace _04.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" " ,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startingNumber = (inputNumbers.Length / 2) / 2;

            int[] firstNumber = new int[inputNumbers.Length /2];
            int[] secondNumber = new int[inputNumbers.Length / 2];

            int[] totalsum = new int[inputNumbers.Length / 2];

            int firstPositionCounter = 0;
            int secondPositionCounter = 0;
            for (int i = startingNumber - 1; i >= 0; i--)
            {
                firstNumber[firstPositionCounter] += inputNumbers[i];
                firstPositionCounter++;
            }

            for (int i = startingNumber; i < inputNumbers.Length - startingNumber; i++)
            {
                secondNumber[secondPositionCounter] += inputNumbers[i];
                secondPositionCounter++;
            }
            for (int i = inputNumbers.Length - 1 ; i >= inputNumbers.Length - startingNumber; i--)
            {
                firstNumber[firstPositionCounter] += inputNumbers[i];
                firstPositionCounter++;
            }

            for (int i = 0; i < totalsum.Length; i++)
            {
                totalsum[i] += firstNumber[i] + secondNumber[i];
            }

            Console.WriteLine(string.Join (" " , totalsum));
        }
    }
}

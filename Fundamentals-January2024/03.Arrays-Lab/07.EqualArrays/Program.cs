namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondNumber = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int arraySum = 0;
            if (firstNumber.Length != secondNumber.Length)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at 0 index");
                return;
            }

            for (int i = 0; i < firstNumber.Length; i++)
            {
                arraySum += secondNumber[i];
                if (firstNumber[i] != secondNumber[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {arraySum}");
        }
    }
}

namespace _04.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                Console.WriteLine("1");
                return;
            }
            else if (number == 0)
            {
                Console.WriteLine();
                return;
            }

            int[] tribonacciNumbers = new int[number];

            int first = 0;
            int second = 1;
            int thired = 1;
            tribonacciNumbers[0] = 1;
            tribonacciNumbers[1] = 1;

            for (int i = 2; i < number; i++)
            {
                tribonacciNumbers[i] = first + second + thired;
                first = tribonacciNumbers[i - 2];
                second = tribonacciNumbers[i - 1];
                thired = tribonacciNumbers[i];
            }

            Console.WriteLine(string.Join(" ", tribonacciNumbers ));
        }
    }
}

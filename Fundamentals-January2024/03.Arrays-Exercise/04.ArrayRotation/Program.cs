namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startingNumbers = Console.ReadLine() 
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotatopn = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotatopn; i++)
            {
                int firstNumber = startingNumbers[0];
                for (int j = 0; j < startingNumbers.Length -1; j++)
                {
                    startingNumbers[j] = startingNumbers[j + 1];
                }
                startingNumbers[startingNumbers.Length -1] = firstNumber;
            }
            Console.WriteLine(string.Join(" ", startingNumbers));
        }
    }
}

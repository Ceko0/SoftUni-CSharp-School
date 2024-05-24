namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize,matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i,j] = input[j];
                }
            }
            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (i == j)
                    {
                        leftDiagonalSum += matrix[i,j];
                    }
                    if(i == matrixSize - j - 1)
                    {
                        rightDiagonalSum += matrix[i,j];
                    }
                }               
            }
            Console.WriteLine($"{Math.Abs(leftDiagonalSum - rightDiagonalSum)}");
        }
    }
}

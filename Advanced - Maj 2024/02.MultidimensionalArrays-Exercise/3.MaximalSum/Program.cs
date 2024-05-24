namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int maxSum = 0;
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row    , col] + matrix[row    , col + 1] + matrix[row     , col + 2] +
                                     matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1 , col + 2] +
                                     matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2 , col + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startRow    , startCol]} {matrix[startRow    , startCol + 1]} {matrix[startRow    , startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]} {matrix[startRow + 1, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 2, startCol]} {matrix[startRow + 2, startCol + 1]} {matrix[startRow + 2, startCol + 2]}");
        }
    }
}

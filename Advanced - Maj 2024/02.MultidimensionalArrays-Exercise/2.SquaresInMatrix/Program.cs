namespace _2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int equalCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row,col] == matrix[row + 1, col] && matrix[row, col + 1] == matrix[row + 1 , col + 1] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        equalCount++;
                    }
                }
            }           
            Console.WriteLine(equalCount);           
        }
    }
}

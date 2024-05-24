using System.Text;
using System.Text.RegularExpressions;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] inpuit = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inpuit[col];
                }
            }

            int[] coordinates = Regex.Matches(Console.ReadLine(), @"\d+")
                .Cast<Match>()
                .Select(x => int.Parse(x.Value))
                .ToArray();
            int[] bombArea = new int[]
            {
                -1,-1,
                -1, 0,
                -1, 1,
                 0,-1,
                 0, 1,
                 1,-1,
                 1, 0,
                 1, 1
            };

            for (int row = 0; row < coordinates.Length; row += 2)
            {
                int bombRow = coordinates[row];
                int bombCol = coordinates[row + 1];
                if(RangeCheck(matrix, bombRow, bombCol) && matrix[bombRow, bombCol] > 0)
                {
                    int bombValue = matrix[bombRow, bombCol];
                    for (int i = 0;i < bombArea.Length; i+=2)
                    {
                        int newRow = bombRow + bombArea[i];
                        int newCol = bombCol + bombArea[i + 1];
                        if (RangeCheck(matrix , newRow, newCol) && matrix[newRow, newCol] > 0)
                        {
                            matrix[newRow, newCol] -= bombValue;
                        }
                    }
                    matrix[bombRow, bombCol] = 0;
                }
            }
            int aliveCells = 0;
            int aliveSum = 0;
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aliveSum += matrix[row, col];

                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aliveSum}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool RangeCheck(int[,] matrix, int Row, int Col)
        {
            return Row >= 0 && Row < matrix.GetLength(0) && Col >= 0 && Col < matrix.GetLength(1);
            
        }
    }
}

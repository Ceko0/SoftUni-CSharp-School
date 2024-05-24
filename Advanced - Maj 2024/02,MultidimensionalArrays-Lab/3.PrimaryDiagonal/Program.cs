namespace _3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int diagonalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i == j)
                    {
                        diagonalSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(diagonalSum);
        }
    }
}

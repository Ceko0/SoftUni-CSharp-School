namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
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
            for (int i = 0;i < matrix.GetLength(1); i++)
            {
                int columSum = 0;
                for (int j = 0;j < matrix.GetLength(0); j++)
                {
                    columSum += matrix[j, i];
                }
                Console.WriteLine(columSum);
            }
        }
    }
}

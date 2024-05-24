namespace _5.SquareWithMaximumSum
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
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int maxSum = int.MinValue;
            int row = 0;
            int col = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    int currentSum = matrix[i, j]+ matrix[i,j+1]+
                        matrix[i+1 , j] + matrix[i+1 , j +1];
                    if(currentSum> maxSum)
                    {
                        maxSum = currentSum;
                        row = i;
                        col = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[row,col]} {matrix[row, col+1]}");
            Console.WriteLine($"{matrix[row+1,col]} {matrix[row+1, col+1]}");
            Console.WriteLine(maxSum);
        }
    }
}

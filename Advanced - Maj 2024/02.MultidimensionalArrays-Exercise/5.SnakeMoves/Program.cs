namespace _5.SnakeMoves
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
            char[] text = Console.ReadLine().ToCharArray();
            int textCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row += 2)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = text[textCounter++].ToString();
                    if (textCounter == text.Length)
                    {
                        textCounter =0;
                    }
                }
                int endRow = matrix.GetLength(0) - 1 ;
                if ( row >= endRow ) 
                {
                    break; 
                }
                for (int j = matrix.GetLength(1) - (1); j >= 0; j--)
                {
                    matrix[row + 1, j] = text[textCounter++].ToString();
                    if (textCounter == text.Length )
                    {
                        textCounter = 0;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

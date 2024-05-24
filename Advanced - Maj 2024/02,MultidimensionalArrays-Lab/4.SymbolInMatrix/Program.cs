namespace _4.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                char[] symbols = Console.ReadLine()
                    .ToCharArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = symbols[j];

                }
            }
            char specialSymbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] == specialSymbol )
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }

                }
            }
            Console.WriteLine($"{specialSymbol} does not occur in the matrix");
        }
    }
}

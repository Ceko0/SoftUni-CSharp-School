namespace _4.MatrixShuffling
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
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string commands = string.Empty;
            while((commands = Console.ReadLine()) != "END")
            {
                string[] action = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (action.Length == 5)
                {
                    int rowOne = int.Parse(action[1]);
                    int colOne = int.Parse(action[2]);
                    int rowTwo = int.Parse(action[3]);
                    int colTwo = int.Parse(action[4]);
                    
                    if (rowOne >= 0 && rowOne < matrix.GetLength(0) && rowTwo >= 0 && rowTwo < matrix.GetLength(0) &&
                        colOne >= 0 && colOne < matrix.GetLength(1) && colTwo >= 0 && colTwo < matrix.GetLength(1))
                    {
                        string currentInfo = matrix[rowOne, colOne];
                        matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                        matrix[rowTwo, colTwo] = currentInfo;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write($"{matrix[i,j]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } 
        }
    }
}

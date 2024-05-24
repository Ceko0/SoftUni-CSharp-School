namespace _7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            string[,] matrix = new string[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j].ToString();
                }
            }

            int[] moves =
                {
                 - 2 , - 1,
                 - 2 , + 1,
                 - 1 , - 2,
                 - 1 , + 2,
                 + 1 , - 2,
                 + 1 , + 2,
                 + 2 , - 1,
                 + 2 , + 1,
                };

            int removedHorse = 0;

            while(true)
            {
                int maxAttacks = 0;
                int attackerRow = 0;
                int attackerCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == "K")
                        {
                            int attacktHorse = 0;

                            for (int i = 0; i < moves.Length; i += 2)
                            {
                                int currentRow = row + moves[i];
                                int currentCol = col + moves[i + 1];

                                if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1)
                                    && matrix[currentRow, currentCol] == "K")
                                {
                                    attacktHorse++;
                                }
                            }
                            if (attacktHorse > maxAttacks)
                            {
                                maxAttacks = attacktHorse;
                                attackerRow = row;
                                attackerCol = col;
                            }
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    removedHorse++;
                    matrix[attackerRow , attackerCol] = "0";
                    maxAttacks = 0;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedHorse);
        }
    }
}

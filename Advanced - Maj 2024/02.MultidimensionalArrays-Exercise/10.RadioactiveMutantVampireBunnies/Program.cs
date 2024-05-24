namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lairParameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] lair = new char[lairParameters[0], lairParameters[1]];
            int playerRow = 0;
            int playerCol = 0;
            Dictionary<int, List<int>> bunnyPosition = new();
            for (int row = 0; row < lairParameters[0]; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < lairParameters[1]; col++)
                {
                    lair[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (lair[row, col] == 'B')
                    {
                        if (!bunnyPosition.ContainsKey(row))
                        {
                            bunnyPosition.Add(row, new List<int>());
                        }
                        bunnyPosition[row].Add(col);
                    }
                }
            }
            char[] commands = Console.ReadLine()
                .ToCharArray();

            int newPlayerRow = playerRow;
            int newPlayerCol = playerCol;

            for (int i = 0; i < commands.Length; i++)
            {
                char move = commands[i];
                int currentPlayerRow = newPlayerRow;
                int currentPlayerCol = newPlayerCol;
                lair[newPlayerRow, newPlayerCol] = '.';
                switch (move)
                {
                    case 'L':
                        newPlayerCol--;
                        break;
                    case 'R':
                        newPlayerCol++;
                        break;
                    case 'U':
                        newPlayerRow--;
                        break;
                    case 'D':
                        newPlayerRow++;
                        break;
                }

                if (RangeCheck(lair, newPlayerRow, newPlayerCol))
                {
                    BunnyMove(ref lair, ref bunnyPosition);

                    if (lair[newPlayerRow, newPlayerCol] == 'B')
                    {
                        for (int row = 0; row < lair.GetLength(0); row++)
                        {
                            for (int col = 0; col < lair.GetLength(1); col++)
                            {
                                Console.Write(lair[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"dead: {newPlayerRow} {newPlayerCol}");
                        return;
                    }
                    lair[newPlayerRow, newPlayerCol] = 'P';

                }
                else
                {
                    BunnyMove(ref lair, ref bunnyPosition);

                    for (int row = 0; row < lair.GetLength(0); row++)
                    {
                        for (int col = 0; col < lair.GetLength(1); col++)
                        {
                            Console.Write(lair[row, col]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"won: {currentPlayerRow} {currentPlayerCol}");
                    return;
                }
            }
        }
        private static void BunnyMove(ref char[,] lair, ref Dictionary<int, List<int>> bunnyPosition)
        {
            foreach (var (row, colons) in bunnyPosition)
            {
                for (int col = 0; col < colons.Count; col++)
                {
                    int bunnyRow = row;
                    int bunnyCol = colons[col];
                    lair[bunnyRow, bunnyCol] = 'B';
                    if (RangeCheck(lair, bunnyRow + 1, bunnyCol))
                    {
                        lair[bunnyRow + 1, bunnyCol] = 'B';
                    }
                    if (RangeCheck(lair, bunnyRow - 1, bunnyCol))
                    {
                        lair[bunnyRow - 1, bunnyCol] = 'B';
                    }
                    if (RangeCheck(lair, bunnyRow, bunnyCol + 1))
                    {
                        lair[bunnyRow, bunnyCol + 1] = 'B';
                    }
                    if (RangeCheck(lair, bunnyRow + 1, bunnyCol - 1))
                    {
                        lair[bunnyRow, bunnyCol - 1] = 'B';
                    }
                }
            }
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (!bunnyPosition.ContainsKey(row))
                        {
                            bunnyPosition.Add(row, new List<int>());
                        }
                        bunnyPosition[row].Add(col);
                    }
                }
            }
        }

        private static bool RangeCheck(char[,] lair, int row, int col)
        {
            return row >= 0 && row < lair.GetLength(0) &&
                   col >= 0 && col < lair.GetLength(1);
        }
    }
}

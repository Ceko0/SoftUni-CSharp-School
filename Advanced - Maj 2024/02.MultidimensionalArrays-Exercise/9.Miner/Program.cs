namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mineSize = int.Parse(Console.ReadLine());
            string[,] mine = new string[mineSize,mineSize];
            string[] moves = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int startingCoal = 0;
            int startingRow = 0;
            int startingCol = 0;
            for (int i = 0; i < mineSize; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < mineSize; j++)
                {
                    mine[i, j] = input[j].ToString();
                    if (input[j].ToString() == "c")
                    {
                        startingCoal++;
                    }
                    else if (input[j].ToString() == "s")
                    {
                        startingRow = i;
                        startingCol = j;
                    }
                }
            }
            bool isFinish = true;   
            int currentRow = startingRow;
            int currentCol = startingCol;
            for (int i = 0; i < moves.Length; i++)
            {
                string way = moves[i].ToLower();
                switch(way)
                {
                    case "up":
                        if(currentRow -1 >= 0)
                        {
                            int rowToCheck = currentRow - 1;
                            int colToCheck = currentCol;
                            checking(mine, ref currentRow, ref currentCol, rowToCheck, colToCheck , ref startingCoal, ref isFinish);
                        }
                        break;
                    case "down":
                        if (currentRow + 1 < mine.GetLength(0))
                        {
                            int rowToCheck = currentRow + 1;
                            int colToCheck = currentCol;
                            checking(mine, ref currentRow, ref currentCol, rowToCheck, colToCheck, ref startingCoal ,ref isFinish);
                        }
                        break;
                    case "left":
                        if (currentCol - 1 >= 0)
                        {
                            int rowToCheck = currentRow;
                            int colToCheck = currentCol - 1;
                            checking(mine, ref currentRow, ref currentCol, rowToCheck, colToCheck, ref startingCoal,ref isFinish);
                        }
                        break;
                    case "right":
                        if (currentCol + 1 < mine.GetLength(1))
                        {
                            int rowToCheck = currentRow;
                            int colToCheck = currentCol + 1;
                            checking(mine, ref currentRow, ref currentCol, rowToCheck, colToCheck, ref startingCoal,ref isFinish);
                        }
                        break;
                }
            }
            if(isFinish)
            Console.WriteLine($"{startingCoal} coals left. ({currentRow}, {currentCol})");
        }

        private static void checking(string[,] mine,  ref int currentRow, ref int currentCol, int row, int col, ref int startCoal,ref bool isFinish)
        {
            if (mine[row, col] == "c")
            {
                startCoal--;
                if(startCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    isFinish = false;
                    return;
                }
                mine[row, col] = "s";
                
            }
            else if (mine[row, col] == "e")
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                isFinish = false ;
                return;
            }
            mine[currentRow, currentCol] = "*";
            currentRow = row;
            currentCol = col;
            mine[currentRow, currentCol] = "s";
        }
    }
}

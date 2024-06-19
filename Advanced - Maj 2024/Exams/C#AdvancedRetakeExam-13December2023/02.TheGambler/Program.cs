namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] board = new char[boardSize,boardSize];
            int gamblerRow = 0;
            int gamblerCol = 0;
            for (int i = 0; i < boardSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < boardSize; j++)
                {
                    board[i,j] = input[j];
                    if (board[i,j] == 'G')
                    {
                        gamblerRow = i; 
                        gamblerCol = j;
                    }
                }
            }
            int budget = 100;
            string command = string.Empty;
            while((command =  Console.ReadLine()) != "end")
            {
                int currentRow = gamblerRow;
                int currentCol = gamblerCol;
                board[gamblerRow, gamblerCol] = '-';
                switch (command)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }
                if (currentRow < 0 || currentRow >= boardSize ||
                    currentCol < 0 || currentCol >= boardSize)
                {
                    Console.WriteLine("Game over! You lost everything!");
                    return;
                }

                if (board[currentRow, currentCol] == 'W') budget += 100;
                else if(board[currentRow, currentCol] == 'P')
                {
                    budget -= 200;
                    if ( budget <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }
                }
                else if (board[currentRow, currentCol] == 'J')
                {
                    budget += 100000;
                    Console.WriteLine($"You win the Jackpot!");
                    Console.WriteLine($"End of the game.Total amount: {budget}$");
                    board[currentRow, currentCol] = 'G';
                    board[gamblerRow, gamblerCol] = '-';
                    for (int i = 0; i < boardSize; i++)
                    {
                        for (int j = 0; j < boardSize; j++)
                        {
                            Console.Write(board[i, j]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                board[currentRow, currentCol] = 'G';
                board[gamblerRow, gamblerCol] = '-';
                gamblerRow = currentRow;
                gamblerCol = currentCol;
            }
            Console.WriteLine($"End of the game. Total amount: {budget}$");
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

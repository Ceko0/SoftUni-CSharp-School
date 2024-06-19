namespace _02.EscapeTheMaze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] maze = new char[matrixSize, matrixSize];

            int health = 100;
            int travellerRow = 0;
            int travellerCol = 0;
            int exitRow = 0;
            int exitCol = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < input.Length; j++)
                {
                    maze[i, j] = input[j];
                    if (input[j] == 'P')
                    {
                        travellerCol = j;
                        travellerRow = i;
                    }
                    if (input[j] == 'X')
                    {
                        exitCol = j;
                        exitRow = i;
                    }
                }
            }
            while (true)
            {
                string direction = Console.ReadLine();
                int currentTravellerRow = travellerRow;
                int currentTravellerCol = travellerCol;

                switch (direction)
                {
                    case "up":
                        currentTravellerRow--;
                        break;
                    case "down":
                        currentTravellerRow++;
                        break;
                    case "right":
                        currentTravellerCol++;
                        break;
                    case "left":
                        currentTravellerCol--;
                        break;
                }
                maze[travellerRow, travellerCol] = '-';
                if (currentTravellerRow >= matrixSize || currentTravellerCol >= matrixSize)
                {
                    continue;
                }
                if (maze[currentTravellerRow, currentTravellerCol] == 'M')
                {
                    health -= 40;
                    maze[currentTravellerRow, currentTravellerCol] = 'P';
                }
                else if (maze[currentTravellerRow, currentTravellerCol] == 'H')
                {
                    maze[currentTravellerRow, currentTravellerCol] = 'P';
                    if (health + 15 >= 100)
                    {
                        health = 100;
                    }
                    else
                    {
                        health += 15;
                    }
                }
                if (maze[currentTravellerRow, currentTravellerCol] == 'X')
                {
                    maze[currentTravellerRow, currentTravellerCol] = 'P';
                    Console.WriteLine("Player escaped the maze. Danger passed!");
                    Console.WriteLine($"Player's health: {health} units");
                    break;
                }
                if (health <= 0)
                {
                    Console.WriteLine("Player is dead. Maze over!");
                    Console.WriteLine($"Player's health: 0 units");
                    break;
                }
                maze[currentTravellerRow, currentTravellerCol] = 'P';
                travellerCol = currentTravellerCol;
                travellerRow = currentTravellerRow;
            }
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

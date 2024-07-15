using SimpleSnake.Enums;
using System;
using System.Threading;

namespace SimpleSnake.GameObjects
{
    public class Engine
    {
        private readonly Point[] pointsOfDirection;
        private readonly Wall wall;
        private readonly Snake snake;
        private readonly GameStatistics statistics;
        private double sleepTime;
        private Direction direction;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
            this.statistics = new GameStatistics(wall.LeftX, wall.TopY);
            CreateDirections();
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction], statistics);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }

        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0);   
            pointsOfDirection[1] = new Point(-1, 0);  
            pointsOfDirection[2] = new Point(0, 1);   
            pointsOfDirection[3] = new Point(0, -1); 
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            direction = userInput.Key switch
            {
                ConsoleKey.LeftArrow when direction != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when direction != Direction.Left => Direction.Right,
                ConsoleKey.UpArrow when direction != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when direction != Direction.Up => Direction.Down,
                _ => direction
            };

            Console.CursorVisible = false;
        }
    }
}

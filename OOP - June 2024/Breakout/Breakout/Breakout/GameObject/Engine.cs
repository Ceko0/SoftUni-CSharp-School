using Breakout.Enums;

namespace Breakout.GameObject
{
    public class Engine
    {
        private readonly Point[] pointsOfDirection;
        private Wall wall;
        private double sleepTime;
        private Direction direction;
        private Board board;
        private Ball ball;
        private Box box;
        private int counter = 0;
        public Engine(Wall wall)
        {
            this.wall = wall;
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[2];
            CreateDirections();
            box = new(1, 5, wall);
            board = new Board(wall.LeftX / 2 - 2, wall.TopY - 3, wall);
            ball = new Ball(wall.LeftX / 2, wall.TopY / 2 - 10, 1, 1, wall, this.board, this.box);
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    //FieldCleaner(wall, board, ball, box);
                    GetNextDirection();
                    board.MoveBoard(pointsOfDirection[(int)direction]);
                    Point point;
                    if (0 == (int)direction)
                        point = new Point(board.boardPosition.Last().LeftX + 1, board.boardPosition.Last().TopY);
                    else
                        point = new Point(board.boardPosition.First().LeftX - 1, board.boardPosition.First().TopY);

                    Console.BackgroundColor = ConsoleColor.White;
                    point.Draw(point.LeftX, point.TopY, ' ');
                }
                if (counter++ % 3 != 0) continue;

                try
                {
                    ball.Move();
                }
                catch (ArgumentException)
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
            string output = "Would you like to continue? y/n";
            Console.SetCursorPosition(leftX, topY);
            Console.Write(output);
            Console.SetCursorPosition(leftX + output.Length / 2, topY + 3);
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
            pointsOfDirection[0] = new Point(-1, 0);
            pointsOfDirection[1] = new Point(1, 0);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (ConsoleKey.LeftArrow == userInput.Key)
                direction = Direction.Left;
            else if (ConsoleKey.RightArrow == userInput.Key)
                direction = Direction.Right;

            Console.CursorVisible = false;
        }

        public void FieldCleaner(Wall wall, Board board, Ball ball, Box box)
        {
            Point point = new Point(0, 0);
            while (point.TopY != 40 && point.LeftX != 50)
            {
                for (int i = 0; i < wall.LeftX; i++)
                {
                    for (int j = 1; j < wall.TopY; j++)
                    {
                        if (ball.IsPointOfBall(point)) continue;

                        else if (box.IsPointOfBox(point)) continue;

                        else if (board.IsPointOfBoard(point)) continue;

                        else if (wall.IsWallPoint(point)) continue;


                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(point.LeftX, point.TopY);
                        Console.Write(' ');
                        Console.ResetColor();
                        point.TopY++;
                    }

                    point.LeftX++;
                    point.TopY = 1;
                }
            }

        }
    }
}

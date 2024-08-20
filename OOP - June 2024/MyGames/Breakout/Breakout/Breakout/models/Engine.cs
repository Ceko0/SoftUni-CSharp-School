using System.Timers;
using Breakout.methods;
using Timer = System.Timers.Timer;

namespace Breakout.models
{
    public class Engine
    {
        private int direction = 0;
        private Wall wall;
        private boxes boxes;
        private Board board;
        private Ball ball;
        private Timer ballTimer;
        private Timer boardTimer;
        private object lockObject = new object();
        public Engine(int row, int coll)
        {
            wall = new Wall(row, coll);
            boxes = new(wall);
            board = new(wall);
            ball = new(wall);

            ballTimer = new Timer(100);
            ballTimer.Elapsed += BallMovementHandler;
            ballTimer.Start();

            boardTimer = new Timer(20);
            boardTimer.Elapsed += BoardMovementHandler;
            boardTimer.Start();
            
        }
        private void BallMovementHandler(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                ball.Moving();
                ball.ballHitBoard(board.boardPieces);
                ball.ballHitBox(boxes.boxPosition);
                ball.ballHitLeftWall(wall);
                ball.ballHitRightWall(wall);
                ball.ballHitToptWall(wall);
                ballHitDownWall();
                ball.OutputScore(wall);
            }
        }
        private void BoardMovementHandler(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                if (Console.KeyAvailable)
                {
                    if (GetNextDirection())board.Moving(direction, 0, wall);
                }
            }
        }
        public void run()
        {
            while (true)
            {

            }
        }
        private bool GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (ConsoleKey.LeftArrow == userInput.Key)
            {
                direction = -1;
                
                return true;
            }
            else if (ConsoleKey.RightArrow == userInput.Key)
            {
                direction = 1;
               
                return true; 
            }
            Console.CursorVisible = false;
            return false;
        }

        private void LevelIsOver()
        {
            if (boxes.boxPosition.Count == 0)
            {
                int currentscore = ball.score;
                int  ballCurrentTimer = int.Parse(ballTimer.ToString());
                StartUp.MainTwo();
                ball.score = currentscore;
                ballTimer = new Timer(ballCurrentTimer - 10);
            }
        }
        private void ballHitDownWall()
        {
            if (wall.DownWallBoarder.Contains((ball.ballPosition[0].Item1 - 1, ball.ballPosition[0].Item2)))
            {
                AskUserForRestart();
            }
        }
        private void AskUserForRestart()
        {
            int row = wall.wallRow + 2;
            int col = 4;
            Console.SetCursorPosition((wall.wallRow / 2) - 5, wall.wallCol / 2);
            Console.WriteLine("Game over!");
            
            string output = "Would you like to continue? y/n";
            Console.SetCursorPosition((wall.wallRow / 2) - output.Length/2 , wall.wallCol / 2 + 2 );
            Console.WriteLine(output);
            Console.SetCursorPosition(wall.wallRow / 2, wall.wallCol / 2 + 4);
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.Clear();
                ballTimer.Stop();
                ballTimer.Close();
                boardTimer.Stop();
                boardTimer.Close();
                StartUp.MainTwo();
            }
            else
                StopGame();

        }
        private void StopGame()
        {
            string output = "Game over!";
            int row = (wall.wallRow / 2) - (output.Length / 2);
            int col = wall.wallCol / 2;

            Console.SetCursorPosition(row, col);
            Console.WriteLine(output);
            Environment.Exit(0);
        }
    }
}

using Breakout.methods;

namespace Breakout.models
{
    public class Ball
    {
        private char ballSymbol = '\u25CF';
        public List<(int, int)> ballPosition;
        drawing drawing = new();
        private int ballRow;
        private int ballColl;
        public int score = 0;
        public Ball(Wall wall)
        {
            ballPosition = new();
            int startingRowl = wall.wallRow / 2;
            int startingColl = wall.wallCol / 2;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            drawing.drawPoint(startingRowl, startingColl, ballSymbol);
            ballPosition.Add((startingRowl, startingColl));
            Console.ResetColor();
            ballRow = 1;
            ballColl = 1;
        }

        public void Moving()
        {
            List<(int, int)> newBallPosition = new List<(int, int)>();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach ((int currentRow, int currentColl) in ballPosition)
            {
                drawing.drawPoint(currentRow + ballRow, currentColl + ballColl, ballSymbol);
                newBallPosition.Add((currentRow + ballRow, currentColl + ballColl));
                Console.ResetColor();
                drawing.drawPoint(currentRow, currentColl, ' ');
            }

            ballPosition = new List<(int, int)>();
            ballPosition = newBallPosition;
        }
        public void ballHitBoard(List<(int, int)> boardPieces)
        {
            int direction = 1;
            foreach ((int boardRow, int boardColl) in boardPieces)
            {
                
                if (ballPosition[0].Item1 == boardRow && ballPosition[0].Item2 == boardColl - 1)
                {
                    ballColl *= -direction;
                    continue;
                }
                else
                {
                    if (ballColl > 0) ballColl = 1;
                    else ballColl = -1;
                }
            }
        }
        public void ballHitBox(List<(int, int)> boxPieces)
        {
            int indexToRemove = -1;
            indexToRemove = boxPieces.IndexOf((ballPosition[0].Item1, ballPosition[0].Item2));

            if (indexToRemove != -1)
            {
                this.ballColl *= -1;
                boxPieces.RemoveAt(indexToRemove);
                score++;
            }
        }

        public void ballHitLeftWall(Wall wall)
        {
            if (wall.LeftWallBoarder.Contains((ballPosition[0].Item1 - 1, ballPosition[0].Item2)))
                ballRow *= -1;
        }
        public void ballHitRightWall(Wall wall)
        {
            if (wall.RightWallBoarder.Contains((ballPosition[0].Item1 + 1, ballPosition[0].Item2)))
                ballRow *= -1;
        }
        public void ballHitToptWall(Wall wall)
        {
            if (wall.TopWallBoarder.Contains((ballPosition[0].Item1, ballPosition[0].Item2 - 1)))
                ballColl *= -1;
        }

        public void OutputScore(Wall wall)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            int row = wall.wallRow + 2;
            int col = 3;
            string output = $"Score : {score}";
            Console.SetCursorPosition(row, col);
            Console.Write(output);
            Console.ResetColor();
        }
    }
}

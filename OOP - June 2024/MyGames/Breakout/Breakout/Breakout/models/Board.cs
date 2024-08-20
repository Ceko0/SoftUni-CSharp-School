using Breakout.methods;

namespace Breakout.models
{
    public class Board
    {
        public List<(int, int)> boardPieces = new();
        private char boardSymbol = '\u25A0';
        drawing drawing = new();
        public Board(Wall wall)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;

            int startPosition = wall.wallRow / 2 - 3;
            for (int i = 0; i < 22; i++)
            {
                drawing.drawPoint(startPosition + i, wall.wallCol - 5, boardSymbol);
                boardPieces.Add((startPosition + i, wall.wallCol - 5));
            }
            Console.ResetColor();
        }

        public void Moving(int row, int coll , Wall wall)
        {
            int rightRow = 0;
            int rightColl = 0;
            int leftRow = 0;
            int leftColl = 0;

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            List<(int, int)> newBoardPieces = new List<(int, int)>();
            if (wall.LeftWallBoarder.Contains((boardPieces[0].Item1 + row, boardPieces[0].Item2)) || wall.RightWallBoarder.Contains((boardPieces[6].Item1 + row, boardPieces[6].Item2)) )
            {
                Console.ResetColor();
                return;
            }
            int counter = 0;
            foreach ((int currentRow, int currentColl) in boardPieces)
            {
                if (counter++ == 0)
                {
                    leftRow = currentRow;
                    leftColl = currentColl;
                }
                rightRow = currentRow;
                rightColl = currentColl;
                drawing.drawPoint(currentRow + row, currentColl + coll, boardSymbol);
                newBoardPieces.Add((currentRow + row, currentColl + coll));
            }
            Console.ResetColor();

            if (row == -1)
            {
                drawing.drawPoint(rightRow, rightColl, ' ');
                
            }
            else
            {
                drawing.drawPoint(leftRow, leftColl, ' ');
                
            }

            boardPieces = new List<(int, int)>();
            boardPieces = newBoardPieces;
        }
    }
}

using Breakout.methods;

namespace Breakout.models
{
    public class Wall
    {
        private List<(int, int)> topWallBoarder;
        private List<(int, int)> leftWallBoarder;
        private List<(int, int)> rightWallBoarder;
        private List<(int, int)> downWallBoarder;

        private char wallSymbol = '\u25A0';
        public int wallRow { get; }
        public int wallCol { get; }

        public Wall(int row, int coll)
        {
            wallRow = row;
            wallCol = coll;

            topWallBoarder = new();
            leftWallBoarder = new();
            rightWallBoarder = new();
            downWallBoarder = new();
            TopWallBoarder = topWallBoarder.AsReadOnly();
            LeftWallBoarder = leftWallBoarder.AsReadOnly();
            RightWallBoarder = rightWallBoarder.AsReadOnly();
            DownWallBoarder = downWallBoarder.AsReadOnly();
            drawing drawing = new();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < row; i++)
            {

                drawing.drawPoint(i, 0, wallSymbol);
                topWallBoarder.Add((i, 0));
            }
            for (int i = 0; i < row; i++)
            {
                drawing.drawPoint(i, coll-1, wallSymbol);
                downWallBoarder.Add((i, coll-1));
            }

            for (int i = 0; i < coll; i++)
            {
                drawing.drawPoint(0, i, wallSymbol);
                leftWallBoarder.Add((0, i));
            }
            for (int i = 0; i < coll; i++)
            {
                drawing.drawPoint(row,i, wallSymbol);
                rightWallBoarder.Add((row, i));
            }
            Console.ResetColor();
        }


        public IReadOnlyCollection<(int, int)> TopWallBoarder;
        public IReadOnlyCollection<(int, int)> LeftWallBoarder;
        public IReadOnlyCollection<(int, int)> RightWallBoarder;
        public IReadOnlyCollection<(int, int)> DownWallBoarder;


    }

}

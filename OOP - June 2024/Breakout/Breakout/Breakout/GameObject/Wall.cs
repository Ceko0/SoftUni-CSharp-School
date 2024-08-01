using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Breakout.GameObject
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public List<Point> wallPoints = new ();

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                wallPoints.Add(new Point(leftX, topY));
                Console.ForegroundColor = ConsoleColor.Black;
                Draw(leftX, topY, WallSymbol);
                Console.ResetColor();
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Draw(leftX, topY, WallSymbol);
                Console.ResetColor();
                wallPoints.Add(new Point(leftX, topY));

            }
        }
        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY -1);
            SetVerticalLine(0);
            SetVerticalLine(LeftX -1);
        }

        public bool IsPointOfWall(Point positionPoint)
        {
            return positionPoint.TopY == 0 || positionPoint.LeftX == 0 || positionPoint.LeftX == LeftX - 1 ||
                   positionPoint.TopY == TopY - 1;
        }

        public bool IsWallPoint(Point point)
        {
            foreach (Point wallPoint in wallPoints) if(wallPoint.TopY == point.TopY && wallPoint.LeftX == point.LeftX) return true;

            return false;
        }
    }
}

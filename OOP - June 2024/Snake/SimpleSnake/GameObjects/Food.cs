using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly Random random;
        private readonly char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            do
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);
            } while (snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY));

            Draw(foodSymbol);
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.TopY == TopY && snakeHead.LeftX == LeftX;
        }
    }
}

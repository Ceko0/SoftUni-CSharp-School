using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private readonly Wall wall;
        private readonly Food[] foods;
        private readonly Queue<Point> snakeElements;
        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            InitializeFoods();
            CreateInitialSnake();
        }

        private void InitializeFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
            foodIndex = new Random().Next(0, foods.Length);
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void CreateInitialSnake()
        {
            for (int topY = 0; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }

            foreach (Point point in snakeElements)
            {
                point.Draw(SnakeSymbol);
            }
        }

        public bool IsMoving(Point direction, GameStatistics statistics)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPointOfSnake || wall.IsPointOfWall(new Point(nextLeftX, nextTopY)))
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);
            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, currentSnakeHead, statistics);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' '); 
            statistics.UpdateSnakeLength(snakeElements.Count);
            return true;
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currentSnakeHead, GameStatistics statistics)
        {
            int length = foods[foodIndex].FoodPoints;
            statistics.UpdateScore(length);

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            foodIndex = new Random().Next(0, foods.Length);
            foods[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}

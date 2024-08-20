using System;

namespace SimpleSnake.GameObjects
{
    public class GameStatistics
    {
        private int leftX;
        private int topY;
        private int score;
        private int snakeLength;

        public GameStatistics(int wallWidth, int wallHeight)
        {
            leftX = wallWidth + 2;
            topY = 2;
            score = 0;
            snakeLength = 6; 
        }

        public void UpdateScore(int points)
        {
            score += points;
            DisplayStatistics();
        }

        public void UpdateSnakeLength(int length)
        {
            snakeLength = length;
            DisplayStatistics();
        }

        public void DisplayStatistics()
        {
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine($"Score: {score}");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.WriteLine($"Snake Length: {snakeLength}");
        }
    }
}

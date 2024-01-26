using System.Linq;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main()
        {
            int[] field = new int[int.Parse(Console.ReadLine())];
            int[] startingLadybugsPosition = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < startingLadybugsPosition.Length; i++)
            {
                if (startingLadybugsPosition[i] >= 0 && startingLadybugsPosition[i] < field.Length)
                {
                    field[startingLadybugsPosition[i]] = 1;
                }

            }

            while (true)
            {
                string[] positionChange = Console.ReadLine()
                    .Split()
                    .ToArray();
                if (positionChange[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", field));
                    break;
                }

                int.TryParse(positionChange[0], out int ladybugIndex);
                string movingWay = positionChange[1];
                int.TryParse(positionChange[2], out int flyLength);
                
                if (ladybugIndex >= 0 && ladybugIndex < field.Length && field[ladybugIndex] == 1)
                {
                    field[ladybugIndex] = 0;
                    if (movingWay == "left")
                    {
                        field = MovingLeft(field, ladybugIndex, flyLength);
                    }
                    else if (movingWay == "right")
                    {
                        field = MovingRight(field, ladybugIndex, flyLength);
                    }
                }
            }
        }
        static int[] MovingRight(int[] field, int ladybugIndex, int flyLength)
        {
            for (int i = ladybugIndex + flyLength; i < field.Length; i += flyLength)
            {
                if (field[i] == 0)
                {
                    field[i] = 1;
                    break;
                }
            }
            return field;
        }
        static int[] MovingLeft(int[] field, int ladybugIndex, int flyLength)
        {
            for (int i = ladybugIndex - flyLength; i >= 0; i -= flyLength)
            {
                if (field[i] == 0)
                {
                    field[i] = 1;
                    break;
                }
            }
            return field;
        }
    }
}
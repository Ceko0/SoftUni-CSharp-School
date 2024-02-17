namespace _03.LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLine = NewMethod(x1, x2) + NewMethod(y1, y2);
            double secondLine = NewMethod(x3, x4) + NewMethod(y3, y4);

            if (firstLine > secondLine)
            {
                if (CloserToZeroCheck(x1, y1, x2, y2))
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }

            }
            else
            {
                if (!CloserToZeroCheck(x3, y3, x4, y4))
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }

            }
        }

        private static bool CloserToZeroCheck(double x1, double y1, double x2, double y2)
        {
            if (x1 < x2)
            {
                if (y1 < y2)
                {
                    return true;
                }
                else if (x1 < y2)
                {
                    return true;
                }
            }
            else
            {
                if (y1 < y2)
                {
                    if (x2 > y1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static double NewMethod(double x1, double x2)
        {
            double sideOne = 0;
            if (biger(x1, x2))
            {
                sideOne = x1 - x2;
            }
            else
            {
                sideOne = x2 - x1;
            }

            return Math.Pow(sideOne, 2);
        }

        private static bool biger(double x1, double x2)
        {
            if (x1 > x2)
            {
                return true;
            }

            return false;
        }
    }
}

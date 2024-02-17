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
            CheckTheLongestLine(x1,y1,x2,y2,x3,y3,x4,y4);
        }

        private static void CheckTheLongestLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double x1y1 = XAndYCalculator(x1, y1);
            double x2y2 = XAndYCalculator(x2, y2);
            double x3y3 = XAndYCalculator(x3, y3);
            double x4y4 = XAndYCalculator(x4, y4);

            double firstLine = LineCalculator(x1y1, x2y2); ;
            double secondLine = LineCalculator(x3y3, x4y4); ;

            if (firstLine >= secondLine)
            {
                CloserToCenterPrint(x1y1, x2y2 , x1 , y1 , x2 , y2);
            }
            else
            {
                CloserToCenterPrint(x3y3, x4y4, x3, y3, x4, y4);
            }
        }

        private static void CloserToCenterPrint(double x1y1, double x2y2, double x1, double y1, double x2, double y2)
        {
            if (x1y1 < x2y2) Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            else Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }

        private static double XAndYCalculator(double x, double y)
        {
            //double xy = 0;
            //if ((x > 0 && y > 0) || (x < 0 && y < 0)) xy = x + y;
            //else if ((x <= 0 && y >= 0) || (x >= 0 && y <= 0)) xy = x + y;
            return x + y;
        }
        private static double LineCalculator(double x1y1, double x2y2)
        {
            //double line = 0;
            //if ((x1y1 > 0 && x2y2 > 0) || (x1y1 < 0 && x2y2 < 0))
            //{
            //    if (x1y1 > x2y2) line = x1y1 - x2y2;
            //    else line = x2y2 - x1y1;
            //}
            //if ((x1y1 >= 0 && x2y2 <= 0) || (x1y1 <= 0 && x2y2 >= 0)) line = Math.Abs(x1y1 + x2y2);
            return x1y1 + x2y2;
        }
    }
}

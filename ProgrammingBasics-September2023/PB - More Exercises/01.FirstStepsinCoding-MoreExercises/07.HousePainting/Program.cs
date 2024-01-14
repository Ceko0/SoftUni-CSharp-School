using System;

namespace _07.HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double front = 2 * x * x;
            double side = 2 * x * y;
            double roofside = x * y * 2;
            double rooffront = (x * h / 2) * 2;

            double redpaint = (roofside + rooffront)/ 4.3 ;
            double greenpaint = (front + side - (1.2 * 2 + 1.5 * 1.5 + 1.5 * 1.5)) / 3.4;
            Console.WriteLine($"{greenpaint:f2}");
            Console.WriteLine($"{redpaint:f2}");
           
        }
    }
}

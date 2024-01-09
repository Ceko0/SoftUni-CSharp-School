using System;

namespace _02.TriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine($"{a*h /2 :f2}");
        }
    }
}

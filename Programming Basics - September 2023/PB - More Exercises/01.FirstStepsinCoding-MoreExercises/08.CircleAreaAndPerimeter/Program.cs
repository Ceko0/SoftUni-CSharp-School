using System;

namespace _08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine($"{Math.PI * r * r :f2}");
            Console.WriteLine($"{Math.PI *2 * r :f2}");
        }
    }
}

using System;

namespace _03.CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double gradus = double.Parse(Console.ReadLine());
            Console.WriteLine($"{gradus * 9/5 + 32 :f2}");
        }
    }
}

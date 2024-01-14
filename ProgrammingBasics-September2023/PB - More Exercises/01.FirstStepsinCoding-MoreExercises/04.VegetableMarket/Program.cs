using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Nprice = double.Parse(Console.ReadLine());
            double Mprice = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            Console.WriteLine($"{(Nprice * n + Mprice * m ) / 1.94 :f2}");
        }
    }
}

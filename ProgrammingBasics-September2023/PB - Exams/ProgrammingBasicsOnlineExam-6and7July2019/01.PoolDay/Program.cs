using System;
using System.Xml.Schema;

namespace _01.PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            double entertax = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double unbrelaprice = double.Parse(Console.ReadLine());

            double totalprice = 0;
            totalprice += people * entertax;
            totalprice += price * Math.Ceiling(people * 0.75);
            double totalpeople = Math.Ceiling(people / 2);
            totalprice +=unbrelaprice * totalpeople;
            Console.WriteLine($"{totalprice:f2} lv.");
        }
    }
}

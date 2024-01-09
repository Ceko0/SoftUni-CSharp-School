using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mackerel = double.Parse(Console.ReadLine());
            double sprinkle = double.Parse(Console.ReadLine());
            double bonito = double.Parse(Console.ReadLine());
            double safrid = double.Parse(Console.ReadLine());
            int mussels = int.Parse(Console.ReadLine());
            double pricebonito = bonito * (mackerel*1.60);
            double safridprice = safrid * (sprinkle * 1.80);
            double musselsprice = mussels * 7.50;
            double totalprice = pricebonito + safridprice + musselsprice;
            Console.WriteLine($"{totalprice:f2}");
        }
    }
}

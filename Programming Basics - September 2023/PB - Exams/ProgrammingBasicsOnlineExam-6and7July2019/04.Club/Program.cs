using System;

namespace _04.Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double needmoney = double.Parse(Console.ReadLine());
            string name = "";
            int n = 0;
            double totalmoney = 0;
            double price = 0;
            int number = name.Length;
            while (name != "Party!")
            {
                name = Console.ReadLine();
                if (name == "Party!") { break; }
                n = int.Parse(Console.ReadLine());
                price += n * number;
                if (price % 2 == 1)
                {
                    price *= 0.75;
                    totalmoney += price;
                }
                else 
                {
                    totalmoney += price;
                }
                if (totalmoney >= needmoney)
                {
                    break;
                }
            }
            if (totalmoney <= needmoney)
            {
                Console.WriteLine($"We need {needmoney - totalmoney:f2} leva more.");
            }
            else 
            {
                Console.WriteLine("Target acquired.");
                Console.WriteLine($"Club income - {totalmoney - needmoney:f2} leva.");
            }
        }
    }
}

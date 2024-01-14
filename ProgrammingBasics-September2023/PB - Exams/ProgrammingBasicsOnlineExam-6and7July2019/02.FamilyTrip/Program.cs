using System;

namespace _02.FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int others = int.Parse(Console.ReadLine());

            if (nights > 7) 
            {
                price = price * 0.95;
            }
            double totalprice = nights * price;
            double othersprice = budjet * others / 100;
            totalprice += othersprice;
            if (budjet > totalprice)
            {
                Console.WriteLine($"Ivanovi will be left with {budjet - totalprice:f2} leva after vacation.");
            }
            else 
            {
                Console.WriteLine($"{totalprice - budjet:f2} leva needed.");
            }
        }
    }
}

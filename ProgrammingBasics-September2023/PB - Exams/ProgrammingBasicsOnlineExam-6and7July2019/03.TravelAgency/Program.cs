using System;

namespace _03.TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string package = Console.ReadLine();
            string vipdiscount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            if (days > 7)
            {
                days -= 1;
            }
            
            double totalprice = 0;
            if (city == "Bansko" || city == "Borovets")
            {
                switch (package) 
                {
                    case "noEquipment":
                        totalprice = days * 80;
                        if (vipdiscount == "yes") { totalprice = totalprice * 0.95; }
                        break;
                    case "withEquipment":
                        totalprice = days * 100;
                        if (vipdiscount == "yes") { totalprice = totalprice * 0.90; }
                        break;
                }
            }
            else if (city == "Varna" || city == "Burgas") 
            {
            switch (package)
                { 
                case "noBreakfast":
                        totalprice = days * 100;
                        if (vipdiscount == "yes") { totalprice = totalprice * 0.93; }
                        break;
                case "withBreakfast":
                        totalprice = days * 130;
                        if (vipdiscount == "yes") { totalprice = totalprice * 0.88; }
                        break;

                }
            }
            if (city != "Bansko" && city != "Borovets"  && city != "Varna" && city != "Burgas")
            {
                Console.WriteLine("Invalid input!");
            }
            else if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            { 
                Console.WriteLine($"The price is {totalprice:f2}lv! Have a nice time!");
            }
        }
    }
}

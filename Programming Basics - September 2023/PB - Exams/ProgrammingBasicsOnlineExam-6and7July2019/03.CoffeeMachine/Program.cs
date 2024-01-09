using System;

namespace _03.CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Без захар       Нормално       Допълнително захар
            //Еспресо    0.90 лв./ бр.      1 лв. / бр.   1.20 лв. / бр.
            //Капучино  1.00 лв. / бр.   1.20 лв. / бр.   1.60 лв. / бр.
            //Чай       0.50 лв. / бр.   0.60 лв. / бр.   0.70 лв. / бр.

            string tipe = Console.ReadLine();
            string sugar = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            double totalprice = 0;

            if (tipe == "Espresso")
            {
                switch (sugar)
                {
                    case "Without":
                        totalprice = number * (0.90 * 0.65);
                        break;
                    case "Normal":
                        totalprice = number * 1.00;
                        break;
                    case "Extra":
                        totalprice = number * 1.20;
                        break;
                   
                }
                if (number > 5)
                {
                    totalprice = totalprice * 0.75;
                }
            }
            else if (tipe == "Cappuccino")
            {
                switch (sugar)
                {
                    case "Without":
                        totalprice = number * (1 * 0.65);
                        break;
                    case "Normal":
                        totalprice = number * 1.20;
                        break;
                    case "Extra":
                        totalprice = number * 1.60;
                        break;
                }
            }
            else if (tipe == "Tea")
            {
                switch (sugar)
                {
                    case "Without":
                        totalprice = number * (0.50 * 0.65);
                        break;
                    case "Normal":
                        totalprice = number * 0.60;
                        break;
                    case "Extra":
                        totalprice = number * 0.70;
                        break;
                }
            }
            if (totalprice > 15) 
            {
                totalprice = totalprice * 0.80;
            }
            Console.WriteLine($"You bought {number} cups of {tipe} for {totalprice:f2} lv.");
        }
    }
}

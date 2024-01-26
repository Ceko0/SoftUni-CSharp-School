namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double partPriceWhithoutTax = 0;
            double partTax = 1.20;
            double specialDiscount = 1;
            while (true)
            {
                string partPrice = Console.ReadLine();

                if (partPrice == "special")
                {
                    specialDiscount = 0.90;
                    break;
                }
                else if (partPrice == "regular")
                {
                    break;
                }
                else if (double.Parse(partPrice) < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                else
                {
                    partPriceWhithoutTax += double.Parse(partPrice);
                }
            }
            if (partPriceWhithoutTax == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {partPriceWhithoutTax:f2}$");
                Console.WriteLine($"Taxes: {partPriceWhithoutTax * 0.2 :f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {partPriceWhithoutTax * partTax * specialDiscount :f2}$");
            }
        }
    }
}

namespace _03.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> stock = new Dictionary<string, int>();

            string income = String.Empty;
            int soldFood = 0;
            while ((income = Console.ReadLine()) != "Complete")
            {
                string[] commands = income
                    .Split()
                    .ToArray();

                string command = commands[0];
                string foodName = commands[2];
                int foodQuantity = int.Parse(commands[1]);
                switch (command)
                {
                    case "Receive":

                        if (foodQuantity >= 0)
                        {
                            if (stock.ContainsKey(foodName)) stock[foodName] += foodQuantity;
                            else stock.Add(foodName, foodQuantity);
                        }
                        break;
                    case "Sell":
                        if (stock.ContainsKey(foodName))
                        {
                            if (stock[foodName] < foodQuantity)
                            {
                                Console.WriteLine($"There aren't enough {foodName}. You sold the last {stock[foodName]} of them.");
                                soldFood += stock[foodName];
                                stock.Remove(foodName);
                            }
                            else
                            {
                                Console.WriteLine($"You sold {foodQuantity} {foodName}.");
                                soldFood += foodQuantity;
                                stock[foodName] -= foodQuantity;
                                if (stock[foodName] == 0) stock.Remove(foodName);
                            }
                        }
                        else Console.WriteLine($"You do not have any {foodName}.");
                        break;
                }
            }
            foreach (var (name, quantity) in stock)
            {
                Console.WriteLine($"{name}: {quantity}");
            }
            Console.WriteLine($"All sold: {soldFood} goods");
        }
    }
}


double budget = 0;
bool isCoin = false;
double moneyNeed = 0;

while (true)
{
    string income = Console.ReadLine();

    if (income == "Start")
    {
        while (true)
        { 
            string products = Console.ReadLine();
            moneyNeed = products == "Nuts" ? moneyNeed = 2 : products == "Water" ? moneyNeed = 0.7 : products == "Crisps" ? moneyNeed = 1.5 : products == "Soda" ? moneyNeed = 0.8 : products == "Coke" ? moneyNeed = 1 : moneyNeed = 0;
            if (products == "End")
            {
                Console.WriteLine($"Change: {budget:f2}");
                return;
            }
            else if (!(products == "Nuts" || products == "Water" || products == "Crisps" || products == "Soda" || products == "Coke"))
            {
                Console.WriteLine("Invalid product");
                continue;
            }
            else if (budget >= moneyNeed)
            {
                budget -= moneyNeed;
                Console.WriteLine($"Purchased {products.ToLower()}");
            }
            else
            {
                Console.WriteLine("Sorry, not enough money");
                continue;
            }
        }
    }
    else
    {
       double coins = double.Parse(income);
       isCoin = coins == 0.1 ? isCoin = true : coins == 0.2 ? isCoin = true : coins == 0.5 ? isCoin = true : coins == 1 ? isCoin = true : coins == 2 ? isCoin = true : isCoin = false;

        if (isCoin) budget += coins;
        else Console.WriteLine($"Cannot accept {coins}");
    }

}

double bankBalance = 0;
while (true)
{
    string income = Console.ReadLine();
    if (income != "NoMoreMoney")
    {
        double money = double.Parse(income);
        if (money < 0)
        {
            Console.WriteLine("Invalid operation!");
            Console.WriteLine($"Total: {bankBalance:F2}");
            break;
        }
        else
        {
            bankBalance += money;
            Console.WriteLine($"Increase: {money:F2}");
        }
    }
    if (income == "NoMoreMoney")
    {
        Console.WriteLine($"Total: {bankBalance:F2}");
        break;
    }
}

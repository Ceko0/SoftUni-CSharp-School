int needSum = int.Parse(Console.ReadLine());
int cashSum = 0;
int cardSum = 0; 
int cash = 0;
int card = 0;
int incomeSum = 0;

for (int i = 1; i !=0; i++)
{
    string money = Console.ReadLine();
    if (money == "End")
    {
        Console.WriteLine("Failed to collect required money for charity.");
        break;
    }
    if (i % 2 == 1)
    {
        if (int.Parse(money) > 100) Console.WriteLine("Error in transaction!");
        else 
        {
            Console.WriteLine("Product sold!");
            cashSum += int.Parse(money);
            incomeSum += int.Parse(money);
            cash++;
        }
    }
    else
    { 
        if (int.Parse(money) < 10) Console.WriteLine("Error in transaction!");
        else
        {
            Console.WriteLine("Product sold!");
            cardSum += int.Parse(money);
            incomeSum += int.Parse(money);
            card++;
        }
    }
    if (needSum <=  incomeSum)
    {
        Console.WriteLine($"Average CS: {(double)cashSum / cash:f2}");
        Console.WriteLine($"Average CC: {(double)cardSum / card:f2}");
        break;
    }
}
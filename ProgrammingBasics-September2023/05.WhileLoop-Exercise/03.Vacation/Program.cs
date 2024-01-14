double moneyForExcursion = double.Parse(Console.ReadLine());
double bankacount = double.Parse(Console.ReadLine());
double dayseSpendmoney = 0;
int totalDayse = 0;
while (true)
{
    string spendOrSave = Console.ReadLine();
    double income = double.Parse(Console.ReadLine());
    totalDayse++;
    if (spendOrSave == "save")
    {
        bankacount += income;
        dayseSpendmoney = 0;
    }
    else
    {
        dayseSpendmoney++;
        bankacount -= income;
    }
    if (bankacount < 0) bankacount = 0;
    if (dayseSpendmoney == 5)
    {
        Console.WriteLine("You can't save the money.");
        Console.WriteLine($"{totalDayse}");
        break;
    }
    if (moneyForExcursion <= bankacount)
    {
        Console.WriteLine($"You saved the money for {totalDayse} days.");
        break;
    }
}

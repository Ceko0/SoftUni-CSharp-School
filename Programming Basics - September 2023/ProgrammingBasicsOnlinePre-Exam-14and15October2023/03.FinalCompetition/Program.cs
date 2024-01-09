int dancer = int.Parse(Console.ReadLine());
double points = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
string place = Console.ReadLine();

double finalMoney = 0;

if (place == "Bulgaria")
{
    finalMoney = dancer * points;

    if (season == "summer")
    {
        finalMoney *= 0.95;
    }
    else if (season == "winter")
    {
        finalMoney *= 0.92;
    }

}
else if (place == "Abroad")
{
    finalMoney = (dancer * points) *1.50;

    if (season == "summer")
    {
        finalMoney *= 0.90;
    }
    else if (season == "winter")
    {
        finalMoney *= 0.85;
    }

}
double moneyForCharity = finalMoney * 0.75;
double moneyForPerson = (finalMoney - moneyForCharity) / dancer;

Console.WriteLine($"Charity - {moneyForCharity:f2}");
Console.WriteLine($"Money per dancer - {moneyForPerson:f2}");

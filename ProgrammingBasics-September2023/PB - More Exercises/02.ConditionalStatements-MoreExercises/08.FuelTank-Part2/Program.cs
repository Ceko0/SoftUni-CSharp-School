string gasolin = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
string card = Console.ReadLine();
double finalPrice = 0;
if (card == "Yes")
{
    if (quantity >= 20 && quantity <= 25)
    {
        switch (gasolin)
        {
            case "Gas": finalPrice = quantity * (0.93 - 0.08); break;
            case "Gasoline": finalPrice = quantity * (2.22 - 0.18); break;
            case "Diesel": finalPrice = quantity * (2.33 - 0.12); break;
        }
        finalPrice *= 0.92;
    }
    else if (quantity > 25)
    {
        switch (gasolin)
        {
            case "Gas": finalPrice = quantity * (0.93 - 0.08); break;
            case "Gasoline": finalPrice = quantity * (2.22 - 0.18); break;
            case "Diesel": finalPrice = quantity * (2.33 - 0.12); break;
        }
        finalPrice *= 0.90;
    }
}
else
{
    if (quantity >= 20 && quantity <= 25)
    {
        switch (gasolin)
        {
            case "Gas": finalPrice = quantity * 0.93; break;
            case "Gasoline": finalPrice = quantity * 2.22; break;
            case "Diesel": finalPrice = quantity * 2.33; break;
        }
        finalPrice *= 0.92;
    }
    else if (quantity > 25)
    {
        switch (gasolin)
        {
            case "Gas": finalPrice = quantity * 0.93; break;
            case "Gasoline": finalPrice = quantity * 2.22; break;
            case "Diesel": finalPrice = quantity * 2.33; break;
        }
        finalPrice *= 0.90;
    }
    else 
    {
        switch (gasolin)
        {
            case "Gas": finalPrice = quantity * 0.93; break;
            case "Gasoline": finalPrice = quantity * 2.22; break;
            case "Diesel": finalPrice = quantity * 2.33; break;
        }
    }
}
Console.WriteLine($"{finalPrice:f2} lv.");
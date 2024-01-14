int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int fishman = int.Parse(Console.ReadLine());
double finalPrice = 0;
switch (season)
{
    case "Spring": finalPrice = 3000;
        break;
    case "Summer":
    case "Autumn": finalPrice = 4200;
        break;
    case "Winter": finalPrice = 2600;
        break;
}
if (fishman <= 6) finalPrice *= 0.90;
else if (fishman <= 11) finalPrice *= 0.85;
else finalPrice *= 0.75;
if (fishman % 2 == 0 && season != "Autumn") finalPrice *= 0.95;
if (budget >= finalPrice) Console.WriteLine($"Yes! You have {budget - finalPrice:f2} leva left.");
else Console.WriteLine($"Not enough money! You need {finalPrice - budget:f2} leva.");
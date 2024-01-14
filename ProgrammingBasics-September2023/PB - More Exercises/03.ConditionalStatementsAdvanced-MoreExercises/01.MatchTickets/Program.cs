double budget = double.Parse(Console.ReadLine());
string category  = Console.ReadLine();
int group = int.Parse(Console.ReadLine());

double moneyLeft = 0;
double moneyForTicket = 0;

if (group <= 4) moneyLeft = budget * 0.25;
else if (group <= 9) moneyLeft = budget * 0.40;
else if (group <= 24) moneyLeft = budget * 0.50;
else if (group <= 49) moneyLeft = budget * 0.60;
else moneyLeft = budget * 0.75;

if (category == "VIP") moneyForTicket = group * 499.99;
else if (category == "Normal") moneyForTicket = group * 249.99;

if (moneyLeft <= moneyForTicket) Console.WriteLine($"Not enough money! You need {moneyForTicket - moneyLeft:f2} leva.");
else Console.WriteLine($"Yes! You have {moneyLeft - moneyForTicket:f2} leva left.");
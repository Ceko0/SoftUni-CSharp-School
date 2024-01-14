double budget = double.Parse(Console.ReadLine());
int extras = int.Parse(Console.ReadLine());
double clothing = double.Parse(Console.ReadLine());
double decor =budget * 0.10;
double clothingPrice = extras * clothing;
if (extras > 150 )
{
    clothingPrice *= 0.90;
}
double totalPrice = decor + clothingPrice;
if (budget >= totalPrice)
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {budget - totalPrice:f2} leva left.");
}
else
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {totalPrice - budget:f2} leva more.");
}
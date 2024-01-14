using System.Globalization;

string flowers = Console.ReadLine();
int quantity = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());
double totalPrice = 0;

    switch (flowers)
{
    case "Roses":
        totalPrice = quantity * 5.00;
        if (quantity > 80) totalPrice *= 0.90;
        break;
    case "Dahlias":
        totalPrice = quantity * 3.80;
        if (quantity > 90) totalPrice *= 0.85;
        break; 
    case "Tulips":
        totalPrice = quantity * 2.80;
        if (quantity > 80) totalPrice *= 0.85;
        break;
    case "Narcissus":
        totalPrice = quantity * 3.00;
        if (quantity < 120) totalPrice *= 1.15;
        break;
    case "Gladiolus":
        totalPrice = quantity * 2.50;
        if (quantity < 80) totalPrice *= 1.20;
        break;
}
if (budget >= totalPrice) Console.WriteLine($"Hey, you have a great garden with {quantity} {flowers} and {budget - totalPrice:f2} leva left.");
else Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");

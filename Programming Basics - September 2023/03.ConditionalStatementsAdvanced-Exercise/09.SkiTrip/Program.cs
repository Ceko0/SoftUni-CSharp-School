int days = int.Parse(Console.ReadLine());
string room = Console.ReadLine();
string evaluation = Console.ReadLine();
days -= 1;
double price = 0; 

if (room == "room for one person")
{
    price = 18.00 * days;
}
else if (room == "apartment")
{
    price = 25.00 * days;
    if (days <= 9) price *= 0.70;
    else if (days <= 14) price *= 0.65;
    else price *= 0.50;
}
else if (room == "president apartment") 
{
    price = 35.00 * days;
    if (days <= 9) price *= 0.90;
    else if (days <= 14) price *= 0.85;
    else price *= 0.80;
}
if (evaluation == "positive") price *= 1.25;
else if (evaluation == "negative") price *= 0.90;
Console.WriteLine($"{price:f2}");
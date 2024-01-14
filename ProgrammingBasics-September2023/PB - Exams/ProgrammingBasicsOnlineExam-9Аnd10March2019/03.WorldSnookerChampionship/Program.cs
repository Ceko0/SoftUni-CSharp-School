string stage = Console.ReadLine();
string ticket  = Console.ReadLine();
int number = int.Parse(Console.ReadLine());
string picture  = Console.ReadLine();

double ticketPrice = 0;
double totalPrice = 0;
if (stage == "Quarter final")
{
    if (ticket == "Standard") ticketPrice = number * 55.50;
    else if (ticket == "Premium") ticketPrice = number * 105.20;
    else if (ticket == "VIP") ticketPrice = number * 118.90;
    totalPrice = ticketPrice;
}
else if (stage == "Semi final")
{
    if (ticket == "Standard") ticketPrice = number * 75.88;
    else if (ticket == "Premium") ticketPrice = number * 125.22;
    else if (ticket == "VIP") ticketPrice = number * 300.40;
    totalPrice = ticketPrice;
}
else if (stage == "Final")
{
    if (ticket == "Standard") ticketPrice = number * 110.10;
    else if (ticket == "Premium") ticketPrice = number * 160.66;
    else if (ticket == "VIP") ticketPrice = number * 400.00;
    totalPrice = ticketPrice;
}
if (ticketPrice > 4000) totalPrice = ticketPrice * 0.75;
else if (ticketPrice > 2500) totalPrice = ticketPrice * 0.90;
if (picture == "Y" && ticketPrice < 4000) totalPrice += 40 * number;

Console.WriteLine($"{totalPrice:f2}");
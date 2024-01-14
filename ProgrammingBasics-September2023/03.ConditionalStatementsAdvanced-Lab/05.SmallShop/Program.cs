//град / продукт  coffee   water 	beer	sweets	peanuts
//Sofia         	0.50	0.80	1.20	1.45	1.60
//Plovdiv        	0.40	0.70	1.15	1.30	1.50
//Varna         	0.45	0.70	1.10	1.35	1.55
using System.Security.Principal;

string product = Console.ReadLine();
string city  = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
double totalPrice = 0;
if (city == "Sofia")
{
    switch (product)
    {
        case "coffee": totalPrice = quantity * 0.50; break;
        case "water": totalPrice = quantity * 0.80; break;
        case "beer": totalPrice = quantity * 1.20; break;
        case "sweets": totalPrice = quantity * 1.45; break;
        case "peanuts": totalPrice = quantity * 1.60; break;
    }

}
else if (city == "Plovdiv")
{
    switch (product)
    {
        case "coffee": totalPrice = quantity * 0.40; break;
        case "water": totalPrice = quantity * 0.70; break;
        case "beer": totalPrice = quantity * 1.15; break;
        case "sweets": totalPrice = quantity * 1.30; break;
        case "peanuts": totalPrice = quantity * 1.50; break;
    }
}
else if (city == "Varna")
{
    switch (product)
    {
        case "coffee": totalPrice = quantity * 0.45; break;
        case "water": totalPrice = quantity * 0.70; break;
        case "beer": totalPrice = quantity * 1.10; break;
        case "sweets": totalPrice = quantity * 1.35; break;
        case "peanuts": totalPrice = quantity * 1.55; break;
    }
}
Console.WriteLine(totalPrice);
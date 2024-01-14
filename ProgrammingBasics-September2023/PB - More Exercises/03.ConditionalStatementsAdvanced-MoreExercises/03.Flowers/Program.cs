//Сезон             Хризантеми	    Рози        	Лалета
//Пролет / Лято 	2.00 лв./бр.	4.10 лв./бр.	2.50 лв./бр.
//Есен / Зима   	3.75 лв./бр.	4.50 лв./бр.	4.15 лв./бр.

using System.Security.Principal;

int chrysanthemums = int.Parse(Console.ReadLine());
    int roses = int.Parse(Console.ReadLine());
    int tulips  = int.Parse(Console.ReadLine());
    string season =  Console.ReadLine();
    string day = Console.ReadLine();

 double totalPrice = 0;
switch (season)
{
    case "Spring":
    case "Summer":
        totalPrice = chrysanthemums * 2.00 + roses * 4.10 + tulips * 2.50;
        if (day == "Y") totalPrice *= 1.15;
        if (tulips > 7) totalPrice *= 0.95;
        if (20 < chrysanthemums + roses + tulips) totalPrice *= 0.80;
        break;
    case "Autumn":
    case "Winter":
        totalPrice = chrysanthemums * 3.75 + roses * 4.50 + tulips * 4.15;
        if (day == "Y") totalPrice *= 1.15;
        if (roses > 10) totalPrice *= 0.90;
        if (20 < chrysanthemums + roses + tulips) totalPrice *= 0.80;
        break;
        
}
Console.WriteLine($"{totalPrice + 2:f2}");


//Сезон                 Хризантеми	    Рози	            Лалета
//Пролет / Лято     	2.00 лв./бр.	4.10 лв./бр.	2.50 лв./бр.
//Есен / Зима	        3.75 лв./бр.	4.50 лв./бр.	4.15 лв./бр.
//[Spring, Summer, Аutumn, Winter]

int chrysanthemums = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int tulips = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
string howyday = Console.ReadLine();
double totalPrice = 0;

(totalPrice) = (season) switch
{
    "Spring" or "Summer" => chrysanthemums * 2.00 + roses * 4.10 + tulips * 2.50,
    "Autumn" or "Winter" => chrysanthemums * 3.75 + roses * 4.50 + tulips * 4.15,
};
if (howyday == "Y") totalPrice *= 1.15;
if (roses >= 10 && season == "Winter") totalPrice *= 0.90;
if (tulips > 7 && season == "Spring") totalPrice *= 0.95;
if (roses + tulips + chrysanthemums > 20) totalPrice *= 0.80;


Console.WriteLine($"{totalPrice + 2:f2}");
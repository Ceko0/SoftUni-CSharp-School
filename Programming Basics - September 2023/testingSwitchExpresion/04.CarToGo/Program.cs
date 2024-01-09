
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string classType = "";
string carType = "";
double carPrice = 0;

(classType , carType , carPrice) = (budget , season) switch
{
    (<= 100 , "Summer" )=> ("Economy class", "Cabrio" , budget * 0.35),
    (<= 100 , "Winter" )=> ("Economy class", "Jeep", budget * 0.65),
    (<= 500 , "Summer" )=> ("Compact class", "Cabrio" , budget * 0.45),
    (<= 500 , "Winter" )=> ("Compact class", "Jeep", budget * 0.80),
    (>  500 , "Summer" or "Winter" )=> ("Luxury class", "Jeep", budget * 0.90),
};

Console.WriteLine($"{classType}");
Console.WriteLine($"{carType} - {carPrice:f2}");
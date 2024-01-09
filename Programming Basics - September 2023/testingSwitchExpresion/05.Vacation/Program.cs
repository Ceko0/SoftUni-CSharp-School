double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string location = "";
string place = "";
double price = 0;

(place , location , price) = (budget , season ) switch
{
    ( <= 1000, "Summer") => ("Camp", "Alaska" , budget * 0.65),
    ( <= 1000, "Winter") => ("Camp", "Morocco", budget * 0.45),
    ( <= 3000, "Summer") => ("Hut" , "Alaska" , budget * 0.80),
    ( <= 3000, "Winter") => ("Hut" , "Morocco", budget * 0.60),
    ( >  3000, "Summer") => ("Hotel", "Alaska" , budget * 0.90),
    ( >  3000, "Winter") => ("Hotel", "Morocco", budget * 0.90),
};

Console.WriteLine($"{location} - {place} - {price:f2}");
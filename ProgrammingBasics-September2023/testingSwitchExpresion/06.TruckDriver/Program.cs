
string season = Console.ReadLine();
double kilometers = int.Parse(Console.ReadLine());

double paiment = 0;

paiment = (kilometers , season) switch
{
    ( <= 5000, "Spring" or "Autumn") => (kilometers * 0.75 * 4) * 0.90,
    ( <= 5000, "Summer") => (kilometers * 0.90 * 4) * 0.90,
    ( <= 5000, "Winter") => (kilometers * 1.05 * 4) * 0.90,
    ( <= 10000, "Spring" or "Autumn") => (kilometers * 0.95 * 4) * 0.90,
    ( <= 10000, "Summer") => (kilometers * 1.10 * 4) * 0.90,
    ( <= 10000, "Winter") => (kilometers * 1.25 * 4) * 0.90,
    ( <= 20000, "Spring" or "Autumn" or "Summer" or "Winter") => (kilometers * 1.45 * 4) * 0.90,
};

Console.WriteLine($"{paiment :f2}");
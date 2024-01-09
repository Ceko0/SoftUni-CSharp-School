
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

if (budget <= 1000)
{
    if (season == "Summer") Console.WriteLine($" Alaska - Camp - {budget * 0.65:f2}");
    else if (season == "Winter") Console.WriteLine($" Morocco - Camp - {budget * 0.45:f2}");
}
else if (budget <= 3000)
{
    if (season == "Summer") Console.WriteLine($" Alaska - Hut - {budget * 0.80:f2}");
    else if (season == "Winter") Console.WriteLine($" Morocco - Hut - {budget * 0.60:f2}");
}
else 
{
    if (season == "Summer") Console.WriteLine($" Alaska - Hotel - {budget * 0.90:f2}");
    else if (season == "Winter") Console.WriteLine($" Morocco - Hotel - {budget * 0.90:f2}");
}
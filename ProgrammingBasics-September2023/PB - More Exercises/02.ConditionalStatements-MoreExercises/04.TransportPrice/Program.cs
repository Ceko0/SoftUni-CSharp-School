int kilometers = int.Parse(Console.ReadLine());
string day = Console.ReadLine();
if (kilometers < 20)
{
    switch (day)
    {
        case "day": Console.WriteLine($"{0.7 + kilometers * 0.79:f2}"); break;
            
        case "night": Console.WriteLine($"{0.7 + kilometers * 0.9:f2}"); break;
    }
}
else if (kilometers < 100)
{
    Console.WriteLine($"{kilometers * 0.09:f2}");
}
else
{
    Console.WriteLine($"{kilometers * 0.06:f2}");
}
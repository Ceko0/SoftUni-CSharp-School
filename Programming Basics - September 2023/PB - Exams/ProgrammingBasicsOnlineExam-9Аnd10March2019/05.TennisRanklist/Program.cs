int turnaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());
int curentPoints = 0;
int winturnaments = 0;
for (int i = 0; i < turnaments; i++)
{
    string stage = Console.ReadLine();
    if (stage == "W")
    {
        startingPoints += 2000;
        curentPoints += 2000;
        winturnaments++;
    }
    else if (stage == "F")
    {
        startingPoints += 1200;
        curentPoints += 1200;
    }
    else if (stage == "SF")
    {
        startingPoints += 720;
        curentPoints += 720;
    }
}
Console.WriteLine($"Final points: {startingPoints}");
Console.WriteLine($"Average points: {Math.Floor((double)curentPoints / turnaments)}");
Console.WriteLine($"{((double)winturnaments / turnaments)*100:f2}%");

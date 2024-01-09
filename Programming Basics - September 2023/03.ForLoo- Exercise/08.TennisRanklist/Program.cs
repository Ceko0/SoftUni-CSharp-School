//W - ако е победител получава 2000 точки
//F - ако е финалист получава 1200 точки
//SF - ако е полуфиналист получава 720 точки
int number = int.Parse(Console.ReadLine());
int startingPoints =  int.Parse(Console.ReadLine());
int totalPoints = 0;
int W = 0;
int F = 0;
int SF = 0;
for (int i = 0; i < number; i++)
{ 
    string stage = Console.ReadLine();
    
    if (stage == "W")
    {
        W++;
        totalPoints += 2000;
    }
    else if (stage == "F")
    {
        F++;
        totalPoints += 1200;
    }
    else if (stage == "SF")
    {
        SF++;
        totalPoints += 720;
    }
}
Console.WriteLine($"Final points: {totalPoints + startingPoints}");
Console.WriteLine($"Average points: {Math.Floor((double)totalPoints / number)}");
Console.WriteLine($"{100.00*W/number:f2}%");
string playerName = Console.ReadLine();
int startingpoints = 301;
int count = 0;
int count2 = 0;

while (true)
{ 
    string field  = Console.ReadLine();
    if (field == "Retire")
    {
        Console.WriteLine($"{playerName} retired after {count} unsuccessful shots.");
        break;
    }
    int points  = int.Parse(Console.ReadLine());
    if (field == "Double") points *= 2;
    else if (field == "Triple") points *= 3;
    if (startingpoints - points == 0)
    {
        count2++;
        Console.WriteLine($"{playerName} won the leg with {count2} shots.");
        break;
    }
    else if (startingpoints - points < 0)
    {
        count++;
        continue;
    }
    else
    { 
        startingpoints -= points;
        count2++;
    }

}

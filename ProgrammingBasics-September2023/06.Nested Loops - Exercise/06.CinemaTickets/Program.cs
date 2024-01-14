
    int student = 0;
    int standard = 0;
    int kid = 0;
    int totaltickets = 0;
   

while (true)
{
    string moveName = Console.ReadLine();
    if (moveName == "Finish") break;
    int freePlace = int.Parse(Console.ReadLine());
    string ticket = "";
    int curentTickets = 0;

    for (int i = 0; i < freePlace; i++)
    {
        ticket = Console.ReadLine();
        if (ticket == "End") break;
        if (ticket == "student") student++;
        else if (ticket == "standard") standard++;
        else if (ticket == "kid") kid++;
        totaltickets++;
        curentTickets++;

    }
    Console.WriteLine($"{moveName} - {(double)curentTickets / freePlace * 100:f2}% full.");
}

Console.WriteLine($"Total tickets: {totaltickets}");
Console.WriteLine($"{(double)student / totaltickets * 100:f2}% student tickets.");
Console.WriteLine($"{(double)standard / totaltickets * 100:f2}% standard tickets.");
Console.WriteLine($"{(double)kid / totaltickets * 100:f2}% kids tickets.");

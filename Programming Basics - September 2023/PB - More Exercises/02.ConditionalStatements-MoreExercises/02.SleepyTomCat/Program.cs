int offdays = int.Parse(Console.ReadLine());
int workdays = (365 - offdays) * 63;
offdays = offdays * 127;
int totalminuts = offdays + workdays;
if (totalminuts > 30000)
{
    int h = (totalminuts - 30000) / 60;
    int m = (totalminuts - 30000) % 60;
    Console.WriteLine("Tom will run away");
    Console.WriteLine($"{h} hours and {m} minutes more for play");
}
else
{
    int h = (30000 - totalminuts) / 60;
    int m = (30000 - totalminuts) % 60;
    Console.WriteLine("Tom sleeps well");
    Console.WriteLine($"{h} hours and {m} minutes less for play");
}
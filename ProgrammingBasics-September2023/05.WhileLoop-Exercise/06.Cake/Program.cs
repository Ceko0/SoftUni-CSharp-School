int pace1 = int.Parse(Console.ReadLine());
int pace2 = int.Parse(Console.ReadLine());
int totalPace = pace1 * pace2;

while (true)
{
    string income = Console.ReadLine();
    if (income == "STOP")
    {
        Console.WriteLine($"{totalPace} pieces are left.");
        break;
    }
    totalPace -= int.Parse(income);
    if (totalPace <= 0)
    {
        Console.WriteLine($"No more cake left! You need {Math.Abs(totalPace)} pieces more.");
        break;
    }

}
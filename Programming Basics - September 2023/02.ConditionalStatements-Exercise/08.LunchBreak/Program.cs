string moveName = Console.ReadLine();
int move = int.Parse(Console.ReadLine());
double breack =  double.Parse(Console.ReadLine());
double needtime = breack * 1 / 8;
needtime += breack * 1/4;
double timeLeft = breack - needtime;
if (timeLeft >= move)
{
    Console.WriteLine($"You have enough time to watch {moveName} and left with {Math.Ceiling(timeLeft - move)} minutes free time.");
}
else 
{
    Console.WriteLine($"You don't have enough time to watch {moveName}, you need {Math.Ceiling( move - timeLeft)} more minutes.");
}

string actorName = Console.ReadLine();
double academyPoints = double.Parse(Console.ReadLine());
int evaluativeNumber = int.Parse(Console.ReadLine());
double totalPoints = 0;
for (int i = 0; i < evaluativeNumber; i++)
{
    string evaluativeName = Console.ReadLine();
    double evaluativePoints = double.Parse(Console.ReadLine());
    academyPoints += evaluativePoints * evaluativeName.Length /2;
    if (academyPoints >= 1250.5)
    {
        Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {academyPoints:f1}!");
        break;
    }
}
if  (academyPoints < 1250.5) Console.WriteLine($"Sorry, {actorName} you need {1250.5 - academyPoints:f1} more!");
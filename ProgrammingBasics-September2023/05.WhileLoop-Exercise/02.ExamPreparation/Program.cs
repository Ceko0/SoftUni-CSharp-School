int needBadGrades = int.Parse(Console.ReadLine());
int badGrades = 0;
int gradesSum = 0;
int gradesCount = 0;
string lastTask = "";
while (true)
{
    string taskName = Console.ReadLine();
    if (taskName == "Enough")
    {
        Console.WriteLine($"Average score: {(double)gradesSum / (gradesCount + badGrades):f2}");
        Console.WriteLine($"Number of problems: {badGrades + gradesCount}");
        Console.WriteLine($"Last problem: {lastTask}");
        break;
    }
    int taskGrades = int.Parse(Console.ReadLine());
    gradesCount++;
    if (taskGrades <= 4)
    {
        badGrades++;
        gradesCount--;
    }
    gradesSum += taskGrades;

    if (badGrades == needBadGrades)
    {
        Console.WriteLine($"You need a break, {needBadGrades} poor grades.");
        break;
    }
    lastTask = taskName;
}
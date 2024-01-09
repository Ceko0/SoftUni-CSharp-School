string studenName = Console.ReadLine();
double assessment = 0;
int scoolClass = 0;
int badAssessment = 0;
double income = double.Parse(Console.ReadLine());

while (true)
{

    if (income >= 4)
    {
        assessment += income;
        scoolClass++;
    }
    else
    {
        badAssessment++;
        if (badAssessment >= 2)
        {
            Console.WriteLine($"{studenName} has been excluded at {scoolClass + 1} grade");
            break;
        }

    }
    if (scoolClass == 12)
    {
        Console.WriteLine($"{studenName} graduated. Average grade: {assessment / 12:f2}");
        break;
    }
    income = double.Parse(Console.ReadLine());
}
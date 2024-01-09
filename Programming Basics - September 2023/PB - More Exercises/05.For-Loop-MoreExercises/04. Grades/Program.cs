int studentsCounter = int.Parse(Console.ReadLine());
int TopCounter = 0;
int exellentCounter = 0;
int godCounter= 0;
int failCounter = 0;
double averageCounter = 0;

for (int i = 1; i <= studentsCounter; i++)
{
    double studentsScore = double.Parse(Console.ReadLine());
    _ = studentsScore <= 2.99 ? failCounter++ : studentsScore <= 3.99 ? godCounter++ : studentsScore <= 4.99 ? exellentCounter++ : TopCounter++;
    averageCounter += studentsScore;
}
Console.WriteLine($"Top students: {(double)TopCounter / studentsCounter * 100 :f2}%");
Console.WriteLine($"Between 4.00 and 4.99: {(double)exellentCounter / studentsCounter * 100 :f2}%");
Console.WriteLine($"Between 3.00 and 3.99: {(double)godCounter / studentsCounter * 100 :f2}%");
Console.WriteLine($"Fail: {(double)failCounter / studentsCounter * 100 :f2}%");
Console.WriteLine($"Average: {averageCounter / studentsCounter :f2}");
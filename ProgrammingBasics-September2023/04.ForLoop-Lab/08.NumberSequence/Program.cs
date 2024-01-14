int n = int.Parse(Console.ReadLine());
int maxNumb = int.MinValue;
int minNumb = int.MaxValue;
for (int i = 0; i < n; i++)
{
    int income = int.Parse(Console.ReadLine());
    if (income < minNumb) minNumb = income;
    if (income > maxNumb) maxNumb = income;
}
Console.WriteLine($"Max number: {maxNumb}");
Console.WriteLine($"Min number: {minNumb}");
using System.Diagnostics.Metrics;

int n = int.Parse(Console.ReadLine());

int counter1 = 0;
int counter2 = 0;
int counter3 = 0;
int counter4 = 0;
int counter5 = 0;
for (int i = 0; i < n; i++) 
{
    int number = int.Parse(Console.ReadLine());
    switch (number)
    {
        case < 200: counter1++;
            break;
        case < 400: counter2++;
            break;
        case < 600: counter3++;
            break;
        case < 800: counter4++;
            break;
        case >= 800: counter5++;
            break;
    }
}
Console.WriteLine($"{100.00 * counter1 / n:f2}%");
Console.WriteLine($"{100.00 * counter2 / n:f2}%");
Console.WriteLine($"{100.00 * counter3 / n:f2}%");
Console.WriteLine($"{100.00 * counter4 / n:f2}%");
Console.WriteLine($"{100.00 * counter5 / n:f2}%");
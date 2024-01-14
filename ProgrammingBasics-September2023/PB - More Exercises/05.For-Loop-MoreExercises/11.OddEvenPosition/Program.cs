
using System.Threading.Channels;

int counter = int.Parse(Console.ReadLine());

double oddSum = 0;
double evenSum = 0;
double oddMin = double.MaxValue;
double evenMin = double.MaxValue;
double oddMax = double.MinValue;
double evenMax = double.MinValue;

for (int i = 1; i <= counter; i++)
{
    double income = double.Parse(Console.ReadLine());
    if (i % 2 == 1)
    { 
        oddSum += income;
        if (oddMin > income) oddMin = income;
        if (oddMax < income) oddMax = income;    
    }
    else
    {
        evenSum += income;
        if (evenMin > income) evenMin = income;
        if (evenMax < income) evenMax = income;
    }
}
Console.WriteLine($"OddSum={oddSum:f2},");
if (oddMin == double.MaxValue) Console.WriteLine("OddMin=No,");
else Console.WriteLine($"OddMin={oddMin:f2},");
if (oddMax == double.MinValue) Console.WriteLine("OddMax=No,");
else Console.WriteLine($"OddMax={oddMax:f2},");
Console.WriteLine($"EvenSum={evenSum:f2},");
if (evenMin == double.MaxValue) Console.WriteLine("EvenMin=No,");
else Console.WriteLine($"EvenMin={evenMin:f2},");
if (evenMax == double.MinValue) Console.WriteLine("EvenMax=No");
else Console.WriteLine($"EvenMax={evenMax:f2}");

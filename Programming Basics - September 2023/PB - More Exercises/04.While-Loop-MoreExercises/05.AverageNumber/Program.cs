int counter = int.Parse(Console.ReadLine());

int sumOfNumbers = 0;

for (int i = 1; i <= counter; i++)
{
    sumOfNumbers += int.Parse(Console.ReadLine());
}
Console.WriteLine($"{sumOfNumbers / (double)counter:f2}");
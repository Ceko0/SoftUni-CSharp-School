int n = int.Parse(Console.ReadLine());
int curentNumber = 1;
int sum = 1;
for (int i = 1; i < n; i+= 1 )
{
    Console.WriteLine(curentNumber);
    curentNumber += 2;
    sum += curentNumber;
}
Console.WriteLine(curentNumber);
Console.WriteLine($"Sum: {sum}");
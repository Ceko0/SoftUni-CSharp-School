int cargos = int.Parse(Console.ReadLine());

int busPrice = 0;
int busLoad = 0; 
int truckPrice = 0;
int truckLoad = 0; 
int trainPrice = 0;
int trainLoad = 0;
int totalLoad = 0;

for (int i = 1; i <= cargos; i++)
{
    int loadWeight = int.Parse(Console.ReadLine());
    _ = loadWeight <= 3 ? busPrice += 200 * loadWeight : loadWeight <= 11 ? truckPrice += 175 * loadWeight : trainPrice += 120 * loadWeight;
    _ = loadWeight <= 3 ? busLoad += loadWeight : loadWeight <= 11 ? truckLoad += loadWeight : trainLoad += loadWeight;
    totalLoad += loadWeight;
}

Console.WriteLine($"{(double)(busPrice + truckPrice + trainPrice) / totalLoad:f2}");
Console.WriteLine($"{(double)busLoad / totalLoad * 100.00:f2}%");
Console.WriteLine($"{(double)truckLoad / totalLoad * 100.00:f2}%");
Console.WriteLine($"{(double)trainLoad / totalLoad * 100.00:f2}%");

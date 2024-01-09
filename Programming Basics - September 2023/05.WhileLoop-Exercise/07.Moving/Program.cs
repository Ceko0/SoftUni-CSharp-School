int width = int.Parse(Console.ReadLine());
int length = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());
int freeSpace = width * length * height;
while (true)
{
    string income = Console.ReadLine();

    if (income == "Done")
    {
        Console.WriteLine($"{freeSpace} Cubic meters left.");
        break;
    }
    freeSpace -= int.Parse(income);
    if (freeSpace <= 0)
    {
        Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
        break;
    }

}
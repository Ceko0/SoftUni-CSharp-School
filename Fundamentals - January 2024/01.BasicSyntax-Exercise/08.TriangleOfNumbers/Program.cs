
int endingNumber = int.Parse(Console.ReadLine());

for (int i = 1; i <= endingNumber; i++)
{
	for (int j = 0; j < i; j++)
	{
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}

int n = int.Parse(Console.ReadLine());
int counter = 0;

for (int i = 0; i <= n; i++)
{

	for (int j = counter; j < n; j++)
	{
		Console.Write(" ");
	}	
	for (int k = counter; k > 0; k--)
	{
        Console.Write("*");
    }
	Console.Write(" | ");
	for (int l = 0; l < counter; l++)
	{
        Console.Write("*");
    }
    Console.WriteLine();
    counter++;
}
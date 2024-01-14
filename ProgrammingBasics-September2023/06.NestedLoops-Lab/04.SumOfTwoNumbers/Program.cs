int startingNumb = int.Parse(Console.ReadLine());
int endingNumb  = int.Parse(Console.ReadLine());
int magicNumb  = int.Parse(Console.ReadLine());
bool stop = false;
int counter = 0;
int counter2 = 0;
for (int i = startingNumb; i <= endingNumb;	i++)
{
	for (int j = startingNumb; j <= endingNumb; j++)
	{
		counter++;
		if (magicNumb == i + j)
		{
		Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNumb})");
		counter2++;
		stop = true;
			break;			
		}
    }
	if (stop) break;
}
if (counter2 == 0)
{
    Console.WriteLine($"{counter} combinations - neither equals {magicNumb}");
}
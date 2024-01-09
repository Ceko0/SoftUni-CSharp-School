int jury = int.Parse(Console.ReadLine());
double finalScore = 0;
int counter = 0;
while (true)
{

	string presentation = Console.ReadLine();
    if ( presentation == "Finish")
    {
        Console.WriteLine($"Student's final assessment is {finalScore/ counter:f2}." );
        break;
    }
    double score = 0;
	

    for (int i = 0; i < jury; i++)
	{
		score += double.Parse(Console.ReadLine());

	}
    counter++;
    double totalScore = score / jury;
	finalScore += totalScore;
    Console.WriteLine($"{presentation} - {totalScore:f2}.");
}




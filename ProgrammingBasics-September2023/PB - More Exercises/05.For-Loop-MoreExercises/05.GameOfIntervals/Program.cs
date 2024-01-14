int counter = int.Parse(Console.ReadLine());
double score = 0;
int firstIntervalCounter = 0;
int secondIntervalCounter = 0;
int thirthIntervalCounter = 0;
int forthIntervalCounter = 0;
int fifthIntervalCounter = 0;
double invalidNumberCounter = 0;

for (int i = 0; i < counter; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (number < 0 || number >= 51)
    {
        score /= 2;
        invalidNumberCounter++;
    }
    else if (number >= 0 && number <= 9)
    {
        score += number *0.20;
        firstIntervalCounter++;
    }
    else if (number <= 19)
    {
        score += number * 0.30;
        secondIntervalCounter++;
    }
    else if (number <= 29)
    {
        score += number * 0.40;
        thirthIntervalCounter++;
    }
    else if (number <= 39)
    {
        score += 50;
        forthIntervalCounter++;
    }
    else if (number <= 50)
    {
        score += 100;
        fifthIntervalCounter++;
    }
}


Console.WriteLine($"{score:f2}");
Console.WriteLine($"From 0 to 9: {(double)firstIntervalCounter / counter * 100 :f2}%");
Console.WriteLine($"From 10 to 19: {(double)secondIntervalCounter / counter * 100 :f2}%");
Console.WriteLine($"From 20 to 29: {(double)thirthIntervalCounter / counter * 100 :f2}%");
Console.WriteLine($"From 30 to 39: {(double)forthIntervalCounter / counter * 100 :f2}%");
Console.WriteLine($"From 40 to 50: {(double)fifthIntervalCounter / counter * 100 :f2}%");
Console.WriteLine($"Invalid numbers: {(double)invalidNumberCounter / counter * 100 :f2}%");
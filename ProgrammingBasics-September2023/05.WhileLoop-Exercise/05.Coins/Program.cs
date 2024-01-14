double instead = double.Parse(Console.ReadLine()) * 100;

int coins = 0;
while (true)
{
    if (instead >= 200)
    {
        instead -= 200;
        coins++;
    }
    else if (instead >= 100)
    {
        instead -= 100;
        coins++;
    }
    else if (instead >= 50)
    {
        instead -= 50;
        coins++;
    }
    else if (instead >= 20)
    {
        instead -= 20;
        coins++;
    }
    else if (instead >= 10)
    {
        instead -= 10;
        coins++;
    }
    else if (instead >= 5)
    {
        instead -= 5;
        coins++;
    }
    else if (instead >= 2)
    {
        instead -= 2;
        coins++;
    }
    else if (instead >= 1)
    {
        instead -= 1;
        coins++;
    }
    else
    {
        instead *= 0;
        break;
    }
}
Console.WriteLine(coins);
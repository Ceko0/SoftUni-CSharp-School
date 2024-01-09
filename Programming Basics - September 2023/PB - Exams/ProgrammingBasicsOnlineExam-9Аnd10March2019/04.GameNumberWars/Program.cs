string firstPLayerName = Console.ReadLine();
string secondPLayerName = Console.ReadLine();

int firstPlayerScore = 0;
int secondPlayerScore = 0;
while (true)
{ 
    string firstcard = Console.ReadLine();
    if (firstcard == "End of game")
    {
        Console.WriteLine($"{firstPLayerName} has {firstPlayerScore} points");
        Console.WriteLine($"{secondPLayerName} has {secondPlayerScore} points");

        break;
    }
    string secondcard = Console.ReadLine();

    int first = int.Parse(firstcard);
    int second = int.Parse(secondcard);

    if (first > second)
    {
        firstPlayerScore += first - second;
    }
    else if (second > first)
    {
        secondPlayerScore += second - first;
    }
    else
    {
        int firstPlayerCard = int.Parse(Console.ReadLine());
        int secondPlayerCard = int.Parse(Console.ReadLine());
        if (firstPlayerCard > secondPlayerCard)
        {
            Console.WriteLine("Number wars!");
            Console.WriteLine($"{firstPLayerName} is winner with {firstPlayerScore} points");
            break;
        }
        else 
        {
            Console.WriteLine("Number wars!");
            Console.WriteLine($"{secondPLayerName} is winner with {secondPlayerScore} points");
            break;
        }
    }
}
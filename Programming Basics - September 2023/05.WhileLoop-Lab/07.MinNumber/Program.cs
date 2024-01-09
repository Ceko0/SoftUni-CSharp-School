int minNumber = int.MaxValue;
while (true)
{
    string income = Console.ReadLine();
    if (income == "Stop")
    {
        Console.WriteLine(minNumber);
        break;
    }
    int number = int.Parse(income);
    if (number < minNumber) minNumber = number;
}
int maxNumber = int.MinValue;
while (true)
{
    string income = Console.ReadLine();
    if (income == "Stop")
    {
        Console.WriteLine(maxNumber);
        break;
    }
    int number = int.Parse(income);
    if (number > maxNumber) maxNumber = number;
}

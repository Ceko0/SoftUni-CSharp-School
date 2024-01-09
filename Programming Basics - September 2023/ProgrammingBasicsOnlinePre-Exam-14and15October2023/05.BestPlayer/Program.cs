string bestPlayer = "";
int bestScore = 0;


while (true)
{
    string income = Console.ReadLine();
    if (income == "END") break;
    int incomeScore = int.Parse(Console.ReadLine());
    if (incomeScore > bestScore)
    { 
        bestScore = incomeScore;
        bestPlayer = income;
    }
    if (incomeScore >= 10) break;


}
Console.WriteLine($"{bestPlayer} is the best player!");
if (bestScore >= 3) Console.WriteLine($"He has scored {bestScore} goals and made a hat-trick !!!");
else Console.WriteLine($"He has scored {bestScore} goals.");
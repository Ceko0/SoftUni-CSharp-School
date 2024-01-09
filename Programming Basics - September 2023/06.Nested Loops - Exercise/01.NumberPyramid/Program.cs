int n = int.Parse(Console.ReadLine());
int curentNumber = 0;
bool itsBigerr = false;
for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= i; j++)
    {
        curentNumber++;
        Console.Write($"{curentNumber} ");
        if (curentNumber >= n)
        {
            itsBigerr = true;
            break;
        }
    }
    if (itsBigerr)
        break;
    Console.WriteLine();
}
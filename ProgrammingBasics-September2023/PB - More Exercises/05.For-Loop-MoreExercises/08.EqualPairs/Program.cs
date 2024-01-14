int counter = int.Parse(Console.ReadLine());
int maxDiff = 0;
int sum = int.Parse(Console.ReadLine()) + int.Parse(Console.ReadLine());
int previousSum = sum;
for (int i = 1; i < counter; i++)
{ 
    int firstNumber = int.Parse(Console.ReadLine());
    int secondNumber = int.Parse(Console.ReadLine());
    int curentSum = firstNumber + secondNumber;
    if (sum < curentSum)
    { 
        if (maxDiff < curentSum - previousSum)
        maxDiff=curentSum - previousSum;
    }
    else if (sum > curentSum) 
    {
        if (maxDiff < previousSum - curentSum)
        maxDiff = previousSum - curentSum;
    }
    previousSum = curentSum;
}
if (maxDiff == 0)
{
    Console.WriteLine($"Yes, value={sum}");
}
else
{
    Console.WriteLine($"No, maxdiff={maxDiff}");
}
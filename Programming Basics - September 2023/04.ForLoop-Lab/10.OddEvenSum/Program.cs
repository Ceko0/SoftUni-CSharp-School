int n = int.Parse(Console.ReadLine());
int evenSum = 0;
int oddSum = 0;
for (int i = 0; i < n; i++) 
{
    if (i % 2 == 1)
    evenSum += int.Parse(Console.ReadLine());
    else
    oddSum += int.Parse(Console.ReadLine());
}
if (oddSum == evenSum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {evenSum}");
}
else
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(oddSum - evenSum)}");
}
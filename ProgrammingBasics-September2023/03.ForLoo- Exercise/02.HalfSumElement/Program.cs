int n = int.Parse(Console.ReadLine());
int maxnumber = int.MinValue;
int sum = 0;
for (int i = 0; i < n; i++)
{
    int numb = int.Parse(Console.ReadLine());
    sum += numb;
    if (numb > maxnumber) maxnumber = numb;

}
if (2*maxnumber == sum )
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {maxnumber}");
}
else 
{
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {Math.Abs(2*maxnumber - sum)}");
}
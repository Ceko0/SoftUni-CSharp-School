
int n = int.Parse(Console.ReadLine());
int counter = 1;

for (int i = 1; i <= n; i++)
{ 
    for (int j = counter; j <= n-1 ; j++)
    {
        Console.Write(" ");
    }
    for (int l = 0; l <= counter - 1; l++)
    {
        Console.Write("* ");
    }
    
    Console.WriteLine();
    counter++;
}

for (int i = 1; i <= n; i++)
{
    for (int j = counter -2; j <= n-1; j++)
    {
        Console.Write(" ");
    }

    for (int j = counter - 2;  j >= 1;  j--)
    {
        Console.Write("* ");
    }
    Console.WriteLine();
    counter--;
}
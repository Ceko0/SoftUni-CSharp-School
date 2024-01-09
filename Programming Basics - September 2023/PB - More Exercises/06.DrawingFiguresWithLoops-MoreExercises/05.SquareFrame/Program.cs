
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{ 
    for (int j = 1; j <= n; j++)
    {
        if (i == 1 && j == 1) Console.Write("+ ");
        else if (i == 1 && j == n) Console.Write("+ ");
        else if (i == n && j == 1) Console.Write("+ ");
        else if (i == n && j == n) Console.Write("+ ");
        else if (j == 1 ) Console.Write("| ");
        else if (j == n ) Console.Write("| ");
        else Console.Write("- ");        
    }
    Console.WriteLine();
}
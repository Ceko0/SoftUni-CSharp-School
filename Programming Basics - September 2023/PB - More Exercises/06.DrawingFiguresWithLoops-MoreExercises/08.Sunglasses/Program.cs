
int n = int.Parse(Console.ReadLine());


for (int j = 1; j <= n*2; j++)
{
    Console.Write("*");
}
for (int k = 1; k <= n; k++) 
{
    Console.Write(" "); 
}
for (int j = 1; j <= n * 2; j++)
{
    Console.Write("*");
}
Console.WriteLine();
for (int k = 1; k <= n - 2; k++)
{
    if (n % 2 == 0)
    {
        if (k == n / 2 - 1)
        {
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            for (int b = 1; b <= n; b++)
            {
                Console.Write("|");
            }
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        else
        {
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            for (int b = 1; b <= n; b++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            Console.WriteLine();

        }
    }
    else
    {
        if (k == n / 2)
        {
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            for (int b = 1; b <= n; b++)
            {
                Console.Write("|");
            }
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        else
        {
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            for (int b = 1; b <= n; b++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            for (int a = 1; a <= 2 * n - 2; a++)
            {
                Console.Write("/");
            }
            Console.Write("*");
            Console.WriteLine();

        }
    }
    
}
for (int j = 1; j <= n * 2; j++)
{
    Console.Write("*");
}
for (int k = 1; k <= n; k++)
{
    Console.Write(" ");
}
for (int j = 1; j <= n * 2; j++)
{
    Console.Write("*");
}



int n = int.Parse(Console.ReadLine());
int counter = 1;

for (int i = 0; i < (n + 1) / 2; i++)
{ 
    if (n%2 == 0)
    {
        for (int j = counter ; j < (n + 1) /2; j++)
        {
            Console.Write("-");
        }
        for (int a = 0; a < counter; a++)
        {
            Console.Write("**");
        }
        for (int j = counter ; j < (n + 1) / 2; j++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        counter++;
    }
    else
    {
        for (int j = counter; j < (n + 1) / 2; j++)
        {
            Console.Write("-");
        }   
                Console.Write("*");            
        if (i != 0)
        {
            for (int b = 1; b < counter; b++)
            {
                Console.Write("**");
            }
        }
        for (int j = counter; j < (n + 1) / 2; j++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        counter++;
    }
}
for (int i = 0; i < n / 2; i++)
{
    Console.Write("|");
    for (int j = 0; j < n - 2 ; j++)
    {
        Console.Write("*");
    }
    Console.Write("|");
    Console.WriteLine();
}
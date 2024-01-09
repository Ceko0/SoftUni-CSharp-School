
int firstNumb = int.Parse(Console.ReadLine());
int secondNumb = int.Parse(Console.ReadLine());
int therthNumb = int.Parse(Console.ReadLine());

for (int i = 2; i <= firstNumb; i += 2)
{ 
    for (int j = 2; j <= secondNumb; j++)
    {
        if (j != 4 )
        {
            if (j != 6)
            {
                 if (j != 8)
                 {
                    if (j != 9)
                    {
                        for (int k = 2; k <= therthNumb; k += 2)
                            Console.WriteLine($"{i} {j} {k}");
                    }
                 }
            }           
        }       
    }
}
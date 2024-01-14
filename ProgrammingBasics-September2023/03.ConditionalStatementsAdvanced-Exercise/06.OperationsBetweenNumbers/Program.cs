double numb1 = double.Parse(Console.ReadLine());
int numb2 = int.Parse(Console.ReadLine());
char simbol = char.Parse(Console.ReadLine());
double numb3 = 0;

if (simbol == '+' || simbol == '-' || simbol == '*')
{ 
    switch (simbol)
    {
        case '+':
            numb3 = numb1 + numb2;
            break;
        case '-':
            numb3 = numb1 - numb2;
            break;
        case '*':
            numb3 = numb1 * numb2;
            break;
    }
    if (numb3 % 2 == 0)
         Console.WriteLine($"{numb1} {simbol} {numb2} = {numb3} - even");
    else
        Console.WriteLine($"{numb1} {simbol} {numb2} = {numb3} - odd");
}
else
{
    if (numb2 == 0)
    {
        Console.WriteLine($"Cannot divide {numb1} by zero");
    }
    else
    {
        switch (simbol)
        {
            case '/':
                numb3 = numb1 / numb2;
                Console.WriteLine($"{numb1} / {numb2} = {numb3:f2}");
                break;
            case '%':
                numb3 = numb1 % numb2;
                Console.WriteLine($"{numb1} % {numb2} = {numb3}");
                break;
        }
        
    }
}
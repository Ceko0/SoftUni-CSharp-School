int numb1 = int.Parse(Console.ReadLine());
int numb2 = int.Parse(Console.ReadLine());

for (int i = numb1; i <= numb2; i++)
{
    string number = i.ToString();
    char zero = number[0];
    char one = number[1];
    char two = number[2];
    char three = number[3];
    char four = number[4];
    char five = number[5];

    if (zero + two + four == one + three + five)
    { Console.Write($"{i} "); }
    
}

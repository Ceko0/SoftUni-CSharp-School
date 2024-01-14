int numb = int.Parse(Console.ReadLine());

for (int i = 1111; i < 9999; i++)
{
    string number = i.ToString();

    int zero = number[0] - '0';
    int one = number[1] - '0';
    int two = number[2] - '0';
    int three = number[3] - '0';
    if (three == 0) continue;
    if (two == 0)
    { i += 9; continue;  }
    if (one == 0)
    { i += 99; continue; }
    if (numb % zero == 0 && numb % one == 0 && numb % two == 0 && numb % three == 0)
    {
        Console.Write($"{i} ");
    }

}
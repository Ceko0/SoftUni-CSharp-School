

while (true)
{
    double numb = double.Parse(Console.ReadLine());
    if (numb < 0)
    {
        Console.WriteLine("Negative number!");
        break;
    }
    else Console.WriteLine($"Result: {numb *2 :f2}");
}
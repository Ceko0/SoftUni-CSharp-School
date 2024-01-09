int numb = int.Parse(Console.ReadLine());
double bonus = 0;
if (numb <= 100)
{
    bonus += 5;
}
else if (numb <= 1000)
{
    bonus += numb * 0.20;
}
else 
{
    bonus += numb * 0.10;
}
if (numb % 2 == 0)
{
    bonus += 1;
}
if (numb % 10 == 5)
{
    bonus += 2;
}
Console.WriteLine(bonus);
Console.WriteLine(numb+bonus);
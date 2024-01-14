int age = int.Parse(Console.ReadLine());
double washingPrice = double.Parse(Console.ReadLine());
int toysPrice = int.Parse(Console.ReadLine());
int money = 0;
for (int i = 1; i <= age; i++)
{
    if (i % 2 == 0) 
    {
        money += i * 5 - 1;

    }
    else 
    {
        money += toysPrice;
    }
}
if (money >= washingPrice) Console.WriteLine($"Yes! {money - washingPrice:f2}");
else Console.WriteLine($"No! {washingPrice - money:f2}");
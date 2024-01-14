double excursionPrice = double.Parse(Console.ReadLine());
int puzzle =  int.Parse(Console.ReadLine());
int doly = int.Parse(Console.ReadLine());
int bear = int.Parse(Console.ReadLine());
int minion = int.Parse(Console.ReadLine());
int truck = int.Parse(Console.ReadLine());
int totaltoys = puzzle + doly + bear + minion + truck;
double totalprice = puzzle * 2.60 + doly * 3 + bear * 4.10 + minion * 8.20 + truck * 2;

if (totaltoys >= 50)
{
    totalprice *= 0.75;
}
totalprice *= 0.90;
if (totalprice >= excursionPrice)
{
    Console.WriteLine($"Yes! {totalprice - excursionPrice:f2} lv left.");
}
else 
{
    Console.WriteLine($"Not enough money! {excursionPrice - totalprice:f2} lv needed.");
}
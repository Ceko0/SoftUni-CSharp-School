using System.Security.Principal;

double budget = double.Parse(Console.ReadLine());
int video =  int.Parse(Console.ReadLine());
int procesor = int.Parse(Console.ReadLine());
int ram = int.Parse(Console.ReadLine());
double videoPrice = video * 250;
double procesorPrice = videoPrice * 0.35 * procesor;
double ramPrice = ram * videoPrice * 0.10;
double totalprice = videoPrice + procesorPrice +  ramPrice;
if (video > procesor)
{
    totalprice *= 0.85;
}
if (budget >= totalprice)
{
    Console.WriteLine($"You have {budget - totalprice:f2} leva left!");
}
else 
{
    Console.WriteLine($"Not enough money! You need {totalprice - budget :f2} leva more!");
}
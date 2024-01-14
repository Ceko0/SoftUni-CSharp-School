int juniorsBikers = int.Parse(Console.ReadLine());
int seniorsBikers = int.Parse(Console.ReadLine());
string route  = Console.ReadLine();

double totalMoney = 0;

if (route == "trail")
    totalMoney += juniorsBikers * 5.50 + seniorsBikers * 7;
else if (route == "cross-country")
{
    totalMoney += juniorsBikers * 8 + seniorsBikers * 9.5;
    if (50 <= juniorsBikers + seniorsBikers) totalMoney *= 0.75;
}
else if (route == "downhill")
    totalMoney += juniorsBikers * 12.25 + seniorsBikers * 13.75;
else if (route == "road")
    totalMoney += juniorsBikers * 20 + seniorsBikers * 21.5;
Console.WriteLine($"{totalMoney*0.95:f2}");
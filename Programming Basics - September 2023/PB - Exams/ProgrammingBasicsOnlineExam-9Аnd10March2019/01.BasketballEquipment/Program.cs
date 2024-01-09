int fee = int.Parse(Console.ReadLine());


double sneakers = fee * 0.60;
double equipment = sneakers * 0.80;
double ball = equipment * 0.25;
double accessories = ball * 0.20;

double totalMoney = fee + sneakers + equipment + ball + accessories;

Console.WriteLine($"{totalMoney:f2}");
double budget = double.Parse(Console.ReadLine());
int year  = int.Parse(Console.ReadLine());

int ageCounter = 18;
double needMoney = 0;

for (int i = 1800; i <= year; i++)
{
    if (i % 2 == 0)
        needMoney += 12000;
    else
        needMoney += 12000 + (ageCounter * 50);
    ageCounter++;
}
if (needMoney > budget) 
    Console.WriteLine($"He will need {needMoney - budget:f2} dollars to survive.");
else 
    Console.WriteLine($"Yes! He will live a carefree life and will have {budget - needMoney :f2} dollars left.");
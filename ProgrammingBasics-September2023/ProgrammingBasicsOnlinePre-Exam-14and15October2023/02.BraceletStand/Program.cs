

double terezaMoneyForDay = double.Parse(Console.ReadLine());
double incomeFromSells = double.Parse(Console.ReadLine());
double totalExpenses = double.Parse(Console.ReadLine());
double giftPrice = double.Parse(Console.ReadLine());

double totalIncome = incomeFromSells * 5;
double totalMoney = (terezaMoneyForDay * 5) + totalIncome - totalExpenses;

if (giftPrice <= totalMoney)
{
    Console.WriteLine($"Profit: {totalMoney:f2} BGN, the gift has been purchased.");
}
else
{
    Console.WriteLine($"Insufficient money: {giftPrice - totalMoney :f2} BGN.");
}
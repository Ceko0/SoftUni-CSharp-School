int nylon = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int thinner = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());
double matPrice = ((nylon + 2) * 1.50) + (paint * 1.1 * 14.50) + (thinner * 5.00) + 0.40;
double masterpayment = matPrice * 0.30 * hours;
Console.WriteLine(matPrice + masterpayment);
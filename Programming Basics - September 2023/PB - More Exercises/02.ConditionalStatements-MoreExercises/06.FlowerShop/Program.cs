//•	Магнолии – 3.25 лева
//•	Зюмбюли – 4 лева
//•	Рози – 3.50 лева
//•	Кактуси – 8 лева
//От общата сума, Мария трябва да плати 5% данъци.
int m = int.Parse(Console.ReadLine());
int z = int.Parse(Console.ReadLine());
int r = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());
double gift = double.Parse(Console.ReadLine());
double totalMoney = (m * 3.25 + z * 4 + r * 3.50 + k * 8);
totalMoney *= 0.95;
if (gift <= totalMoney) 
{
    Console.WriteLine($"She is left with {Math.Floor(totalMoney - gift)} leva.");
}
else
{
    Console.WriteLine($"She will have to borrow {Math.Ceiling(gift - totalMoney)} leva.");
}
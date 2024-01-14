int days = int.Parse(Console.ReadLine());
int food = int.Parse(Console.ReadLine());
double dogFood = double.Parse(Console.ReadLine());
double catFood = double.Parse(Console.ReadLine());
double turtleFood = double.Parse(Console.ReadLine());
double totalFood = days * (dogFood+ catFood + turtleFood/1000);
if (food >= totalFood) 
{
    Console.WriteLine($"{Math.Floor(food - totalFood)} kilos of food left.");
}
else
{
    Console.WriteLine($"{Math.Ceiling(totalFood - food)} more kilos of food are needed.");
}
double size = double.Parse(Console.ReadLine());
double grapes = double.Parse(Console.ReadLine());
double liters  = double.Parse(Console.ReadLine());
double worckers = double.Parse(Console.ReadLine());
double grapesSize = size * 0.40;
double kilo = grapesSize * grapes;
double wine = kilo / 2.5;
if (liters > wine)
{
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(liters - wine)} liters wine needed.");
}
else
{
    double wineleft = wine - liters;
    Console.WriteLine($"Good harvest this year! Total wine: {wine} liters.");
    Console.WriteLine($"{Math.Ceiling(wineleft)} liters left -> {Math.Ceiling(wineleft/worckers)} liters per person.");
}
string type = Console.ReadLine();
int r = int.Parse(Console.ReadLine());
int c  = int.Parse(Console.ReadLine());
int totalPlaces = r * c;

if (type == "Premiere")
{
    Console.WriteLine($"{totalPlaces * 12.00:f2} leva");
}
else if (type == "Normal")
{
    Console.WriteLine($"{totalPlaces * 7.50:f2} leva");
}
else if (type == "Discount")
{
    Console.WriteLine($"{totalPlaces * 5.00:f2} leva");
}
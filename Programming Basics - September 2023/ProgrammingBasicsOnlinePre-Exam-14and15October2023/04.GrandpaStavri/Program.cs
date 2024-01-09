int days = int.Parse(Console.ReadLine());

double totalLiter = 0;
double degree = 0;


for (int i = 0; i < days; i++)
{
    double literForDay = double.Parse(Console.ReadLine());
    totalLiter += literForDay;
    degree += literForDay *  double.Parse(Console.ReadLine());
    
}

double degreeForLiter = degree / totalLiter;
Console.WriteLine($"Liter: {totalLiter:f2}");
Console.WriteLine($"Degrees: {degreeForLiter:f2}");
if (degreeForLiter < 38)
{
    Console.WriteLine("Not good, you should baking!");
}
else if (degreeForLiter < 42)
{
    Console.WriteLine("Super!");
}
else if (degreeForLiter >= 42)
{
    Console.WriteLine("Dilution with distilled water!");
}
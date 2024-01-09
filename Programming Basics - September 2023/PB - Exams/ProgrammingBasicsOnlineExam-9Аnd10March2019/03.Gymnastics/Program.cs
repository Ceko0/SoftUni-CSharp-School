
string country = Console.ReadLine();
string appliance = Console.ReadLine();

double difficulty = 0;
double performance = 0;

if (country == "Russia")
{
    if (appliance == "ribbon")
    {
        difficulty += 9.100;
        performance += 9.400;
    }
    else if (appliance =="hoop")
    {
        difficulty += 9.300;
        performance += 9.800;
    }
    else if (appliance == "rope")
    {
        difficulty += 9.600;
        performance += 9.000;
    }
}
else if (country == "Bulgaria")
{
    if (appliance == "ribbon")
    {
        difficulty += 9.600;
        performance += 9.400;
    }
    else if (appliance == "hoop")
    {
        difficulty += 9.550;
        performance += 9.750;
    }
    else if (appliance == "rope")
    {
        difficulty += 9.500;
        performance += 9.400;
    }
}
else if (country == "Italy")
{
    if (appliance == "ribbon")
    {
        difficulty += 9.200;
        performance += 9.500;
    }
    else if (appliance == "hoop")
    {
        difficulty += 9.450;
        performance += 9.350;
    }
    else if (appliance == "rope")
    {
        difficulty += 9.700;
        performance += 9.150;
    }
}

double totalScore = difficulty + performance;
double totalPercent =  100 - (totalScore / 20.00 * 100);

Console.WriteLine($"The team of {country} get {totalScore:f3} on {appliance}.");
Console.WriteLine($"{totalPercent:f2}%");
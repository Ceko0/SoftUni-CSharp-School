
using System.Xml.Schema;

string season = Console.ReadLine();
string tipe = Console.ReadLine();
int student = int.Parse(Console.ReadLine());
int nights = int.Parse(Console.ReadLine());
double totalmoney = 0;
string sport = "";
if (season == "Winter")
{
    switch (tipe)
    {
        case "boys":
            totalmoney = student * nights * 9.60;
            sport = "Judo";
            break;
        case "girls":
            sport = "Gymnastics";
            totalmoney = student * nights * 9.60;
            break;
        case "mixed":
            sport = "Ski";
            totalmoney = student * nights * 10.00;
            break;
    }
}
else if (season == "Spring")
{
    switch (tipe)
    {
        case "boys":
            totalmoney = student * nights * 7.20;
            sport = "Tennis";
            break;
        case "girls":
            sport = "Athletics";
            totalmoney = student * nights * 7.20;
            break;
        case "mixed":
            sport = "Cycling";
            totalmoney = student * nights * 9.50;
            break;
    }
}
else if (season == "Summer")
{
    switch (tipe)
    {
        case "boys":
            totalmoney = student * nights * 15.00;
            sport = "Football";
            break;
        case "girls":
            sport = "Volleyball";
            totalmoney = student * nights * 15.00;
            break;
        case "mixed":
            sport = "Swimming";
            totalmoney = student * nights * 20.00;
            break;
    }
}

if (student >= 50) totalmoney *= 0.50;
else if (student >= 20) totalmoney *= 0.85;
else if (student >= 10) totalmoney *= 0.95;

Console.WriteLine($"{sport} {totalmoney:f2} lv.");
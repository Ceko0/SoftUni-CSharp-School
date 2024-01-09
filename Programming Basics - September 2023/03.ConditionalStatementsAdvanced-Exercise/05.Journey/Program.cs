double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();
double money = 0;
if (budget <= 100) 
{
    switch (season)
    {
        case "summer":
            money = budget * 0.30;
            Console.WriteLine("Somewhere in Bulgaria");
            Console.WriteLine($"Camp - {money:f2}");
            break;
        case "winter":
            money = budget * 0.70;
            Console.WriteLine("Somewhere in Bulgaria");
            Console.WriteLine($"Hotel - {money:f2}");
            break;
    }
}
else if (budget <= 1000) 
{
    switch (season)
    {
        case "summer":
            money = budget * 0.40;
            Console.WriteLine("Somewhere in Balkans");
            Console.WriteLine($"Camp - {money:f2}");
            break;
        case "winter":
            money = budget * 0.80;
            Console.WriteLine("Somewhere in Balkans");
            Console.WriteLine($"Hotel - {money:f2}");
            break;
    }
}
else  
{
    money = budget * 0.90;
    Console.WriteLine("Somewhere in Europe");
    Console.WriteLine($"Hotel - {money:f2}");
}
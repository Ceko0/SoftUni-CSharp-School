

//Сезоните са лято и зима – "Summer" и "Winter". Типа коли са кабрио и джип – "Cabrio" и "Jeep". 


double budget = double.Parse(Console.ReadLine());
string season  = Console.ReadLine();

if (budget <= 100)
{
    switch (season)
    {
        case "Summer":
            Console.WriteLine("Economy class");
            Console.WriteLine($"Cabrio - {0.35* budget:f2}");

            break;
        case "Winter":
            Console.WriteLine("Economy class");
            Console.WriteLine($"Jeep - {0.65 * budget:f2}");
            break;
    }
}
else if (budget <= 500)
{
     switch (season)
    {
        case "Summer":
            Console.WriteLine("Compact class");
            Console.WriteLine($"Cabrio - {0.45* budget:f2}");

            break;
        case "Winter":
            Console.WriteLine("Compact class");
            Console.WriteLine($"Jeep - {0.80 * budget:f2}");
            break;
    }
}
else
{
      Console.WriteLine("Luxury class");
      Console.WriteLine($"Jeep - {0.90 * budget:f2}");
}


while (true)
{
    string destination = Console.ReadLine();
    if (destination == "End") break;
    double budget = double.Parse(Console.ReadLine());
    
    while (true)
    { 
        double income = double.Parse(Console.ReadLine());
        budget -= income;
        if (budget <= 0)
        {
            Console.WriteLine($"Going to {destination}!");
            break;
        }

    }
}

int steps = 0;

while (true)
{


    string income = Console.ReadLine();

    if (income == "Going home")
    {
        steps += int.Parse(Console.ReadLine());
        if (steps >= 10000)
        {
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{steps - 10000} steps over the goal!");
            break;
        }
        else
        {
            Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            break;
        }

    }
    steps += int.Parse(income);
    if (steps >= 10000)
    {
        Console.WriteLine("Goal reached! Good job!");
        Console.WriteLine($"{steps - 10000} steps over the goal!");
        break;
    }
    else if (income == "Going home")
    {
        Console.WriteLine($"{10000 - steps} more steps to reach goal.");
        break;
    }

}
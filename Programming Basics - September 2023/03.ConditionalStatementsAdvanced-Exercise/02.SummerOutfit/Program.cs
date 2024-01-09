double degrees = double.Parse(Console.ReadLine());
string dayTime = Console.ReadLine();
switch (dayTime)
{
    case "Morning":
        if (degrees >= 10 && degrees <= 18)
        {
            Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
        }
        else if (degrees <= 24)
        {
            Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
        }
        else if (degrees >= 25)
        {
            Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
        }
        break;
    case "Afternoon":
        if (degrees >= 10 && degrees <= 18)
        {
            Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
        }
        else if (degrees <= 24)
        {
            Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
        }
        else if (degrees >= 25)
        {
            Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot.");
        }
        break;
    case "Evening":
        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
        break;
}
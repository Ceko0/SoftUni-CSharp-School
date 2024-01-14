string fruit = Console.ReadLine();
string day =  Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
double price = 0;
//плод banana	apple	orange	grapefruit	kiwi	pineapple	grapes
//цена	2.50	1.20	0.85	1.45	    2.70     	5.50	3.85

// почивни дни
//плод	banana	apple	orange	grapefruit	kiwi	pineapple	grapes
//цена	2.70	1.25	0.90	1.60	    3.00	    5.60	4.20
if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
{
    switch (fruit)
    {
        case "banana":Console.WriteLine($"{quantity * 2.50:f2}"); break;
        case "apple":Console.WriteLine($"{quantity * 1.20:f2}"); break;
        case "orange": Console.WriteLine($"{quantity * 0.85:f2}"); break;
        case "grapefruit": Console.WriteLine($"{quantity * 1.45:f2}"); break;
        case "kiwi": Console.WriteLine($"{quantity * 2.70:f2}"); break;
        case "pineapple": Console.WriteLine($"{quantity * 5.50:f2}"); break;
        case "grapes": Console.WriteLine($"{quantity * 3.85:f2}"); break;
        default:Console.WriteLine("error"); break;
    }
}
else if (day == "Saturday" || day == "Sunday")
{
    switch (fruit)
    {
        case "banana": Console.WriteLine($"{quantity * 2.70:f2}"); break;
        case "apple": Console.WriteLine($"{quantity * 1.25:f2}"); break;
        case "orange": Console.WriteLine($"{quantity * 0.90:f2}"); break;
        case "grapefruit": Console.WriteLine($"{quantity * 1.60 :f2}"); break;
        case "kiwi": Console.WriteLine($"{quantity * 3.00:f2}"); break;
        case "pineapple": Console.WriteLine($"{quantity * 5.60:f2}"); break;
        case "grapes": Console.WriteLine($"{quantity * 4.20:f2}"); break;
        default: Console.WriteLine("error"); Console.WriteLine($"{price:f2}"); break;
    }
}
else 
{
    Console.WriteLine("error");
}
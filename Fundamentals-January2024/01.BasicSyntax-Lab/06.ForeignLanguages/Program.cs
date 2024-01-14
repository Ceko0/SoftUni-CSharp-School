
/*
• English is spoken in England and the USA.
• Spanish is spoken in Spain, Argentina, and Mexico.
• For the others, we should print "unknown".
*/
string countryName = Console.ReadLine();

switch (countryName)
{
	case "England":
	case "USA":
        Console.WriteLine("English");
        break;
    case "Spain":
    case "Argentina":
    case "Mexico":
        Console.WriteLine("Spanish");
        break;
    default:
        Console.WriteLine("unknown");
        break;
}
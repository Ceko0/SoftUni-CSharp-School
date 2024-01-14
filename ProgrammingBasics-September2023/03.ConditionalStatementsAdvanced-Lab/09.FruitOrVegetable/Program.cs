string name = Console.ReadLine();
switch (name)
{
	case "banana":
    case "kiwi":
    case "cherry":
    case "lemon":
    case "apple":
    case "grapes":
        Console.WriteLine("fruit");
        break;
    case "tomato":
    case "cucumber":
    case "pepper":
    case "carrot":
        Console.WriteLine("vegetable");
        break;
    default:
        Console.WriteLine("unknown");
        break;
}
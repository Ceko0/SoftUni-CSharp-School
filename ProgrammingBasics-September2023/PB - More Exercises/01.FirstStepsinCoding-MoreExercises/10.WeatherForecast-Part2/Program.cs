double degrees = double.Parse(Console.ReadLine());
switch (degrees)
{
    case > 35:
        Console.WriteLine("unknown");
        break;
    case >=26:
        Console.WriteLine("Hot");
        break;
    case >=20.1: 
        Console.WriteLine("Warm");
        break;
    case >=15:
        Console.WriteLine("Mild");
        break;
    case >=12:
        Console.WriteLine("Cool");
        break;
    case >=5:
        Console.WriteLine("Cold");
        break;
    default:
        Console.WriteLine("unknown");
        break;

}
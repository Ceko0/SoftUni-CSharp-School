string figure = Console.ReadLine();
double result = 0;

switch (figure)
{
    case "square":
        double numb = double.Parse(Console.ReadLine());
        result = numb * numb;
        break;
    case "rectangle":
        double numb1 = double.Parse(Console.ReadLine());
        double numb2 = double.Parse(Console.ReadLine());
        result = numb1 * numb2;
        break;
    case "circle":
        double numb3 = double.Parse(Console.ReadLine());
        result = Math.PI * Math.Pow(numb3,2);
        break;
    case "triangle":
        double numb4 = double.Parse(Console.ReadLine());
        double numb5 = Double.Parse(Console.ReadLine());
        result = (numb4 * numb5) / 2;
        break;
}
Console.WriteLine($"{result :f3}");
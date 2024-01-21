namespace _01.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string income = Console.ReadLine();
                if (income == "END")
                {
                    break;
                }
                if (int.TryParse(income, out int isInteger))
                {
                    Console.WriteLine($"{income} is integer type");
                }
                else if (double.TryParse(income, out double floatingPoint))
                {
                    Console.WriteLine($"{income} is floating point type");
                }
                else if (char.TryParse(income, out char isCharacter))
                {
                    Console.WriteLine($"{income} is character type");
                }
                else if (bool.TryParse(income, out bool isBoolean))
                {
                    Console.WriteLine($"{income} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{income} is string type");
                }
            }
        }
    }
}

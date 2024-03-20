using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        class Furniture
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

        }
        static void Main(string[] args)
        {
            decimal totalPrice = 0;
            string input = String.Empty;
            StringBuilder sb = new StringBuilder();
            while ((input = Console.ReadLine()) != "Purchase")
            {
                string pattern = @">>\s*(?<Name>[A-Za-z]+)\s*<<\s*(?<Price>[\d+\.\d+|\d+]+)\s*!\s*(?<Quantity>\d+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    sb.Append($"{match.Groups["Name"].Value}\n");
                    totalPrice += decimal.Parse(match.Groups["Price"].Value) * int.Parse(match.Groups["Quantity"].Value);
                }
            }
            Console.WriteLine("Bought furniture:");
            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}

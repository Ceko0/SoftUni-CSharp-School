using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string income = String.Empty;
          string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>[\d.\d|\d]+)!(?<quantity>[\d]+)";
          decimal total = 0;
          Console.WriteLine("Bought furniture:");
          while ((income = Console.ReadLine()) != "Purchase")
          {
              MatchCollection matches = Regex.Matches(income, pattern);
              foreach (Match match in matches)
              {
                    Console.WriteLine(match.Groups["name"].Value);
                    total += decimal.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
              }
          }

          Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}

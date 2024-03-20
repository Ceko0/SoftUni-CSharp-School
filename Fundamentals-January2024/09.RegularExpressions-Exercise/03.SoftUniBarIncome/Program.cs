using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = String.Empty;
            decimal totalIncome = 0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.\d+|\d+)\$";

                MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);

                foreach (Match match in matches)
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);

                    Console.WriteLine($"{customer}: {product} - {count* price :f2}");
                    totalIncome += count * price;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}

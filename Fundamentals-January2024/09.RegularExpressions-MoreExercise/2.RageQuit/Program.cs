using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<symbols>[^0-9])*(?<multiplier>[\d]+)";
            string singlePattern = @"(?<singleSymbols>[^0-9])";
            string inputUpper = input.ToUpper();
            MatchCollection matches = Regex.Matches(input, pattern);
            MatchCollection singleMatches = Regex.Matches(inputUpper, singlePattern);

            List<string> symbols = new List<string>();

            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                string symbol = String.Empty;
                int count = match.Groups[0].ValueSpan.Length;
                int multiplier = int.Parse(match.Groups["multiplier"].Value);
                string checking = multiplier.ToString();
                for (int i = 0; i < count-checking.Length; i++)
                {
                    string currentSymbol = match.Groups[0].ValueSpan[i].ToString().ToUpper();
                    symbol += currentSymbol;
                    if (!symbols.Contains(currentSymbol)) symbols.Add(currentSymbol);
                }

                for (int i = 0; i < multiplier; i++)
                {
                    sb.Append(symbol);
                }
            }

            Console.WriteLine($"Unique symbols used: {symbols.Count}");
            Console.WriteLine(sb.ToString());
        }
    }
}

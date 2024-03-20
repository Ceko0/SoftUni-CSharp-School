using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<day>\d{2})(?<s>[\.|\-|\/])(?<month>[A-Z][a-z][a-z])(\k<s>)(?<year>\d{4})";
            
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }
        }
    }
}

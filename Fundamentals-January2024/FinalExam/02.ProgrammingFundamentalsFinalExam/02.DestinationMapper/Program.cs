using System.Text;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startingLetter = Console.ReadLine();

            List<string> destination = new List<string>();

            string pattern = @"([=/])([A-Z][a-zA-Z]{2,})\1";
            MatchCollection matches = Regex.Matches(startingLetter, pattern);

            foreach (Match match in matches)
            {
                string validString = match.Value;
                validString = validString.Replace("=", "");
                validString = validString.Replace("/", "");
                destination.Add(validString);
            }
            StringBuilder sb = new StringBuilder();
            int points = 0;
            foreach (var location in destination)
            {
                sb.Append($", {location}");
                points += location.Length;
            }

            Console.WriteLine($"Destinations: {sb.ToString().Trim(',',' ')}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}

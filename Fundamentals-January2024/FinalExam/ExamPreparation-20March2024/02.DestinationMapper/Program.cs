using System.Text;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pettern = @"(\=|\/)(?<text>[A-Z][A-Za-z]{2,})(\1)";
            MatchCollection matches = Regex.Matches(text, pettern);
            StringBuilder sb = new StringBuilder();
            int travelPoints = 0;
            foreach (Match match in matches)
            {
                string destination = match.Groups["text"].Value;
                sb.Append($"{destination}, ");
                travelPoints += destination.Length;
            }
            Console.WriteLine($"Destinations: {sb.ToString().Trim(',', ' ')}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}

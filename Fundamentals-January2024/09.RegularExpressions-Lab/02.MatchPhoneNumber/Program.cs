using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<Number>\+359(?<s>[\-\ ])2(\k<s>)\d{3}(\k<s>)\d{4})";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> numbers = new List<string>();
            foreach (Match match in matches)
            {
                numbers.Add(match.Groups["Number"].Value);
            }

            Console.WriteLine(string.Join(", " , numbers));
        }
    }
}

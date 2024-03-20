using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<FullName>[A-Z][a-z]+ [A-Z][a-z]+)\b";
            List<string> names = new List<string>();
            MatchCollection matchs = Regex.Matches(input, pattern);
            foreach (Match match in matchs)
            {
                names.Add(match.Groups["FullName"].Value);
            }

            Console.WriteLine(string.Join(" " , names));
        }
    }
}

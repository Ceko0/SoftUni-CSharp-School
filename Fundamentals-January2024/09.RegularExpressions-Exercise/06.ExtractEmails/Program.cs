using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"[^\.\-_]\b(?![\._\-])[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+@[^\.\-](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";

            MatchCollection matches = Regex.Matches(input, pattern);
            
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0].Value);
            }
        }
    }
}

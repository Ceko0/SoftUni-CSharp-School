using System.Text.RegularExpressions;

namespace _3.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|')
                .ToArray();
            string capitalPattern = @"(?<separator>[#$%*&])(?<CapitalLetter>[A-Z]+)(\k<separator>)";
            string wordsPattern = @"(?<WordsInfo>[\d]+:[\d]{2})";

            MatchCollection capitalMatchCollection = Regex.Matches(input[0], capitalPattern);
            MatchCollection wordMatchCollection = Regex.Matches(input[1], wordsPattern);

            List<string> words = input[2]
                .Split(" ")
                .Select(x => x.Trim())
                .ToList();
        }
    }
}

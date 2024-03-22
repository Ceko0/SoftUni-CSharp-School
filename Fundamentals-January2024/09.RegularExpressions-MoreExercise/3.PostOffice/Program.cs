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
            MatchCollection capitalMatchCollection = Regex.Matches(input[0], capitalPattern);
            Dictionary<char, int> capitalList = new Dictionary<char, int>();
            foreach (Match match in capitalMatchCollection)
            {
                string symbol = match.Groups["CapitalLetter"].Value;

                foreach (char character in symbol)
                {
                    if (Char.IsUpper(character))
                    {
                        capitalList.Add(character, 0);
                    }
                }

            }

            string wordsPattern = @"(?<WordsInfo>[\d]+:[\d]{2})";
            MatchCollection wordMatchCollection = Regex.Matches(input[1], wordsPattern);
            foreach (var info in wordMatchCollection)
            {
                int[] information = info
                    .ToString()
                    .Split(":")
                    .Select(int.Parse)
                    .ToArray();
                char currentChar = Convert.ToChar(information[0]);
                if (capitalList.ContainsKey(currentChar))
                {
                    capitalList[currentChar] = information[1] + 1;
                }
            }

            List<string> words = input[2]
                .Split(" ")
                .Select(x => x.Trim())
                .ToList();

            foreach (var word in words)
            {
                char firstSymbol = word[0];
                if (capitalList.ContainsKey(firstSymbol))
                {
                    if (word.Length == capitalList[firstSymbol])
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}

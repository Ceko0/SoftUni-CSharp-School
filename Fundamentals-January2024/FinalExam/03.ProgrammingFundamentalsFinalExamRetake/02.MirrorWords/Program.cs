using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> mirror = new List<string>();
            string pattern = @"([\@|\#])(?<word>[A-Za-z]{3,})(\1)([\@|\#])(?<wordTwo>[A-Za-z]{3,})(\1)";
            MatchCollection matches = Regex.Matches(text, pattern);
            int pairsCounter = 0;
            foreach (Match match in matches)
            {
                pairsCounter++;
                string firstWord = match.Groups["word"].Value;
                string secondWord = new string(match.Groups["wordTwo"].Value.Reverse().ToArray());
               
                if (firstWord == secondWord)
                {
                    mirror.Add($"{firstWord} <=> {match.Groups["wordTwo"].Value}");
                }
            }
            if (pairsCounter == 0) 
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine($"{pairsCounter} word pairs found!");
            if (mirror.Count == 0 ) 
            {
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine($"The mirror words are:");
            Console.WriteLine(string.Join(", ", mirror).Trim(',',' '));
        }
    }
}

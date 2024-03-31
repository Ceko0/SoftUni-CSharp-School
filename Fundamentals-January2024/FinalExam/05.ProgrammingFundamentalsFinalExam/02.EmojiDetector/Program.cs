using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToCheck = Console.ReadLine();

            ulong threshold = 1;
            string digitPattern = @"(?<digit>[\d])";
            MatchCollection digitMatches = Regex.Matches(textToCheck, digitPattern);
            foreach (Match match in digitMatches)
            {
                threshold *= ulong.Parse(match.Groups["digit"].Value);
            }

            Console.WriteLine($"Cool threshold: {threshold}");

            Dictionary<string, ulong> words = new Dictionary<string, ulong>();
            string wordPattern = @"(?<output>([::|**]{2})(?<text>[A-Z][a-z]{2,})(\1))";
            MatchCollection wordMatches = Regex.Matches(textToCheck, wordPattern);
            foreach (Match wordMatch in wordMatches)
            {
                string word = wordMatch.Groups["text"].Value;
                if (char.IsUpper(word[0]))
                {
                    ulong wordValue = 0;
                    foreach (char symbol in word)
                    {
                        wordValue += (ulong)symbol;
                    }

                    words.Add(wordMatch.Groups["output"].Value, wordValue);
                }
            }

            Console.WriteLine($"{words.Count} emojis found in the text. The cool ones are:");
            foreach (var (word, value) in words)
            {
                if (value > threshold)
                {
                    Console.WriteLine($"{word} ");
                }
            }
        }
    }
}
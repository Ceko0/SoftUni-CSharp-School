using System.Text.RegularExpressions;
using System.Text;

namespace _02.BossRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            string pattern = @"((?<s>\|)(?<bossName>[A-Z]{4,})(\k<s>)):((?<se>[\#])(?<title>[A-Za-z]+ [A-Za-z]+)(\k<se>))";

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string name = match.Groups["bossName"].Value;
                        string title = match.Groups["title"].Value;
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"{name}, The {title}\n");
                        sb.Append($">> Strength: {name.Length}\n");
                        sb.Append($">> Armor: {title.Length}");
                        Console.WriteLine(sb.ToString());
                    }
                }
                else Console.WriteLine("Access denied!");

            }
        }
    }

using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string pattern = @"(?<series>[@]{6,10}|[#]{6,10}|[$]{6,10}|[/^]{6,10})";

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }
                string leftSide = String.Empty;
                string rightSide = String.Empty;
                for (int i = 0; i < 10; i++)
                {
                    leftSide += ticket[i];
                    rightSide += ticket[i + 10];
                }

                MatchCollection leftMatch = Regex.Matches(leftSide, pattern);
                MatchCollection rightMatch = Regex.Matches(rightSide, pattern);

                if (leftMatch.Count > 0 && rightMatch.Count > 0)
                {
                    int leftLength = leftMatch[0].Groups["series"].Length;
                    int rightLength = rightMatch[0].Groups["series"].Length;
                    if ((leftLength != 10 || rightLength != 10) && leftMatch[0].Value[0] == rightMatch[0].Value[0])
                    {
                        int shortMatch = 0;
                        if (leftLength <= rightLength) shortMatch = leftLength;
                        else shortMatch = rightLength;
                        Console.WriteLine($"ticket \"{ticket}\" - {shortMatch}{leftMatch[0].Value[0]}");
                    }
                    else if (leftMatch[0].Value[0] == rightMatch[0].Value[0])
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {leftLength}{leftMatch[0].Value[0]} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
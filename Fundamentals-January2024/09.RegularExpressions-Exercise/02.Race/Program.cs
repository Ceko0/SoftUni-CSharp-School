using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();
            Dictionary<string , int> racers = new Dictionary<string , int>();
            foreach (string participant in participants)
            {
                racers.Add (participant, 0);
            }
            string input = string.Empty;
            
            string patternLetter = "[A-Za-z]";
            string patternDigits = @"[\d]";

            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = string.Empty;
                int distance = 0;
                MatchCollection matches = Regex.Matches(input, patternLetter);
                foreach (Match match in matches) name += match.Value;

                if(racers.ContainsKey(name))
                {
                    matches = Regex.Matches(input, patternDigits);
                    foreach (Match match in matches) distance += int.Parse(match.Value);
                    racers[name] += distance;
                }
            }
            int counter = 1;
            List<string> result = new List<string>();
            foreach (var (name , distance) in racers.OrderByDescending(x => x.Value).Take(3))
            {
               result.Add(name);
            }
            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");
        }
    }
}

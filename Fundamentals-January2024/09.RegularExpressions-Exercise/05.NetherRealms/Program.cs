using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string healthPattern = @"[^0-9\+\-\*\/\.]";
            string dmgPattern = @"(?<dmg>[+|-]*\d+\.\d+|[+|-]*\d+)";
            string otherPattern = @"(?<symbols>[\*\/])";
            Dictionary<string, Dictionary<int, decimal>>
                demonsInfo = new Dictionary<string, Dictionary<int, decimal>>();
            for (int i = 0; i < demons.Length; i++)
            {
                MatchCollection healthMatches = Regex.Matches(demons[i], healthPattern);
                MatchCollection dmgMatches = Regex.Matches(demons[i], dmgPattern);
                MatchCollection otherMatches = Regex.Matches(demons[i], otherPattern);

                int totalHealth = 0;
                decimal totalDMG = 0;
                foreach (Match healthMatch in healthMatches)
                {
                    totalHealth += (int)healthMatch.Value[0];
                }

                foreach (Match dmgMatch in dmgMatches)
                {
                    if (dmgMatch.Value != " * " && dmgMatch.Value != "/")
                    {
                        decimal currentDMG = 0;
                        decimal.TryParse(dmgMatch.Value, out currentDMG);
                        totalDMG += currentDMG;
                    }
                }

                foreach (Match symbol in otherMatches)
                {
                    if (symbol.Value == "*") totalDMG *= 2;
                    if (symbol.Value == "/") totalDMG /= 2;
                }

                demonsInfo.Add(demons[i], new Dictionary<int, decimal>());
                demonsInfo[demons[i]].Add(totalHealth, totalDMG);
            }

            foreach (var (name, info) in demonsInfo.OrderBy(x => x.Key))
            {
                int health = info.Keys.First();
                decimal damage = info.Values.First();

                Console.WriteLine($"{name} - {health} health, {damage:f2} damage");
            }
        }
    }
}


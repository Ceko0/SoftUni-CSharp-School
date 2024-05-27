using System.Text;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> userInfo = new();
            HashSet<string> banList = new();
            Dictionary<string, int> submissions = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] info = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (info[1] == "banned")
                {
                    banList.Add(info[0]);
                    continue;
                }

                string name = info[0];
                string languageName = info[1];
                decimal points = decimal.Parse(info[2]);

                userInfo.TryAdd(name, 0);
                userInfo[name] = Math.Max(userInfo[name], points);
                submissions.TryAdd(languageName, 0);
                submissions[languageName]++;
            }

            Console.WriteLine("Results:");
            foreach ((string name, decimal points) in userInfo
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Where(x => !banList.Contains(x.Key)))
            {
                Console.WriteLine($"{name} | {points}");
            }

            Console.WriteLine("Submissions:");
            foreach ((string name, int count) in submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{name} - {count}");
            }
        }
    }
}

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, String> contestsValidation = new();

            string contestsInput = string.Empty;

            Dictionary<string, Dictionary<string, int>> userInfo = new();

            while ((contestsInput = Console.ReadLine()) != "end of contests")
            {
                string[] contestsInfo = contestsInput
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (!contestsValidation.ContainsKey(contestsInfo[0]))
                {
                    contestsValidation.Add(contestsInfo[0], contestsInfo[1]);
                }
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] information = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = information[0];
                string contestPass = information[1];
                string userName = information[2];
                int points = int.Parse(information[3]);

                if (contestsValidation.ContainsKey(contestName) && contestsValidation[contestName] == contestPass)
                {
                    if (!userInfo.ContainsKey(userName))
                    {
                        userInfo.Add(userName, new Dictionary<string, int>());
                    }
                    if (!userInfo[userName].ContainsKey(contestName))
                    {
                        userInfo[userName].Add(contestName, 0);
                    }
                    userInfo[userName][contestName] = Math.Max(userInfo[userName][contestName], points);
                }
            }
            Dictionary<string, Dictionary<string, int>> orderedInfo = userInfo
                .OrderByDescending(x => x.Value.Values.Sum())
                .Take(1)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach ((string name , Dictionary<string, int> contests) in orderedInfo)
            {
                Console.WriteLine($"Best candidate is {name} with total {contests.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking:");
            foreach((string name , Dictionary<string, int> contests) in userInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine(name);
                foreach((string contestName , int points) in contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }
}

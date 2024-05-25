namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,(HashSet<string> followers , HashSet<string> following)>  VLogger = new();           

            string input = string.Empty;
            while((input = Console.ReadLine()) != "Statistics") 
            {
                string[] commands = input
                    .Split(' ');
                string name = commands[0];
                string action = commands[1];
                string followerName = commands[2];

                if ( action == "joined")
                {
                    if(!VLogger.ContainsKey(name))
                    {
                        VLogger.Add(name, (new HashSet<string>() , new HashSet<string>()));                      
                    }
                }
                else if ( action == "followed")
                {
                    if (name != followerName && VLogger.ContainsKey(name)&& VLogger.ContainsKey(followerName))
                    {
                        if (!VLogger[followerName].followers.Contains(name))
                        {
                            VLogger[name].following.Add(followerName);
                            VLogger[followerName].followers.Add(name);
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {VLogger.Count} vloggers in its logs.");

            var orderedVloggers = VLogger
                .OrderByDescending(v => v.Value.followers.Count)
                .ThenBy(v => v.Value.following.Count)
                .ThenBy(v => v.Key)
                .ToList();

            if (orderedVloggers.Count > 0)
            {
                var mostFamousVlogger = orderedVloggers.First();
                Console.WriteLine($"1. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.followers.Count} followers, {mostFamousVlogger.Value.following.Count} following");
                foreach (var follower in mostFamousVlogger.Value.followers.OrderBy(f => f))
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            int rank = 2;
            foreach (var vlogger in orderedVloggers.Skip(1))
            {
                Console.WriteLine($"{rank}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");
                rank++;
            }
        }
    }
}

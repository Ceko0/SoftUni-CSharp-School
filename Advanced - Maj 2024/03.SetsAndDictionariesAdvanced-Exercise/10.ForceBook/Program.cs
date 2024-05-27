using System.ComponentModel;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> sideInfo = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] commands = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int actionIndex = int.MaxValue;
                string action = string.Empty;
                string firstInput = string.Empty;
                string secondInput = string.Empty;
                for (int i = 0; i < commands.Length; i++)
                {                   
                    if (commands[i] == "|" || commands[i] == "->")
                    {
                            actionIndex = i;
                        action = commands[i];
                    }
                    if (actionIndex > i)
                    {
                        if (firstInput != string.Empty)
                        {
                            firstInput += $" {commands[i]}";
                        }
                        else
                        {
                            firstInput += commands[i];
                        }
                    }
                    else if (i > actionIndex)
                    {
                        if (secondInput != string.Empty)
                        {
                            secondInput += $" {commands[i]}";
                        }
                        else
                        {
                            secondInput += commands[i];
                        }
                    }
                } 
                
                
                switch (action)
                {
                    case "|":
                        string userName = secondInput;
                        string side = firstInput;
                        addingUser(sideInfo, userName, side);
                        break;

                    case "->":
                        userName = firstInput;
                        side = secondInput;
                        foreach ((string sideName, HashSet<string> users) in sideInfo)
                        {
                            if (users.Contains(userName))
                            {
                                users.Remove(userName);
                                break;
                            }
                        }
                        addingUser(sideInfo, userName, side);
                        Console.WriteLine($"{userName} joins the {side} side!");
                        break;
                }
            }
            foreach((string sideName , HashSet<string> userNames) in sideInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x .Key))
            {
                if (userNames.Count != 0)
                {
                    Console.WriteLine($"Side: {sideName}, Members: {userNames.Count}");

                    foreach (string name in userNames.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }

        private static void addingUser(Dictionary<string, HashSet<string>> sideInfo, string userName, string side)
        {
            sideInfo.TryAdd(side, new HashSet<string>());
            bool containUser = false;
            foreach ((string sideName, HashSet<string> users) in sideInfo)
            {
                if (users.Contains(userName))
                {
                    containUser = true;
                }
            }
            if (!containUser)
            {
                sideInfo[side].Add(userName);
            }
        }
    }
}

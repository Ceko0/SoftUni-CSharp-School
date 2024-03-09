namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , string> parkingList = new Dictionary<string , string>();

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] userInfo = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string operation = userInfo[0];
                string userName = userInfo[1];
               

                switch (operation)
                {
                    case "register":
                        string number = userInfo[2];
                        if (parkingList.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {number}");
                        }
                        else
                        {
                            parkingList.Add(userName, number);
                            Console.WriteLine($"{userName} registered {number} successfully");
                        }
                        break;
                    case "unregister":
                        if (!parkingList.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            parkingList.Remove(userName);
                            Console.WriteLine($"{userName} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var kvp in parkingList)
            {
                Console.WriteLine($"{kvp.Key } => {kvp.Value }");
            }
        }
    }
}

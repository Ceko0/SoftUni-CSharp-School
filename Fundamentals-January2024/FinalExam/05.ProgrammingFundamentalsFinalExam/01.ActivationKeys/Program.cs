namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string income = String.Empty;
            while ((income = Console.ReadLine()) != "Generate")
            {
                string[] commands = income
                    .Split(">>>")
                    .ToArray();
                string command = commands[0];
                switch (command)
                {
                    case "Contains":
                        string substring = commands[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }

                        break;
                    case "Flip":
                        string caseToApply = commands[1];
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);
                        string sub = activationKey.Substring(startIndex, endIndex -startIndex);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        if (caseToApply == "Upper")
                        {
                            sub = sub.ToUpper();
                            activationKey = activationKey.Insert(startIndex, sub);
                            Console.WriteLine(activationKey);
                        }
                        else
                        {
                            sub = sub.ToLower();
                            activationKey = activationKey.Insert(startIndex, sub);
                            Console.WriteLine(activationKey);
                        }

                        break;
                    case "Slice":
                        startIndex = int.Parse(commands[1]);
                        endIndex = int.Parse(commands[2]);
                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(activationKey);
                        break;
                }

            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}

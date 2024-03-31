namespace _01.Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string income = string.Empty;
            while ((income = Console.ReadLine()) != "Registration")
            {
                string[] commands = income
                    .Split()
                    .ToArray();
                string command = commands[0];
                switch (command)
                {
                    case "Letters":
                        command = commands[1];
                        switch (command)
                        {
                            case "Lower":
                                userName = userName.ToLower();
                                break;
                            case "Upper":
                                userName = userName.ToUpper();
                                break;
                        }
                        Console.WriteLine(userName);
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && startIndex < userName.Length && endIndex >= 0 & endIndex < userName.Length)
                        {
                            string textToReverse = userName.Substring(startIndex, endIndex - startIndex + 1);
                            char[] charArray = textToReverse.ToCharArray();
                            Array.Reverse(charArray);
                            string reversedText = new string(charArray);
                            Console.WriteLine(reversedText);
                        }
                        break;
                    case "Substring":
                        string textToCut = commands[1];
                        if (userName.Contains(textToCut))
                        {
                            userName = userName.Remove(userName.IndexOf(textToCut), textToCut.Length);
                            Console.WriteLine(userName);
                        }
                        else
                        {
                            Console.WriteLine($"The username {userName} doesn't contain {textToCut}.");
                        }
                        break;
                    case "Replace":
                        char symbulToreplayse = char.Parse(commands[1]);
                        userName = userName.Replace(symbulToreplayse, '-');
                        Console.WriteLine(userName);
                        break;
                    case "IsValid":
                        char validSymbul = char.Parse(commands[1]);
                        if (userName.Contains(validSymbul))
                        {
                            Console.WriteLine("Valid username.");
                        }
                        else
                        {
                            Console.WriteLine($"{validSymbul} must be contained in your username.");
                        }
                        break;
                }
            }
        }
    }
}

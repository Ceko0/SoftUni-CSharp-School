namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string income = String.Empty;
            while ((income = Console.ReadLine()) != "Reveal")
            {
                string[] commands = income
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substring = commands[1];
                        if (message.Contains(substring))
                        {
                            message = message.Remove(message.IndexOf(substring), substring.Length);
                            substring = new string(substring.Reverse().ToArray());
                            message += substring;
                            Console.WriteLine(message);
                        }
                        else Console.WriteLine("error");
                        break;
                    case "ChangeAll":
                        substring = commands[1];
                        string replacement = commands[2];
                        message = message.Replace(substring, replacement);
                        Console.WriteLine(message);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
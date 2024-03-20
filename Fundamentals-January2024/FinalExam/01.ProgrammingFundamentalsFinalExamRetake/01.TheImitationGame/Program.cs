namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string income = "";
            while ((income = Console.ReadLine())!= "Decode")
            {
                string[] commands = income
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "Move":
                        int letterCount = int.Parse(commands[1]);
                        string letterToMove = message.Substring(0, letterCount);
                        message = message.Remove(0, letterCount);
                        message = message += letterToMove;
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string sub = commands[1];
                        string replacement = commands[2];
                        message = message.Replace(sub, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}

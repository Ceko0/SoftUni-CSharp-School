namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string income = String.Empty;
            while ((income = Console.ReadLine()) != "Done")
            {
                string[] commands = income
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                switch (commands[0])
                {
                    case "TakeOdd":
                        password = new string(password.Where(((c ,index) => index % 2 != 0)).ToArray());
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        string substring = password.Substring(index, length);
                        int firstIndex = password.IndexOf(substring);
                        password = password.Remove(firstIndex , length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substringToReplace = commands[1];
                        string substringToPlace = commands[2];
                        if (password.Contains(substringToReplace))
                        {
                            password = password.Replace(substringToReplace, substringToPlace);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}

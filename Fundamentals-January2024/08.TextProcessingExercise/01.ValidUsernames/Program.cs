namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < userNames.Length; i++)
            {
                string currentUserName = userNames[i];
                if (currentUserName.Length >= 3 && currentUserName.Length <= 16)
                {
                    bool isValid = true;
                    foreach (var digit in currentUserName)
                    {
                        if (char.IsLetterOrDigit(digit) || digit == '_' || digit == '-')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(currentUserName);
                    }
                }
            }
        }
    }
}
namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneList = Console.ReadLine()
                .Split(", " , StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string income = "";
            while ((income = Console.ReadLine()) != "End")
            {
                List<string> commands = income
                    .Split(" - " , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                switch (commands[0])
                {
                    case "Add":
                        if (!phoneList.Contains(commands[1]))
                        {
                            phoneList.Add(commands[1]);
                        }
                        break;
                    case "Remove":
                        if (phoneList.Contains(commands[1]))
                        {
                            phoneList.Remove(commands[1]);
                        }
                        break;
                    case "Bonus phone":
                        List<string> PhonesToAdd = commands[1]
                            .Split(":")
                            .ToList();
                        if (phoneList.Contains(PhonesToAdd[0]))
                        {
                            int index = phoneList.IndexOf(PhonesToAdd[0]);
                            if (index + 1 >= phoneList.Count)
                            {
                                phoneList.Add(PhonesToAdd[1]);
                                continue;
                            }
                            phoneList.Insert(index +1 , PhonesToAdd[1]);
                        }
                        break;
                    case "Last":
                        if (phoneList.Contains(commands[1]))
                        {
                            phoneList.Remove(commands[1]);
                            phoneList.Add(commands[1]);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", phoneList).Trim(',',' '));
        }
    }
}
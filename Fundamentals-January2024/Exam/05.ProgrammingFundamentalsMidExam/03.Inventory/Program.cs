namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", " ,StringSplitOptions.RemoveEmptyEntries )
                .ToList();
            string income = "";
            while ((income = Console.ReadLine()) != "Craft!")
            {
                List<string> commands = income
                    .Split(" - ")
                    .ToList();

                switch (commands[0])
                {
                    case "Collect":
                        if (!journal.Contains(commands[1]))
                        {
                            journal.Add(commands[1]);
                        }
                        break;
                    case "Drop":
                        if (journal.Contains(commands[1]))
                        {
                            journal.Remove(commands[1]);
                        }
                        break;
                    case "Combine Items":
                        List<string> currentItems = commands[1]
                            .Split(":")
                            .ToList();
                        if (journal.Contains(currentItems[0]))
                        {
                            int position = journal.IndexOf(currentItems[0]);
                            if (position+1 >= journal.Count)
                            {
                                journal.Add(currentItems[1]);
                                continue;
                            }
                            journal.Insert(position + 1, currentItems[1]);
                        }
                        break;
                    case "Renew":
                        if (journal.Contains(commands[1]))
                        {
                            journal.Remove(commands[1]);
                            journal.Add(commands[1]);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", " , journal).Trim(',' , ' '));
        }
    }
}

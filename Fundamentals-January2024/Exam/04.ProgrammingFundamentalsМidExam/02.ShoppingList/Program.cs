namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ShopingList = Console.ReadLine()
                .Split("!" , StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string income;
            while ((income = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> commands = income
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                switch (commands[0])
                {
                    case "Urgent":
                        if (!ShopingList.Contains(commands[1]))
                        {
                            ShopingList.Insert(0, commands[1]);
                        }
                        break;
                    case "Unnecessary":
                        if (ShopingList.Contains(commands[1]))
                        {
                            ShopingList.Remove(commands[1]);
                        }
                        break;
                    case "Correct":
                        if (ShopingList.Contains(commands[1]))
                        {
                            int position = ShopingList.IndexOf(commands[1]);
                            ShopingList.Remove(commands[1]);
                            ShopingList.Insert(position , commands[2]);
                        }
                        break;
                    case "Rearrange":
                        if (ShopingList.Contains(commands[1]))
                        {
                            ShopingList.Remove(commands[1]);
                            ShopingList.Add(commands[1]);
                        }
                        break;
                }
            }

            Console.WriteLine(String.Join(", " , ShopingList).Trim(',',' '));
        }
    }
}

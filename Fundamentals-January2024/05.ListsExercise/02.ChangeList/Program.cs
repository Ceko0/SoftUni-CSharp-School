namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse) 
                .ToList();

            string command = "";
            while ((command = Console.ReadLine()) != "end") 
            {
                List<string> commands = command
                    .Split()
                    .ToList();
                if (commands[0] == "Delete")
                {
                    list.RemoveAll(x => x == int.Parse(commands[1]));
                }
                else if (commands[0] == "Insert")
                {
                    list.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}

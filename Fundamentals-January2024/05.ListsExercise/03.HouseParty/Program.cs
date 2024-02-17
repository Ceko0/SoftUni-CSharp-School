namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> people = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> commands = Console.ReadLine()
                    .Split()
                    .ToList();
                if (commands[2] != "not")
                {
                    bool isOnList = people.Contains(commands[0]);
                    if(!isOnList) people.Add(commands[0]);
                    else Console.WriteLine($"{commands[0]} is already in the list!");
                }
                else
                {
                    bool isOnList = people.Contains(commands[0]);
                    if (isOnList) people.Remove(commands[0]);
                    else Console.WriteLine($"{commands[0]} is not in the list!");
                }
            }
            Console.WriteLine(string.Join("\n" ,people));
        }
    }
}
/*
5
Tom is going!
Annie is going!
Tom is going!
Garry is going!
Jerry is going! 

 */
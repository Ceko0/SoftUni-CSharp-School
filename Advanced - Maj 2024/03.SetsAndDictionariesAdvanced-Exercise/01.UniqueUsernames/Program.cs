namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userCounter = int.Parse(Console.ReadLine());

            HashSet<string> users = new();
            for (int i = 0; i < userCounter; i++)
            {
                string userName = Console.ReadLine();
                users.Add(userName);
            }
            Console.WriteLine(string.Join(Environment.NewLine , users));
        }
    }
}

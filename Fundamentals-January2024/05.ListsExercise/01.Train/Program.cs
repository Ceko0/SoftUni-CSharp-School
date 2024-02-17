namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> vagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int vagonCapacity = int.Parse(Console.ReadLine());

            string command = "";
            while ((command = Console.ReadLine()) != "end" )
            {
                List<string> commands = command
                    .Split()
                    .ToList();
                if (commands[0] == "Add")
                {
                    vagons.Add(int.Parse(commands[1]));
                }
                else
                {
                    for (int i = 0; i < vagons.Count; i++)
                    {
                        int people = vagons[i] + int.Parse(commands[0]);
                        if (people <= vagonCapacity)
                        {
                            vagons.Insert(i , people);
                            vagons.RemoveAt(i + 1);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", vagons));
        }
    }
}

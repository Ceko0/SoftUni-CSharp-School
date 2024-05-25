namespace _06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            HashSet<string> names = new();

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}

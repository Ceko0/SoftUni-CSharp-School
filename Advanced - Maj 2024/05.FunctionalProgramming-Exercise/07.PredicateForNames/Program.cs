namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> filter =( name , nameLength) => name.Length <= nameLength;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => filter(x, nameLength))));
        }
    }
}

namespace _05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Box<string> box = new();
            for (int i = 0; i < counter; i++)
            {
                box.Elements.Add(Console.ReadLine());
            }
            string value = Console.ReadLine();

            Console.WriteLine(box.CountOFLargetThenValue(value));
        }
    }
}

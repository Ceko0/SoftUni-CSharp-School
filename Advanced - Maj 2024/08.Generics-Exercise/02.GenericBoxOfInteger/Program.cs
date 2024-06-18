namespace _02.GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Box<int> box = new();
            for (int i = 0; i < counter; i++)
            {
                box.Elements.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(box);
        }
    }
}

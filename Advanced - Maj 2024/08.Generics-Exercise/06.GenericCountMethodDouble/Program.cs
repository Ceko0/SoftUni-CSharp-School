namespace _05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Box<double> box = new();
            for (int i = 0; i < counter; i++)
            {
                box.Elements.Add(double.Parse(Console.ReadLine()));
            }
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountOFLargetThenValue(value));
        }
    }
}

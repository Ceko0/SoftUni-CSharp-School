namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();
            Func<string, string> addingSir = x => "sir " + x;
            Action<string[]> print =
                x => Console.WriteLine(string.Join(Environment.NewLine,x.Select(x => addingSir(x))));

            print(input);
        }
    }
}

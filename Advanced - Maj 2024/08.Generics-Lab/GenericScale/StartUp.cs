namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new(22, 33);
            Console.WriteLine(scale.AreEqual());
        }
    }
}

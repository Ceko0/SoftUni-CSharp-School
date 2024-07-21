namespace Shapes
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            Rectangle rectangle = new(2, 3);
            Circle circle = new(2);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());

        }
    }
}

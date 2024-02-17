namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int productsCounter = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();
            for (int i = 0; i < productsCounter; i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();
            for (int i = 1; i <= productsCounter; i++)
            {
                Console.WriteLine($"{i}.{products[i-1]}");
            }
        }
    }
}
namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SortedDictionary<string, List<(string, decimal)>> shops = new();
            string input = string.Empty;

            while((input = Console.ReadLine()) != "Revision") 
            {
                string[] commands = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = commands[0];
                string product = commands[1];
                decimal price = decimal.Parse(commands[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new List<(string, decimal)>());
                }

                shops[shop].Add((product, price));
            }
            foreach ((string shop , List<(string, decimal)> productInfo) in shops)
            {
                Console.WriteLine($"{shop}->");
                foreach((string product , decimal price) in productInfo)
                {
                    Console.WriteLine($"Product: {product}, Price: {price.ToString("0.##")}");
                }
            }
        }
    }
}

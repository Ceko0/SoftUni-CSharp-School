namespace _03.Orders
{
    internal class Program
    {
        class Product
        {
            public Product(string name, decimal price, decimal quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Product> productsList = new Dictionary<string, Product>();
            string income = "";
            while ((income = Console.ReadLine()) != "buy")
            {
                string[] information = income
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!productsList.ContainsKey(information[0]))
                {
                    productsList.Add(information[0], new Product(information[0], decimal.Parse(information[1]), decimal.Parse(information[2])));
                }
                else
                {
                    productsList[information[0]].Price = decimal.Parse(information[1]);
                    productsList[information[0]].Quantity += decimal.Parse(information[2]);
                }
            }
            foreach (var kvp in productsList)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Quantity * kvp.Value.Price:f2}");
            }
        }
    }
}

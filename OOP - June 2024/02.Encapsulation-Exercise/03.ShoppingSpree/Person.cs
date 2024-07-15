using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public string Name { get; }
        private decimal Money;
        private readonly List<Product> products;
        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty");
            if (money < 0)
                throw new ArgumentException("Money cannot be negative");

            Name = name;
            Money = money;
            products = new();
            Products = products.AsReadOnly();
        }

        public IReadOnlyCollection<Product> Products;

        public bool TryBuy(Product product)
        {
            if (product.Cost > Money) return false;
            else
            {
                products.Add(product);
                Money -= product.Cost;
                return true;
            }
        }
        public override string ToString()
        {
            if (products.Count == 0) return $"{Name} - Nothing bought";
            StringBuilder sb = new();
            sb.Append($"{Name} - ");
            foreach (Product product in products)
            {
                sb.Append($"{product.Name}, ");
            }
            return sb.ToString().TrimEnd(' ', ',');
        }
    }
}
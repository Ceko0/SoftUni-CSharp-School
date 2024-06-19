using System.Xml.Linq;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new();
        }
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity && !Stall.Contains(product))
            {
                Stall.Add(product);
            }
        }
        public bool RemoveProduct(string name)
        {
            Product currentProduct = Stall.FirstOrDefault(p => p.Name == name);
            if (currentProduct != null)
            {
                Stall.Remove(currentProduct);
                return true;
            }
            return false;
        }
        public string SellProduct(string name, double quantity)
        {
            Product currentProduct = Stall.FirstOrDefault(p => p.Name == name);
            if (currentProduct != null)
            {
                Turnover += quantity * currentProduct.Price;
                return currentProduct.ToString();
            }
            return "Product not found";
        }
        public string GetMostExpensive()
        {
            
            return Stall.OrderByDescending(p => p.Price).ToList().FirstOrDefault().ToString();

        }
        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }
        public string PriceList()
        {
            return $"Groceries Price List:{Environment.NewLine}{string.Join(Environment.NewLine, Stall)}";
        }
    }
}

namespace _05.ShoppingSpree
{
    internal class Program
    {
        class Person
        {
            public Person(string name, decimal money)
            {
                Name = name;
                Money = money;
            }

            public string Name { get; set; }
            public decimal Money { get; set; }
            public List<Bag> Bag { get; set; } = new List<Bag>();
            public override string ToString()
            {
                if (Bag.Count == 0)
                {
                    return $"{Name} - Nothing bought";
                }
                else
                {
                    string outputProducts = string.Join(", ", Bag.Select(b => b.buyedProduct));
                    return $"{Name} - {outputProducts}";
                }
            }
        }

        class Bag
        {
            public Bag(string buyedProduct)
            {
                this.buyedProduct = buyedProduct;
            }

            public string buyedProduct { get; set; }
        }

        class Product
        {
            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        static void Main(string[] args)
        {
            string[] person = Console.ReadLine()
                .Split(";",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Person> peopleList = new List<Person>();
            foreach (var personWhitMoney in person)
            {
                string[] personInfo = personWhitMoney.Split("=");

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);
                peopleList.Add(new Person(name, money));
            }

            string[] products = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Product> productsList = new List<Product>();
            foreach (var productInput in products)
            {
                string[] productInfo = productInput.Split("=");

                string name = productInfo[0];
                decimal price = decimal.Parse(productInfo[1]);
                productsList.Add(new Product(name, price));
            }

            string income = "";

            while ((income = Console.ReadLine()) != "END")
            {
                string[] shoping = income
                    .Split()
                    .ToArray();
                string name = shoping[0];
                string productToBuy = shoping[1];

                Person currentPerson = peopleList.FirstOrDefault(x => x.Name == name);
                Product currentProduct = productsList.FirstOrDefault(p => p.Name == productToBuy);

                if (currentPerson != null && currentProduct != null)
                {
                    if (currentProduct.Price <= currentPerson.Money)
                    {
                        currentPerson.Money -= currentProduct.Price;
                        currentPerson.Bag.Add(new Bag(productToBuy));
                        Console.WriteLine($"{name} bought {productToBuy}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} can't afford {productToBuy}");
                    }
                }
            }

            foreach (var personBagList in peopleList)
            {
                Console.WriteLine(personBagList);
            }
        }
    }
}

namespace _06.StoreBoxes
{
    class Item
    {
        public Item(decimal price, string name)
        {
            Price = price;
            Name = name;
        }
        public string Name { get;}
        public decimal Price { get;}
    }
    class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity, decimal price)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            Price = price;
        }

        public string SerialNumber { get; }
        public Item Item { get; }
        public int ItemQuantity { get; }
        public decimal Price { get; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string income = "";
            while((income = Console.ReadLine()) != "end")
            {
                string[] information = income
                    .Split();
                
                decimal price = int.Parse(information[2]) * decimal.Parse(information[3]);
                Item item = new Item(decimal.Parse(information[3]), information[1]);
                Box box = new Box(information[0], item, int.Parse(information[2]), price);

                boxes.Add(box);
            }
            boxes = boxes.OrderByDescending(b => b.Price).ToList();
            foreach(Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
}

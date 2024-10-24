namespace DeskMarket.Models
{
    public class IndexViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public bool IsSeller { get; set; }

        public bool HasBought { get; set; }

    }
}

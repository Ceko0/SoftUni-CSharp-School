namespace DeskMarket.Models
{
    using System.ComponentModel.DataAnnotations;

    using static common.ValidationConstraints.Product;

    public class CartViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(PriceMinRange, PriceMaxRange)]
        public decimal Price { get; set; }
    }
}

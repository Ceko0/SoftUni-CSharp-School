namespace DeskMarket.Models
{
    using System.ComponentModel.DataAnnotations;

    using static common.ValidationConstraints.Product;

    public class DetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Range(PriceMinRange, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        public string Seller { get; set; } = null!;

        public bool HasBought { get; set; }

        public string CategoryName { get; set; } = null!;

        [DataType(DataType.Date)]
        public string AddedOn { get; set; } = null!;
    }
}

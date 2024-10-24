namespace DeskMarket.Models
{    
    using System.ComponentModel.DataAnnotations;

    using static common.ValidationConstraints.Product;
    using Data.Models;

    public class EditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(PriceMinRange, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Url]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string AddedOn { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;

        public IEnumerable<Category> Categories { get; set; } = [];
    }
}

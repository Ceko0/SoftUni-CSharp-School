namespace DeskMarket.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static common.ValidationConstraints.Product;

    public class AddInputModel
    {
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
        public string? ImageUrl { get; set; }

        [Required]
        public string AddedOn { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>(); // Инициализирана с нова колекция
    }
}

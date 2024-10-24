namespace DeskMarket.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static common.ValidationConstraints.Product;

    public class Product
    {
        [Required]
        [Key]
        [Comment("Primary key of the product.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Name of the product.")]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the current product.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PriceMinRange, PriceMaxRange)]
        [Comment("Price of the product.")]
        public decimal Price { get; set; }

        [Url]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("URL of the product's image.")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Identifier of the seller of the product.")]
        public string SellerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(SellerId))]
        [Comment("User entity who is selling the product.")]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("Date when the product was added.")]
        public DateTime AddedOn { get; set; }

        [Required]
        [Comment("Category identifier for the product.")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category of the product.")]
        public Category Category { get; set; } = null!;

        [Comment("Flag indicating if the product is deleted.")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of clients associated with this product.")]
        public ICollection<ProductClient> ProductsClients { get; set; } = [];
    }
}

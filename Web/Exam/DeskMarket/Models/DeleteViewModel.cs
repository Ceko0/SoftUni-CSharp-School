namespace DeskMarket.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static common.ValidationConstraints.Product;

    public class DeleteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        public string SellerId { get; set; } = null!;

        [Required]
        public string Seller { get; set; } = null!;
    }
}

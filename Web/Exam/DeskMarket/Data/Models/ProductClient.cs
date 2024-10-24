namespace DeskMarket.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class ProductClient
    {
        [Required]        
        [Comment("Primary key and foreign key linking to the product.")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey(nameof(ProductId))]
        [Comment("The product associated with the client.")]
        public Product Product { get; set; } = null!;

        [Required]
        [Comment("Primary key and foreign key linking to the client.")]
        public string ClientId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ClientId))]
        [Comment("The client (user) associated with the product.")]
        public IdentityUser Client { get; set; } = null!;
    }
}

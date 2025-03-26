namespace ProductShop.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class User
    {

        public int Id { get; set; }

        public string? FirstName { get; set; } 
        
        [Required]
        public string LastName { get; set; } = null!;

        public int? Age { get; set; }
        [InverseProperty(nameof(Product.Seller))]
        public virtual ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>() ;

        [InverseProperty(nameof(Product.Buyer))]
        public virtual ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}
namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        [InverseProperty("Seller")]
        public ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>();

        [InverseProperty("Buyer")]
        public ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}
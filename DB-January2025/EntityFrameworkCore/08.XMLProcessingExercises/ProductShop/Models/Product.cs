using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }


        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual User Seller { get; set; } = null!;

        public int? BuyerId { get; set; }
        public virtual User? Buyer { get; set; } 

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new HashSet<CategoryProduct>();
    }
}
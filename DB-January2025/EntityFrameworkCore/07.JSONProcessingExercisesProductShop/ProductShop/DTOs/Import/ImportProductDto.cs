using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import
{
    public class ImportProductDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Price { get; set; } =null!;

        [Required] public string SellerId { get; set; } = null!;


        public string? BuyerId { get; set; } 
    }
}

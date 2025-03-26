namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportCategoryProductDto
    {
        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string ProductId { get; set; }
    }
}

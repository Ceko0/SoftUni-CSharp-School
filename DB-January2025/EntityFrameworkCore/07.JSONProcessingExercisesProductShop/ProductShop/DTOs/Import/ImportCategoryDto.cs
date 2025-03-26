namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}

namespace DeskMarket.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static common.ValidationConstraints.Category;

    public class Category
    {
        [Key]
        [Comment("Primary key of the category.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Name of the category.")]
        public string Name { get; set; } = null!;

        [Comment("Collection of products associated with this category.")]
        public ICollection<Product> Products { get; set; } = [];
    }
}

using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [JsonProperty(nameof(FirstName))]
        public string? FirstName { get; set; }

        [Required]
        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; } = null!;

        [JsonProperty(nameof(Age))]
        public int? Age { get; set; }
    }
}

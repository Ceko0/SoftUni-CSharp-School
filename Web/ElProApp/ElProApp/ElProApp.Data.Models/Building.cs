namespace ElProApp.Data.Models
{
    using ElProApp.Data.Models.Mappings;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Building;
    using static Common.EntityValidationErrorMessage.Building;
    using static Common.EntityValidationErrorMessage.Master;

    public class Building
    {
        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Comment("Unique identifier for the building.")]
        public Guid Id { get; set; } = new();

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(BuildingNameMinLength, ErrorMessage = ErrorMassageBuildingNameMinLength)]
        [MaxLength(BuildingNameMaxLength, ErrorMessage = ErrorMassageBuildingNameMaxLength)]
        [Comment("The name of the building with a minimum of 3 and a maximum of 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [MinLength(LocationMinLength, ErrorMessage = ErrorMassageLocationMinLength)]
        [MaxLength(LocationMaxLength, ErrorMessage = ErrorMassageLocationMaxLength)]
        [Comment("The location of the building with a minimum of 10 and a maximum of 100 characters.")]
        public string Location { get; set; } = null!;

        public virtual ICollection<BuildingTeamMapping> TeamsOnBuilding { get; set; } = new HashSet<BuildingTeamMapping>();
    }
}

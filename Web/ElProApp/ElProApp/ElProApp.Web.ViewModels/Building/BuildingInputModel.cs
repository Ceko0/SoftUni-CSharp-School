namespace ElProApp.Web.ViewModels.Building
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Building;
    using static Common.EntityValidationErrorMessage.Building;
    using static Common.EntityValidationErrorMessage.Master;
    using Team;

    public class BuildingInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageBuildingNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageBuildingNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(LocationMinLength, ErrorMessage = ErrorMassageLocationMinLength)]
        [MaxLength(LocationMaxLength, ErrorMessage = ErrorMassageLocationMaxLength)]
        public string Location { get; set; } = null!;

        public virtual ICollection<TeamViewModel> TeamMapping { get; set; } = new HashSet<TeamViewModel>();

    }
}

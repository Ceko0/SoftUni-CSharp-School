namespace ElProApp.Web.ViewModels.Building
{
    using System.ComponentModel.DataAnnotations;

    using Team;
    using static Common.EntityValidationConstants.Building;
    using static Common.EntityValidationErrorMessage.Building;
    using static Common.EntityValidationErrorMessage.Master;

    public class AddTeamToBuildingInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageBuildingNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageBuildingNameMaxLength)]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(LocationMinLength, ErrorMessage = ErrorMassageLocationMinLength)]
        [MaxLength(LocationMaxLength, ErrorMessage = ErrorMassageLocationMaxLength)]
        public string Location { get; set; } = null!;

        public IEnumerable<TeamCheckBoxItemInputModel> TeamMapping { get; set; } =
            new HashSet<TeamCheckBoxItemInputModel>();
    }
}

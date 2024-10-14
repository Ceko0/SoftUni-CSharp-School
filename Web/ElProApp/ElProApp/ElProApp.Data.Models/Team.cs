namespace ElProApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Team;
    using static Common.EntityValidationErrorMessage.Team;
    using static Common.EntityValidationErrorMessage.Master;
    using ElProApp.Data.Models.Mappings;

    public class Team
    {
        [Required]
        [Comment("Primary key and unique identifier for the team")]
        public Guid Id { get; set; } = new();

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength )]
        [Comment("The name of the team with a maximum length")]
        public string Name { get; set; } = null!;

        public virtual ICollection<BuildingTeamMapping> BuildingWhitTeam {  get; set; } = new HashSet<BuildingTeamMapping>();

        public virtual ICollection<JobDoneTeamMapping> JobsDoneByTeam { get; set; } = new HashSet<JobDoneTeamMapping>();

        public virtual ICollection<EmployeeTeamMapping> EmployeesInTeam { get; set; } = new HashSet<EmployeeTeamMapping>();
    }
}
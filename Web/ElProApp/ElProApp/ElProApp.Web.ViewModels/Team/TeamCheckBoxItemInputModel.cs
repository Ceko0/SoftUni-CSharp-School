namespace ElProApp.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Team;
    public  class TeamCheckBoxItemInputModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public bool IsSelected { get; set; }

    }
}

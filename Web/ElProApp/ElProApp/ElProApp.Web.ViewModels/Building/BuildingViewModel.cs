namespace ElProApp.Web.ViewModels.Building
{
    using Team;
    public class BuildingViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public virtual ICollection<TeamViewModel> TeamMapping { get; set; } = new HashSet<TeamViewModel>();
    }
}

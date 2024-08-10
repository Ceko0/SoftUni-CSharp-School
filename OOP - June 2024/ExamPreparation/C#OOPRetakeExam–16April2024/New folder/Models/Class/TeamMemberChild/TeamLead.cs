using TheContentDepartment.Enums;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Class.TeamMemberChild
{
    public class TeamLead : TeamMember
    {
        public TeamLead(string name, string path)
            : base(name, ValidatePath(path))
        {
        }
        private static string ValidatePath(string path)
        {
            if (!TeamLeadPath.TryParse(path, out TeamLeadPath pathResult))
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, nameof(path)));

            return path;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.";
        }
    }
}

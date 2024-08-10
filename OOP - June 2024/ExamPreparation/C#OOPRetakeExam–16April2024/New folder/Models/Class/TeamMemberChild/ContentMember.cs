using TheContentDepartment.Enums;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Class.TeamMemberChild
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path)
            : base(name, ValidatePath(path))
        {
        }
        private static string ValidatePath(string path)
        {
            if (!ContentMemberPath.TryParse(path, out ContentMemberPath pathResult))
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, nameof(path)));

            return path;
        }
        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";

        }
    }
}

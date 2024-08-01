using TheContentDepartment.Enums;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Class
{
    public abstract class TeamMember : ITeamMember
    {
        private List<string> inProgress;
        protected TeamMember(string name, string path)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
            Name = name;
            Path = path;
            inProgress = new();
            InProgress = inProgress.AsReadOnly();
        }

        public string Name { get; }
        public string Path { get; }
        public IReadOnlyCollection<string> InProgress { get; }
        public void WorkOnTask(string resourceName)
        {
            inProgress.Add(resourceName);
        }

        public void FinishTask(string resourceName)
        {
            inProgress.Remove(resourceName);
        }
    }
}

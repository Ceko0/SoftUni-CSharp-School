using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Class
{
    public abstract class Resource :IResource
    {
        protected Resource(string name, string creator, int priority)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
            Name = name;
            Creator = creator;
            Priority = priority;
            IsTested = false;
            IsApproved = false;
        }

        public string Name { get; }
        public string Creator { get; }
        public int Priority { get; }
        public bool IsTested { get; private set;  }
        public bool IsApproved { get; private set; }
        public void Test()
        {
            this.IsTested = true;
        }

        public void Approve()
        {
            this.IsApproved = true;
        }
        public override string ToString() => $"{Name} ({GetType().Name}), Created By: {Creator}";
    }
}

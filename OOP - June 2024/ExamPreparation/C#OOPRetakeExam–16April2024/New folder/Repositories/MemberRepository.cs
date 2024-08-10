using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private List<ITeamMember> models = new();
        public IReadOnlyCollection<ITeamMember> Models => models.AsReadOnly();
        public void Add(ITeamMember model) => models.Add(model);
        public ITeamMember TakeOne(string modelName) => models.FirstOrDefault(m => m.Name == modelName);
    }
}

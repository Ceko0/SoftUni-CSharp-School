using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private List<ITeamMember> models;

        public MemberRepository()
        {
            models = new();
            Models = models.AsReadOnly();
        }
        public IReadOnlyCollection<ITeamMember> Models { get; }
        public void Add(ITeamMember model) => models.Add(model);
        public ITeamMember TakeOne(string modelName) => models.FirstOrDefault(m => m.Name == modelName);
    }
}

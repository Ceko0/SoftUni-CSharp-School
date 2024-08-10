using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models.Class.ResourceChild;
using TheContentDepartment.Models.Class.TeamMemberChild;
using TheContentDepartment.Models.Contracts;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private List<IResource> resources = new();
        private List<ITeamMember> members = new();
        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (!(memberType == "TeamLead" || memberType == "ContentMember"))
                return $"{memberType} is not a valid member type.";
            if (members.Any(m => m.Path == path))
                return "Position is occupied.";
            if (members.Any(m => m.Name == memberName))
                return $"{memberName} has already joined the team.";
            members.Add(memberType == "TeamLead" ? new TeamLead(memberName, path) : new ContentMember(memberName, path));
            return $"{memberName} has joined the team. Welcome!";
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (!(resourceType == "Exam" || resourceType == "Workshop" || resourceType == "Presentation"))
                return $"{resourceType} type is not handled by Content Department.";

            ITeamMember teamMember = members.FirstOrDefault(x => x.Path == path);
            if (teamMember == null)
                return $"No content member is able to create the {resourceName} resource.";

            if (teamMember.InProgress.Contains(resourceName))
                return $"The {resourceName} resource is being created.";
            
            resources.Add(resourceType == "Exam"
                ? new Exam(resourceName, teamMember.Name)
                : resourceType == "Workshop"
                    ? new Workshop(resourceName, teamMember.Name)
                    : new Presentation(resourceName, teamMember.Name));
            teamMember.WorkOnTask(resourceName);
            return $"{teamMember.Name} created {resourceType} - {resourceName}.";
        }

        public string LogTesting(string memberName)
        {
            ITeamMember teamMember = this.members.FirstOrDefault(m => m.Name == memberName);
            if (teamMember == null) return "Provide the correct member name.";
            IResource resource = this.resources.OrderBy(r => r.Priority).Where(r => r.IsTested == false)
                .FirstOrDefault(r => r.Creator == memberName);
            if (resource == null) return $"{memberName} has no resources for testing.";
            resource.Test();
            ITeamMember teamLead = members.FirstOrDefault(m => m.Path == "Master");
            teamMember.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);

            return $"{resource.Name} is tested and ready for approval.";
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources
                .FirstOrDefault(r => this.members
                    .Any(m => m.InProgress.Contains(r.Name) && r.Name == resourceName));
            if (!resource.IsTested)
                return $"{resourceName} cannot be approved without being tested.";
            ITeamMember teamLead = this.members.FirstOrDefault(m => m.Path == "Master");
            if (isApprovedByTeamLead == true) resource.Approve();
            if (isApprovedByTeamLead)
            {
                teamLead.FinishTask(resourceName);
                return $"{teamLead.Name} approved {resourceName}.";
            }
                
             return $"{teamLead.Name} returned {resourceName} for a re-test.";
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new();
            sb.AppendLine("Finished Tasks:");
            foreach (IResource resource in resources)
            {
                if (resource.IsApproved) sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine("Team Report:");
            sb.AppendLine($"--{members.FirstOrDefault(m => m.Path == "Master").ToString()}");
            foreach (ITeamMember member in members)
            {
                if (member.Path != "Master") sb.AppendLine(member.ToString());
            }

            return sb.ToString();
        }
    }
}

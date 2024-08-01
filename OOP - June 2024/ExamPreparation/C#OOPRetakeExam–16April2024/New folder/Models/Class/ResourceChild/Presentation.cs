namespace TheContentDepartment.Models.Class.ResourceChild
{
    public class Presentation : Resource
    {
        public const int DefaultPriority = 3;
        public Presentation(string name, string creator) 
            : base(name, creator, DefaultPriority)
        {
        }
    }
}

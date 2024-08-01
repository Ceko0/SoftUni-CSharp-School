namespace TheContentDepartment.Models.Class.ResourceChild
{
    public class Workshop :Resource
    {
        public const int DefaultPriority = 2;
        public Workshop(string name, string creator ) 
            : base(name, creator, DefaultPriority)
        {
        }
    }
}

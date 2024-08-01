namespace TheContentDepartment.Models.Class.ResourceChild
{
    public class Exam :Resource
    {
        public const int DefaultPriority = 1;
        public Exam(string name, string creator) 
            : base(name, creator, DefaultPriority)
        {
        }
    }
}

using _08.CollectionHierarchy.Interfeces;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> collection = new();

        public int Add(string input) 
        {
            collection.Add(input);
            return collection.Count -1;
        }
    }
}

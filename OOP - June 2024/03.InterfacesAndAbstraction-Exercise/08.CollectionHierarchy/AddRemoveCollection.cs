using _08.CollectionHierarchy.Interfeces;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> collection = new();

        public int Add(string input)
        {
            collection.Insert(0,input);
            return 0;
        }
        public string Remove() 
        {
            string itemToRemove = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count -1);
            return itemToRemove;
        
        }
    }
}

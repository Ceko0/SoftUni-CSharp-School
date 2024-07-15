using _08.CollectionHierarchy.Interfeces;

namespace _08.CollectionHierarchy
{
    public class MyList : IAdd, IRemove, ICount
    {
        private List<string> collection = new();

        public int Count => collection.Count;
        public int Add(string input)
        {
            collection.Insert(0, input);
            return 0;
        }
        public string Remove()
        {
            string itemToRemove = collection[0];
            collection.RemoveAt(0);
            return itemToRemove;
        }
    }
}

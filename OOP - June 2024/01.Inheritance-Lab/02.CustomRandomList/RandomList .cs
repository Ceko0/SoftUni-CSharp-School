namespace CustomRandomList
{
    public class RandomList :List<string>
    {
        public string RandomString()
        {
            Random rnd = new();
            int index = rnd.Next(Count);
            string removedElement = this[index];
            RemoveAt(index);
            return removedElement;
        }
    }
}

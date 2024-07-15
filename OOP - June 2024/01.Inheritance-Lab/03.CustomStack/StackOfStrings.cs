namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count ==0;
        public Stack<string> AddRange(IEnumerable<string> values)
        {
            foreach (string item in values)
            {
                this.Push(item);
            }
            return this;
        }
    }
}

using System.Collections;
using System.Text;

namespace _04.Froggy
{
    internal class Lake : IEnumerable<int>
    {
         private List<int> stones;

        public int Count => stones.Count;
        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var stone in stones)
            {
                sb.Append(stone.ToString());
            }
            return sb.ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i++)
            {
                if  (i % 2 ==  0)
                yield return stones[i];
            }
            for (int i = stones.Count -1 ; i >= 0; i--)
            {
                if (i % 2 != 0) 
                    yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

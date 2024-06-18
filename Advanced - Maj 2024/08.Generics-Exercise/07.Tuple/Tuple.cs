using System.Text;

namespace _07.Tuple
{
    public class MyTuple<T1,T2>
    {
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }

        List<Tuple<T1,T2>> elements;

        public MyTuple()
        {
            elements = new();
        }

        public MyTuple(T1 item1, T2 item2)
        {
            elements = new();
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {           
              return $"{item1} -> {item2}";          
        }
    }
}

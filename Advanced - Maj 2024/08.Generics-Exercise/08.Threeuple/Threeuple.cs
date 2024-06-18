namespace _08.Threeuple
{
    internal class MyThreeuple<T1, T2, T3>
    {
        public T1 item1 { get; set; }
        public T2 item2 { get; set; }
        public T3 item3 { get; set; }

        List<Tuple<T1, T2, T3>> elements;

        public MyThreeuple()
        {
            elements = new();
        }

        public MyThreeuple(T1 item1, T2 item2, T3 item3)
        {
            elements = new();
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}

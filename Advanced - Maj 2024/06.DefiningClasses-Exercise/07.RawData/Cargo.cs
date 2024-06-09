namespace _07.RawData
{
    internal class Cargo
    {
        private string type;
        private int weigth;

        public Cargo(string type, int weigth)
        {
            Type = type;
            Weigth = weigth;
        }

        public string Type { get => type; set => this.type = value; }
        public int Weigth { get => weigth; set => this.weigth = value; }
    }
}

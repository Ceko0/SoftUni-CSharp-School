namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}

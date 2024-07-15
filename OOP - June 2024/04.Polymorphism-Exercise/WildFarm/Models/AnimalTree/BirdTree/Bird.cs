namespace WildFarm.Models.AnimalTree.BirdTree
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize,double eatingCoefficient)
            : base(name, weight, eatingCoefficient)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}

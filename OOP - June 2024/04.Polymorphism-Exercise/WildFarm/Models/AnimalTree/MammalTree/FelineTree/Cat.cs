using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree.MammalTree.FelineTree
{
    public class Cat : Feline, IProductSound
    {
        const double eatingCoefficient = 0.30;
        public Cat(string name, double weight,  string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, eatingCoefficient)
        {
        }
        public string ProductSound() => "Meow";
    }
}

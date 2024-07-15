using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree.MammalTree
{
    public class Mouse : Mammal, IProductSound
    {
        const double eatingCoefficient = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, eatingCoefficient)
        {
        }
        public string ProductSound() => "Squeak";
    }
}

using WildFarm.Interfeces;
using WildFarm.Models.FoodTree;

namespace WildFarm.Models.AnimalTree.MammalTree.FelineTree
{
    public class Tiger : Feline, IProductSound
    {
        const double eatingCoefficient = 1.00;
        public Tiger(string name, double weight,  string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, eatingCoefficient)
        {
        }
        public string ProductSound() => "ROAR!!!";
    }
}

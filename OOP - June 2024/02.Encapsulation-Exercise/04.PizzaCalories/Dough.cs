using PizzaCalories.enums;
namespace PizzaCalories
{
    public class Dough
    {
        private static int MinWeight = 1;
        private static int MaxWeight = 200;
        private string _flourType;
        private string _bakingTechnique;
        private int _weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            if (!Enum.TryParse(flourType,ignoreCase: true ,out FlourTypeEnums flowerTypevalue) || !Enum.TryParse(bakingTechnique, ignoreCase: true , out BakingTechniqueEnums bakingTechniqueValue))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            if (weight < MinWeight || weight > MaxWeight) throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            _weight = weight;
        }

        public string FlourType { get => _flourType; private set => _flourType = value; }
        public string BakingTechnique { get => _bakingTechnique; private set => _bakingTechnique = value; }
        public int Weight => _weight;
        
        public string CalculateCalories()
        {
            double flourTypeCalories = FlourType.ToLower() == "white" ? 1.5 : 1.0;
            double bakingTechniqueCalories = BakingTechnique.ToLower() == "crispy" ? 0.9 : BakingTechnique.ToLower() == "chewy" ? 1.1 : 1.0;
            return (flourTypeCalories * bakingTechniqueCalories * Weight * 2).ToString("f2");
        }
    }
}

using WildFarm.Models.FoodTree;

namespace WildFarm.ClassCreator
{
    public interface IFoodCreator
    {
        public Food CreateFood(string[] input)
        {
            return (input[0]) switch
            {
                "Vegetable" => new Vegetable(input[0], int.Parse(input[1])),
                "Fruit" => new Fruit(input[0], int.Parse(input[1])),
                "Meat" => new Meat(input[0], int.Parse(input[1])),
                "Seeds" => new Seeds(input[0], int.Parse(input[1]))
            };
        }
    }
}

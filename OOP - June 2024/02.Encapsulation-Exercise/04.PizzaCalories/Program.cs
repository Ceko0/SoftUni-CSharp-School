namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            string[] pizzaName = Console.ReadLine().Split();
            Pizza pizza = null;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] pizzaIngredients = input.Split();
                    switch (pizzaIngredients[0])
                    {
                        case "Dough":
                            if (pizza == null)
                            {
                                string flourType = pizzaIngredients[1];
                                string bakingTechnique = pizzaIngredients[2];
                                Dough dough = new(flourType,bakingTechnique , int.Parse(pizzaIngredients[3]));
                                pizza = new(pizzaName[1], dough);
                            }
                            break;

                        case "Topping":
                            if (pizza != null)
                            {
                                string toppingType = pizzaIngredients[1];
                                Topping topping = new(toppingType, int.Parse(pizzaIngredients[2]));
                                pizza.AddTopping(topping);
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }                
            }
            Console.WriteLine(pizza);
        }
    }
}

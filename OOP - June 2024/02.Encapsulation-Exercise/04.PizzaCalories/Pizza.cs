namespace PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private Dough _dough;
        private List<Topping> _topping;
        public Pizza(string name, Dough dougth)
        {
            if (name.Length < 1 || name.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");            
            Name = name;
            Dougth = dougth;
            _topping = new(); 
        }
        public string Name { get => _name; set => _name = value; }
        public Dough Dougth { get => _dough; set => _dough = value; }
        public IReadOnlyCollection<Topping> Toppings { get => _topping.AsReadOnly();}
        public void AddTopping(Topping topping)
        {
            if (_topping.Count > 9) throw new ArgumentException("Number of toppings should be in range [0..10].");
            _topping.Add(topping);
        }
        public override string ToString()
        {
            double totalCalories = 0;
            foreach (var topping in _topping)
            {
                totalCalories += double.Parse(topping.CalculateCalories());
            }
            totalCalories += double.Parse(_dough.CalculateCalories());

            return $"{Name} - {totalCalories:F2} Calories.";
        }
    }
}

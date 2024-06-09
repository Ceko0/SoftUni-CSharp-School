namespace _09.PokemonTrainer
{
    internal class Trainer
    {
        public string  Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons {  get; set; }

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new();
        }
        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}

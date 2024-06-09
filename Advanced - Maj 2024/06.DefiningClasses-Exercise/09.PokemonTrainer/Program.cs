namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Tournament") 
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealt = int.Parse(info[3]);

                Pokemon currentPokemon = new()
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Healt = pokemonHealt
                };
                if(!trainers.Any(x => x.Name  == trainerName))
                {
                    trainers.Add(new(trainerName));
                }
                Trainer currentTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                currentTrainer.Pokemons.Add(currentPokemon);
            }
            
            while((input = Console.ReadLine()) != "End")
            {
                trainers.ForEach(trainer =>
                {
                    if (trainer.Pokemons.Any(pokemon => pokemon.Element == input))
                    {
                        trainer.Badges += 1;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(pokemon => pokemon.Healt -= 10);
                        trainer.Pokemons.RemoveAll(pokemon => pokemon.Healt <= 0);
                    }

                });
            }
            foreach (Trainer trainer in trainers.OrderByDescending(trainer => trainer.Badges)
    .ThenBy(trainer => trainers.IndexOf(trainer))
    .ToList())
            {
                Console.WriteLine(trainer);
            }
        }
    }
}

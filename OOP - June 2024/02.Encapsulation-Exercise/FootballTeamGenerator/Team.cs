namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly Dictionary<string ,Player> Players = new();
        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("A name should not be empty.");
            Name = name;            
        }
        public string Name { get; }        
        public int Rating => CalculateRating();

        public bool AddPlayer(Player player) => Players.TryAdd(player.Name ,player);        
        public bool RemovePlayer(string playerName) => Players.Remove(playerName);        
        private int CalculateRating() => Players.Count == 0 ? 0 : (int) Math.Round( Players.Average(p => p.Value.Rating));
        
    }
}

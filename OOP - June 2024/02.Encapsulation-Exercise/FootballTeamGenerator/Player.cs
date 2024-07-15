namespace FootballTeamGenerator
{
    public class Player
    {
        const int minRange = 0;
        const int maxRange = 100;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("A name should not be empty.");

            Name = name;
            this.Endurance = StatValidation(endurance, nameof(Endurance)); ;
            this.Sprint = StatValidation(sprint, nameof(Sprint));
            this.Dribble = StatValidation(dribble, nameof(Dribble));
            this.Passing = StatValidation(passing, nameof(Passing));
            this.Shooting = StatValidation(shooting, nameof(Shooting));            
        }
        public string Name { get; }
        public int Endurance { get; }
        public int Sprint {  get; }
        public int Dribble { get; }
        public int Passing {  get; }
        public int Shooting { get; }
        public double Rating => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        private int StatValidation(int input, string fieldName)
        {
            if (input < minRange || input > maxRange) throw new ArgumentException($"{fieldName} should be between {minRange} and {maxRange}.");
            return input;
        }
    }
}

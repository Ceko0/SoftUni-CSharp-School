namespace P02_FootballBetting
{
    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                using FootballBettingContext dbContext = new FootballBettingContext();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                Console.WriteLine("Db Creation was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Db Creation failed!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
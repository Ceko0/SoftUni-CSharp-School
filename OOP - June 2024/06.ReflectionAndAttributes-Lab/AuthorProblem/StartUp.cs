namespace AuthorProblem
{
    [Author("Victor")]
    internal class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker = new();
            tracker.PrintMethodsByAuthor();
        }
    }
}

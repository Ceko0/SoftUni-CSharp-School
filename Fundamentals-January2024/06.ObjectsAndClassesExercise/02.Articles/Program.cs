namespace _02.Articles
{
    class ArticleClass
    {
        public ArticleClass(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public void Edite(string newContent)
        {
            Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleInformation = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int numberOfCommands = int.Parse(Console.ReadLine());

            List<ArticleClass> articlesList = new List<ArticleClass>();
            ArticleClass article = new ArticleClass(articleInformation[0], articleInformation[1], articleInformation[2]);
            articlesList.Add(article);

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                switch (commands[0])
                {
                    case "Edit":
                        article.Edite(commands[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(commands[1]);
                        break;
                    case "Rename":
                        article.Rename(commands[1]);
                        break;
                }
            }

            foreach (var newArticle in articlesList)
            {
                Console.WriteLine(newArticle);
            }
        }
    }
}

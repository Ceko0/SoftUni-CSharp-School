namespace _03.Articles2._0
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
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<ArticleClass> articlesList = new List<ArticleClass>();
            for (int i = 1; i <= numberOfArticles; i++)
            {
                string[] articleInformation = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
              
               
                ArticleClass article = new ArticleClass(articleInformation[0], articleInformation[1], articleInformation[2]);
                articlesList.Add(article);
            }

            foreach (var newArticle in articlesList)
            {
                Console.WriteLine(newArticle);
            }
        }
    }
}

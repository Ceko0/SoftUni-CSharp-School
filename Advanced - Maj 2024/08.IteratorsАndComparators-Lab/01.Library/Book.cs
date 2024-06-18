namespace IteratorsAndComparators
{
    public class Book :IComparable<Book>
    {
        public Book(string title, int year,params string[] authors)
        {          
            Title = title;
            Year = year;
            Authors = new(authors.ToList());
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<String> Authors;

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }
        public override string ToString() => $"{Title} - {Year}";
    }
}

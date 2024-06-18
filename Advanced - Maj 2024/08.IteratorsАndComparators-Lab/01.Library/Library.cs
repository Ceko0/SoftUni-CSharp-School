using System.Collections;
using static System.Reflection.Metadata.BlobBuilder;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new(books.ToList());
        }
        public IEnumerator<Book> GetEnumerator()
        {
            BookComparator comparator = new();
            books.Sort(comparator);
            return new LibraryIterator(books);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex = -1;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }
            public void Reset()
            {
                currentIndex = -1;
            }
        }
        
    }
}


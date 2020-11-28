namespace C3Meetup.PotterKata
{
    public class BookSets
    {
        public int BooksInSet { get;}
        public int NumberOfSets { get; }

        public BookSets(int booksInSet, int numberOfSets)
        {
            this.BooksInSet = booksInSet;
            this.NumberOfSets = numberOfSets;
        }
    }
}
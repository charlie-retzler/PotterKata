namespace C3Meetup.PotterKata
{
    public class GroupedBooks
    {
        public int BookNumber { get; }
        public int Count { get; }

        public GroupedBooks(int bookNumber, int count)
        {
            BookNumber = bookNumber;
            Count = count;
        }
    }
}
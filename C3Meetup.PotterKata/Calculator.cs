using System.Collections.Generic;

namespace C3Meetup.PotterKata
{
    public class Calculator
    {

        public double Price(List<int> books)
        {
            return books.Count * 8;
        }
    }
}

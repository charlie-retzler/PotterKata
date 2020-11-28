using System.Collections.Generic;
using System.Linq;

namespace C3Meetup.PotterKata
{
    public class Calculator
    {

        public double Price(List<int> books)
        {
            var groups = books.GroupBy(x => x).ToList();

            if (groups.Count() == 2)
            {
                return groups.Count() * 8 * 0.95;
            }


            return books.Count * 8;
        }
    }
}

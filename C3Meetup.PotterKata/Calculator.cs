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

            if (groups.Count() == 3)
            {
                return groups.Count() * 8 * 0.90;
            }

            if (groups.Count() == 4)
            {
                return groups.Count() * 8 * 0.80;
            }

            if (groups.Count() == 5)
            {
                return groups.Count() * 8 * 0.75;
            }


            return books.Count * 8;
        }
    }
}

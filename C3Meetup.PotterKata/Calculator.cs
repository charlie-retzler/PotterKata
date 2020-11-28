using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace C3Meetup.PotterKata
{
    public class Calculator
    {

        public double Price(List<int> books)
        {
            //var groups = books.GroupBy(x => x).ToList();
            var groups = books
                .GroupBy(x => x)
                .Select(grp => new
                {
                    BookNumber = grp.Key,
                    Count = grp.Count()
                }).ToList();

            var total = 0.0;

            while (groups.Count > 0)
            {
                if (groups.Count == 1)
                {
                    total += groups.Count * 8 * 1.0;
                }

                if (groups.Count == 2)
                {
                    total += groups.Count * 8 * 0.95;
                }

                if (groups.Count == 3)
                {
                    total += groups.Count * 8 * 0.90;
                }

                if (groups.Count == 4)
                {
                    total += groups.Count * 8 * 0.80;
                }

                if (groups.Count == 5)
                {
                    total += groups.Count * 8 * 0.75;
                }

                groups = groups
                    .Where(x => x.Count > 1)
                    .Select(x => new { BookNumber = x.BookNumber, Count = x.Count - 1 })
                    .ToList();
            }

            return total;
        }
    }
}

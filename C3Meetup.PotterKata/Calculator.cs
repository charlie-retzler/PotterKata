using System.Collections.Generic;
using System.Linq;

namespace C3Meetup.PotterKata
{
    public class Calculator
    {
        private readonly Dictionary<int, double> _discounts = new Dictionary<int, double>
        {
            {1, 1.0},
            {2, .95},
            {3, .90}, 
            {4, .80},
            {5, .75}
        };

        private readonly int _retailPrice = 8;

        public double Price(List<int> books)
        {
            var groups = books
                .GroupBy(x => x)
                .Select(grp => new GroupedBooks(grp.Key, grp.Count()))
                .ToList();

            var optimizedTotal = CalculateOptimizedPrice(groups);

            return optimizedTotal;
        }

        private double CalculateOptimizedPrice(List<GroupedBooks> groups)
        {
            var total = 0.0;
            while (groups.Count > 0)
            {
                var groupCost =  groups.Count * _retailPrice * _discounts[groups.Count];

                var tempGroups = groups
                    .Where(x => x.Count > 1)
                    .Select(x => new GroupedBooks(x.BookNumber, x.Count - 1))
                    .ToList();

                if (groups.Count == 5 && tempGroups.Count == 3)
                {
                    // Price as two groups of 4, since it's cheaper for the current discounts. See Math(s)
                    // (Group of 5 + Group of 3) > (Two Groups of 4)
                    // (5 * 8 * .75) + (3 * 8 * .90) > (2 * 4 * 8 * .80) 
                    // => (5 * .75) + (3 * .90) > (2 * 4 * .80)
                    // => (5 * .75) + (3 * .90) > (8 * .80)
                    // => 3.75 + 2.7 > 6.4
                    // => 6.45 > 6.4

                    groupCost = 2 * 4 * _retailPrice * _discounts[4];

                    tempGroups = groups
                        .Where(x => x.Count > 2)
                        .Select(x => new GroupedBooks(x.BookNumber, x.Count - 2))
                        .ToList();
                }

                groups = tempGroups;
                total += groupCost;
            }

            return total;
        }
    }
}

using System;
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
            var bookSets = CalculateGreedySets(groups);
            bookSets = OptimizeSets(bookSets);

            var total = bookSets.Sum(x => x.BooksInSet * x.NumberOfSets * _retailPrice * _discounts[x.BooksInSet]);

            return total;
        }

        private List<BookSets> OptimizeSets(List<BookSets> bookSets)
        {
            var threeBooks = bookSets.SingleOrDefault(x => x.BooksInSet == 3);
            var fiveBooks = bookSets.SingleOrDefault(x => x.BooksInSet == 5);


            if (threeBooks is null || fiveBooks is null)
            {
                return bookSets;
            }

            // Price as two groups of 4, since it's cheaper for the current discounts. See Math(s)
            // (Group of 5 + Group of 3) > (Two Groups of 4)
            // (5 * 8 * .75) + (3 * 8 * .90) > (2 * 4 * 8 * .80) 
            // => (5 * .75) + (3 * .90) > (2 * 4 * .80)
            // => (5 * .75) + (3 * .90) > (8 * .80)
            // => 3.75 + 2.7 > 6.4
            // => 6.45 > 6.4

            var fourBooks = bookSets.SingleOrDefault(x => x.BooksInSet == 4) ?? new BookSets(4, 0);
            var otherBooks = bookSets.Where(x => x.BooksInSet < 3);

            var minimum = Math.Min(threeBooks.NumberOfSets, fiveBooks.NumberOfSets);

            var optimized = new List<BookSets>(otherBooks)
            {
                new BookSets(fourBooks.BooksInSet, fourBooks.NumberOfSets + 2 * minimum),
                new BookSets(threeBooks.BooksInSet, threeBooks.NumberOfSets - minimum),
                new BookSets(fiveBooks.BooksInSet, fiveBooks.NumberOfSets - minimum)
            };

            return optimized;

        }

        private List<BookSets> CalculateGreedySets(List<GroupedBooks> groups)
        {
            var bookSets = new List<BookSets>();
            while (groups.Count > 0)
            {
                var minimum = groups.Min(x => x.Count);

                bookSets.Add(new BookSets(groups.Count, minimum));

                groups = groups
                    .Where(x => x.Count > minimum)
                    .Select(x => new GroupedBooks(x.BookNumber, x.Count - minimum))
                    .ToList();
            }

            return bookSets;
        }
    }
}

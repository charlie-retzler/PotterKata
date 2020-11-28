﻿using System.Collections.Generic;
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

            var total = 0.0;

            total = CalculateGreedyPrice(groups, total);

            return total;
        }

        private double CalculateGreedyPrice(List<GroupedBooks> groups, double total)
        {
            while (groups.Count > 0)
            {
                total += groups.Count * _retailPrice * _discounts[groups.Count];

                groups = groups
                    .Where(x => x.Count > 1)
                    .Select(x => new GroupedBooks(x.BookNumber, x.Count - 1))
                    .ToList();
            }

            return total;
        }
    }
}

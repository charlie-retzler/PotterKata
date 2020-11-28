using System.Collections.Generic;
using Xunit;

namespace C3Meetup.PotterKata.Tests
{
    public class PotterTests
    {
        private readonly Calculator _calculator = new Calculator();


        [Fact]
        public void GivenNoBooks_WhenIPurchase_ItShouldCostZero()
        {
            var price = _calculator.Price(new List<int>());
            Assert.Equal(0, price);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GivenAnyOneBook_WhenIPurchase_ItShouldCost8(int bookNumber)
        {
            var price = _calculator.Price(new List<int>{bookNumber});
            Assert.Equal(8, price);
        }

        [Fact]
        public void GivenThreeOfTheSameBook_WhenIPurchase_ItShouldCost24()
        {
            var price = _calculator.Price(new List<int> { 1, 1, 1 });
            Assert.Equal(24, price);
        }

        [Fact]
        public void GivenTwoDifferentBooks_WhenIPurchase_ItShouldBeDiscountedTo95percent()
        {
            var price = _calculator.Price(new List<int> {1, 2});
            Assert.Equal(16 * 0.95, price);
        }

        [Fact]
        public void GivenThreeDifferentBooks_WhenIPurchase_ItShouldBeDiscountedTo90percent()
        {
            var price = _calculator.Price(new List<int> { 1, 3, 5 });
            Assert.Equal(24 * 0.90, price);
        }

        [Fact]
        public void GivenFourDifferentBooks_WhenIPurchase_ItShouldBeDiscountedTo80percent()
        {
            var price = _calculator.Price(new List<int> { 1, 2, 3, 5 });
            Assert.Equal(32 * 0.80, price);
        }

        [Fact]
        public void GivenFiveDifferentBooks_WhenIPurchase_ItShouldBeDiscountedTo75percent()
        {
            var price = _calculator.Price(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(40 * 0.75, price);
        }

        [Fact]
        public void GivenTwoOfTheSameBookAndOneDifferentBook_WhenIPurchase_TwoBooksShouldBeDiscountedTo95percentAndOneNotDiscounted()
        {
            var price = _calculator.Price(new List<int> { 1, 1, 2 });
            Assert.Equal(16 * 0.95 + 8, price);
        }

        [Fact]
        public void GivenTwoOfTheSameBookAndTwoOfAnother_WhenIPurchase_TwoBooksShouldBeDiscountedTo95percentForBothGroups()
        {
            var price = _calculator.Price(new List<int> { 1, 1, 2, 2 });
            Assert.Equal(32 * 0.95, price);
        }

        [Fact]
        public void GivenOneGroupOfFourBooksAndGroupOfTwoBooks_WhenIPurchase_FourBooksShouldBeDiscounted80percentAndOtherDiscounted95percent()
        {
            var price = _calculator.Price(new List<int> { 1, 1, 2, 3, 3, 4 });
            Assert.Equal(32 * 0.80 + 16 * 0.95, price);
        }

        [Fact]
        public void GivenOneGroupOfFiveBooksAndOneAdditionalBooks_WhenIPurchase_FiveBooksShouldBeDiscounted75percentAndOneAtRetailPrice()
        {
            var price = _calculator.Price(new List<int> { 1, 2, 2, 3, 4, 5 });
            Assert.Equal(40 * 0.75 + 8, price);
        }

        [Fact]
        public void GivenGroupThatCouldBeFiveAndThreeOrFourAndFour_WhenIPurchase_ShouldHaveTheLowestPrice()
        {
            var price = _calculator.Price(new List<int>{1, 1, 2, 2, 3, 3, 4, 5});
            Assert.Equal(2 * 32 * 0.80, price);
        }
    }
}

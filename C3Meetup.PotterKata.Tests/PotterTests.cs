using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace C3Meetup.PotterKata.Tests
{
    public class PotterTests
    {
        private Calculator calculator = new Calculator();


        [Fact]
        public void GivenNoBooks_WhenIPurchase_ItShouldCostZero()
        {
            var price = calculator.Price(new List<int>());
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
            var price = calculator.Price(new List<int>{bookNumber});
            Assert.Equal(8, price);
        }

        [Fact]
        public void GivenThreeOfTheSameBook_WhenIPurchase_ItShouldCost24()
        {
            var price = calculator.Price(new List<int> { 1, 1, 1 });
            Assert.Equal(24, price);
        }
    }
}

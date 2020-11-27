using System.Collections.Generic;
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

        [Fact]
        public void GivenOneBooks_WhenIPurchase_ItShouldCost8()
        {
            var price = calculator.Price(new List<int>(){1});
            Assert.Equal(8, price);
        }
    }
}

using EntityAndValueObjectBase.Infrastructure.Domain;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests{
    public class IntegerNeedsToBeGreaterThanZeroTests{
        [Fact]
        public void IsOfTypeBrokenRule()
        {
            var sut = new IntegerNeedsToBeGreaterThanZero("");

            Assert.IsAssignableFrom<BrokenRule>(sut);
        }


        [Fact]
        public void MessageReturnsPropertyNameNeedsToHaveValueGreaterThan0()
        {
            const string propertyName = "IntegerPropertyName";
            var sut = new IntegerNeedsToBeGreaterThanZero(propertyName);
            const string expected = propertyName + " needs to have a value greater than 0";

            var actual = sut.Message;

            Assert.Equal(expected,actual);
        }
    }
}
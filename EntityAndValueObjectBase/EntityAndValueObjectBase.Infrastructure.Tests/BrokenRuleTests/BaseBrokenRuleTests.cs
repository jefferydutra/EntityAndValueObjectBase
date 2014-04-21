using EntityAndValueObjectBase.Infrastructure.Domain;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests{
    public class BaseBrokenRuleTests
    {
        [Fact]
        public void IsOfTypeBrokenRule()
        {
            var sut = new BaseBrokenRule("","","");

            Assert.IsAssignableFrom<BrokenRule>(sut);
        }


        [Fact]
        public void MessageReturnsPropertyNamePropertyValueCustomMessage()
        {
            const string propertyName = "BasePropertyName";
            const string propertyValue = "BasePropertyValue";
            const string customMessage = "custom message";
            var sut = new BaseBrokenRule(propertyName, propertyValue, customMessage);
            const string expected = propertyName  + " | " + propertyValue + " | " +  customMessage;

            var actual = sut.Message;

            Assert.Equal(expected, actual);
        }
    }
}
using EntityAndValueObjectBase.Infrastructure.Domain;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests{
    public class EmptyStringTests{
        [Fact]
        public void IsOfTypeBrokenRule()
        {
            var sut = new NotEmptyString("fd");

            Assert.IsAssignableFrom<BrokenRule>(sut);
        }


        [Fact]
        public void MessageReturnsPropertyNameCanNotBeAnEmptyString()
        {
            const string propertyName = "EmptyPropertyName";
            var sut = new NotEmptyString(propertyName);
            const string expected = propertyName + " can not be an empty string";

            var actual = sut.Message;

            Assert.Equal(expected, actual);
        }
    }
}
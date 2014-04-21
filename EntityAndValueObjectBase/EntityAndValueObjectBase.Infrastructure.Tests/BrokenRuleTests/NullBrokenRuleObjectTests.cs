using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests
{
    public class NullBrokenRuleObjectTests
    {
        [Fact]
        public void IsOfTypeBrokenRule(){
            var sut = new NotNull("test");

            Assert.IsAssignableFrom<BrokenRule>(sut);
        }

        [Fact]
        public void MessageReturnsPropertyNameCanNotBeNull(){
            const string propertyName = "NullPropertyName";
            var sut = new NotNull(propertyName);
            const string expected = propertyName + " can not be null";

            var actual = sut.Message;

            Assert.Equal(expected,actual);
        }
        
    }
}

using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.ValueObjectTests
{
    public class ValidationTests
    {
        [Fact]
        public void WhenAnObjectIsNullANullBrokenRuleIsAdded()
        {
            var sut = ValueObjectCreate.Anonymous();
            Assert.False(sut.GetBrokenRules.Any());
            sut.TestStringProperty = null;

            Assert.True(sut.GetBrokenRules.Any());
        }
    }
}

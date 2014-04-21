using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests
{
    public class EntityBaseValidationTests
    {
        [Fact]
        public void WhenAnObjectIsNullANullBrokenRuleIsAdded(){
            var sut = EntityStubWithBrokenRulesCreate.Anonymous();
            Assert.False(sut.GetBrokenRules.Any());
            sut.TestStringProperty = null;

            Assert.True(sut.GetBrokenRules.Any());
        }


    }
}

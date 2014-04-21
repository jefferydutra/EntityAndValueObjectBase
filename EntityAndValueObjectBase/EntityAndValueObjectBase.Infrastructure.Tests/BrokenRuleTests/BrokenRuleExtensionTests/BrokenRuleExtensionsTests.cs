using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests.BrokenRuleExtensionTests{
    public class AddBrokenRuleIfPropertyIsNullTests{
        [Fact]
        public void AddsExpectedBrokenRuleWhenNull(){
            var entity = new EntityStubWithBrokenRules{TestStringProperty = null};
            var propertyName = PropertyNameHelper.GetName(() => entity.TestStringProperty);
            var expected = new List<BrokenRule>{
                new NotNull(propertyName)
            };

            var sut = new List<BrokenRule>();
            sut.AddBrokenRuleIfPropertyIsNull(entity.TestStringProperty, () => entity.TestStringProperty);


            CustomAssertions.BrokenRuleAssertions.ListsEqual(expected, sut);
        }

        [Fact]
        public void DoesNotAddsExpectedBrokenRuleWhenNotNull()
        {
            var entity = new EntityStubWithBrokenRules { TestStringProperty = "test" };

            var sut = new List<BrokenRule>();
            sut.AddBrokenRuleIfPropertyIsNull(entity.TestStringProperty, () => entity.TestStringProperty);

            Assert.False(sut.Any());
        }
    }
}
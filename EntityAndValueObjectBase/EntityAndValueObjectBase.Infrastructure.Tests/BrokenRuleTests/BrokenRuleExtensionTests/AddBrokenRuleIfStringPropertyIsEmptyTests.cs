using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes;
using EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests.BrokenRuleExtensionTests{
    public class AddBrokenRuleIfStringPropertyIsEmptyTests
    {
        [Fact]
        public void AddsExpectedBrokenRuleWhenNull()
        {
            var entity = new EntityStub { TestStringProperty = string.Empty };
            var propertyName = PropertyNameHelper.GetName(() => entity.TestStringProperty);
            var expected = new List<BrokenRule>{
                new NotEmptyString(propertyName)
            };

            var sut = new List<BrokenRule>();
            sut.AddIfPropertyEmpty(entity.TestStringProperty, () => entity.TestStringProperty);


            CustomAssertions.BrokenRuleAssertions.ListsEqual(expected, sut); 
        }

        [Fact]
        public void DoesNotAddsExpectedBrokenRuleWhenNotNull()
        {
            var entity = new EntityStub { TestStringProperty = "test" };

            var sut = new List<BrokenRule>();
            sut.AddIfPropertyEmpty(entity.TestStringProperty, () => entity.TestStringProperty);

            Assert.False(sut.Any());
        }
    }
}
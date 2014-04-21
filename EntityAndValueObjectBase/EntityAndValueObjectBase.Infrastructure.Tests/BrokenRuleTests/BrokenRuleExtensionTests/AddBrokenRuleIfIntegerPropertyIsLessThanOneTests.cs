using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes;
using EntityAndValueObjectBase.Infrastructure.Tests.CustomAssertions;
using EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs;
using Xunit;
using Xunit.Extensions;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRuleTests.BrokenRuleExtensionTests{
    public class AddBrokenRuleIfIntegerPropertyIsLessThanOneTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddsExpectedBrokenRuleWhenNull(int value)
        {
            var entity = new EntityStub { TestIntProperty = value };
            var propertyName = PropertyNameHelper.GetName(() => entity.TestIntProperty);
            var expected = new List<BrokenRule>{
                new IntegerNeedsToBeGreaterThanZero(propertyName)
            };

            var sut = new List<BrokenRule>();
            sut.AddIfIntegerPropertyLessThanOne(
                entity.TestIntProperty, () => entity.TestIntProperty);

            
           BrokenRuleAssertions.ListsEqual(expected, sut);
        }

        [Fact]
        public void DoesNotAddsExpectedBrokenRuleWhenNotNull()
        {
            var entity = new EntityStub { TestIntProperty = 1 };

            var sut = new List<BrokenRule>();
            sut.AddIfIntegerPropertyLessThanOne(
                entity.TestIntProperty, () => entity.TestIntProperty);

            Assert.False(sut.Any());
        }
    }
}
using EntityAndValueObjectBase.Infrastructure.DomainValidation;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.ValidateValueObjectTests
{
    public class IsValidTests
    {
        [Fact]
        public void When_No_Broken_Rules_Return_True()
        {
            var valueObject = ValueObjectCreate.Anonymous();
            var actual = valueObject.IsValid();

            Assert.True(actual);
        }

        [Fact]
        public void When_Has_Broken_Rules_Return_False()
        {
            var entity = ValueObjectCreate.AnonymousWithBrokenRules();
            var actual = entity.IsValid();

            Assert.False(actual);
        }


    }
}

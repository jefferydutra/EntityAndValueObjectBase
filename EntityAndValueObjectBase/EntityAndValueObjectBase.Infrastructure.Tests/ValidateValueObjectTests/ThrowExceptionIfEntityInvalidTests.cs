using EntityAndValueObjectBase.Infrastructure.DomainValidation;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Infrastructure.Base.Domain;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.ValidateValueObjectTests{
    public class ThrowExceptionIfInvalidTests
    {
        [Fact]
        public void When_No_Broken_Rules_Return_True()
        {
            var entity = ValueObjectCreate.Anonymous();

            Assert.DoesNotThrow(entity.ThrowExceptionIfEntityIsInvalid);
        }

        [Fact]
        public void When_Has_Broken_Rules_Return_False(){
            var entity = ValueObjectCreate.AnonymousWithBrokenRules();

            Assert.Throws<ValueObjectIsNotValidException>(() => entity.ThrowExceptionIfEntityIsInvalid());
        }


    }
}
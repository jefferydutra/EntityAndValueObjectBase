using EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.TestHelpersTests
{
    public class ValidateEntityStubFactoryTests
    {
        [Fact]
        public void IsValidReturnsValidateEntityInValidStateStub(){
            var actual = ValidateEntityStubFactory
                            .CreateValidateEntity(ValidateEntityStubType.IsValid);

            Assert.IsAssignableFrom<ValidateEntityInValidStateStub>(actual);
        }

        [Fact]
        public void NotValidAndThrowsExceptionReturnsValidateEntityInNotValidStateWtihExceptionStub()
        {
            var actual = ValidateEntityStubFactory
                            .CreateValidateEntity(ValidateEntityStubType.NotValidAndThrowsException);

            Assert.IsAssignableFrom<ValidateEntityInNotValidStateWtihExceptionStub>(actual);
        }

        [Fact]
        public void NotValidAndThrowsExceptionReturnsValidateEntityInNotValidStateNoExceptionStub()
        {
            var actual = ValidateEntityStubFactory
                            .CreateValidateEntity(ValidateEntityStubType.NotValidAndShouldNotThrowException);

            Assert.IsAssignableFrom<ValidateEntityInNotValidStateNoExceptionStub>(actual);
        }
    }
}

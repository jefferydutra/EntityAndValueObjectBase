using EntityAndValueObjectBase.Infrastructure.DomainValidation;

namespace EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs
{
    public static class ValidateEntityStubFactory{
        public static IValidateEntity CreateValidateEntity(ValidateEntityStubType validateEntityStubType){
            if (validateEntityStubType == ValidateEntityStubType.NotValidAndThrowsException)
            {
                return new ValidateEntityInNotValidStateWtihExceptionStub();
            }
            if (validateEntityStubType == ValidateEntityStubType.NotValidAndShouldNotThrowException)
            {
                return new ValidateEntityInNotValidStateNoExceptionStub();
            }
            return new ValidateEntityInValidStateStub();
        }
        
    }
}

using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using Infrastructure.Base.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation{
    public static class ValidateValueObject{

        public static bool IsValid(this ValueObject valueObject)
        {
            return valueObject.GetBrokenRules.HasNoBrokenRules();
        }
        public static void ThrowExceptionIfEntityIsInvalid(this ValueObject valueObject)
        {
            ThrowException(valueObject.GetBrokenRules);
        }
        private static void ThrowException(IEnumerable<BrokenRule> brokenRules)
        {
            if (!brokenRules.Any())
            {
                return;
            }
            var message = brokenRules.GetInvalidDomainObjectExceptionMessage();
            throw new ValueObjectIsNotValidException(message);
        }
    }
}
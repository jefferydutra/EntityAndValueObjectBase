using System;
using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation
{
    public static class ValidateEntityExtensions{
        public static bool IsValid(this EntityBase<int> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }
        public static bool IsValid(this EntityBase<string> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }

        public static bool IsValid(this EntityBase<Guid> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }

        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<int> entity){
            ThrowException(entity.GetBrokenRules);
        }
        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<string> entity){
            ThrowException(entity.GetBrokenRules);
        }
        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<Guid> entity)
        {
            ThrowException(entity.GetBrokenRules);
        }

        private static void ThrowException(IEnumerable<BrokenRule> brokenRules){
            if (!brokenRules.Any())
            {
                return;
            }
            var message = brokenRules.GetInvalidDomainObjectExceptionMessage();
            throw new EntityIsNotValidException(message);
        }
    }
}

using System;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation
{
    public class ValidateEntity : IValidateEntity
    {
        public bool IsValid(EntityBase<int> entity)
        {
            return entity.IsValid();
        }

        public bool IsValid(EntityBase<string> entity)
        {
            return entity.IsValid();
        }

        public bool IsValid(EntityBase<Guid> entity)
        {
            return entity.IsValid();
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity)
        {
            entity.ThrowExceptionIfEntityIsInvalid();
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity)
        {
            entity.ThrowExceptionIfEntityIsInvalid();
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity)
        {
            entity.ThrowExceptionIfEntityIsInvalid();
        }
    }
}
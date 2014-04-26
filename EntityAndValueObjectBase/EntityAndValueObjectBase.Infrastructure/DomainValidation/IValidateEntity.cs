using System;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation
{
    public interface IValidateEntity
    {
        bool IsValid(EntityBase<int> entity);
        bool IsValid(EntityBase<string> entity);
        bool IsValid(EntityBase<Guid> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity);
    }
}
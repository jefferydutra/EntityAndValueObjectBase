using System;
using System.Collections.Generic;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation
{
    public interface IValidateEntity
    {
        bool IsValid(EntityBase<int> entity);
        bool IsValid(EntityBase<string> entity);
        bool IsValid(EntityBase<Guid> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<int> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<string> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<Guid> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity);
    }
}
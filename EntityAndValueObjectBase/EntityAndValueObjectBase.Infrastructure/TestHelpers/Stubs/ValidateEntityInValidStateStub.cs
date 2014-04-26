using System;
using System.Collections.Generic;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.DomainValidation;

namespace EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs
{
    public class ValidateEntityInValidStateStub : IValidateEntity
    {
        public bool IsValid(EntityBase<int> entity)
        {
            return true;
        }

        public bool IsValid(EntityBase<string> entity)
        {
            return true;
        }

        public bool IsValid(EntityBase<Guid> entity)
        {
            return true;
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<int> entity)
        {
            return new List<String>();
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<string> entity)
        {
            return new List<String>();
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<Guid> entity)
        {
            return new List<String>();
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity)
        {
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity)
        {
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity)
        {
        }
    }
}

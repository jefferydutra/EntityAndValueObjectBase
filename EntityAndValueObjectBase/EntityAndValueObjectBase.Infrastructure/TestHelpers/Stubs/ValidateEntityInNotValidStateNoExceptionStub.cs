using System;
using System.Collections.Generic;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.DomainValidation;

namespace EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs{
    public class ValidateEntityInNotValidStateNoExceptionStub : IValidateEntity{
        private readonly IEnumerable<string> _messages;

        public ValidateEntityInNotValidStateNoExceptionStub(){
            _messages = new List<string>{
                "message" + DateTimeOffset.Now.Ticks
            };
        }

        public bool IsValid(EntityBase<int> entity){
            return false;
        }

        public bool IsValid(EntityBase<string> entity){
            return false;
        }

        public bool IsValid(EntityBase<Guid> entity){
            return false;
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<int> entity){
            return _messages;
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<string> entity){
            return _messages;
        }

        public IEnumerable<string> GetErrorMessages(EntityBase<Guid> entity){
            return _messages;
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity){
            
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity){
            
        }

        public void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity){
            
        }
    }
}
using System;

namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public class EntityIsNotValidException : Exception{
        public EntityIsNotValidException(string message) : base(message){
            
        }
    }
}
using System;

namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public class ValueObjectIsNotValidException : Exception
    {
        public ValueObjectIsNotValidException(string message)
            : base(message)
        {

        }
    }
}
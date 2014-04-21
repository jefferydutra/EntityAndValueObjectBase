using System;

namespace Infrastructure.Base.Domain{
    public class ValueObjectIsNotValidException : Exception
    {
        public ValueObjectIsNotValidException(string message)
            : base(message)
        {

        }
    }
}
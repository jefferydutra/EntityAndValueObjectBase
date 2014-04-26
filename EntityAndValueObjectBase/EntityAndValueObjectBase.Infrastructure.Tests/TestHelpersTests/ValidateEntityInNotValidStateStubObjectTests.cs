using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.DomainValidation;
using EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.TestHelpersTests{
    public class ValidateEntityInNotValidStateWtihExceptionStubbObjectTests{
        private readonly IValidateEntity _sut;

        public ValidateEntityInNotValidStateWtihExceptionStubbObjectTests(){
            _sut = new ValidateEntityInNotValidStateWtihExceptionStub();
        }

        [Fact]
        public void IsValidFalseForEntityIntegerId(){
            var entity = EntityStubCreate.AnonymousIntegerId();
            var actual = _sut.IsValid(entity);
            
            Assert.False(actual);
        }

        [Fact]
        public void IsValidFalseForEntityStringId(){
            var entity = EntityStubCreate.AnonymousStringId();
            var actual = _sut.IsValid(entity);

            Assert.False(actual);
        }

        [Fact]
        public void IsValidFalseForEntityStubGuidId(){
            var entity = EntityStubCreate.AnonymousGuidId();
            var actual = _sut.IsValid(entity);

            Assert.False(actual);
        }

        [Fact]
        public void GetErrorMessagesNotEmptyForEntityIntegerId(){
            var entity = EntityStubCreate.AnonymousIntegerId();
            var actual = _sut.GetErrorMessages(entity).Any();

            Assert.True(actual);
        }

        [Fact]
        public void GetErrorMessagesNotEmptyForEntityStringId()
        {
            var entity = EntityStubCreate.AnonymousStringId();
            var actual = _sut.GetErrorMessages(entity).Any();

            Assert.True(actual);
        }

        [Fact]
        public void GetErrorMessagesNotEmptyForEntityGuidId()
        {
            var entity = EntityStubCreate.AnonymousGuidId();
            var actual = _sut.GetErrorMessages(entity).Any();

            Assert.True(actual);
        }

        [Fact]
        public void InvalidEntityExceptionThrownForEntityIntegerId()
        {
            var entity = EntityStubCreate.AnonymousIntegerId();

            Assert.Throws<EntityIsNotValidException>(() => _sut.ThrowExceptionIfEntityIsInvalid(entity));
        }


        [Fact]
        public void InvalidEntityExceptionThrownForEntityStringId()
        {
            var entity = EntityStubCreate.AnonymousStringId();

            Assert.Throws<EntityIsNotValidException>(() => _sut.ThrowExceptionIfEntityIsInvalid(entity));
        }

        [Fact]
        public void InvalidEntityExceptionThrownForEntityGuidId()
        {
            var entity = EntityStubCreate.AnonymousGuidId();

            Assert.Throws<EntityIsNotValidException>(() => _sut.ThrowExceptionIfEntityIsInvalid(entity));
        }



    }
}
using System;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using EntityAndValueObjectBase.Infrastructure.TestHelpers.Stubs;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.TestHelpersTests
{
    public class ValidateEntityInAValidStateStubObjectTests
    {
        private EntityBase<int> GetEntityIntId
        {
            get { return EntityStubCreate.AnonymousIntegerId(); }
        }
        private EntityBase<string> GetEntityStringId
        {
            get { return EntityStubCreate.AnonymousStringId(); }
        }
        private EntityBase<Guid> GetEntityGuidId
        {
            get { return EntityStubCreate.AnonymousGuidId(); }
        }
        private readonly ValidateEntityInValidStateStub _sut;

        public ValidateEntityInAValidStateStubObjectTests()
        {
            _sut = new ValidateEntityInValidStateStub();

        }
        [Fact]
        public void IsValidForIntBasedTrue()
        {
            var actual = _sut.IsValid(GetEntityIntId);
            Assert.True(actual);
        }

        [Fact]
        public void IsValidForGuidBasedTrue()
        {
            var actual = _sut.IsValid(GetEntityGuidId);
            Assert.True(actual);
        }

        [Fact]
        public void IsValidForStringBasedTrue()
        {
            var actual = _sut.IsValid(GetEntityStringId);
            Assert.True(actual);
        }

        [Fact]
        public void GetErrorMessagesReturnsEmptyForGuidBased()
        {
            var actual = _sut.GetErrorMessages(GetEntityGuidId).Any();
            Assert.False(actual);
        }

        [Fact]
        public void GetErrorMessagesReturnsEmptyForIntBased()
        {
            var actual = _sut.GetErrorMessages(GetEntityIntId).Any();
            Assert.False(actual);
        }
        

        [Fact]
        public void GetErrorMessagesReturnsEmptyForStringBased()
        {
            var actual = _sut.GetErrorMessages(GetEntityStringId).Any();
            Assert.False(actual);
        
        }

        [Fact]
        public void ThrowExceptionIfEntityIsInvalid_NoExceptionGuidBased()
        {
            Assert.DoesNotThrow(() => _sut.ThrowExceptionIfEntityIsInvalid(GetEntityGuidId));
        }

        [Fact]
        public void ThrowExceptionIfEntityIsInvalid_NoExceptionIntBased()
        {
            Assert.DoesNotThrow(() => _sut.ThrowExceptionIfEntityIsInvalid(GetEntityIntId));
        }


        [Fact]
        public void ThrowExceptionIfEntityIsInvalid_NoExceptionStringBased()
        {
            Assert.DoesNotThrow(() => _sut.ThrowExceptionIfEntityIsInvalid(GetEntityStringId));

        }
    }
}

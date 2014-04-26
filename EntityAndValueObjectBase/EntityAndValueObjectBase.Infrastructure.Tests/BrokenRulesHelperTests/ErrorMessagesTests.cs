using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.DomainValidation;
using EntityAndValueObjectBase.Infrastructure.Tests.Create;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.BrokenRulesHelperTests
{
    public class ErrorMessagesTests
    {
        [Fact]
        public void Returns_IEnumerable_Of_String()
        {
            var entity = EntityStubCreate.AnonymousStringIdWithBrokenRules();

            var actual = entity.GetBrokenRules.GetMessages();

            Assert.IsAssignableFrom<IEnumerable<string>>(actual);
        }

        [Fact]
        public void Returns_List_Of_BrokenRule_Strings()
        {
            var entity = EntityStubCreate.AnonymousStringIdWithBrokenRules();
            var expected = entity.GetBrokenRules.Select(x => x.Message);

            var actual = entity.GetBrokenRules.GetMessages();

            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using EntityAndValueObjectBase.Infrastructure.Domain;
using Xunit;

namespace EntityAndValueObjectBase.Infrastructure.Tests.CustomAssertions
{
    public static class BrokenRuleAssertions
    {
        public static void ListsEqual(IList<BrokenRule> expected, IList<BrokenRule> actual){
            Assert.NotNull(expected);
            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);

            Assert.True(expected.All(
                    ex => actual.Any(act=> AreEqual(ex,act))
                ));
        }

        private static bool AreEqual(BrokenRule expected, BrokenRule actual){
            return expected.Message == actual.Message
                   && expected.PropertyName == actual.PropertyName
                   && expected.PropertyValue == actual.PropertyValue;
        }
    }
}

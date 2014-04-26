using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.DomainValidation{
    public static class BrokenRulesHelpers{
        public static bool HasNoBrokenRules(this IEnumerable<BrokenRule> brokenRules)
        {
            return !brokenRules.Any();
        }

        public static IEnumerable<string> GetMessages(this IEnumerable<BrokenRule> brokenRules)
        {
            return brokenRules.Select(x=> x.Message);
        }
        public static string GetInvalidDomainObjectExceptionMessage(this IEnumerable<BrokenRule> brokenRules)
        {

            var message = new StringBuilder();
            message.Append("Invalid because of:");
            foreach (var brokenRule in brokenRules)
            {
                message.Append("|" + brokenRule.Message + "| ");
            }
            return message.ToString();
        }
    }
}
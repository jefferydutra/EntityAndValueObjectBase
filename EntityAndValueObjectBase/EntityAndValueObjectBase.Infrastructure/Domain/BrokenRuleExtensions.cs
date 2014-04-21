using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public static class BrokenRuleExtensions{
        public static void AddBrokenRuleIfPropertyIsNull<T>(this IList<BrokenRule> brokenRules, object value, Expression<Func<T>> e)
        {
            if (value == null)
            {
                brokenRules.Add(new NotNull(PropertyNameHelper.GetName(e)));
            }
        }
        public static void AddBrokenRuleIfPropertyEmpty<T>(this IList<BrokenRule> brokenRules, string value, Expression<Func<T>> e)
        {
            if (value == string.Empty)
            {
                brokenRules.Add(new NotEmptyString(PropertyNameHelper.GetName(e)));
            }
        }

        public static void AddBrokenRuleIfIntegerPropertyLessThanOne<T>(
            this IList<BrokenRule> brokenRules, int value, Expression<Func<T>> e)
        {
            if (value <= 0)
            {
                brokenRules.Add(new IntegerNeedsToBeGreaterThanZero(PropertyNameHelper.GetName(e)));;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes;

namespace EntityAndValueObjectBase.Infrastructure.Domain
{
    public static class BrokenRuleExtensions
    {
        public static void AddIfPropertyIsNull<T>(this IList<BrokenRule> brokenRules, object value, Expression<Func<T>> e)
        {
            if (value == null)
            {
                brokenRules.Add(new NotNull(PropertyNameHelper.GetName(e)));
            }
        }
        public static void AddIfPropertyEmpty<T>(this IList<BrokenRule> brokenRules, string value, Expression<Func<T>> e)
        {
            if (value != string.Empty) return;
            brokenRules.Add(new NotEmptyString(PropertyNameHelper.GetName(e)));
        }

        public static void AddIfIntegerPropertyLessThanOne<T>(
            this IList<BrokenRule> brokenRules, int value, Expression<Func<T>> e)
        {
            if (value > 0) return;
            brokenRules.Add(new IntegerNeedsToBeGreaterThanZero(PropertyNameHelper.GetName(e))); ;
        }
    }
}
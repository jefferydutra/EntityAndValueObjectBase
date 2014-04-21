using System;
using System.Linq.Expressions;

namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public static class PropertyNameHelper
    {
        public static string ResolvePropertyNameWithObject<T>(
            Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;

            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                expr = u.Operand as MemberExpression;
            }

            return expr
                .ToString()
                .Substring(expr.ToString().IndexOf(".") + 1);
        }

        public static string GetName<T>(Expression<Func<T>> e)
        {

            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }

    }


}
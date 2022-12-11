using System.Linq.Expressions;
using System.Reflection;

namespace SiKoperasi.Core.Common
{
    public class PredicateHelper<T>
    {
        public static Expression<Func<T, bool>> SetPredicateExpression(PropertyInfo propertyInfo, object value)
        {
            Expression<Func<T, bool>> expression;
            ParameterExpression param = Expression.Parameter(typeof(T));

            if (propertyInfo.PropertyType == typeof(string))
            {
                MethodInfo? method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                Expression constantExp = Expression.Constant(value, value.GetType());
                expression = Expression.Lambda<Func<T, bool>>(Expression.Call(Expression.Property(param, propertyInfo.Name), method, constantExp), param);

                return expression;
            }
            else if (propertyInfo.PropertyType == typeof(int))
            {
                Expression constantExp = Expression.Constant(value, value.GetType());
                expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(param, propertyInfo.Name), constantExp), param);
                return expression;
            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {

            }

            return null;
        }
    }
}

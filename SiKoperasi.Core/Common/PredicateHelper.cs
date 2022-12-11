using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;

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

        public static Expression<Func<T, object>> SetPredicateExpression(string orderBy)
        {
            ParameterExpression param = Expression.Parameter(typeof(T));
            Expression prop = Expression.Property(param, orderBy);
            UnaryExpression objectProp = Expression.Convert(prop, typeof(object));

            return Expression.Lambda<Func<T, object>>(objectProp, param);
        }
    }
}

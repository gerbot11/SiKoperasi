using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Enums;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace SiKoperasi.Core.Data
{
    public class PagingModel<T>
    {
        public IEnumerable<T>? Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItem { get; private set; }
        public int PageSize { get; private set; }
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);

        public PagingModel(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItem = count;
            PageSize = pageSize;
        }

        public static async Task<PagingModel<T>> CreateAsync(IQueryable<T> source, IQueryParam queryParam)
        {
            IQueryable<T> sourceFinal = SetSearchQueryable(SetSortingQueryable(source, queryParam), queryParam);
            sourceFinal = SetFilterQueryable(sourceFinal, queryParam);
            int count = await sourceFinal.CountAsync();
            List<T> items = await sourceFinal.Skip((queryParam.PageIndex - 1) * queryParam.PageSize).Take(queryParam.PageSize).ToListAsync();

            return new PagingModel<T>(items, count, queryParam.PageIndex, queryParam.PageSize);
        }

        public static async Task<PagingModel<TResult>> CreateDtoPagingAsync<TResult>(IQueryable<T> source, IQueryParam queryParam, Func<T, TResult> dtoMapper) 
            where TResult : class
        {
            IQueryable<T> sourceFinal = SetSearchQueryable(SetSortingQueryable(source, queryParam), queryParam);
            sourceFinal = SetFilterQueryable(sourceFinal, queryParam);
            int count = await sourceFinal.CountAsync();
            List<T> items = await sourceFinal.Skip((queryParam.PageIndex - 1) * queryParam.PageSize).Take(queryParam.PageSize).ToListAsync();

            return new PagingModel<TResult>(items.Select(dtoMapper).ToList(), count, queryParam.PageIndex, queryParam.PageSize);
        }

        private static IQueryable<T> SetSearchQueryable(IQueryable<T> source, IQueryParam queryParam)
        {
            if (string.IsNullOrEmpty(queryParam.SearchQuery))
                return source;

            List<PropertyInfo> props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(a => a.PropertyType == typeof(string) && !a.Name.Contains("Id") && !a.Name.Contains("Usr")).ToList();

            List<Expression<Func<T, bool>>> expresions = PredicateHelper<T>.SetListPredicateExpression(props, queryParam.SearchQuery);
            
            string expString = string.Empty;
            for (int i = 0; i < expresions.Count; i++)
            {
                if (i == expresions.Count - 1 && i == 0)
                {
                    expString = expresions[i].ToString();
                    break;
                }
                else if (i == 0)
                {
                    expString += expresions[i].ToString();
                }
                else
                {
                    expString += " OR " + expresions[i].Body.ToString();
                }
            }

            return source.Where(expString);
        }

        private static IQueryable<T> SetSortingQueryable(IQueryable<T> source, IQueryParam queryParam)
        {
            if (string.IsNullOrEmpty(queryParam.OrderBy))
                return source;

            PropertyInfo? property = typeof(T).GetProperty(queryParam.OrderBy);
            if (property is null)
                throw new Exception($"Invalid Field '{queryParam.OrderBy}' for Order!");

            Expression<Func<T, object>> expresionOrder = PredicateHelper<T>.SetPredicateExpression(queryParam.OrderBy);

            if (queryParam.OrderBehavior == OrderBehaviour.Asc)
                return source.OrderBy(expresionOrder);
            else
                return source.OrderByDescending(expresionOrder);
        }

        private static IQueryable<T> SetFilterQueryable(IQueryable<T> source, IQueryParam queryParam)
        {
            if (string.IsNullOrEmpty(queryParam.SearchFilter))
                return source;

            List<PropertyInfo> props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(a => !a.Name.Contains("Id") && !a.Name.Contains("Usr")).ToList();

            ParameterExpression param = Expression.Parameter(typeof(T));
            Expression<Func<T, bool>> fieldFilter;

            var filterParam = SetListFilterQueryFieldAndValue(queryParam.SearchFilter);
            if (!filterParam.Any())
            {
                throw new Exception("Unable to process logical operator for filter!");
            }

            foreach (var item in filterParam)
            {
                Expression body = param;
                Expression? expOpr;
                if (item.Field.Contains('.'))
                {
                    string[] splitField = item.Field.Split('.').ToArray();
                    if (splitField.Length > 5)
                        throw new Exception("Length of search parameter which separate by '.' is more than 5!");

                    List<Type> listType = new(); 
                    for (int i = 0; i < splitField.Length; i++)
                    {
                        string field = splitField[i];
                        body = Expression.PropertyOrField(body, field);

                        if (listType.Any())
                        {
                            PropertyInfo? pi = listType[i - 1].GetProperties().FirstOrDefault(a => a.Name.ToLower() == field.ToLower());
                            if (pi is null)
                                throw new Exception($"Invalid filter field {field}");

                            listType.Add(pi.PropertyType);
                        }
                        else
                        {
                            PropertyInfo? pi = props.FirstOrDefault(a => a.Name.ToLower() == field.ToLower());
                            if (pi is null)
                                throw new Exception($"Invalid filter field {item.Field}");

                            listType.Add(pi.PropertyType);
                        }
                    }

                    object? valRes = null;
                    foreach (var typeitem in listType)
                    {
                        if (typeitem.IsClass && !typeitem.IsPrimitive && typeitem != typeof(string))
                            continue;

                        TypeConverter converter = TypeDescriptor.GetConverter(typeitem);
                        Type valType = item.Value.GetType();
                        valRes = converter.ConvertFrom(item.Value);
                    }

                    Expression rightValue = Expression.Constant(valRes, valRes.GetType());
                    expOpr = SetExprOperator(item.Opr, body, rightValue);
                    if (expOpr is null)
                        throw new Exception("Invalid Logical Expression Operator");

                    fieldFilter = Expression.Lambda<Func<T, bool>>(expOpr, param);
                }
                else
                {
                    PropertyInfo? pi = props.FirstOrDefault(a => a.Name.ToLower() == item.Field.ToLower());
                    if (pi is null)
                        throw new Exception($"Invalid filter field {item.Field}");

                    body = Expression.PropertyOrField(body, pi.Name);
                    TypeConverter converter = TypeDescriptor.GetConverter(pi.PropertyType);
                    Type valType = item.Value.GetType();
                    var valRes = converter.ConvertFrom(item.Value);
                    Expression rightValue = Expression.Constant(valRes, pi.PropertyType);

                    expOpr = SetExprOperator(item.Opr, body, rightValue);
                    if (expOpr is null)
                        throw new Exception("Invalid Logical Expression Operator");

                    fieldFilter = Expression.Lambda<Func<T, bool>>(expOpr, param);
                }

                source = source.Where(fieldFilter);
            }

            return source;
        }

        private static List<FilterParam> SetListFilterQueryFieldAndValue(string data)
        {
            List<string> listFilter = data.Split(Constants.SEARCH_FIELD_SEPARATOR).ToList();
            List<FilterParam> filterParam = new();

            foreach (string item in listFilter)
            {
                FilterParam param = new();
                if (item.Contains(Constants.OPR_EQUAL))
                {
                    int position = item.IndexOf(Constants.OPR_EQUAL);
                    int position2 = item.IndexOf(Constants.OPR_GREATER);
                    int position3 = item.IndexOf(Constants.OPR_LOWER);
                    int position4 = item.IndexOf('!');

                    if (position2 > 0) //Operasi GTE
                    {
                        param.Opr = Constants.OPR_GTE;
                        param.Field = item[..position2];
                        param.Value = item[(position + 1)..];
                        filterParam.Add(param);
                        continue;
                    }

                    if (position3 > 0) //Operasi LTE
                    {
                        param.Opr = Constants.OPR_LTE;
                        param.Field = item[..position3];
                        param.Value = item[(position + 1)..];
                        filterParam.Add(param);
                        continue;
                    }

                    if (position4 > 0) //Operasi NOE
                    {
                        param.Opr = Constants.OPR_NOT_EQUAL;
                        param.Field = item[..position4];
                        param.Value = item[(position + 1)..];
                        filterParam.Add(param);
                        continue;
                    }

                    param.Opr = Constants.OPR_EQUAL;
                    param.Field = item[..position];
                    param.Value = item[(position + 1)..];
                    ValidationLogicOprValue(param.Opr, param.Value);
                    filterParam.Add(param);
                    continue;
                }

                if (item.Contains(Constants.OPR_GREATER))
                {
                    int position = item.IndexOf(Constants.OPR_GREATER);
                    param.Opr = Constants.OPR_GREATER;
                    param.Field = item[..position];
                    param.Value = item[(position + 1)..];
                    filterParam.Add(param);
                    continue;
                }

                if (item.Contains(Constants.OPR_LOWER))
                {
                    int position = item.IndexOf(Constants.OPR_LOWER);
                    param.Opr = Constants.OPR_LOWER;
                    param.Field = item[..position];
                    param.Value = item[(position + 1)..];
                    filterParam.Add(param);
                    continue;
                }
            }

            return filterParam;
        }

        private static Expression? SetExprOperator(string opr, Expression body, Expression rightValue)
        {
            Expression? expOpr = opr switch
            {
                Constants.OPR_EQUAL => Expression.Equal(body, rightValue),
                Constants.OPR_LTE => Expression.LessThanOrEqual(body, rightValue),
                Constants.OPR_GTE => Expression.GreaterThanOrEqual(body, rightValue),
                Constants.OPR_GREATER => Expression.GreaterThan(body, rightValue),
                Constants.OPR_LOWER => Expression.LessThan(body, rightValue),
                Constants.OPR_NOT_EQUAL => Expression.NotEqual(body, rightValue),
                _ => null,
            };
            return expOpr;
        }

        private static void ValidationLogicOprValue(string opr, object value)
        {
            if (value.GetType() == typeof(string) &&
                (opr == Constants.OPR_LOWER || opr == Constants.OPR_GTE || opr == Constants.OPR_GREATER
                || opr == Constants.OPR_LTE))
            {
                throw new Exception($"Cannot Apply Logical '{opr}' On type string");
            }
        }
    }
}

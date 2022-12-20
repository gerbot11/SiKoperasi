using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Enums;
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
            int count = await sourceFinal.CountAsync();
            List<T> items = await sourceFinal.Skip((queryParam.PageIndex - 1) * queryParam.PageSize).Take(queryParam.PageSize).ToListAsync();

            return new PagingModel<T>(items, count, queryParam.PageIndex, queryParam.PageSize);
        }

        public static async Task<PagingModel<TResult>> CreateDtoPagingAsync<TResult>(IQueryable<T> source, IQueryParam queryParam, Func<T, TResult> dtoMapper) 
            where TResult : class
        {
            IQueryable<T> sourceFinal = SetSearchQueryable(SetSortingQueryable(source, queryParam), queryParam);
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

        private static Dictionary<object, object> SetListSearchQueryFieldAndValue(string data)
        {
            List<string> listFilter = data.Split(Constants.SEARCH_FIELD_SEPARATOR).ToList();
            Dictionary<object, object> searchParam = new();
            foreach (string item in listFilter)
            {
                int pos = item.IndexOf(Constants.SEARCH_VALUE_SEPARATOR);
                string field = item[..pos];
                object val = item.Substring(pos + 1);
                searchParam.Add(field, val);
            }

            return searchParam;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Enums;
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

        private static IQueryable<T> SetSearchQueryable(IQueryable<T> source, IQueryParam queryParam)
        {
            if (string.IsNullOrEmpty(queryParam.SearchQuery))
                return source;

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Dictionary<object, object> searchProps = SetListSearchQueryFieldAndValue(queryParam.SearchQuery);

            foreach (KeyValuePair<object, object> item in searchProps)
            {
                PropertyInfo? property = props.FirstOrDefault(a => a.Name == item.Key.ToString());
                if (property is null)
                {
                    throw new Exception("Invalid Field for Searching!");
                }

                Expression<Func<T, bool>> expression = PredicateHelper<T>.SetPredicateExpression(property, item.Value);
                source = source.Where(expression);
            }

            return source;
        }

        private static IQueryable<T> SetSortingQueryable(IQueryable<T> source, IQueryParam queryParam)
        {
            if (string.IsNullOrEmpty(queryParam.OrderBy))
                return source;

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo? property = props.FirstOrDefault(a => a.Name == queryParam.OrderBy);
            if (property == null)
            {
                throw new Exception("Invalid Field for Order!");
            }

            if (queryParam.OrderBehavior == OrderBehaviour.Asc)
            {
                return source.OrderBy(a => property.GetValue(a));
            }
            else
            {
                return source.OrderByDescending(a => property.GetValue(a));
            }
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

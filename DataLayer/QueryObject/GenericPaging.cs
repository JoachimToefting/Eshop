using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.QueryObject
{
	public static class GenericPaging
	{
		/// <summary>
		/// Gets only one page from query with size and placement
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query">Returns One Page from this query</param>
		/// <param name="pageNumStart">The placment in pages the user wants to get</param>
		/// <param name="pageSize">Number of objects it wants</param>
		/// <returns></returns>
		public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumStart, int pageSize)
		{
			if (pageSize <= 0)
			{
				throw new Exception("PageSize under 0");
			}
			if (pageNumStart > 0)
			{
				//to skip number of pages
				query = query.Skip(pageNumStart * pageSize);
			}
			return query.Take(pageSize);
		}
	}
}

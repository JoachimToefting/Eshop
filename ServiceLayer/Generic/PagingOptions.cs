using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Generic
{
	public class PagingOptions
	{
		public const int DefaultPageSize = 2;
		//Page number current
		public int PageNum { get; set; }
		//Size of page -> default == DeafultPageSize
		public int PageSize { get; set; } = DefaultPageSize;
		//Max Pagenumber, can only be set internal
		public int NumPages { get; private set; }
		/// <summary>
		/// Setting values for paging
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="query">The Query to prepage on</param>
		public void SetupRestOfOption<T>(IQueryable<T> query)
		{
			//Setting the max pagenumber
			NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
			//PageNum -> max:NumPages min:1 
			PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
		}
	}
}

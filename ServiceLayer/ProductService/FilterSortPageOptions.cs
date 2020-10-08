using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService
{
	public class FilterSortPageOptions
	{
		#region Filter
		public ProductFilterBy FilterBy { get; set; }
		public string FilterValue { get; set; }
		#endregion

		#region Ordering
		public OrderByOptions OrderBy { get; set; }
		#endregion

		#region Paging
		//Default size per page
		public const int DefaultPageSize = 10;
		//Page number
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
		public void SetupRestOfDto<T>(IQueryable<T> query)
		{
			//Setting the max pagenumber
			NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
			//PageNum -> max:NumPages min:1 
			PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
		}
		#endregion
	}
}

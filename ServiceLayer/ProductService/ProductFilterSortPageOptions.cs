using ServiceLayer.Generic;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService
{
	public class ProductFilterSortPageOptions : PagingOptions
	{
		#region Filter
		public ProductFilterBy FilterBy { get; set; }
		public string FilterValue { get; set; }
		#endregion

		#region Ordering
		public OrderByOptions OrderBy { get; set; }
		public bool FeaturedFirst { get; set; } = true;
		#endregion
	}
}

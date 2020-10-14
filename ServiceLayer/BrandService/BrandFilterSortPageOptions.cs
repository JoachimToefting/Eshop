﻿using ServiceLayer.BrandService.QueryObjects;
using ServiceLayer.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.BrandService
{
	public class BrandFilterSortPageOptions : PagingOptions
	{
		public BrandFilterSortPageOptions()
		{
			FilterBy = BrandFilterBy.NoFilter;
			FilterValue = "";
			OrderBy = BrandOrderByOptions.NoOrder;
		}
		#region Filter
		public BrandFilterBy FilterBy { get; set; }
		public string FilterValue { get; set; }
		#endregion

		#region Ordering
		public BrandOrderByOptions OrderBy { get; set; }
		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
	public enum BrandOrderByOptions
	{
		NoOrder = 0,
		ByNameAsc,
		ByNameDesc
	}
	public static class BrandListDtoSort
	{
		public static IQueryable<BrandListDto> OrderBrandBy(this IQueryable<BrandListDto> brands, BrandOrderByOptions orderByOptions)
		{
			switch (orderByOptions)
			{
				case BrandOrderByOptions.NoOrder:
					return brands;
				case BrandOrderByOptions.ByNameAsc:
					return brands.OrderBy(b => b.Name);
				case BrandOrderByOptions.ByNameDesc:
					return brands.OrderByDescending(b => b.Name);
				default:
					throw new Exception("bad order");
			}
		}
	}
}

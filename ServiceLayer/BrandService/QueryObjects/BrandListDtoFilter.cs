using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
	public enum BrandFilterBy
	{
		NoFilter = 0,
		ByName
	}
	public static class BrandListDtoFilter
	{
		public static IQueryable<BrandListDto> FilterBrandBy(this IQueryable<BrandListDto> brands, BrandFilterBy filterBy, string filterValue)
		{
			if (string.IsNullOrEmpty(filterValue))
			{
				return brands;
			}
			switch (filterBy)
			{
				case BrandFilterBy.NoFilter:
					return brands;
				case BrandFilterBy.ByName:
					return brands.Where(b => b.Name == filterValue);
				default:
					throw new Exception("filter unhandled filtertype");
			}
		}
	}
}

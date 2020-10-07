using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
	public enum ProductFilterBy
	{
		NoFilter = 0,
		ByName,
		ByPriceMax,
		ByPriceMin,
		ByBrand
	}
	public static class ProductListDtoFilter
	{
		public static IQueryable<ProductListDto> FilterProductBy(this IQueryable<ProductListDto> products,ProductFilterBy filterBy, string filtervalue)
		{
			if (string.IsNullOrEmpty(filtervalue))
			{
				return products;
			}
			switch (filterBy)
			{
				case ProductFilterBy.NoFilter:
					return products;
				case ProductFilterBy.ByName:
					return products.Where(p => p.Name.Contains(filtervalue));
				case ProductFilterBy.ByPriceMax:
					return products.Where(p => p.Price <= double.Parse(filtervalue));
				case ProductFilterBy.ByPriceMin:
					return products.Where(p => p.Price >= double.Parse(filtervalue));
				case ProductFilterBy.ByBrand:
					return products.Where(p => p.Brand.Name.Contains(filtervalue));
				default:
					throw new Exception("filter unhandled filtertype");
			}
		}
	}
}

using Microsoft.EntityFrameworkCore;
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
		ByBrand,
		ByLikeAll
	}
	public static class ProductListDtoFilter
	{
		public static IQueryable<ProductListDto> FilterProductBy(this IQueryable<ProductListDto> products, ProductFilterBy filterBy, string filterValue)
		{
			if (string.IsNullOrEmpty(filterValue))
			{
				return products;
			}
			switch (filterBy)
			{
				case ProductFilterBy.NoFilter:
					return products;
				case ProductFilterBy.ByName:
					return products.Where(p => p.Name.Contains(filterValue));
				case ProductFilterBy.ByPriceMax:
					return products.Where(p => p.Price <= double.Parse(filterValue));
				case ProductFilterBy.ByPriceMin:
					return products.Where(p => p.Price >= double.Parse(filterValue));
				case ProductFilterBy.ByBrand:
					return products.Where(p => p.BrandName.Contains(filterValue));
				case ProductFilterBy.ByLikeAll:
					return products.Where(p => EF.Functions.Like(p.Name.ToLower(), "*" + filterValue.ToLower() + "*") || EF.Functions.Like(p.BrandName.ToLower(), "*" + filterValue.ToLower() + "*") || p.Price.ToString() == filterValue);
				default:
					throw new Exception("filter unhandled filtertype");
			}
		}
	}
}

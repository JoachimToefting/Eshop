using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
	public enum OrderByOptions
	{
		NoOrder = 0,
		ByNameAsc,
		ByNameDesc,
		ByPriceAsc,
		ByPriceDesc,
		ByBrandNameAsc,
		ByBrandNameDesc
	}
	public static class ProductListDtoSort
	{
		public static IQueryable<ProductListDto> OrderProductsBy(this IQueryable<ProductListDto> products, OrderByOptions orderByOptions)
		{
			switch (orderByOptions)
			{
				case OrderByOptions.NoOrder:
					return products;
				case OrderByOptions.ByNameAsc:
					return products.OrderBy(p => p.Name);
				case OrderByOptions.ByNameDesc:
					return products.OrderByDescending(p => p.Name);
				case OrderByOptions.ByPriceAsc:
					return products.OrderBy(p => p.Price);
				case OrderByOptions.ByPriceDesc:
					return products.OrderByDescending(p => p.Price);
				case OrderByOptions.ByBrandNameAsc:
					return products.OrderBy(p => p.BrandName);
				case OrderByOptions.ByBrandNameDesc:
					return products.OrderByDescending(p => p.BrandName);
				default:
					throw new Exception("bad order");
			}
		}
	}
}

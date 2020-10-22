using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
	public enum OrderByOptions
	{
		[Display(Name = "No Order")]
		NoOrder = 0,
		[Display(Name = "By Name Asc.")]
		ByNameAsc,
		[Display(Name = "By Name Desc.")]
		ByNameDesc,
		[Display(Name = "By Price Asc.")]
		ByPriceAsc,
		[Display(Name = "By Price Desc.")]
		ByPriceDesc,
		[Display(Name = "By Brand Asc.")]
		ByBrandNameAsc,
		[Display(Name = "By Brand Desc.")]
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

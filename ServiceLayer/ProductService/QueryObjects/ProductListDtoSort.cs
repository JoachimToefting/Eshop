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
		ByBrandNameDesc,
		[Display(Name = "By Description Asc.")]
		ByDescriptionAsc,
		[Display(Name = "By Description Desc.")]
		ByDescriptionDesc
	}
	public static class ProductListDtoSort
	{
		public static IQueryable<ProductListDto> OrderProductsBy(this IQueryable<ProductListDto> products, OrderByOptions orderByOptions, bool featured)
		{
			IOrderedQueryable<ProductListDto> orderetProducts = (IOrderedQueryable<ProductListDto>)products;
			if (featured)
			{
				orderetProducts = orderetProducts.OrderByDescending(p => p.Featured);
			}
			switch (orderByOptions)
			{
				case OrderByOptions.NoOrder:
					orderetProducts = orderetProducts;
					break;
				case OrderByOptions.ByNameAsc:
					orderetProducts = orderetProducts.ThenBy(p => p.Name);
					break;
				case OrderByOptions.ByNameDesc:
					orderetProducts = orderetProducts.ThenByDescending(p => p.Name);
					break;
				case OrderByOptions.ByPriceAsc:
					orderetProducts = orderetProducts.ThenBy(p => p.Price);
					break;
				case OrderByOptions.ByPriceDesc:
					orderetProducts = orderetProducts.ThenByDescending(p => p.Price);
					break;
				case OrderByOptions.ByBrandNameAsc:
					orderetProducts = orderetProducts.ThenBy(p => p.BrandName);
					break;
				case OrderByOptions.ByBrandNameDesc:
					orderetProducts = orderetProducts.ThenByDescending(p => p.BrandName);
					break;
				case OrderByOptions.ByDescriptionAsc:
					orderetProducts = orderetProducts.ThenBy(p => p.Description);
					break;
				case OrderByOptions.ByDescriptionDesc:
					orderetProducts = orderetProducts.ThenByDescending(p => p.Description);
					break;
				default:
					throw new Exception("bad order");
			}
			return (IQueryable<ProductListDto>)orderetProducts;
		}
	}
}

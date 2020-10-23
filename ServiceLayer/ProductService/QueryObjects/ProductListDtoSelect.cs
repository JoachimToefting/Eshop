using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
	public static class ProductListDtoSelect
	{
		public static IQueryable<ProductListDto> MapProductListDto(this IQueryable<Product> products)
		{
			return products.Select(p => new ProductListDto
			{
				ProductID = p.ProductID,
				Name = p.Name,
				BrandName = p.Brand.Name,
				Price = p.Price,
				NumberOfTags = p.ProductTags.Count(),
				ImgPath = p.ImgPath
			});
		}
		public static ProductListDto MapProductListDtoSingle(this Product product)
		{

			var p = new ProductListDto
			{
				ProductID = product.ProductID,
				Name = product.Name,
				BrandName = product.Brand?.Name,
				Price = product.Price,
				ImgPath = product.ImgPath
			};
			if (product.ProductTags != null)
			{
				p.NumberOfTags = product.ProductTags.Count();
			}
			return p;
		}
	}
}

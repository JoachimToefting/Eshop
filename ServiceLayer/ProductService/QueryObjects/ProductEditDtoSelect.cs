using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
	public static class ProductEditDtoSelect
	{
		public static ProductEditDto MapProductEditDto(this Product product)
		{
			return new ProductEditDto
			{
				ProductID = product.ProductID,
				Name = product.Name,
				Price = product.Price,
				BrandID = product.BrandID,
				ImgPath = product.ImgPath,
				Description = product.Description
			};
		}
		public static Product MapProduct(this ProductEditDto product)
		{
			return new Product
			{
				ProductID = product.ProductID,
				Name = product.Name,
				Price = product.Price,
				BrandID = product.BrandID,
				ImgPath = product.ImgPath,
				Description = product.Description
			};
		}
	}
}

using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
	public static class BrandEditSelect
	{
		public static BrandEditDto MapBrandEditDto(this Brand brand)
		{
			return new BrandEditDto
			{
				BrandID = brand.BrandID,
				Name = brand.Name
			};
		}
		public static Brand MapBrand(this BrandEditDto brand)
		{
			return new Brand
			{
				BrandID = brand.BrandID,
				Name = brand.Name
			};
		}
	}
}

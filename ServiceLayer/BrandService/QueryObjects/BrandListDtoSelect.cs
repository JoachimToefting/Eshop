using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.QueryObjects
{
	public static class BrandListDtoSelect
	{
		public static IQueryable<BrandListDto> MapBrandListDto(this IQueryable<Brand> brands)
		{
			return brands.Select(b => new BrandListDto
			{
				BrandID = b.BrandID,
				Name = b.Name
			});
		}
	}
}

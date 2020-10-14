using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObject;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BrandService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.BrandService.Concrete
{
	public class ListBrandService : IListBrandService
	{
		private readonly EshopContext _context;
		public ListBrandService(EshopContext context)
		{
			_context = context;
		}
		public IQueryable<BrandListDto> FilterSortPage(BrandFilterSortPageOptions options)
		{
			var brandsQuery = _context.Brands
				.AsNoTracking()
				.MapBrandListDto()
				.FilterBrandBy(options.FilterBy, options.FilterValue)
				.OrderBrandBy(options.OrderBy)
				;
			options.SetupRestOfDto(brandsQuery);
			// -1 for index offset
			return brandsQuery.Page(options.PageNum - 1, options.PageSize);
		}
		public void Add(Brand brand)
		{
			_context.Add(brand);
			_context.SaveChangesAsync();
		}


	}
}

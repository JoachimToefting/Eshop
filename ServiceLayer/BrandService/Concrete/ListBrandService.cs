using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObject;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BrandService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			options.SetupRestOfOption(brandsQuery);
			// -1 for index offset
			return brandsQuery.Page(options.PageNum - 1, options.PageSize);
		}
		public async Task<int> AddAsync(BrandEditDto brandEditDto)
		{
			Brand brand = brandEditDto.MapBrand();
			_context.Add(brand);
			await _context.SaveChangesAsync();
			return brand.BrandID;
		}
		public async Task<BrandEditDto> FindEditDtoByIDAsync(int id)
		{
			return (await _context.Brands.FindAsync(id)).MapBrandEditDto();
		}
		public async Task<int> UpdateAsync(BrandEditDto brandEditDto)
		{
			Brand brand = brandEditDto.MapBrand();
			_context.Attach(brand);
			await _context.SaveChangesAsync();
			return brand.BrandID;
		}
		public async Task<int> DeleteByIDAsync(int id)
		{
			_context.Remove(await _context.Brands.FindAsync(id));
			return await _context.SaveChangesAsync();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.QueryObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ServiceLayer.ProductService.QueryObjects;

namespace ServiceLayer.ProductService.Concrete
{
	public class ListProductService : IListProductService
	{
		private readonly EshopContext _context;

		public ListProductService(EshopContext context)
		{
			_context = context;
		}
		public IQueryable<ProductListDto> FilterSortPage(ProductFilterSortPageOptions options)
		{
			var productsQuery = _context.Products
				.AsNoTracking()
				.MapProductListDto()
				.FilterProductBy(options.FilterBy, options.FilterValue)
				.OrderProductsBy(options.OrderBy)
				;

			options.SetupRestOfOption(productsQuery);
			//-1 for index offset
			return productsQuery.Page(options.PageNum - 1, options.PageSize);
		}
		public async Task<int> AddAsync(ProductEditDto product)
		{
			Product productEntity = product.MapProduct();
			_context.Add(productEntity);
			await _context.SaveChangesAsync();
			return productEntity.ProductID;
		}
		public async Task<ProductEditDto> FindEditByIdAsync(int id)
		{
			return (await _context.Products.FindAsync(id))?.MapProductEditDto();
		}
		public async Task UpdateAsync(ProductEditDto product)
		{
			Product productEntity = product.MapProduct();
			_context.Products.Update(productEntity);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteByIdAsync(int id)
		{
			_context.Remove(await _context.Products.FindAsync(id));
			await _context.SaveChangesAsync();
		}
	}
}

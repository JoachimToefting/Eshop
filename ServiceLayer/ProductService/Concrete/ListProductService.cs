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
	public class ListProductService
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

			options.SetupRestOfDto(productsQuery);
			//-1 for index offset
			return productsQuery.Page(options.PageNum - 1, options.PageSize);
		}
		public async Task<int> Add(Product product)
		{
			_context.Add(product);
			await _context.SaveChangesAsync();
			return product.ProductID;
		}
		public async Task<Product> FindById(int id)
		{
			return await _context.Products.FindAsync(id);
		}
		public async Task Update(Product product)
		{
			_context.Attach(product);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteById(int id)
		{
			_context.Remove(await FindById(id));
			await _context.SaveChangesAsync();
		}
	}
}

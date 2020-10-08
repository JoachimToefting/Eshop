using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.QueryObject;
using Microsoft.EntityFrameworkCore;
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
		public IQueryable<ProductListDto> FilterSortPage(FilterSortPageOptions options)
		{
			var productsQuery = _context.Products
				.AsNoTracking()
				.MapProductListDto()
				.FilterProductBy(options.FilterBy, options.FilterValue)
				.OrderProductsBy(options.OrderBy)
				;

			options.SetupRestOfDto(productsQuery);
			return productsQuery.Page(options.PageNum, options.PageSize);
		}
	}
}

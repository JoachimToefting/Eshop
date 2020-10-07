using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace ServiceLayer.ProductService.Concrete
{
	public class ListProductService
	{
		private readonly EshopContext _context;

		public ListProductService(EshopContext context)
		{
			_context = context;
		}
		public IQueryable<ProductListDto> FilterSortPage()
	}
}

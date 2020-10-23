using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceLayer.BrandService;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;

namespace EshopWebApp.Pages.Admin
{
	public class AdminPanelModel : PageModel
	{
		private readonly IListProductService _listProductService;
		public AdminPanelModel(IListProductService listProductService)
		{
			_listProductService = listProductService;
		}
		[BindProperty(SupportsGet = true)]
		public int? pageCurrent { get; set; }

		[BindProperty(SupportsGet = true)]
		public int? pageSize { get; set; }
		[BindProperty]
		public int totalPages { get; set; }
		[BindProperty(SupportsGet = true)]
		public string searchTerm { get; set; }
		[BindProperty(SupportsGet = true)]
		public int? orderBy { get; set; }
		[BindProperty(SupportsGet = true)]
		public bool featuredFirst { get; set; }
		public IList<ProductListDto> Products { get; set; }
		public async Task OnGetAsync()
		{
			ProductFilterSortPageOptions productFilterSortPageOptions = new ProductFilterSortPageOptions();
			if (!string.IsNullOrEmpty(searchTerm))
			{
				productFilterSortPageOptions.FilterBy = ServiceLayer.ProductService.QueryObjects.ProductFilterBy.ByLikeAll;
				productFilterSortPageOptions.FilterValue = searchTerm;
			}
			productFilterSortPageOptions.FeaturedFirst = featuredFirst;
			if (orderBy.HasValue)
			{
				productFilterSortPageOptions.OrderBy = (ServiceLayer.ProductService.QueryObjects.OrderByOptions)orderBy;
			}
			if (pageSize.HasValue)
			{
				productFilterSortPageOptions.PageSize = (int)pageSize;
			}
			if (pageCurrent.HasValue)
			{
				productFilterSortPageOptions.PageNum = (int)pageCurrent;
			}
			Products = await _listProductService.FilterSortPage(productFilterSortPageOptions).ToListAsync();
			totalPages = productFilterSortPageOptions.NumPages;
		}
	}
}

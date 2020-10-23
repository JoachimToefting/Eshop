using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;

namespace EshopWebApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IListProductService _listProductService;

		public IndexModel(ILogger<IndexModel> logger, IListProductService listProductService)
		{
			_logger = logger;
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
		public IList<ProductListDto> Products { get; set; }
		public void OnGet()
		{

			ProductFilterSortPageOptions productFilterSortPageOptions = new ProductFilterSortPageOptions();
			if (!string.IsNullOrEmpty(searchTerm))
			{
				productFilterSortPageOptions.FilterBy = ServiceLayer.ProductService.QueryObjects.ProductFilterBy.ByLikeAll;
				productFilterSortPageOptions.FilterValue = searchTerm;
			}
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
			Products = _listProductService.FilterSortPage(productFilterSortPageOptions).ToList();
			totalPages = productFilterSortPageOptions.NumPages;
		}
	}
}

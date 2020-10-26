using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace EshopWebApp.Pages.Admin.ProductPages
{
	public class DeleteProductModel : PageModel
	{
		private readonly IListProductService _listProductService;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<EditProductModel> _logger;

		public DeleteProductModel(ILogger<EditProductModel> logger, IListProductService listProductService, IWebHostEnvironment webHostEnvironment)
		{
			_logger = logger;
			_listProductService = listProductService;
			_webHostEnvironment = webHostEnvironment;
			
		}

		[BindProperty]
		public ProductListDto Product { get; set; }
		[BindProperty(SupportsGet = true)]
		public int? id { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Product = await _listProductService.FindListByIdAsync((int)id);

			if (Product == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			if (!string.IsNullOrEmpty(Product.ImgPath))
			{
				string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "img", $"{Product.ProductID}.{Product.ImgPath}");
				if (System.IO.File.Exists(filepath))
				{
					//No need to update product as it will be deleted
					System.IO.File.Delete(filepath);
				}
				else
				{
					_logger.LogWarning("No file was deleted and has to be deleted manual");
				}
			}

			await _listProductService.DeleteByIdAsync((int)id);

			return RedirectToPage("../AdminPanel");
		}
	}
}

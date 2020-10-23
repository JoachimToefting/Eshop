using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.BrandService;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.QueryObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;

namespace EshopWebApp.Pages.Admin.ProductPages
{
	public class EditProductModel : PageModel
	{
		private readonly IListProductService _listProductService;
		private readonly IListBrandService _listBrandService;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<EditProductModel> _logger;

		public EditProductModel(IListProductService listProductService, IListBrandService listBrandService, IWebHostEnvironment webHostEnvironment, ILogger<EditProductModel> logger)
		{
			_listProductService = listProductService;
			_listBrandService = listBrandService;
			_webHostEnvironment = webHostEnvironment;
			_logger = logger;
		}

		[BindProperty]
		public ProductEditDto Product { get; set; }
		[BindProperty]
		public IFormFile Upload { get; set; }
		[BindProperty(SupportsGet = true)]
		public int? id { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			ViewData["Brand"] = new SelectList(_listBrandService.FilterSortPage(new BrandFilterSortPageOptions()), "BrandID", "Name");
			if (id.HasValue)
			{
				Product = await _listProductService.FindEditByIdAsync((int)id);
			}
			else
			{
				Product = new ProductEditDto();
			}

			if (Product == null)
			{
				RedirectToPage("/Error");
			}
			return Page();
		}



		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			string fileextension = Upload?.FileName.Split('.').Last();
			Product.ImgPath = fileextension;
			int productID;
			if (Product.ProductID > 0)
			{
				await _listProductService.UpdateAsync(Product);
				productID = Product.ProductID;
			}
			else
			{
				productID = await _listProductService.AddAsync(Product);
			}
			//image upload
			if (Upload != null && (fileextension == "png" || fileextension == "jpg" || fileextension == "jpeg"))
			{
				var file = Path.Combine(_webHostEnvironment.WebRootPath, "img", productID.ToString() + "." + Upload.FileName.Split('.').Last());
				using (var filestream = new FileStream(file, FileMode.Create))
				{
					await Upload.CopyToAsync(filestream);
				}
				_logger.LogInformation("Images uploaded for product: "+productID);
			}
			_logger.LogInformation($"Product: {productID} change or created");

			return RedirectToPage("/admin/AdminPanel");
		}
	}
}

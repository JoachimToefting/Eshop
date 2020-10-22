﻿using System;
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

namespace EshopWebApp.Pages.Admin.ProductPages
{
	public class EditProductModel : PageModel
	{
		private readonly IListProductService _listProductService;
		private readonly IListBrandService _listBrandService;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public EditProductModel(IListProductService listProductService, IListBrandService listBrandService, IWebHostEnvironment webHostEnvironment)
		{
			_listProductService = listProductService;
			_listBrandService = listBrandService;
			_webHostEnvironment = webHostEnvironment;
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


			if (Product.ProductID > 0)
			{
				await _listProductService.UpdateAsync(Product);
			}
			else
			{
				await _listProductService.AddAsync(Product);
			}

			if (Upload != null)
			{
				var file = Path.Combine(_webHostEnvironment.ContentRootPath, "upload", Upload.FileName);
				using (var filestream = new FileStream(file, FileMode.Create))
				{
					await Upload.CopyToAsync(filestream);
				}
			}
			return RedirectToPage("/admin/AdminPanel");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BrandService;
using ServiceLayer.BrandService.Concrete;
using ServiceLayer.BrandService.QueryObjects;

namespace EshopWebApp.Pages.Admin.BrandPages
{
	public class EditBrandModel : PageModel
	{
		private readonly IListBrandService _listBrandService;
		public EditBrandModel(IListBrandService listBrandService)
		{
			_listBrandService = listBrandService;
		}
		[BindProperty]
		public BrandEditDto Brand { get; set; }
		public async Task<IActionResult> OnGetAsync(int? brandID)
		{
			if (brandID.HasValue)
			{
				Brand = await _listBrandService.FindEditDtoByIDAsync((int)brandID);
			}
			else
			{
				Brand = new BrandEditDto();
			}

			if (Brand == null)
			{
				RedirectToPage("/Error");
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (Brand.BrandID > 0)
			{
				await _listBrandService.UpdateAsync(Brand);
			}
			else
			{
				await _listBrandService.AddAsync(Brand);
			}

			return RedirectToPage("/Admin/AdminPanel");
		}
	}
}

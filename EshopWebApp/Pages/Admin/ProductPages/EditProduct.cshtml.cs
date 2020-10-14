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

namespace EshopWebApp.Pages.Admin.ProductPages
{
    public class EditProductModel : PageModel
    {
        private readonly IListProductService _listProductService;
        private readonly IListBrandService _listBrandService;

        public EditProductModel(IListProductService listProductService, IListBrandService listBrandService)
        {
            _listProductService = listProductService;
            _listBrandService = listBrandService;
        }

        [BindProperty]
        public ProductEditDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productID)
        {
            ViewData["Brand"] = new SelectList(_listBrandService.FilterSortPage(new BrandFilterSortPageOptions()), "BrandID", "Name");
			if (productID.HasValue)
			{
                Product = (await _listProductService.FindById((int)productID)).MapProductEditDto();
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
                await _listProductService.UpdateAsync(Product.MapProduct());
			}
			else
			{
                await _listProductService.AddAsync(Product.MapProduct());
			}

            return RedirectToPage("./Index");
        }
    }
}

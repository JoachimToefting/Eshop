using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.QueryObjects;

namespace EshopWebApp.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly IListProductService _listProductService;
		public ProductPageModel(IListProductService listProductService)
		{
            _listProductService = listProductService;
		}
        public ProductListDto Product { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Product = await _listProductService.FindListByIdAsync(id);
			if (Product == null)
			{
                return NotFound();
			}
            return Page();
        }
    }
}

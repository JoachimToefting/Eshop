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

namespace EshopWebApp.Pages.Admin.ProductPages
{
    public class DeleteProductModel : PageModel
    {
        private readonly IListProductService _listProductService;

        public DeleteProductModel(IListProductService listProductService)
        {
            _listProductService = listProductService;
        }

        [BindProperty]
        public ProductEditDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _listProductService.FindEditByIdAsync((int)id);

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
			

            await _listProductService.DeleteByIdAsync((int)id);

            return RedirectToPage("../AdminPanel");
        }
    }
}

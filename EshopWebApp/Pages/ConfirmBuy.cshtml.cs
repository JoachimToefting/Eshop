using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EshopWebApp.JsonModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;

namespace EshopWebApp.Pages
{
	public class ConfirmBuyModel : PageModel
	{
		public IListProductService _listProductService;
		public ConfirmBuyModel(IListProductService listProductService)
		{
			_listProductService = listProductService;
		}
		[BindProperty]
		public List<ProductListCartDto> Products { get; set; }
		[BindProperty]
		public double TotalPrice { get; set; }
		[Display(Name = "First name")]
		[BindProperty]
		public string firstname { get; set; }
		[Display(Name = "Last name")]
		[BindProperty]
		public string lastname { get; set; }
		public async Task<IActionResult> OnGetAsync()
		{
			string cart = Request.Cookies["Cart"];

			if (cart == null)
			{
				return Page();
			}
			List<CartItem> cartRoot = JsonSerializer.Deserialize<List<CartItem>>(cart);
			Products = new List<ProductListCartDto>();
			foreach (var item in cartRoot)
			{
				var productDto = await _listProductService.FindListByIdAsync(item.ProductID);
				if (productDto != null)
				{
					ProductListCartDto product = new ProductListCartDto(productDto, item.Count);
					TotalPrice = TotalPrice + (productDto.Price * item.Count);
					Products.Add(product);
				}
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			return RedirectToPage("/Confirmed",new { firstname,lastname,TotalPrice });
			//return this.RedirectToAction("myActionName", new { value1 = "queryStringValue1" });
		}
	}
}

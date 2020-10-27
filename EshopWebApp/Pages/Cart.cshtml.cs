using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService.Concrete;
using System.Text.Json;
using System.Web;
using ServiceLayer.ProductService;
using EshopWebApp.JsonModels;
using StackExchange.Profiling.Internal;

namespace EshopWebApp.Pages
{
	public class CartModel : PageModel
	{
		private readonly IListProductService _listProductService;
		public CartModel(IListProductService listProductService)
		{
			_listProductService = listProductService;
		}
		[BindProperty]
		public List<ProductListCartDto> Products { get; set; }
		public double TotalPrice { get; set; } 
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
			List<CartItem> cartItems = new List<CartItem>();
			foreach (var item in Products)
			{
				if (item.Count > 0 && !item.MarkedforDeletion)
				{
					cartItems.Add(new CartItem
					{
						Count = item.Count,
						ProductID = item.Product.ProductID
					});
				}
			}

			string cartRootString = JsonSerializer.Serialize(cartItems);

			Response.Cookies.Append("Cart", cartRootString);

			return RedirectToPage();
		}
	}
}

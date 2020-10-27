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
		public List<ProductListCartDto> Products { get; set; } = new List<ProductListCartDto>();
		public async Task<IActionResult> OnGetAsync()
		{

			string cart = Request.Cookies["Cart"];

			if (cart == null)
			{
				return Page();
			}

			List<CartItem> cartRoot = JsonSerializer.Deserialize<List<CartItem>>(cart);

			foreach (var item in cartRoot)
			{
				ProductListCartDto product = new ProductListCartDto(await _listProductService.FindListByIdAsync(item.ProductID), item.Count);
				Products.Add(product);
			}

			return Page();
		}
	}
}

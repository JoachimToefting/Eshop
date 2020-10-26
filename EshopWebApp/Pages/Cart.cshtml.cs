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
		public List<ProductListDto> Products { get; set; }
		public void OnGet()
		{
			string cart = HttpContext.Request.Cookies["Cart"];
			if (cart != null)
			{
				 
			}

			//JsonSerializer.Deserialize<CartItem>
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Eshop");

			PrintAllProducts();
		}
		public static void PrintAllProducts()
		{
			List<ProductListDto> products = new List<ProductListDto>();
			using (EshopContext context = new EshopContext())
			{
				var productService = new ListProductService(context);
				products = productService.FilterSortPage(new FilterSortPageOptions
				{

				}).ToList();

			}
			foreach (ProductListDto product in products)
			{
				Console.WriteLine($"{product.BrandName} - {product.Name} {product.Price} Dollaridoes");
			}
		}
	}
}

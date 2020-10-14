using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;

namespace ConsoleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Eshop");

			await PrintAllProducts();
			await InsertOrUpdateProduct(new ProductListDto
			{
				Name = "Circle",
				Price = 8888
			});
			await PrintAllProducts();
			await InsertOrUpdateProduct(new ProductListDto
			{
				ProductID = 4,
				Name = "circle1"
			});
			await PrintAllProducts();
		}
		public static async Task PrintAllProducts()
		{
			List<ProductListDto> products = new List<ProductListDto>();
			using (EshopContext context = new EshopContext())
			{
				var productService = new ListProductService(context);
				products = await productService.FilterSortPage(new ProductFilterSortPageOptions
				{

				}).ToListAsync();

			}
			foreach (ProductListDto product in products)
			{
				Console.WriteLine($"{product.BrandName} - {product.Name} {product.Price} Dollaridoes");
			}
		}
		public static async Task InsertOrUpdateProduct(ProductListDto product)
		{
			if (product != null)
			{
				using (EshopContext context = new EshopContext())
				{
					ListProductService service = new ListProductService(context);
					Product result;
					if (product.ProductID == 0)
					{
						result = await service.FindById(product.ProductID);
					}

					if (product != null)
					{
						await service.AddAsync(new Product
						{
							Name = product.Name,
							Price = product.Price,
						});
					}
					else
					{
						await service.UpdateAsync(new Product
						{
							ProductID = product.ProductID,
							Name = product.Name,
							Price = product.Price
						});
					}
				}
			}
		}
		public static async Task<List<ProductListDto>> GetProductsByName(string searchName)
		{
			using (EshopContext context = new EshopContext())
			{
				var productService = new ListProductService(context);
				var products = await productService.FilterSortPage(new ProductFilterSortPageOptions
				{
					FilterBy = ServiceLayer.ProductService.QueryObjects.ProductFilterBy.ByName,
					FilterValue = searchName
				}).ToListAsync();

				return products;

			}
		}
	}
}

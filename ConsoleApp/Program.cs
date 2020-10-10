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
				products = await productService.FilterSortPage(new FilterSortPageOptions
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
					Product oldProduct = context.Products.Find(product.ProductID);
					if (oldProduct == null)
					{
						oldProduct = new Product();
					}
					oldProduct.Name = product.Name;
					oldProduct.Price = product.Price;
					if (!String.IsNullOrEmpty(product.BrandName))
					{
						Brand brand = await context.Brands.SingleOrDefaultAsync(b => b.Name == product.BrandName);
						if (brand == null)
						{
							context.Brands.Add(new Brand
							{
								Name = product.BrandName
							});
						}
						oldProduct.Brand = brand;
					}
					context.Attach(oldProduct);
					await context.SaveChangesAsync();
				}
			}
		}
		public static async Task<List<ProductListDto>> GetProductsByName(string searchName)
		{
			using (EshopContext context = new EshopContext())
			{
				var productService = new ListProductService(context);
				var products = await productService.FilterSortPage(new FilterSortPageOptions
				{
					FilterBy = ServiceLayer.ProductService.QueryObjects.ProductFilterBy.ByName,
					FilterValue = searchName
				}).ToListAsync();

				return products;

			}
		}
	}
}

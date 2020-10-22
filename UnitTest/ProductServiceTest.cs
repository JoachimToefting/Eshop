using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
	[TestClass]
	public class ProductServiceTest
	{
		[TestMethod]
		public async Task AddProductTest()
		{
			//Arrange:
			var options = new DbContextOptionsBuilder<EshopContext>()
				.UseInMemoryDatabase(databaseName: "AddProductTest")
				.Options;

			//Act:
			int ID;
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				ID = await service.AddAsync(new ProductEditDto
				{
					Name = "New Shape",
					Price = 1,
				});
			}
			//Assert:
			using (EshopContext context = new EshopContext(options))
			{
				Assert.AreNotEqual(0, ID);
				Assert.AreEqual("New Shape", context.Products.Last().Name);
				Assert.AreEqual(1, context.Products.Last().Price);
			}
		}
		[TestMethod]
		public async Task FindProductTest()
		{
			//Arrange:
			var options = new DbContextOptionsBuilder<EshopContext>()
				.UseInMemoryDatabase(databaseName: "FindProductTest")
				.Options;

			//Act:
			int ID;
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				ID = await  service.AddAsync(new ProductEditDto
				{
					Name = "New Shape Find",
					Price = 1,
				});
			}

			//Assert
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				var result = await service.FindEditByIdAsync(ID);
				Assert.AreEqual("New Shape Find", result.Name);
			}
		}
		[TestMethod]
		public async Task UpdateProductTest()
		{
			//Arrange:
			var options = new DbContextOptionsBuilder<EshopContext>()
				.UseInMemoryDatabase(databaseName: "UpdateProductTest")
				.Options;

			//Act:
			int ID;
			ProductEditDto product;
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				ID = await service.AddAsync(new ProductEditDto
				{
					Name = "New Shape Update",
					Price = 1,
				});
				product = await service.FindEditByIdAsync(ID);
			}
				//disconncted
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				
				product.Name = "New Shape updated";
				product.Price = 2;

				await service.UpdateAsync(product);
			}

			//Assert:
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);

				var result = await service.FindEditByIdAsync(ID);
				Assert.AreEqual("New Shape updated", result.Name);
				Assert.AreEqual(2, result.Price);
			}
		}
		[TestMethod]
		public async Task DeleteProductTest()
		{
			//Arrange:
			var options = new DbContextOptionsBuilder<EshopContext>()
				.UseInMemoryDatabase(databaseName: "DeleteProductTest")
				.Options;

			//Act:
			int ID;
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				ID = await service.AddAsync(new ProductEditDto
				{
					Name = "New Shape Delete",
					Price = 1,
				});

			}
				//disconncted
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				await service.DeleteByIdAsync(ID);
			}

			//Assert:
			using (EshopContext context = new EshopContext(options))
			{
				var service = new ListProductService(context);
				ProductEditDto result = await service.FindEditByIdAsync(ID);
				Assert.AreEqual(null, result);
			}
		}
	}
}

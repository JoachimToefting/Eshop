using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	[TestClass]
	public class ProductDataLayerTest
	{
		[TestMethod]
		public async Task AddProductTestDatabase()
		{
			//Arrange:
			//none

			//Act:
			int ID;
			using (EshopContext context = new EshopContext())
			{
				var service = new ListProductService(context);
				ID = await service.AddAsync(new ProductEditDto
				{
					Name = "New Shape",
					Price = 1,
				});
			}
			//Assert:
			using (EshopContext context = new EshopContext())
			{
				Assert.AreNotEqual(0, ID);
				Assert.AreEqual("New Shape", context.Products.OrderBy(p => p.ProductID).Last().Name);
				Assert.AreEqual(1, context.Products.OrderBy(p => p.ProductID).Last().Price);
			}
		}
		[TestCleanup]
		public void AddProductCleanUp()
		{
			using (EshopContext context = new EshopContext())
			{
				var products = context.Products.Where(p => p.Name == "New Shape");
				context.RemoveRange(products);
				context.SaveChanges();
			}
		}
	}
}

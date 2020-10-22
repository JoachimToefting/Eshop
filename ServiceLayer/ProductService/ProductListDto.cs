using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace ServiceLayer.ProductService
{
	public class ProductListDto
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string BrandName { get; set; }
		public int NumberOfTags { get; set; }
		public string ImgPath { get; set; }
	}
}

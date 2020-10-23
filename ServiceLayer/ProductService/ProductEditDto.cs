using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService
{
	public class ProductEditDto
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int? BrandID { get; set; }
		public string ImgPath { get; set; }
		public string Description { get; set; }
		public bool Featured { get; set; }
	}
}

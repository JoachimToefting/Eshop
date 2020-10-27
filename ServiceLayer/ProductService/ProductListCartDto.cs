using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService
{
	public class ProductListCartDto
	{
		public ProductListCartDto(ProductListDto product, int count)
		{
			this.Count = count;
			this.Product = product;
		}
		public int Count { get; set; }
		public ProductListDto Product { get; set; }
	}
}

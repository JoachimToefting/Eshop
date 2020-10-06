using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
	class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public int? BrandID { get; set; }
		public Brand Brand { get; set; }
		public ICollection<ProductTag> ProductTags { get; set; }
	}
}

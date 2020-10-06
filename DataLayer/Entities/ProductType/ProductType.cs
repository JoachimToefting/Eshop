using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
	class ProductType
	{
		public int ProductID { get; set; }
		public Product Product { get; set; }
		public int TypeID { get; set; }
		public Type Type { get; set; }
	}
}

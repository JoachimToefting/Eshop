using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
	class Type
	{
		public int TypeID { get; set; }
		public string Name { get; set; }
		public List<ProductType> ProductTypes { get; set; }
	}
}

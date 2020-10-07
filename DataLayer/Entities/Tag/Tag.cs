using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
	public class Tag
	{
		public int TagID { get; set; }
		public string Name { get; set; }
		public ICollection<ProductTag> ProductTags { get; set; }
	}
}

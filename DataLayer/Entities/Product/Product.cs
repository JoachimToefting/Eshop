using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		[Column(TypeName ="decimal(19,2)")]
		public double Price { get; set; }
		public string ImgPath { get; set; }
		public string Description { get; set; }
		public int? BrandID { get; set; }
		public Brand Brand { get; set; }
		public ICollection<ProductTag> ProductTags { get; set; }
	}
}

using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DataLayer
{
	public class EshopContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Tag> Tags { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			dbContextOptionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = EshopDB; Trusted_Connection = true")
				.EnableSensitiveDataLogging(true)
				.UseLoggerFactory(new ServiceCollection()
					.AddLogging(builder => builder.AddConsole()
						.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
					.BuildServiceProvider().GetService<ILoggerFactory>()); ;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Composit key
			modelBuilder.Entity<ProductTag>()
				.HasKey(pt => new { pt.ProductID, pt.TypeID });

#if DEBUG
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					ProductID = 1,
					Name = "SomeSquare",
					Price = 8,
					Brand = new Brand
					{
						BrandID = 1,
						Name = "90° Company"
					}
				},
				new Product
				{
					ProductID = 2,
					Name = "Non Euclidean Pentagon",
					Price = 5,
					BrandID = 1
				}
				);
#endif
		}
	}
}

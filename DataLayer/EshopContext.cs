using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
	public class EshopContext : DbContext
	{
		DbSet<Product> Products { get; set; }
		DbSet<Brand> Brands { get; set; }
		DbSet<Tag> Tags { get; set; }
		protected override void OnConfiguring( DbContextOptionsBuilder dbContextOptionsBuilder)
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
		}
	}
}

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
		public EshopContext()
		{

		}
		public EshopContext(DbContextOptions<EshopContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Tag> Tags { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			if (!dbContextOptionsBuilder.IsConfigured)
			{
				dbContextOptionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = EshopDB; Trusted_Connection = true");
			}
			dbContextOptionsBuilder
			.EnableSensitiveDataLogging(true)
			.UseLoggerFactory(new ServiceCollection()
				.AddLogging(builder => builder.AddConsole()
					.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
				.BuildServiceProvider().GetService<ILoggerFactory>())
			;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Composit key
			modelBuilder.Entity<ProductTag>()
				.HasKey(pt => new { pt.ProductID, pt.TypeID });

			//Product Default value
			modelBuilder.Entity<Product>()
				.Property(p => p.Featured)
				.HasDefaultValue(false);

#if DEBUG
			modelBuilder.Entity<Brand>().HasData(
				new Brand
				{
					BrandID = 1,
					Name = "90° Company"
				}
				);
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					ProductID = 1,
					Name = "SomeSquare",
					Price = 8,
					BrandID = 1
				},
				new Product
				{
					ProductID = 2,
					Name = "Non Euclidean Pentagon",
					Price = 5,
					BrandID = 1
				},
				new Product
				{
					ProductID = 3,
					Name = "None",
					Price = -1
				}
				);
#endif
		}
	}
}

using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=REM-LT-221031D; Database=CodingWiki; TrustServerCertificate=True; Trusted_Connection=True;");
			
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					Id = 1,
					Title = "Spider without Duty",
					ISBN = "123B22",
					Price = 10
				},

				new Book
				{
					Id = 2,
					Title = "Spider with a Duty",
					ISBN = "123B23",
					Price = 11.99m
				});
		}
	}
}

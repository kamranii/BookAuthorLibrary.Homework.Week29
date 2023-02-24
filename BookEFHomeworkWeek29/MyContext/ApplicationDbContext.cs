using System;
using System.Xml;
using BookEFHomeworkWeek29.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookEFHomeworkWeek29.MyContext
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions dbContextOptions)
			:base(dbContextOptions)
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)// Crée la migration
		{
			//schema
			modelBuilder.HasDefaultSchema("myschema");
            //library
            //modelBuilder.Entity<Library>()
            //    .HasKey(l => new { l.Name, l.Address });
            modelBuilder.Ignore<Library>();
			modelBuilder.Entity<Author>()
				.HasAlternateKey(a => new { a.Name, a.Surname });
			modelBuilder.Entity<Author>()
				.HasKey(a => a.AthrId);
			//author-book relationship
			modelBuilder.Entity<Author>()
				.HasMany(a => a.Books)
				.WithOne(b => b.Author);
		}
	}
}


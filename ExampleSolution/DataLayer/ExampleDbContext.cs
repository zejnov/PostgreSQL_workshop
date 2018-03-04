using ExampleSolution.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace ExampleSolution.DataLayer
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext()
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(m => m.Id);
            modelBuilder.Entity<Book>().HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>().HasKey(m => m.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

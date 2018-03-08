using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostgreSQL_poc
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        //public BloggingContext(DbContextOptions<BloggingContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("ConnectionStrings:DefaultConnection");
            //var connectionString = "User ID=postgres;Password=1234;Host=localhost;Port=7000;Database=Postgres_poc;Pooling=true;";
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.Tags)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Post>()
                .ForNpgsqlHasComment("This is post used on blogs");

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Blog
    {
        public long Id { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }

        public long BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

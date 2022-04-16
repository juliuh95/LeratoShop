using LeratoShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeratoShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
             
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Platform>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<ProductType>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

        }

    }

}

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Platform>().HasIndex(p => p.Name).IsUnique();
        }

    }

}

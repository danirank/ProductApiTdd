using Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.Tests
{
    public class TestContext : DbContext
    {

        public DbSet<Product> Products => Set<Product>();

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.Name);

                entity.Property(p => p.Price)
                .HasPrecision(18, 2);
            });
        }


    }


}

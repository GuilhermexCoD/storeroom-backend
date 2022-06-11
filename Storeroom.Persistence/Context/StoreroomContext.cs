using Microsoft.EntityFrameworkCore;
using Storeroom.Domain.Models;

namespace Storeroom.Persistence.Context
{
    public class StoreroomContext : DbContext
    {
        public StoreroomContext(DbContextOptions<StoreroomContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProp> ProductProps { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Family>()
                .HasMany(f => f.Users)
                .WithOne(u => u.Family)
                .HasForeignKey(u => u.FamilyId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.OwnFamily)
                .WithOne(f => f.Manager);
        }
    }
}